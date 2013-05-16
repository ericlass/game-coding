using System;
using System.Collections.Generic;
using OkuBase.Driver.Graphics;
using System.Windows.Forms;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuBase.Platform;
using Tao.OpenGl;

namespace OkuDrivers
{
  public class OpenGLGraphicsDriver : IGraphicsDriver
  {
    private GraphicsSettings _settings = null;
    private Control _display = null;
    private IntPtr _dc = IntPtr.Zero;
    private IntPtr _rc = IntPtr.Zero;

    private Dictionary<int, int> _textures = new Dictionary<int, int>(); //Maps content id to opengl texture names

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
        Gl.glColorPointer(4, Gl.GL_UNSIGNED_BYTE, System.Runtime.InteropServices.Marshal.SizeOf(Color.Black), colors);
      }
      else
        Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
    }

    public string DriverName
    {
      get { return "opengl"; }
    }

    public Control Display
    {
      get { return _display; }
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

      Gl.glClearColor(settings.BackgroundColor.R / 255.0f, settings.BackgroundColor.G / 255.0f, settings.BackgroundColor.B / 255.0f, settings.BackgroundColor.A / 255.0f);

      Gl.glLineWidth(1.0f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(1);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
      Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
      Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

      Gl.glFrontFace(Gl.GL_CW);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(_settings.Width * -0.5, _settings.Width * 0.5, settings.Height * -0.5, settings.Height * 0.5, -1, 1);
    }

    public void Update(float dt)
    {
      //Nothing to do yet.
    }

    public void Finish()
    {
      Opengl32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
      Opengl32.wglDeleteContext(_rc);
      User32.ReleaseDC(_display.Handle, _dc);
    }

    public void LoadImage(Image image)
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
        //OkuManagers.Instance.Logger.LogError("Image \"" + content.Name + "\" (ID " + content.Id + ") Compressed: " + compSize + "; Uncompressed: " + uncompSize + "; Ratio: " + ratio + "%");
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
      Gl.glTexSubImage2D(Gl.GL_TEXTURE_2D, 0, x, y, width, height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, image.ImageData.PixelData);
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

    public void DrawImage(Image image, float x, float y, float rotation, float sx, float sy, Color tint)
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

    public void DrawScreenAlignedQuad(Image image, Color tint)
    {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPushMatrix();

      Gl.glLoadIdentity();
      Gl.glOrtho(0, 1, 0, 1, -1, 1);

      int textureId = _textures[image.Id];

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

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

    public void DrawLines(OkuBase.Geometry.Vector2f[] vertices, Color[] colors, int count, float width, VertexInterpretation interpretation)
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

    public void DrawPoints(OkuBase.Geometry.Vector2f[] points, Color[] colors, int count, float size)
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

    public void DrawMesh(OkuBase.Geometry.Vector2f[] points, OkuBase.Geometry.Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, Image texture)
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

    public void ApplyAndPushTransform(OkuBase.Geometry.Vector2f translation, OkuBase.Geometry.Vector2f scale, float angle)
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

  }
}
