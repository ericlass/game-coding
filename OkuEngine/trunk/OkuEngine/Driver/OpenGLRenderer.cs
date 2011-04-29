using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace OkuEngine
{
  /// <summary>
  /// Implements an Oku renderer using OpenGL hardware acceleration.
  /// </summary>
  public class OpenGLRenderer : IRenderer
  {
    private bool _fullscreen = false;
    private Color _clearColor = new Color(0, 0, 0.5f);

    private Form _form = null;
    private IntPtr _handle = IntPtr.Zero;
    private IntPtr _dc = IntPtr.Zero;
    private IntPtr _rc = IntPtr.Zero;
    private Dictionary<int, int> _textures = new Dictionary<int, int>();

    /// <summary>
    /// Gets or sets if the application should be run in fullscreen or not.
    /// </summary>
    public bool Fullscreen
    {
      get { return _fullscreen; }
      set { _fullscreen = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public Color ClearColor
    {
      get { return _clearColor; }
      set { _clearColor = value; }
    }

    public Form MainForm
    {
      get { return _form; }
    }

    public void Initialize()
    {
      int screenWidth = OkuData.Globals.GetDef<int>(OkuConstants.VarScreenWidth, 800);
      int screenHeight = OkuData.Globals.GetDef<int>(OkuConstants.VarScreenHeight, 600);

      _form = new Form();
      _form.ClientSize = new System.Drawing.Size(screenWidth, screenHeight);
      _form.Resize += new EventHandler(_form_Resize);

      if (_fullscreen)
      {
        _form.FormBorderStyle = FormBorderStyle.None;
        _form.WindowState = FormWindowState.Maximized;
        _form.TopMost = true;
      }

      _form.Show();
      _handle = _form.Handle;

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

      _rc = Wgl.wglCreateContext(_dc);
      Wgl.wglMakeCurrent(_dc, _rc);

      Gl.glEnable(Gl.GL_TEXTURE_2D);

      Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(0, _form.ClientSize.Width - 1, _form.ClientSize.Height - 1, 0, -1, 1);

      Gl.glEnable(Gl.GL_ALPHA_TEST);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.05f);

      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);      

      Gl.glClearColor(_clearColor.R, _clearColor.G, _clearColor.B, 1);

      Gl.glLineWidth(1.0f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(1);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);
    }

    public void Update(float dt)
    {
      //Nothing to do here by now
    }

    public void Finish()
    {
      Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
      Wgl.wglDeleteContext(_rc);
      User.ReleaseDC(_handle, _dc);
    }

    private void _form_Resize(object sender, EventArgs e)
    {
      Gl.glViewport(0, 0, _form.ClientSize.Width, _form.ClientSize.Height);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(0, _form.ClientSize.Width - 1, _form.ClientSize.Height - 1, 0, -1, 1);

      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    public void InitContentFile(ImageContent content, Stream data)
    {
      //Load texture and set it's options
      int textureId = 0;

      Bitmap tex = new Bitmap(data);
      BitmapData bmData = tex.LockBits(new Rectangle(0, 0, tex.Width, tex.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, tex.Width, tex.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bmData.Scan0);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

      tex.UnlockBits(bmData);

      _textures.Add(content.ContentId, textureId);

      content.Width = tex.Width;
      content.Height = tex.Height;
    }

    public void InitContentRaw(ImageContent content, byte[] data, int width, int height)
    {
      //Load texture and set it's options
      int textureId = 0;

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, width, height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

      _textures.Add(content.ContentId, textureId);

      content.Width = width;
      content.Height = height;
    }

    public void ReleaseContent(ImageContent content)
    {
      if (_textures.ContainsKey(content.ContentId))
      {
        int texId = _textures[content.ContentId];
        Gl.glDeleteTextures(1, ref texId);
        _textures.Remove(content.ContentId);
      }
    }

    public void Begin()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
    }

    public void DrawImage(ImageContent content, Vector position)
    {
      DrawImage(content, position, 0.0f, Vector.One, Color.White);
    }

    public void DrawImage(ImageContent content, Vector position, float rotation)
    {
      DrawImage(content, position, rotation, Vector.One, Color.White);
    }

    public void DrawImage(ImageContent content, Vector position, Vector scale)
    {
      DrawImage(content, position, 0.0f, scale, Color.White);
    }

    public void DrawImage(ImageContent content, Vector position, float rotation, Vector scale)
    {
      DrawImage(content, position, rotation, scale, Color.White);
    }

    public void DrawImage(ImageContent content, Vector position, Color tint)
    {
      DrawImage(content, position, 0.0f, Vector.One, tint);
    }

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

      Gl.glColor4f(tint.R, tint.G, tint.B, tint.A);

      Gl.glTexCoord2f(0, 0);
      Gl.glVertex2f(-halfWidth, -halfHeight);

      Gl.glTexCoord2f(1, 0);
      Gl.glVertex2f(halfWidth, -halfHeight);

      Gl.glTexCoord2f(1, 1);
      Gl.glVertex2f(halfWidth, halfHeight);

      Gl.glTexCoord2f(0, 1);
      Gl.glVertex2f(-halfWidth, halfHeight);

      Gl.glEnd();

      Gl.glPopMatrix();
    }

    public void DrawImage(ImageContent content, Matrix3 transform)
    {
      DrawImage(content, transform, Color.White);
    }

    public void DrawImage(ImageContent content, Matrix3 transform, Color tint)
    {
      if (!_textures.ContainsKey(content.ContentId))
        return;

      int textureId = _textures[content.ContentId];
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

      float halfWidth = content.Width / 2.0f;
      float halfHeight = content.Height / 2.0f;

      Gl.glBegin(Gl.GL_QUADS);

      Gl.glColor4f(tint.R, tint.G, tint.B, tint.A);

      Gl.glTexCoord2f(0, 0);

      float x = -halfWidth;
      float y = -halfHeight;
      transform.Transform(ref x, ref y);
      Gl.glVertex2f(x, y);

      Gl.glTexCoord2f(1, 0);

      x = halfWidth;
      y = -halfHeight;
      transform.Transform(ref x, ref y);
      Gl.glVertex2f(x, y);

      Gl.glTexCoord2f(1, 1);

      x = halfWidth;
      y = halfHeight;
      transform.Transform(ref x, ref y);
      Gl.glVertex2f(x, y);

      Gl.glTexCoord2f(0, 1);

      x = -halfWidth;
      y = halfHeight;
      transform.Transform(ref x, ref y);
      Gl.glVertex2f(x, y);

      Gl.glEnd();
    }

    public void DrawLine(Vector start, Vector end, float width, Color color)
    {
      DrawLines(new VectorList() { start, end }, width, color, VertexInterpretation.LineSegments);
    }

    public void DrawLines(VectorList vertices, float width, Color color, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        switch (interpretation)
        {
          case VertexInterpretation.Polygon:
            Gl.glBegin(Gl.GL_LINE_STRIP);
            break;
          case VertexInterpretation.PolygonClosed:
            Gl.glBegin(Gl.GL_LINE_LOOP);
            break;
          case VertexInterpretation.LineSegments:
            Gl.glBegin(Gl.GL_LINES);
            break;
          default:
            throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not implemented in DrawLines(...)!");
        }

        Gl.glColor4f(color.R, color.G, color.B, color.A);
        foreach (Vector vec in vertices)
        {
          Gl.glVertex2f(vec.X, vec.Y);
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }   
    }

    public void DrawLine(Vector start, Vector end, Matrix3 transform, float width, Color color)
    {
      DrawLines(new VectorList() { start, end }, transform, width, color, VertexInterpretation.LineSegments);
    }

    public void DrawLines(VectorList vertices, Matrix3 transform, float width, Color color, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        switch (interpretation)
        {
          case VertexInterpretation.Polygon:
            Gl.glBegin(Gl.GL_LINE_STRIP);
            break;
          case VertexInterpretation.PolygonClosed:
            Gl.glBegin(Gl.GL_LINE_LOOP);
            break;
          case VertexInterpretation.LineSegments:
            Gl.glBegin(Gl.GL_LINES);
            break;
          default:
            throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not implemented in DrawLines(...)!");
        }

        Gl.glColor4f(color.R, color.G, color.B, color.A);
        foreach (Vector vec in vertices)
        {
          float x = vec.X;
          float y = vec.Y;
          transform.Transform(ref x, ref y);
          Gl.glVertex2f(x, y);
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }  
    }

    public void DrawPoint(Vector p, float size, Color color)
    {
      DrawPoints(new VectorList() { p }, size, color);
    }

    public void DrawPoints(VectorList points, float size, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        Gl.glColor4f(color.R, color.G, color.B, color.A);
        foreach (Vector vec in points)
        {
          Gl.glVertex2f(vec.X, vec.Y);
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      } 
    }

    public void DrawPoint(Vector p, Matrix3 transform, float size, Color color)
    {
      DrawPoints(new VectorList() { p }, transform, size, color);    
    }

    public void DrawPoints(VectorList points, Matrix3 transform, float size, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        Gl.glColor4f(color.R, color.G, color.B, color.A);
        foreach (Vector vec in points)
        {
          float x = vec.X;
          float y = vec.Y;
          transform.Transform(ref x, ref y);
          Gl.glVertex2f(x, y);
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      } 
    }

    public void End()
    {
      Gl.glFlush();
      Gdi.SwapBuffers(_dc);
    }

  }
}
