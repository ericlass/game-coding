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

    /// <summary>
    /// Set array pointers for vertices, texture coordinates and vertex colors.
    /// If a non-null value is given for an array, the corresponding client state
    /// array is enabled. If null is given, it is disabled.
    /// </summary>
    /// <param name="vertices">The vertex array.</param>
    /// <param name="texCoords">The texture coordinate array.</param>
    /// <param name="colors">The vertex color array.</param>
    private void SetPointers(Vector2f[] vertices, Vector2f[] texCoords, Color[] colors)
    {
      int vectorSize = System.Runtime.InteropServices.Marshal.SizeOf(Vector2f.Zero);

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
        Gl.glColorPointer(Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, System.Runtime.InteropServices.Marshal.SizeOf(Color.Black), colors);
      }
      else
        Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
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

    public void SetBackgroundColor(Color color)
    {
      Gl.glClearColor(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
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

      SetBackgroundColor(settings.BackgroundColor);

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

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
      int textureId = 0;
      if (_textures.ContainsKey(image.Id))
        textureId = _textures[image.Id];
      else
        return;

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexSubImage2D(Gl.GL_TEXTURE_2D, 0, x, y, width, height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data.PixelData);
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

    public void SetRenderTarget(RenderTarget target)
    {
      if (target == null)
      {
        Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
        Gl.glViewport(0, 0, _display.ClientSize.Width, _display.ClientSize.Height);
      }
      else
      {
        if (!_textures.ContainsKey(target.Id))
          throw new OkuException("Trying to bind an uninitialized render target! ID: " + target.Id);

        Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, _frameBuffer);
        Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, _textures[target.Id], 0);

        Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        Gl.glViewport(0, 0, target.Width, target.Height);
      }

      //TODO: Not sure if this is really needed?
      //Gl.glMatrixMode(Gl.GL_MODELVIEW);
      //Gl.glLoadIdentity();
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

    public void DrawImage(ImageBase image, float x, float y, float rotation, float sx, float sy, Color tint)
    {
      if (!_textures.ContainsKey(image.Id))
        return;

      int textureId = _textures[image.Id];
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

      Gl.glPushMatrix();

      Gl.glTranslatef(x, y, 0.0f);
      Gl.glScalef(sx, sy, 1.0f);
      Gl.glRotatef(rotation, 0.0f, 0.0f, 1.0f);

      float halfWidth = image.Width / 2.0f;
      float halfHeight = image.Height / 2.0f;

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

    public void DrawScreenAlignedQuad(ImageBase image, Color tint)
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPushMatrix();

      Gl.glLoadIdentity();
      Gl.glOrtho(0, 1, 0, 1, -1, 1);

      if (image != null)
      {
        int textureId = _textures[image.Id];
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      }

      Gl.glBegin(Gl.GL_QUADS);

      Gl.glColor4ub(tint.R, tint.G, tint.B, tint.A);

      Gl.glTexCoord2f(0, 1);
      Gl.glVertex2f(0, 1);

      Gl.glTexCoord2f(1, 1);
      Gl.glVertex2f(1, 1);

      Gl.glTexCoord2f(1, 0);
      Gl.glVertex2f(1, 0);

      Gl.glTexCoord2f(0, 0);
      Gl.glVertex2f(0, 0);

      Gl.glEnd();

      if (image != null)
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPopMatrix();
    }

    public void DrawLine(float x1, float y1, float x2, float y2, float width, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        Gl.glBegin(Gl.GL_LINES);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        Gl.glVertex2f(x1, y1);
        Gl.glVertex2f(x2, y2);

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      } 
    }

    public void DrawLines(Vector2f[] vertices, Color[] colors, int count, float width, LineMode interpretation)
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

    public void DrawPoint(float x, float y, float size, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        Gl.glVertex2f(x, y);

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawPoints(Vector2f[] points, Color[] colors, int count, float size)
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

    public void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, ImageBase texture)
    {
      if (texture != null)
      {
        if (!_textures.ContainsKey(texture.Id))
          return;

        int textureId = _textures[texture.Id];
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      }
      else
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

      int primitive = PrimitiveToGLPrimitive(type);

      SetPointers(points, texCoords, colors);
      Gl.glDrawArrays(primitive, 0, count);
    }

    public void SetViewport(float left, float right, float bottom, float top)
    {
      UpdateViewport(left, right, bottom, top);
    }

    public void BeginScreenSpace()
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPushMatrix();

      Gl.glLoadIdentity();
      Gl.glOrtho(0, _settings.Width, 0, _settings.Height, -1, 1);
    }

    public void EndScreenSpace()
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPopMatrix();
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

    public void ApplyAndPushTransform(Vector2f translation, Vector2f scale, float angle)
    {
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glPushMatrix();

      Gl.glTranslatef(translation.X, translation.Y, 0.0f);
      Gl.glScalef(scale.X, scale.Y, 1.0f);
      Gl.glRotatef(angle, 0.0f, 0.0f, 1.0f);
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

    public int GetUniformLocation(ShaderProgram program, string name)
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

    public void UseShaderProgram(ShaderProgram program)
    {
      if (program != null)
      {
        if (!_shaderPrograms.ContainsKey(program.Id))
          throw new OkuException("Trying to use an uninitialized shader program! ID: " + program.Id);

        int programName = _shaderPrograms[program.Id];
        Gl.glUseProgram(programName);
      }
      else
      {
        Gl.glUseProgram(0);
      }
    }

    public void SetShaderFloat(ShaderProgram program, string name, params float[] values)
    {
      if (!_shaderPrograms.ContainsKey(program.Id))
        throw new OkuException("Trying to set a float of an uninitialized shader program! ID: " + program.Id + "; " + name);

      int location = GetUniformLocation(program, name);

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

    public void SetShaderTexture(ShaderProgram program, string name, ImageBase image)
    {
      if (!_shaderPrograms.ContainsKey(program.Id))
        throw new OkuException("Trying to set a texture of an uninitialized shader program! ID: " + program.Id + "; " + name);

      int location = GetUniformLocation(program, name);

      Gl.glActiveTexture(Gl.GL_TEXTURE0 + 1);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, _textures[image.Id]);
      Gl.glUniform1i(location, 1);
      Gl.glActiveTexture(Gl.GL_TEXTURE0);
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

  }
}
