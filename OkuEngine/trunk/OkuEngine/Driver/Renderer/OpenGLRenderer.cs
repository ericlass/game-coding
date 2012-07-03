using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace OkuEngine.Driver.Renderer
{
  /// <summary>
  /// Implements an Oku renderer using OpenGL hardware acceleration.
  /// </summary>
  public class OpenGLRenderer : IRenderer
  {
    public const string RendererName = "opengl";

    private bool _fullscreen = false;
    private Color _clearColor = Color.Black;
    private ViewPort _viewPort = null;
    private int _screenWidth = 1024;
    private int _screenHeight = 768;

    private Control _display = null;
    private IntPtr _handle = IntPtr.Zero;
    private IntPtr _dc = IntPtr.Zero;
    private IntPtr _rc = IntPtr.Zero;
    private Dictionary<int, int> _textures = new Dictionary<int, int>(); //Maps content id to opengl texture names
    private TextureFilter _texFilter = TextureFilter.Linear;

    private int _renderPasses = 0; //The number of render passes. 0 means default rendering is done without any frame buffers.
    private int[] _passTargets = null; //The number of render targets for each pass.

    private int _fbo = 0; //The opengl name of the frame buffer object
    private int[,] _colorBuffers = null; //The opengl names for the color buffers for each render pass
    private Dictionary<int, ImageContent> _colorBufferContent = new Dictionary<int, ImageContent>(); //Maps color buffer opengl name to image content
    private int _renderBuffer = 0; //The opengl name of the depth buffer. It is reused for every pass.

    Dictionary<KeyValuePair<int, string>, int> _uniformLocations = null;

    private int _vertexShader = -1;
    private String _defaultVertexShader =
      "varying vec2 Texcoord;\n" +
      "\n" +
      "void main( void )\n" +
      "{\n" +
      "  gl_Position = ftransform();\n" +
      "  Texcoord    = gl_MultiTexCoord0.xy;\n" +
      "  gl_FrontColor = gl_Color;\n" +
      "}";
    private Dictionary<int, int> _shaderPrograms = new Dictionary<int, int>(); //Maps content ids to shader program names

    /// <summary>
    /// Gets or sets if the application should be run in fullscreen or not.
    /// </summary>
    public bool Fullscreen
    {
      get { return _fullscreen; }
      set { _fullscreen = value; }
    }

    /// <summary>
    /// Gets or sets the color that is used to clear the screen each frame before rendering begins.
    /// </summary>
    public Color ClearColor
    {
      get { return _clearColor; }
      set 
      { 
        _clearColor = value;
        Gl.glClearColor(_clearColor.R / 255.0f, _clearColor.G / 255.0f, _clearColor.B / 255.0f, _clearColor.A / 255.0f);
      }
    }

    /// <summary>
    /// Gets the form that is used to draw on.
    /// </summary>
    public Control Display
    {
      get { return _display; }
    }

    /// <summary>
    /// Gets or sets the viewport.
    /// </summary>
    public ViewPort ViewPort
    {
      get { return _viewPort; }
      set 
      {
        _viewPort = value;
        UpdateGLViewPort();
      }
    }

    /// <summary>
    /// Gets or sets the texture filtering method.
    /// </summary>
    public TextureFilter TextureFilter
    {
      get { return _texFilter; }
      set { _texFilter = value; }
    }

    public int RenderPasses
    {
      get { return _renderPasses; }
    }

    /// <summary>
    /// Gets the number of render targets for the given pass.
    /// </summary>
    /// <param name="pass">The index of the render pass.</param>
    /// <returns>The number of render targets the given pass has.</returns>
    public int GetNumPassTargets(int pass)
    {
      return _passTargets[pass];
    }

    /// <summary>
    /// Gets the rendered image of the given pass for the given target.
    /// </summary>
    /// <param name="pass">The index of the render pass.</param>
    /// <param name="target">The index of the render target.</param>
    /// <returns>The rendered image of the given pass for the given target.</returns>
    public ImageContent GetPassResult(int pass, int target)
    {
      int buffer = _colorBuffers[pass, target];
      ImageContent result = null;
      if (buffer > 0)
      {
        if (!_colorBufferContent.ContainsKey(buffer))
        {
          result = new ImageContent();
          result.Width = _screenWidth;
          result.Height = _screenHeight;
          _textures.Add(result.ContentId, buffer);
          _colorBufferContent.Add(buffer, result);
        }
        else
        {
          result = _colorBufferContent[buffer];
        }
      }
      return result;
    }

    /// <summary>
    /// Method for handling changes on the viewport.
    /// </summary>
    /// <param name="sender"></param>
    private void _viewPort_Change(ViewPort sender)
    {
      UpdateGLViewPort();
    }

    /// <summary>
    /// Create an fbo with a corresponding color render buffer.
    /// </summary>
    /// <param name="width">The width of the render buffer.</param>
    /// <param name="height">The height of the render buffer.</param>
    /// <returns>True if the render buffer was created correctly, else False.</returns>
    private bool CreateFrameBuffer(int width, int height)
    {
      for (int i = 0; i < _renderPasses; i++)
      {
        for (int j = 0; j < _passTargets[i]; j++)
        {
          //Create render target texture
          int textureId = 0;
          Gl.glGenTextures(1, out textureId);
          _colorBuffers[i,j] = textureId;
          Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
          Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, width, height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, null);
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, GetGLTexFilter());
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, GetGLTexFilter());
          Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
        }     
      }

      //Create render buffer and it's storage
      int renderBuffer = 0;
      Gl.glGenRenderbuffersEXT(1, out renderBuffer);
      _renderBuffer = renderBuffer;
      Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, _renderBuffer);
      Gl.glRenderbufferStorageEXT(Gl.GL_RENDERBUFFER_EXT, Gl.GL_DEPTH_COMPONENT, width, height);
      Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, 0);

      //Create frame buffer object
      int fbo = 0;
      Gl.glGenFramebuffersEXT(1, out fbo);
      _fbo = fbo;
      Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, _fbo);

      //Bind color buffer to fbo
      for (int i = 0; i < _passTargets[0]; i++)
      {
        Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT + i, Gl.GL_TEXTURE_2D, _colorBuffers[0, i], 0);
      }      

      //Bind color buffer to fbo
      Gl.glFramebufferRenderbufferEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_RENDERBUFFER_EXT, _renderBuffer);

      //Check if fbo is set up correctly
      int result = Gl.glCheckFramebufferStatusEXT(Gl.GL_FRAMEBUFFER_EXT);

      //Unbind fbo again
      Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);

      return result == Gl.GL_FRAMEBUFFER_COMPLETE_EXT;
    }

    /// <summary>
    /// Initializes the renderer. This includes creating the form and intitializing OpenGL.
    /// </summary>
    public void Initialize(XmlNode node)
    {
      //TODO: Check for compatible node

      //Load config from XML
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name)
        {
          case "fullscreen":
            _fullscreen = Converter.StrToBool(child.FirstChild.Value, false);
            break;

          case "width":
            _screenWidth = int.Parse(child.FirstChild.Value);
            break;

          case "height":
            _screenHeight = int.Parse(child.FirstChild.Value);
            break;

          case "clearcolor":
            Color col;
            if (Color.TryParse(child.FirstChild.Value, out col))
              _clearColor = col;
            break;

          case "passes":
            List<int> passTargets = new List<int>();
            XmlNode passNode = child.FirstChild;
            while (passNode != null)
            {
              if (passNode.Name == "pass")
              {
                _renderPasses++;
                passTargets.Add(passNode.Attributes.GetInt("targets", 1));
              }
              passNode = passNode.NextSibling;
            }
            _passTargets = passTargets.ToArray();
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      //Process parameters
      int maxTargets = 0;
      for (int i = 0; i < _renderPasses; i++)
      {
        maxTargets = Math.Max(maxTargets, _passTargets[i]);
      }
      _colorBuffers = new int[_renderPasses, maxTargets];

      //Create view port
      _viewPort = new ViewPort(_screenWidth, _screenHeight);
      _viewPort.Change += new ViewPortChangeEventHandler(_viewPort_Change);

      //Create and setup form
      Form form = new Form();
      form.ClientSize = new System.Drawing.Size(_screenWidth, _screenHeight);
      form.FormBorderStyle = FormBorderStyle.FixedSingle;        

      if (_fullscreen)
      {
        form.FormBorderStyle = FormBorderStyle.None;
        form.WindowState = FormWindowState.Maximized;
        form.TopMost = true;
      }

      form.Show();
      _display = form;

      _display.Resize += new EventHandler(_form_Resize);
      _handle = _display.Handle;

      //Create and set pixel format descriptor
      _dc = User.GetDC(_handle);

      Gdi.PIXELFORMATDESCRIPTOR pfd = new Gdi.PIXELFORMATDESCRIPTOR();
      pfd.nSize = (short)System.Runtime.InteropServices.Marshal.SizeOf(pfd);
      pfd.nVersion = 1;

      //IMPORTANT: SOMEHOW DOUBLE BUFFERING MESSES UP THE DRAWING. IT IS FASTER AND MORE STABLE WITHOUT DOUBLE BUFFERING!!!
      //pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER; //creates lag when moving mouse cursor in window;
      pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL;

      pfd.iPixelType = Gdi.PFD_TYPE_RGBA;
      pfd.cColorBits = 24;
      pfd.cDepthBits = 16;
      pfd.iLayerType = Gdi.PFD_MAIN_PLANE;
      int format = Gdi.ChoosePixelFormat(_dc, ref pfd);
      Gdi.SetPixelFormat(_dc, format, ref pfd);

      //Active rendering context
      _rc = Wgl.wglCreateContext(_dc);
      Wgl.wglMakeCurrent(_dc, _rc);

      //Setup OpenGL
      Gl.glEnable(Gl.GL_TEXTURE_2D);

      Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

      UpdateGLViewPort();

      Gl.glEnable(Gl.GL_ALPHA_TEST);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.05f);

      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

      Gl.glClearColor(_clearColor.R / 255.0f, _clearColor.G / 255.0f, _clearColor.B / 255.0f, _clearColor.A / 255.0f);

      Gl.glLineWidth(1.0f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(1);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
      Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
      Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

      Gl.glFrontFace(Gl.GL_CW);

      if (_renderPasses > 0)
        CreateFrameBuffer(_screenWidth, _screenHeight);
    }

    /// <summary>
    /// In the OpenGL renderer this method does nothing.
    /// </summary>
    /// <param name="dt"></param>
    public void Update(float dt)
    {
      //Nothing to do here by now
    }

    /// <summary>
    /// Frees all resources that are created by the renderer. This includes all textures.
    /// </summary>
    public void Finish()
    {
      Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
      Wgl.wglDeleteContext(_rc);
      User.ReleaseDC(_handle, _dc);
    }

    /// <summary>
    /// Converts the currently set texture filter method
    /// to an int to be used for OpenGL.
    /// </summary>
    /// <returns>The value of the OpenGL texture filter constant.</returns>
    private int GetGLTexFilter()
    {
      switch (_texFilter)
      {
        case TextureFilter.NearestNeighbor:
          return Gl.GL_NEAREST;
        case TextureFilter.Linear:
          return Gl.GL_LINEAR;
        default:
          throw new ArgumentException("Texure filter " + _texFilter + " not supported in OpenGlRenderer!");
      }
    }

    /// <summary>
    /// Handles resizing of the form. The OpenGL viewport is reset to fit the new size of the form.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event arguments.</param>
    private void _form_Resize(object sender, EventArgs e)
    {
      Gl.glViewport(0, 0, _display.ClientSize.Width, _display.ClientSize.Height);

      UpdateGLViewPort();

      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    private void UpdateGLViewPort()
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(_viewPort.Left, _viewPort.Right, _viewPort.Bottom, _viewPort.Top, -1, 1);
    }

    public void InitImageContent(ImageContent content, Bitmap image)
    {
      int textureId = 0;

      Bitmap flippedImg = new Bitmap(image);

      flippedImg.RotateFlip(RotateFlipType.RotateNoneFlipY); //Important!!! OpenGl assumes the data pointer to point to the lower left corner of the image. So flip the image horizontaly to avoid problems.
      BitmapData bmData = flippedImg.LockBits(new Rectangle(0, 0, flippedImg.Width, flippedImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, image.Width, image.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bmData.Scan0);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, GetGLTexFilter());
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, GetGLTexFilter());

      flippedImg.UnlockBits(bmData);

      if (_textures.ContainsKey(content.ContentId))
        ReleaseContent(content);

      _textures.Add(content.ContentId, textureId);

      flippedImg.Dispose();
    }

    public void UpdateContent(ImageContent content, int x, int y, int width, int height, Bitmap image)
    {
      int textureId = 0;
      if (_textures.ContainsKey(content.ContentId))
        textureId = _textures[content.ContentId];
      else
        return;

      Bitmap flippedImg = new Bitmap(image);
      flippedImg.RotateFlip(RotateFlipType.RotateNoneFlipY); //Important!!! OpenGl assumes the data pointer to point to the lower left corner of the image. So flip the image horizontaly to avoid problems.

      BitmapData bmData = flippedImg.LockBits(new Rectangle(0, 0, flippedImg.Width, flippedImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexSubImage2D(Gl.GL_TEXTURE_2D, 0, x, y, width, height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bmData.Scan0);

      flippedImg.UnlockBits(bmData);
    }

    /// <summary>
    /// Releases content that was previously initialized by the renderer. 
    /// This frees all resource that are conected to the given content.
    /// </summary>
    /// <param name="content">The content to release.</param>
    public void ReleaseContent(ImageContent content)
    {
      if (_textures.ContainsKey(content.ContentId))
      {
        int texId = _textures[content.ContentId];
        Gl.glDeleteTextures(1, ref texId);
        _textures.Remove(content.ContentId);
      }
    }

    private int GetVertexShader()
    {
      if (_vertexShader <= 0)
      {
        _vertexShader = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
        string[] lines = _defaultVertexShader.Split('\n');
        Gl.glShaderSource(_vertexShader, lines.Length, lines, null);
        Gl.glCompileShader(_vertexShader);
      }
      return _vertexShader;
    }

    private String GetShaderInfoLog(int shader)
    {
      int length = 0;
      StringBuilder builder = new StringBuilder();

      int[] lengths = new int[1];
      Gl.glGetObjectParameterivARB(shader, Gl.GL_INFO_LOG_LENGTH, lengths);
      length = lengths[0];

      if (length > 1)
      {
        builder.Capacity = length;
        Gl.glGetInfoLogARB(shader, length, lengths, builder);
        //throw new ArgumentException(builder.ToString());
      }
      return builder.ToString();
    }

    /// <summary>
    /// Intializes the given pixel shader by compiling and linking it.
    /// The source must already be attached to the given content.
    /// </summary>
    /// <param name="content">The pixel shader content to be initialized.</param>
    public void InitShaderContent(PixelShaderContent content)
    {
      if (!_shaderPrograms.ContainsKey(content.ContentId))
      {
        if (content.Source != null)
        {
          string[] lines = content.Source.Split('\n');
          int pixelShader = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
          Gl.glShaderSource(pixelShader, lines.Length, lines, null);
          Gl.glCompileShader(pixelShader);

          int program = Gl.glCreateProgram();
          Gl.glAttachShader(program, GetVertexShader());
          Gl.glAttachShader(program, pixelShader);

          Gl.glLinkProgram(program);

          System.Diagnostics.Debug.WriteLine(GetShaderInfoLog(program));

          _shaderPrograms.Add(content.ContentId, program);
        }
        else
        {
          //TODO: throw exception
        }
      }
    }

    /// <summary>
    /// Enables the given pixel shader. If null is passed shaders are disabled.
    /// </summary>
    /// <param name="content">The shader content to use.</param>
    public void UseShader(PixelShaderContent content)
    {
      if (content != null)
      {
        if (_shaderPrograms.ContainsKey(content.ContentId))
        {
          int program = _shaderPrograms[content.ContentId];
          Gl.glUseProgram(program);
        }
        else
        {
          //TODO: throw exception
        }
      }
      else
      {
        Gl.glUseProgram(0);
      }
    }

    private int GetUniformLocation(PixelShaderContent shader, string name)
    {
      if (_uniformLocations == null)
        _uniformLocations = new Dictionary<KeyValuePair<int, string>, int>();

      if (_shaderPrograms.ContainsKey(shader.ContentId))
      {
        int program = _shaderPrograms[shader.ContentId];
        KeyValuePair<int, string> key = new KeyValuePair<int,string>(program, name);
        if (_uniformLocations.ContainsKey(key))
        {
          return _uniformLocations[key];
        }
        else
        {
          int location = Gl.glGetUniformLocation(program, name);
          _uniformLocations.Add(key, location);
          return location;
        }
      }
      return 0;
    }

    /// <summary>
    /// Sets the given texture to the variable of the given shader.
    /// </summary>
    /// <param name="shader">The shader.</param>
    /// <param name="name">The name of the variable.</param>
    /// <param name="texture">The texture to set.</param>
    public void SetShaderTexture(PixelShaderContent shader, string name, ImageContent texture)
    {
      if (_shaderPrograms.ContainsKey(shader.ContentId))
      {
        //int program = _shaderPrograms[shader.ContentId];
        //int location = Gl.glGetUniformLocation(program, name);
        int location = GetUniformLocation(shader, name);

        Gl.glActiveTexture(Gl.GL_TEXTURE0 + 1);
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, _textures[texture.ContentId]);
        Gl.glUniform1i(location, 1);
        Gl.glActiveTexture(Gl.GL_TEXTURE0);
      }
      else
      {
        //TODO: throw exception
      }
    }

    public void SetShaderFloat(PixelShaderContent shader, string name, float[] values)
    {
      if (_shaderPrograms.ContainsKey(shader.ContentId))
      {
        //int program = _shaderPrograms[shader.ContentId];
        //int location = Gl.glGetUniformLocation(program, name);
        int location = GetUniformLocation(shader, name);

        switch (values.Length)
        {
          case 1:
            Gl.glUniform1f(location, values[0]);
            break;

          case 2:
            Gl.glUniform2f(location, values[0], values[1]);
            int test = Gl.glGetError();
            break;

          case 3:
            Gl.glUniform3f(location, values[0], values[1], values[2]);
            break;

          case 4:
            Gl.glUniform4f(location, values[0], values[1], values[2], values[3]);
            break;

          default:
            break;
        }
      }
      else
      {
        //TODO: throw exception
      }
    }

    /// <summary>
    /// Converts a VertexInterpretation to an OpenGL primitive type that can be used during rendering with glBegin().
    /// </summary>
    /// <param name="interpretation">The interpretation to be converted.</param>
    /// <returns>The OpenGL primitive type for the given VertexInterpretation.</returns>
    private int VertexIntToGLPrimitive(VertexInterpretation interpretation)
    {
      switch (interpretation)
      {
        case VertexInterpretation.Polygon:
          return Gl.GL_LINE_STRIP;
        case VertexInterpretation.PolygonClosed:
          return Gl.GL_LINE_LOOP;
        case VertexInterpretation.LineSegments:
          return Gl.GL_LINES;
        default:
          throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not supported in OpenGLRenderer!");
      }
    }

    /// <summary>
    /// Converts a Mesh Mode to a OpenGL primitive type that can be used with glBegin().
    /// </summary>
    /// <param name="mode">The mode to be converted.</param>
    /// <returns>The OpenGL primitive type for the given mesh mode. Note that MeshMode.Indexed always returns 0 as there is no primitive type for it.</returns>
    private int MeshModeToGLPrimitive(MeshMode mode)
    {
      switch (mode)
      {
        case MeshMode.Triangles:
          return Gl.GL_TRIANGLES;
        case MeshMode.TriangleStrip:
          return Gl.GL_TRIANGLE_STRIP;
        case MeshMode.TriangleFan:
          return Gl.GL_TRIANGLE_FAN;
        case MeshMode.Quads:
          return Gl.GL_QUADS;
        case MeshMode.QuadStrip:
          return Gl.GL_QUAD_STRIP;
        case MeshMode.Indexed:
          return 0;
        default:
          throw new ArgumentOutOfRangeException("Mesh Mode " + mode.ToString() + " is not supported in OpenGLRenderer!");
      }
    }

    /// <summary>
    /// Starts the rendering process. Clears the screen with the setup clear color.
    /// </summary>
    public void Begin(int pass)
    {
      if (_renderPasses > 0)
      {
        Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, _fbo);
        //Bind color buffers to fbo
        for (int i = 0; i < _passTargets[0]; i++)
        {
          Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT + i, Gl.GL_TEXTURE_2D, _colorBuffers[pass, i], 0);
        }
      }

      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    /// <summary>
    /// Draws the given image content at the given position.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    public void DrawImage(ImageContent content, Vector position)
    {
      DrawImage(content, position, 0.0f, Vector.One, Color.White);
    }

    /// <summary>
    /// Draws the given image content at the given position, rotating it by the given angle.
    /// The image rotated around it's center.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    public void DrawImage(ImageContent content, Vector position, float rotation)
    {
      DrawImage(content, position, rotation, Vector.One, Color.White);
    }

    /// <summary>
    /// Draws the given image content at the given position, scaling it by the given factors.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="scale">The scale factors.</param>
    public void DrawImage(ImageContent content, Vector position, Vector scale)
    {
      DrawImage(content, position, 0.0f, scale, Color.White);
    }

    /// <summary>
    /// Draws the given image content at the given position, rotating and scaling it 
    /// by the given values.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="scale">The scale factors.</param>
    public void DrawImage(ImageContent content, Vector position, float rotation, Vector scale)
    {
      DrawImage(content, position, rotation, scale, Color.White);
    }

    /// <summary>
    /// Draws the given image content at the given position. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageContent content, Vector position, Color tint)
    {
      DrawImage(content, position, 0.0f, Vector.One, tint);
    }

    /// <summary>
    /// Draws the given image content at the given position, rotating it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageContent content, Vector position, float rotation, Color tint)
    {
      DrawImage(content, position, rotation, Vector.One, tint);
    }

    /// <summary>
    /// Draws the given image content at the given position, scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageContent content, Vector position, Vector scale, Color tint)
    {
      DrawImage(content, position, 0.0f, scale, tint);
    }

    /// <summary>
    /// Draws the given image content at the given position, rotating and scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageContent content, Vector position, float rotation, Vector scale, Color tint)
    {
      if (!_textures.ContainsKey(content.ContentId))
        return;

      int textureId = _textures[content.ContentId];
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

      Gl.glPushMatrix();

      Gl.glTranslatef(position.X, position.Y, 0.0f);
      Gl.glScalef(scale.X, scale.Y, 1.0f);
      Gl.glRotatef(rotation, 0.0f, 0.0f, 1.0f);

      float halfWidth = content.Width / 2.0f;
      float halfHeight = content.Height / 2.0f;

      Gl.glBegin(Gl.GL_QUADS);

      Gl.glColor4ub(tint.R, tint.G, tint.B, tint.A);

      Gl.glTexCoord2f(0, 1);
      Gl.glVertex2f(-halfWidth, halfHeight);

      Gl.glTexCoord2f(1, 1);
      Gl.glVertex2f(halfWidth, halfHeight);

      Gl.glTexCoord2f(1, 0);
      Gl.glVertex2f(halfWidth, -halfHeight);

      Gl.glTexCoord2f(0, 0);
      Gl.glVertex2f(-halfWidth, -halfHeight);

      Gl.glEnd();

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      Gl.glPopMatrix();
    }

    /// <summary>
    /// Draws the given image content on a screen aligned quad so it fills the whole screen.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    public void DrawScreenAlignedQuad(ImageContent content)
    {
      DrawScreenAlignedQuad(content, Color.White);
    }

    /// <summary>
    /// Draws the given image content on a screen aligned quad so it fills the whole 
    /// screen using the given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="tint">The color tint the image with.</param>
    public void DrawScreenAlignedQuad(ImageContent content, Color tint)
    {
      int textureId = _textures[content.ContentId];

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

      Gl.glBegin(Gl.GL_QUADS);

      Gl.glColor4ub(tint.R, tint.G, tint.B, tint.A);

      Gl.glTexCoord2f(0, 1);
      Gl.glVertex2f(_viewPort.Left, _viewPort.Top);

      Gl.glTexCoord2f(1, 1);
      Gl.glVertex2f(_viewPort.Right, _viewPort.Top);

      Gl.glTexCoord2f(1, 0);
      Gl.glVertex2f(_viewPort.Right, _viewPort.Bottom);

      Gl.glTexCoord2f(0, 0);
      Gl.glVertex2f(_viewPort.Left, _viewPort.Bottom);

      Gl.glEnd();

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
    }

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    public void DrawLine(Vector start, Vector end, float width, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        Gl.glBegin(Gl.GL_LINES);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        Gl.glVertex2f(start.X, start.Y);
        Gl.glVertex2f(end.X, end.Y);

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      } 
    }

    public void DrawLines(Vector[] vertices, Color color, int count, float width, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        //Convert the interpretation to an OpenGL primitive type.
        int primitive = VertexIntToGLPrimitive(interpretation);

        //Draw the lines
        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        SetPointers(vertices, null, null);
        Gl.glDrawArrays(primitive, 0, count);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }   
    }

    public void DrawLines(Vector[] vertices, Color[] colors, int count, float width, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        //Convert the interpretation to an OpenGL primitive type.
        int primitive = VertexIntToGLPrimitive(interpretation);

        SetPointers(vertices, null, colors);
        Gl.glDrawArrays(primitive, 0, count);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    public void DrawPoint(Vector p, float size, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        Gl.glVertex2f(p.X, p.Y);

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawPoints(Vector[] points, Color color, int count, float size)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        SetPointers(points, null, null);
        Gl.glDrawArrays(Gl.GL_POINTS, 0, count);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawPoints(Vector[] points, Color[] colors, int count, float size)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        SetPointers(points, null, colors);
        Gl.glDrawArrays(Gl.GL_POINTS, 0, count);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawMesh(Vector[] points, Vector[] texCoords, Color[] colors, int count, MeshMode mode, ImageContent texture)
    {
      if (texture != null)
      {
        if (!_textures.ContainsKey(texture.ContentId))
          return;

        int textureId = _textures[texture.ContentId];
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      }
      else
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      int primitive = MeshModeToGLPrimitive(mode);

      SetPointers(points, texCoords, colors);
      Gl.glDrawArrays(primitive, 0, count);
    }

    /// <summary>
    /// Set array pointers for vertices, texture coordinates and vertex colors.
    /// If a non-null value is given for an array, the corresponding client state
    /// array is enabled. If null is given, it is disabled.
    /// </summary>
    /// <param name="vertices">The vertex array.</param>
    /// <param name="texCoords">The texture coordinate array.</param>
    /// <param name="colors">The vertex color array.</param>
    private void SetPointers(Vector[] vertices, Vector[] texCoords, Color[] colors)
    {
      int vectorSize = System.Runtime.InteropServices.Marshal.SizeOf(Vector.Zero);

      if (vertices != null)
      {
        Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
        Gl.glVertexPointer(2, Gl.GL_FLOAT, vectorSize, vertices);
      }
      else
        Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);

      if (texCoords != null)
      {
        Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
        Gl.glTexCoordPointer(2, Gl.GL_FLOAT, vectorSize, texCoords);
      }
      else
        Gl.glDisableClientState(Gl.GL_TEXTURE_COORD_ARRAY);

      if (colors != null)
      {
        Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
        Gl.glColorPointer(4, Gl.GL_UNSIGNED_BYTE, System.Runtime.InteropServices.Marshal.SizeOf(Color.Black), colors);
      }
      else
        Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
    }

    /// <summary>
    /// Finished the drawing process. The drawing operations are flushed and the 
    /// offscreen buffer is swapped to the screen.
    /// </summary>
    public void End(int pass)
    {
      //Check if this is the last pass
      if (_renderPasses > 0)
      {
        if (pass == (_renderPasses - 1))
        {
          //Unbind frame buffer as it is not needed anymore
          Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);

          ImageContent content = GetPassResult(pass, 0);

          DrawScreenAlignedQuad(content);

          Gl.glFlush();
          Gdi.SwapBuffers(_dc);
        }
      }
      else
      {
        Gl.glFlush();
        Gdi.SwapBuffers(_dc);
      }
    }
    
    public Vector ScreenToDisplay(int x, int y)
    {
      Point client = Display.PointToClient(new Point(x, y));
      return new Vector(client.X, Display.ClientSize.Height - client.Y);
    }

    public Vector ScreenToWorld(int x, int y)
    {
      return _viewPort.ScreenSpaceMatrix.Transform(ScreenToDisplay(x, y));
    }

    public void BeginScreenSpace()
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(0, _screenWidth, 0, _screenHeight, -1, 1);
    }

    public void EndScreenSpace()
    {
      UpdateGLViewPort();
    }

    public void SetScissorRectangle(int left, int right, int width, int height)
    {
      Gl.glEnable(Gl.GL_SCISSOR_TEST);
      Gl.glScissor(left, right, width, height);
    }

    public void ClearScissorRectangle()
    {
      Gl.glDisable(Gl.GL_SCISSOR_TEST);
    }

    public void ApplyTransform(Vector translate, Vector scale, float rotate)
    {
      Gl.glMatrixMode(Gl.GL_MODELVIEW);

      Gl.glTranslatef(translate.X, translate.Y, 0.0f);
      Gl.glScalef(scale.X, scale.Y, 1.0f);
      Gl.glRotatef(rotate, 0.0f, 0.0f, 1.0f);
    }

    public void PushTransform()
    {
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glPushMatrix();
    }

    public void PopTransform()
    {
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glPopMatrix();
    }

  }
}
