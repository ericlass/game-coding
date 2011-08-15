﻿using System;
using System.Collections.Generic;
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
    private Color _clearColor = Color.Black;

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
    /// Gets or sets the color that is used to clear the screen each frame before rendering begins.
    /// </summary>
    public Color ClearColor
    {
      get { return _clearColor; }
      set 
      { 
        _clearColor = value;
        Gl.glClearColor(_clearColor.R / 255.0f, _clearColor.G / 255.0f, _clearColor.B / 255.0f, 1);
      }
    }

    /// <summary>
    /// Gets the form that is used to draw on.
    /// </summary>
    public Form MainForm
    {
      get { return _form; }
    }

    /// <summary>
    /// Initializes the renderer. This includes creating the form and intitializing OpenGL.
    /// </summary>
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
      Gl.glOrtho(0, _form.ClientSize.Width, _form.ClientSize.Height, 0, -1, 1);

      Gl.glEnable(Gl.GL_ALPHA_TEST);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.05f);

      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

      Gl.glClearColor(_clearColor.R / 255.0f, _clearColor.G / 255.0f, _clearColor.B / 255.0f, 1);

      Gl.glLineWidth(1.0f);
      Gl.glEnable(Gl.GL_LINE_SMOOTH);

      Gl.glPointSize(1);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);

      Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
      Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
      Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
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
    /// Handles resizing of the form. The OpenGL viewport is reset to fit the new size of the form.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event arguments.</param>
    private void _form_Resize(object sender, EventArgs e)
    {
      Gl.glViewport(0, 0, _form.ClientSize.Width, _form.ClientSize.Height);

      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Gl.glOrtho(0, _form.ClientSize.Width, _form.ClientSize.Height, 0, -1, 1);

      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    /// <summary>
    /// Initializes image content which means that OpenGL textures are created for them.
    /// This method also sets the Width and Height properties of the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The content data. This must be a stream that contains a complete image file like PNG, BMP or JPG.</param>
    public void InitContentFile(ImageContent content, Stream data)
    {
      Bitmap tex = new Bitmap(data);
      InitContentBitmap(content, tex);
    }

    /// <summary>
    /// Initializes image content from raw data which is represented by a byte array.
    /// The data is expected to only contain pixel data.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The pixel data.</param>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    public void InitContentRaw(ImageContent content, byte[] data, int width, int height)
    {
      //Load texture and set it's options
      int textureId = 0;

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, width, height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

      if (_textures.ContainsKey(content.ContentId))
        ReleaseContent(content);

      //Remember texture for this content
      _textures.Add(content.ContentId, textureId);

      //Write width and height to the content
      content.Width = width;
      content.Height = height;
    }

    public void InitContentBitmap(ImageContent content, Bitmap image)
    {
      int textureId = 0;

      BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      Gl.glGenTextures(1, out textureId);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, image.Width, image.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bmData.Scan0);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

      image.UnlockBits(bmData);

      if (_textures.ContainsKey(content.ContentId))
        ReleaseContent(content);

      _textures.Add(content.ContentId, textureId);

      content.Width = image.Width;
      content.Height = image.Height;
    }

    public void UpdateContent(ImageContent content, int x, int y, int width, int height, byte[] rawData)
    {
      int textureId = 0;
      if (_textures.ContainsKey(content.ContentId))
        textureId = _textures[content.ContentId];
      else
        return;

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexSubImage2D(Gl.GL_TEXTURE_2D, 0, x, y, width, height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, rawData);
    }

    public void UpdateContent(ImageContent content, int x, int y, int width, int height, Bitmap image)
    {
      int textureId = 0;
      if (_textures.ContainsKey(content.ContentId))
        textureId = _textures[content.ContentId];
      else
        return;

      BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
      Gl.glTexSubImage2D(Gl.GL_TEXTURE_2D, 0, x, y, width, height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bmData.Scan0);

      image.UnlockBits(bmData);
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
    public void Begin()
    {
      Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
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

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw lines with.</param>
    /// <param name="width">The width of the lines in pixel.</param>
    /// <param name="color">The color of the lines.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    public void DrawLines(Vector[] vertices, float width, Color color, VertexInterpretation interpretation)
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
        Gl.glDrawArrays(primitive, 0, vertices.Length);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }   
    }

    public void DrawLines(Vector[] vertices, Color[] colors, float width, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        //Convert the interpretation to an OpenGL primitive type.
        int primitive = VertexIntToGLPrimitive(interpretation);

        SetPointers(vertices, null, colors);
        Gl.glDrawArrays(primitive, 0, vertices.Length);
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

    public void DrawPoints(Vector[] points, float size, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glColor4ub(color.R, color.G, color.B, color.A);
        SetPointers(points, null, null);
        Gl.glDrawArrays(Gl.GL_POINTS, 0, points.Length);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawPoints(Vector[] points, Color[] colors, float size)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        SetPointers(points, null, colors);
        Gl.glDrawArrays(Gl.GL_POINTS, 0, points.Length);
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    public void DrawMesh(Vector[] points, Vector[] texCoords, Color[] colors, MeshMode mode, ImageContent texture)
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
      Gl.glDrawArrays(primitive, 0, points.Length);
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
    public void End()
    {
      Gl.glFlush();
      Gdi.SwapBuffers(_dc);
    }

  }
}
