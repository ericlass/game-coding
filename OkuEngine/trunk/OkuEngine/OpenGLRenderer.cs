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
    private const string ContentTextureName = "gl.texture";
    private const string ContentDispListName = "gl.displaylist";

    private int _screenWidth = 1024;
    private int _screenHeight = 768;
    private bool _fullscreen = false;
    private Color _clearColor = new Color(0, 0, 0.5f);

    private static Form _form = null;
    private static IntPtr _handle = IntPtr.Zero;
    private static IntPtr _dc = IntPtr.Zero;
    private static IntPtr _rc = IntPtr.Zero;

    /// <summary>
    /// Gets or set the prefered screen width in pixels.
    /// </summary>
    public int ScreenWidth
    {
      get { return _screenWidth; }
      set { _screenWidth = value; }
    }

    /// <summary>
    /// Gets or sets the prefered screen height in pixels.
    /// </summary>
    public int ScreenHeight
    {
      get { return _screenHeight; }
      set { _screenHeight = value; }
    }

    /// <summary>
    /// Gets or sets of the application should be run in fullscreen or not.
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
      _form = new Form();
      _form.ClientSize = new System.Drawing.Size(_screenWidth, _screenHeight);
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
      //pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER; //creates lag when moving mouse cursor in window;
      pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_DOUBLEBUFFER;
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

      Gl.glLineWidth(1.5f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(10);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);
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

      _screenWidth = _form.ClientSize.Width;
      _screenHeight = _form.ClientSize.Height;
    }

    public void InitContent(Content content, Stream data)
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

      content.ContentData.Set<int>(ContentTextureName, textureId);

      float halfHeight = tex.Height / 2.0f;
      float halfWidth = tex.Width / 2.0f;

      Vector v1 = new Vector(-halfWidth, -halfHeight);
      Vector v2 = new Vector(halfWidth, -halfHeight);
      Vector v3 = new Vector(halfWidth, halfHeight);
      Vector v4 = new Vector(-halfWidth, halfHeight);

      content.ContentData.Set<Vector>("oku.v1", v1);
      content.ContentData.Set<Vector>("oku.v2", v2);
      content.ContentData.Set<Vector>("oku.v3", v3);
      content.ContentData.Set<Vector>("oku.v4", v4);
    }

    public void ReleaseContent(Content content)
    {
      if (content != null && content.Type == ContentType.Image)
      {
        int texId = content.ContentData.Get<int>(ContentTextureName);
        int dispList = content.ContentData.Get<int>(ContentDispListName);
        content.ContentData.Remove(ContentTextureName);
        content.ContentData.Remove(ContentDispListName);
        Gl.glDeleteTextures(1, ref texId);
        Gl.glDeleteLists(dispList, 1);
      }
    }

    public void Begin()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
    }

    public void Draw(Content content, Vector v1, Vector v2, Vector v3, Vector v4)
    {
      int texture = content.ContentData.Get<int>("gl.texture");
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);

      Gl.glBegin(Gl.GL_QUADS);

      Gl.glTexCoord2f(0, 0);
      Gl.glVertex2f(v1.X, v1.Y);

      Gl.glTexCoord2f(1, 0);
      Gl.glVertex2f(v2.X, v2.Y);

      Gl.glTexCoord2f(1, 1);
      Gl.glVertex2f(v3.X, v3.Y);

      Gl.glTexCoord2f(0, 1);
      Gl.glVertex2f(v4.X, v4.Y);

      Gl.glEnd();
    }

    public void DrawLine(Vector start, Vector end)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      
      Gl.glBegin(Gl.GL_LINES);

      Gl.glColor3f(1, 1, 1);
      Gl.glVertex2f(start.X, start.Y);
      Gl.glVertex2f(end.X, end.Y);

      Gl.glEnd();

      Gl.glEnable(Gl.GL_TEXTURE_2D);
    }

    public void DrawPoint(Vector p)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      Gl.glBegin(Gl.GL_POINTS);

      Gl.glColor3f(1, 1, 1);
      Gl.glVertex2f(p.X, p.Y);

      Gl.glEnd();

      Gl.glEnable(Gl.GL_TEXTURE_2D);
    }

    public void DrawTree(SceneNode startNode)
    {
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();

      DrawTreeRecursive(startNode);
    }

    private void DrawTreeRecursive(SceneNode node)
    {
      Gl.glPushMatrix();

      Gl.glTranslatef(node.Transform.Translation.X, node.Transform.Translation.Y, 0);
      Gl.glScalef(node.Transform.Scale.X, node.Transform.Scale.Y, 1);
      Gl.glRotatef(node.Transform.Rotation, 0, 0, 1);

      if (node.Content != null && node.Content.Type == ContentType.Image)
      {
        //Get texture id and bind it
        int texture = node.Content.ContentData.Get<int>("gl.texture");
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);

        //Draw prepared display list
        int dispList = node.Content.ContentData.Get<int>("gl.displaylist");
        Gl.glCallList(dispList);
      }

      if (node.HasChildren())
      {
        foreach (SceneNode child in node.Children)
          DrawTreeRecursive(child);
      }

      Gl.glPopMatrix();
    }

    public void End()
    {
      Gl.glFlush();
      Gdi.SwapBuffers(_dc);
    }

  }
}
