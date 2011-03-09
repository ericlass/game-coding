﻿using System;
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

      _textures.Add(content.ContentKey, textureId);

      content.Width = tex.Width;
      content.Height = tex.Height;

      float halfHeight = tex.Height / 2.0f;
      float halfWidth = tex.Width / 2.0f;

      content.Vertices.Add(new Vector(-halfWidth, -halfHeight));
      content.Vertices.Add(new Vector(halfWidth, -halfHeight));
      content.Vertices.Add(new Vector(halfWidth, halfHeight));
      content.Vertices.Add(new Vector(-halfWidth, halfHeight));
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

      _textures.Add(content.ContentKey, textureId);

      content.Width = width;
      content.Height = height;

      float halfHeight = height / 2.0f;
      float halfWidth = width / 2.0f;

      content.Vertices.Add(new Vector(-halfWidth, -halfHeight));
      content.Vertices.Add(new Vector(halfWidth, -halfHeight));
      content.Vertices.Add(new Vector(halfWidth, halfHeight));
      content.Vertices.Add(new Vector(-halfWidth, halfHeight));
    }

    public void ReleaseContent(ImageContent content)
    {
      if (content != null && content.Type == ContentType.Image)
      {
        int texId = _textures[content.ContentKey];
        Gl.glDeleteTextures(1, ref texId);
      }
    }

    public void Begin()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
    }

    public void Draw(SceneNode node)
    {
      if (!_textures.ContainsKey(node.Content.ContentKey) || node.Content.Type != ContentType.Image)
        return;

      ImageContent content = (ImageContent)node.Content;

      int textureId = _textures[content.ContentKey];
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);

      Polygon transformed = content.GetTransformedVertices(node.WorldMatrix);

      Gl.glBegin(Gl.GL_QUADS);
 
      Gl.glTexCoord2f(0, 0);
      Vector vec = transformed[0];
      Gl.glVertex2f(vec.X, vec.Y);

      Gl.glTexCoord2f(1, 0);
      vec = transformed[1];
      Gl.glVertex2f(vec.X, vec.Y);

      Gl.glTexCoord2f(1, 1);
      vec = transformed[2];
      Gl.glVertex2f(vec.X, vec.Y);

      Gl.glTexCoord2f(0, 1);
      vec = transformed[3];
      Gl.glVertex2f(vec.X, vec.Y);

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

    public void End()
    {
      Gl.glFlush();
      Gdi.SwapBuffers(_dc);
    }

  }
}
