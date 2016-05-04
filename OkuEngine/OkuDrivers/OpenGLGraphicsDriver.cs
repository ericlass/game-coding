using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OkuBase;
using OkuBase.Driver;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuBase.Platform;
using Tao.OpenGl;
using OkuMath;

namespace OkuDrivers
{
  public class OpenGLGraphicsDriver : IGraphicsDriver
  {
    private static int VectorSize = System.Runtime.InteropServices.Marshal.SizeOf(Vector2f.Zero);
    private static int ColorSize = System.Runtime.InteropServices.Marshal.SizeOf(Color.Black);

    private GraphicsSettings _settings = null;
    private Control _display = null;
    private IntPtr _displayHandle = IntPtr.Zero;
    private IntPtr _dc = IntPtr.Zero;
    private IntPtr _rc = IntPtr.Zero;

    private int _frameBuffer = 0;
    private Dictionary<int, int> _textures = new Dictionary<int, int>(); //Maps content id to opengl texture names

    private Dictionary<int, int> _shaders = new Dictionary<int, int>(); //Maps shader ids to opengl shader names
    private Dictionary<int, int> _shaderPrograms = new Dictionary<int, int>(); //Maps shader program ids to opengl shader program names
    private Dictionary<int, Dictionary<string, int>> _uniformLocations = new Dictionary<int, Dictionary<string, int>>(); //Maps shader program ids to maps that map uniform names to opengl uniform locations
    private Dictionary<int, int> _vertexBuffers = new Dictionary<int, int>(); //Maps buffer ids to opengl buffer names

    private ShaderProgram _activeShader = null;
    private PrimitiveType _primitiveType = PrimitiveType.None;
    private Vector2f[] _vertexPos = null;

    /// <summary>
    /// Handles resizing of the form. The OpenGL viewport is reset to fit the new size of the form.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event arguments.</param>
    private void OnFormResize(object sender, EventArgs e)
    {
      Gl.glViewport(0, 0, _display.ClientSize.Width, _display.ClientSize.Height);
    }

    /// <summary>
    /// Converts the currently set texture filter method
    /// to an int to be used for OpenGL.
    /// </summary>
    /// <returns>The value of the OpenGL texture filter constant.</returns>
    private int GetGLTexFilter()
    {
      switch (_settings.TextureFilter)
      {
        case TextureFilter.NearestNeighbor:
          return Gl.GL_NEAREST;
        case TextureFilter.Linear:
          return Gl.GL_LINEAR;
        default:
          throw new ArgumentException("Texure filter " + _settings.TextureFilter + " not supported in OpenGlRenderer!");
      }
    }

    /// <summary>
    /// Converts a VertexInterpretation to an OpenGL primitive type that can be used during rendering with glBegin().
    /// </summary>
    /// <param name="interpretation">The interpretation to be converted.</param>
    /// <returns>The OpenGL primitive type for the given VertexInterpretation.</returns>
    private int VertexIntToGLPrimitive(LineMode interpretation)
    {
      switch (interpretation)
      {
        case LineMode.Polygon:
          return Gl.GL_LINE_STRIP;
        case LineMode.PolygonClosed:
          return Gl.GL_LINE_LOOP;
        case LineMode.LineSegments:
          return Gl.GL_LINES;
        default:
          throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not supported in OpenGLRenderer!");
      }
    }

    /// <summary>
    /// Converts the given draw mode to an OpenGL primitive.
    /// </summary>
    /// <param name="mode">The draw mode to convert.</param>
    /// <returns>The primitive for the given draw mode or 0 for None or unknown draw mode.</returns>
    private int PrimitiveToGLPrimitive(PrimitiveType mode)
    {
      switch (mode)
      {
        case PrimitiveType.Points:
          return Gl.GL_POINTS;
        case PrimitiveType.Lines:
          return Gl.GL_LINES;
        case PrimitiveType.Polygon:
          return Gl.GL_LINE_STRIP;
        case PrimitiveType.ClosedPolygon:
          return Gl.GL_LINE_LOOP;
        case PrimitiveType.Triangles:
          return Gl.GL_TRIANGLES;
        case PrimitiveType.TriangleStrip:
          return Gl.GL_TRIANGLE_STRIP;
        case PrimitiveType.TriangleFan:
          return Gl.GL_TRIANGLE_FAN;
        case PrimitiveType.Quads:
          return Gl.GL_QUADS;
        case PrimitiveType.QuadStrip:
          return Gl.GL_QUAD_STRIP;
        default:
          return 0;
      }
    }

    private void UpdateViewport(float left, float right, float bottom, float top)
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(left, right, bottom, top, -1, 1);
    }

    public string DriverName
    {
      get { return "opengl"; }
    }

    public Control Display
    {
      get { return _display; }
    }

    public Vector2f[] VertexPositions
    {
      set
      {
        _vertexPos = value;
        if (value != null)
        {
          Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
          Gl.glVertexPointer(2, Gl.GL_FLOAT, VectorSize, value);
        }
        else
          Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
      }
    }

    public Vector2f[] VertexTexCoords
    {
      set
      {
        if (value != null)
        {
          Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
          Gl.glTexCoordPointer(2, Gl.GL_FLOAT, VectorSize, value);
        }
        else
          Gl.glDisableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
      }
    }

    public Vector2f[] VertexColors
    {
      set
      {
        if (value != null)
        {
          Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
          Gl.glColorPointer(Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, ColorSize, value);
        }
        else
          Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
      }
    }

    public PrimitiveType PrimitiveType
    {
      set{ _primitiveType = value; }
    }

    public ImageBase Texture
    {
      set
      {
        if (value != null)
        {
          int textureName = _textures[value.Id];
          Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureName);
        }
        else
          Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
      }
    }

    public Color BackgroundColor
    {
      set { Gl.glClearColor(value.R / 255.0f, value.G / 255.0f, value.B / 255.0f, value.A / 255.0f); }
    }

    public RenderTarget RenderTarget
    {
      set
      {
        if (value == null)
        {
          Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
          Gl.glViewport(0, 0, _display.ClientSize.Width, _display.ClientSize.Height);
        }
        else
        {
          if (!_textures.ContainsKey(value.Id))
            throw new OkuException("Trying to bind an uninitialized render target! ID: " + value.Id);

          Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, _frameBuffer);
          Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, _textures[value.Id], 0);

          Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
          Gl.glViewport(0, 0, value.Width, value.Height);
        }
      }
    }

    public ScissorRect ScissorRectangle
    {
      set
      {
        if (value != null)
        {
          Gl.glEnable(Gl.GL_SCISSOR_TEST);
          Gl.glScissor(value.Left, value.Right, value.Width, value.Height);
        }
        else
          Gl.glDisable(Gl.GL_SCISSOR_TEST);
      }
    }

    public Vector2f Translation
    {
      set
      {
        Gl.glMatrixMode(Gl.GL_MODELVIEW);
        Gl.glTranslatef(value.X, value.Y, 0.0f);
      }
    }

    public Vector2f Scale
    {
      set
      {
        Gl.glMatrixMode(Gl.GL_MODELVIEW);
        Gl.glScalef(value.X, value.Y, 1.0f);
      }
    }

    public float Angle
    {
      set
      {
        Gl.glMatrixMode(Gl.GL_MODELVIEW);
        Gl.glRotatef(value, 0.0f, 0.0f, 1.0f);
      }
    }

    public bool ScreenSpace
    {
      set
      {
        if (value)
        {
          Gl.glMatrixMode(Gl.GL_PROJECTION);
          Gl.glPushMatrix();

          Gl.glLoadIdentity();
          Gl.glOrtho(0, _settings.Width, 0, _settings.Height, -1, 1);
        }
        else
        {
          Gl.glMatrixMode(Gl.GL_PROJECTION);
          Gl.glPopMatrix();
        }
      }
    }

    public ShaderProgram Shader
    {
      set
      {
        _activeShader = value;
        if (value != null)
        {
          if (!_shaderPrograms.ContainsKey(value.Id))
            throw new OkuException("Trying to use an uninitialized shader program! ID: " + value.Id);

          int programName = _shaderPrograms[value.Id];
          Gl.glUseProgram(programName);
        }
        else
        {
          Gl.glUseProgram(0);
        }
      }
    }

    public void Initialize(GraphicsSettings settings)
    {
      _settings = settings;

      //Create and setup form
      Form form = new Form();
      form.ClientSize = new System.Drawing.Size(settings.Width, settings.Height);
      form.FormBorderStyle = FormBorderStyle.FixedSingle;

      if (settings.Fullscreen)
      {
        form.FormBorderStyle = FormBorderStyle.None;
        form.WindowState = FormWindowState.Maximized;
        form.TopMost = true;
      }

      form.Show();
      _display = form;
      _displayHandle = _display.Handle;

      _display.Resize += new EventHandler(OnFormResize);

      //Create and set pixel format descriptor
      _dc = User32.GetDC(_display.Handle);

      Gdi32.PIXELFORMATDESCRIPTOR pfd = new Gdi32.PIXELFORMATDESCRIPTOR();
      pfd.nSize = (ushort)System.Runtime.InteropServices.Marshal.SizeOf(pfd);
      pfd.nVersion = 1;

      //IMPORTANT: SOMEHOW DOUBLE BUFFERING MESSES UP THE DRAWING. IT IS FASTER AND MORE STABLE WITHOUT DOUBLE BUFFERING!!!
      //pfd.dwFlags = Gdi32.PFD_DRAW_TO_WINDOW | Gdi32.PFD_SUPPORT_OPENGL | Gdi32.PFD_DOUBLEBUFFER; //creates lag when moving mouse cursor in window;
      pfd.dwFlags = Gdi32.PFD_DRAW_TO_WINDOW | Gdi32.PFD_SUPPORT_OPENGL;

      pfd.iPixelType = Gdi32.PFD_TYPE_RGBA;
      pfd.cColorBits = 24;
      pfd.cDepthBits = 16;
      pfd.iLayerType = Gdi32.PFD_MAIN_PLANE;
      int format = Gdi32.ChoosePixelFormat(_dc, ref pfd);
      Gdi32.SetPixelFormat(_dc, format, ref pfd);

      //Active rendering context
      _rc = Opengl32.wglCreateContext(_dc);
      Opengl32.wglMakeCurrent(_dc, _rc);

      //Setup OpenGL
      Gl.glEnable(Gl.GL_TEXTURE_2D);

      Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

      Gl.glEnable(Gl.GL_ALPHA_TEST);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.05f);

      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

      if (settings.EnableDepthTest)
      {
        Gl.glEnable(Gl.GL_DEPTH_TEST);
      }

      BackgroundColor = settings.BackgroundColor;

      Gl.glLineWidth(1.0f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(1);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
      Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
      Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

      Gl.glFrontFace(Gl.GL_CW);

      UpdateViewport(settings.Width * -0.5f, settings.Width * 0.5f, settings.Height * -0.5f, settings.Height * 0.5f);

      //Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
    }

    public void Update(float dt)
    {
      //Nothing to do yet.
    }

    public void Finish()
    {
      Opengl32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
      Opengl32.wglDeleteContext(_rc);
      User32.ReleaseDC(_displayHandle, _dc);
    }

    public void InitImage(Image image)
    {
      int textureId = 0;
      int textureFormat = image.IsCompressed ? Gl.GL_COMPRESSED_RGBA : 4;

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, textureFormat, image.Width, image.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, image.ImageData.PixelData);
      if (image.IsCompressed)
      {
        int compSize = 0;
        Gl.glGetTexLevelParameteriv(Gl.GL_TEXTURE_2D, 0, Gl.GL_TEXTURE_COMPRESSED_IMAGE_SIZE, out compSize);
        int uncompSize = image.Width * image.Height * 4;
        float ratio = (compSize / (float)uncompSize) * 100.0f;
      }
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, GetGLTexFilter());
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, GetGLTexFilter());

      if (_textures.ContainsKey(image.Id))
        ReleaseImage(image);

      _textures.Add(image.Id, textureId);
    }

    public void ReleaseImage(Image image)
    {
      if (_textures.ContainsKey(image.Id))
      {
        int texId = _textures[image.Id];
        Gl.glDeleteTextures(1, ref texId);
        _textures.Remove(image.Id);
      }
    }

    public void InitRenderTarget(RenderTarget target)
    {
      //Create color buffer texture
      int textureId = 0;
      Gl.glGenTextures(1, out textureId);
      _textures.Add(target.Id, textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, target.Width, target.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, null);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, GetGLTexFilter());
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, GetGLTexFilter());
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      //Create frame buffer if it was not created yet
      if (_frameBuffer == 0)
      {
        int fbo = 0;
        Gl.glGenFramebuffersEXT(1, out fbo);
        _frameBuffer = fbo;
      }

      //Bind buffer for checking
      Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, _frameBuffer);

      //Bind color buffer to FBO
      Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, textureId, 0);

      //Check if fbo is set up correctly
      int result = Gl.glCheckFramebufferStatusEXT(Gl.GL_FRAMEBUFFER_EXT);

      //Unbind fbo again
      Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);

      if (result != Gl.GL_FRAMEBUFFER_COMPLETE_EXT)
        throw new OkuException("Frame buffer was not setup correctly! ID: " + target.Id);
    }

    public void ReleaseRenderTarget(RenderTarget target)
    {
      if (_textures.ContainsKey(target.Id))
      {
        int texId = _textures[target.Id];
        Gl.glDeleteTextures(1, ref texId);
        _textures.Remove(target.Id);
      }
    }

    public void Begin()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    public void End()
    {
      Gl.glFlush();
      Gdi32.SwapBuffers(_dc);
    }

    public void Clear()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
    }

    public void SetViewport(float left, float right, float bottom, float top)
    {
      UpdateViewport(left, right, bottom, top);
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

    private int GetGlShaderType(ShaderType shaderType)
    {
      switch (shaderType)
      {
        case ShaderType.VertexShader:
          return Gl.GL_VERTEX_SHADER;
        case ShaderType.PixelShader:
          return Gl.GL_FRAGMENT_SHADER;
        default:
          throw new OkuException("ShaderType." + shaderType + " cannot is not supported by OkuDrivers.OpenGLGraphicsDriver!");
      }
    }

    private int CompileShader(Shader shader)
    {
      if (_shaders.ContainsKey(shader.Id))
        return 0;

      if (shader.Source == null)
        throw new OkuException("Trying to compile a shader with no source! ID: " + shader.Id);

      if (shader.ShaderType == ShaderType.None)
        throw new OkuException("Trying to compile a shader with the type ShaderType.None! ID: " + shader.Id);

      string[] lines = shader.Source.Split('\n');
      int shaderName = Gl.glCreateShader(GetGlShaderType(shader.ShaderType));
      Gl.glShaderSource(shaderName, lines.Length, lines, null);
      Gl.glCompileShader(shaderName);

      _shaders.Add(shader.Id, shaderName);
      return shaderName;
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
      }
      return builder.ToString();
    }

    private int GetUniformLocation(ShaderProgram program, string name)
    {
      if (!_shaderPrograms.ContainsKey(program.Id))
        throw new OkuException("Trying to access a variable of an uninitialized shader program! ID: " + program.Id + "; Variable: " + name);

      Dictionary<string, int> shaderUniforms = null;
      if (!_uniformLocations.ContainsKey(program.Id))
      {
        shaderUniforms = new Dictionary<string,int>();
        _uniformLocations.Add(program.Id, shaderUniforms);
      }
      else
        shaderUniforms = _uniformLocations[program.Id];

      if (shaderUniforms.ContainsKey(name))
        return shaderUniforms[name];

      int programName = _shaderPrograms[program.Id];
      int location = Gl.glGetUniformLocation(programName, name);
      shaderUniforms.Add(name, location);
      return location;
    }

    public bool InitShaderProgram(ShaderProgram program)
    {
      //Compile shaders
      int vs = CompileShader(program.VertexShader);
      int ps = CompileShader(program.PixelShader);

      //Create and link program
      int programName = Gl.glCreateProgram();
      Gl.glAttachShader(programName, vs);
      Gl.glAttachShader(programName, ps);

      Gl.glLinkProgram(programName);

      //Check if program could be linked
      int linkStatus = 0;
      Gl.glGetProgramiv(programName, Gl.GL_LINK_STATUS, out linkStatus);

      if (linkStatus == Gl.GL_FALSE)
      {
        string shaderLog = GetShaderInfoLog(programName);
        System.Diagnostics.Debug.WriteLine(shaderLog);
        throw new OkuException("Could not compile shader program! ID: " + program.Id + "\nCompiler output:\n\n" + shaderLog);
      }

      _shaderPrograms.Add(program.Id, programName);
      return true;
    }

    public void ReleaseShaderProgram(ShaderProgram program)
    {
      if (!_shaderPrograms.ContainsKey(program.Id))
        return;

      int vs = _shaders[program.VertexShader.Id];
      int ps = _shaders[program.PixelShader.Id];
      int prog = _shaderPrograms[program.Id];

      Gl.glDeleteShader(vs);
      Gl.glDeleteShader(ps);
      Gl.glDeleteProgram(prog);

      _shaders.Remove(program.VertexShader.Id);
      _shaders.Remove(program.PixelShader.Id);
      _shaderPrograms.Remove(program.Id);
      _uniformLocations.Remove(program.Id);
    }

    public void SetShaderValue(string name, params float[] values)
    {
      if (_activeShader == null)
        throw new OkuException("No shader bound! Bind a shader before trying to set a value!");

      if (!_shaderPrograms.ContainsKey(_activeShader.Id))
        throw new OkuException("Trying to set a float of an uninitialized shader program! ID: " + _activeShader.Id + "; " + name);

      int location = GetUniformLocation(_activeShader, name);

      switch (values.Length)
      {
        case 1:
          Gl.glUniform1f(location, values[0]);
          break;

        case 2:
          Gl.glUniform2f(location, values[0], values[1]);
          break;

        case 3:
          Gl.glUniform3f(location, values[0], values[1], values[2]);
          break;

        case 4:
          Gl.glUniform4f(location, values[0], values[1], values[2], values[3]);
          break;

        default:
          throw new OkuException("Unsupported number of values: " + values.Length + "!");
      }
    }

    public void SetShaderValue(string name, ImageBase image)
    {
      if (_activeShader == null)
        throw new OkuException("No shader bound! Bind a shader before trying to set a value!");

      if (!_shaderPrograms.ContainsKey(_activeShader.Id))
        throw new OkuException("Trying to set a texture of an uninitialized shader program! ID: " + _activeShader.Id + "; " + name);

      int location = GetUniformLocation(_activeShader, name);

      Gl.glActiveTexture(Gl.GL_TEXTURE0 + 1);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, _textures[image.Id]);
      Gl.glUniform1i(location, 1);
      Gl.glActiveTexture(Gl.GL_TEXTURE0);
    }

    public void Draw()
    {
      if (_vertexPos == null)
        throw new OkuException("Vertex positions not set before call to Draw()!");

      int primitive = PrimitiveToGLPrimitive(_primitiveType);
      Gl.glDrawArrays(primitive, 0, _vertexPos.Length);
    }

    public void Draw(int first, int last)
    {
      int primitive = PrimitiveToGLPrimitive(_primitiveType);
      Gl.glDrawArrays(primitive, first, (last - first) + 1);
    }

    public void DrawInstanced(int count)
    {
      if (_vertexPos == null)
        throw new OkuException("Vertex positions not set before call to DrawInstanced(int)!");

      int primitive = PrimitiveToGLPrimitive(_primitiveType);
      Gl.glDrawArraysInstancedEXT(primitive, 0, _vertexPos.Length, count);
    }

    public void DrawInstanced(int count, int first, int last)
    {
      int primitive = PrimitiveToGLPrimitive(_primitiveType);
      Gl.glDrawArraysInstancedEXT(primitive, first, (last - first) + 1, count);
    }

    #region VertexBuffer (unused)
    /*
    public void InitVertexBuffer(VertexBuffer vbuffer)
    {
      if (vbuffer.Vertices == null)
        throw new OkuException("Vertices of vertex buffer to be initialized cannot be null!");

      if (_vertexBuffers.ContainsKey(vbuffer.Id))
        throw new OkuException("Trying to initialize a vertex buffer that has already been initialzed!");

      int buffer = 0;
      Gl.glGenBuffers(1, out buffer);

      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);
      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);

      Vertex test = new Vertex();
      int vertexSize = Marshal.SizeOf(test);

      //Gl.glVertexAttribPointer(0, 2, Gl.GL_FLOAT, Gl.GL_FALSE, vertexSize, IntPtr.Zero);
      //Gl.glVertexAttribPointer(1, 2, Gl.GL_FLOAT, Gl.GL_FALSE,vertexSize, new IntPtr(8));
      //Gl.glVertexAttribPointer(2, 4, Gl.GL_UNSIGNED_BYTE, Gl.GL_FALSE, vertexSize, new IntPtr(16));

      Gl.glBufferData(Gl.GL_ARRAY_BUFFER, new IntPtr(vbuffer.Vertices.Length * vertexSize), vbuffer.Vertices, Gl.GL_STATIC_DRAW);

      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

      _vertexBuffers.Add(vbuffer.Id, buffer);
    }

    public void DrawVertexBuffer(VertexBuffer vbuffer, PrimitiveType ptype, ImageBase texture)
    {
      if (!_vertexBuffers.ContainsKey(vbuffer.Id))
        throw new OkuException("Trying to draw a vertex buffer which has not been initialized or has been released!");

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);

      int buffer = _vertexBuffers[vbuffer.Id];
      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);

      Vertex test = new Vertex();
      Gl.glInterleavedArrays(Gl.GL_T2F_C4UB_V3F, Marshal.SizeOf(test), IntPtr.Zero);

      if (texture != null)
      {
        if (!_textures.ContainsKey(texture.Id))
          return;

        int textureId = _textures[texture.Id];
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      }
      else
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      int primitive = PrimitiveToGLPrimitive(ptype);
      Gl.glDrawArrays(primitive, 0, vbuffer.Vertices.Length);

      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
    }

    public void UpdateVertexBuffer(VertexBuffer vbuffer)
    {
      if (!_vertexBuffers.ContainsKey(vbuffer.Id))
        throw new OkuException("Trying to update a vertex buffer which has not been initialized or has been released!");

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);

      int buffer = _vertexBuffers[vbuffer.Id];
      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);

      Vertex test = new Vertex();
      Gl.glBufferData(Gl.GL_ARRAY_BUFFER, new IntPtr(vbuffer.Vertices.Length * Marshal.SizeOf(test)), vbuffer.Vertices, Gl.GL_STATIC_DRAW);

      Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
    }

    public void ReleaseVertexBuffer(VertexBuffer vbuffer)
    {
      if (!_vertexBuffers.ContainsKey(vbuffer.Id))
        throw new OkuException("Trying to update a vertex buffer which has not been initialized or has been released!");

      int buffer = _vertexBuffers[vbuffer.Id];
      Gl.glDeleteBuffers(1, ref buffer);

      _vertexBuffers.Remove(vbuffer.Id);
    }
    */
    #endregion

  }
}
