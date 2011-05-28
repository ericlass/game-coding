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
    /// Gets or sets the color that is used to clear the screen each frame before rendering begins.
    /// </summary>
    public Color ClearColor
    {
      get { return _clearColor; }
      set 
      { 
        _clearColor = value;
        Gl.glClearColor(_clearColor.R, _clearColor.G, _clearColor.B, 1);
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
      Gl.glOrtho(0, _form.ClientSize.Width - 1, _form.ClientSize.Height - 1, 0, -1, 1);

      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    /// <summary>
    /// Initializes image content which means that OpenGL textures are created for them.
    /// THis method also sets the Width and Height properties of the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The content data. This must be a stream that contains a complete image file like PNG, BMP or JPG.</param>
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

      //Remember texture for this content
      _textures.Add(content.ContentId, textureId);

      //Write width and height to the content
      content.Width = width;
      content.Height = height;
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

    /// <summary>
    /// Draws the given image transforming it by the given tranformation matrix.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="transform">The transformation matrix.</param>
    public void DrawImage(ImageContent content, Matrix3 transform)
    {
      DrawImage(content, transform, Color.White);
    }

    /// <summary>
    /// Draws the given image transforming it by the given tranformation matrix.
    /// The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="transform">The transformation matrix.</param>
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

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    public void DrawLine(Vector start, Vector end, float width, Color color)
    {
      DrawLines(new VectorList() { start, end }, width, color, VertexInterpretation.LineSegments);
    }

    public void DrawLine(Vertex start, Vertex end, float width)
    {
      DrawLines(new VertexList() { start, end }, width, VertexInterpretation.LineSegments, false, Color.White);
    }

    public void DrawLine(Vertex start, Vertex end, float width, Color color)
    {
      DrawLines(new VertexList() { start, end }, width, VertexInterpretation.LineSegments, true, color);
    }

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw lines with.</param>
    /// <param name="width">The width of the lines in pixel.</param>
    /// <param name="color">The color of the lines.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    public void DrawLines(VectorList vertices, float width, Color color, VertexInterpretation interpretation)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        //Convert the interpretation to an OpenGL primitive type.
        int primitive = 0;
        switch (interpretation)
        {
          case VertexInterpretation.Polygon:
            primitive = Gl.GL_LINE_STRIP;
            break;
          case VertexInterpretation.PolygonClosed:
            primitive = Gl.GL_LINE_LOOP;
            break;
          case VertexInterpretation.LineSegments:
            primitive = Gl.GL_LINES;
            break;
          default:
            throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not implemented in DrawLines(...)!");
        }

        //Draw the lines
        Gl.glBegin(primitive);

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

    public void DrawLines(VertexList vertices, float width, VertexInterpretation interpretation)
    {
      DrawLines(vertices, width, interpretation, false, Color.White);
    }

    public void DrawLines(VertexList vertices, float width, VertexInterpretation interpretation, Color color)
    {
      DrawLines(vertices, width, interpretation, true, color);
    }

    private void DrawLines(VertexList vertices, float width, VertexInterpretation interpretation, bool useColorOverride, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      try
      {
        Gl.glLineWidth(width);

        //Convert the interpretation to an OpenGL primitive type.
        int primitive = 0;
        switch (interpretation)
        {
          case VertexInterpretation.Polygon:
            primitive = Gl.GL_LINE_STRIP;
            break;
          case VertexInterpretation.PolygonClosed:
            primitive = Gl.GL_LINE_LOOP;
            break;
          case VertexInterpretation.LineSegments:
            primitive = Gl.GL_LINES;
            break;
          default:
            throw new ArgumentOutOfRangeException("Vertex interpretation " + interpretation.ToString() + " is not implemented in DrawLines(...)!");
        }

        //Draw the lines
        Gl.glBegin(primitive);

        if (useColorOverride)
        {
          Gl.glColor4f(color.R, color.G, color.B, color.A);
          foreach (Vertex vert in vertices)
            Gl.glVertex2f(vert.Position.X, vert.Position.Y);
        }
        else
        {
          foreach (Vertex vert in vertices)
          {
            Gl.glColor4f(vert.Color.R, vert.Color.G, vert.Color.B, vert.Color.A);
            Gl.glVertex2f(vert.Position.X, vert.Position.Y);
          }
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    /// <summary>
    /// Draws a line from start to end with the given width and color. The vertices (start and end) are
    /// tranformed by the transformation matrix before drawing.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    public void DrawLine(Vector start, Vector end, Matrix3 transform, float width, Color color)
    {
      DrawLines(new VectorList() { start, end }, transform, width, color, VertexInterpretation.LineSegments);
    }

    public void DrawLine(Vertex start, Vertex end, Matrix3 transform, float width)
    {
      DrawLines(new VertexList() { start, end }, transform, width, VertexInterpretation.LineSegments, false, Color.White);
    }

    public void DrawLine(Vertex start, Vertex end, Matrix3 transform, float width, Color color)
    {
      DrawLines(new VertexList() { start, end }, transform, width, VertexInterpretation.LineSegments, true, color);
    }

    /// <summary>
    /// Draws line using the given vertices with the given width and color. The vertices are
    /// tranformed by the transformation matrix before drawing.
    /// </summary>
    /// <param name="vertices">The vertices to use.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
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

    public void DrawLines(VertexList vertices, Matrix3 transform, float width, VertexInterpretation interpretation)
    {
      DrawLines(vertices, transform, width, interpretation, false, Color.White);
    }

    public void DrawLines(VertexList vertices, Matrix3 transform, float width, VertexInterpretation interpretation, Color color)
    {
      DrawLines(vertices, transform, width, interpretation, true, color);
    }

    private void DrawLines(VertexList vertices, Matrix3 transform, float width, VertexInterpretation interpretation, bool useColorOverride, Color color)
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

        if (useColorOverride)
        {
          Gl.glColor4f(color.R, color.G, color.B, color.A);
          foreach (Vertex vert in vertices)
          {
            float x = vert.Position.X;
            float y = vert.Position.Y;
            transform.Transform(ref x, ref y);
            Gl.glVertex2f(x, y);
          }
        }
        else
        {
          foreach (Vertex vert in vertices)
          {
            Gl.glColor4f(vert.Color.R, vert.Color.G, vert.Color.B, vert.Color.A);
            float x = vert.Position.X;
            float y = vert.Position.Y;
            transform.Transform(ref x, ref y);
            Gl.glVertex2f(x, y);
          }
        }

        Gl.glEnd();
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
      DrawPoints(new VectorList() { p }, size, color);
    }

    public void DrawPoint(Vertex p, float size)
    {
      DrawPoints(new VertexList() { p }, size, false, Color.White);
    }

    public void DrawPoint(Vertex p, float size, Color color)
    {
      DrawPoints(new VertexList() { p }, size, true, color);
    }

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in screen space pixels.</param>
    /// <param name="size">The size of the points in pixels.</param>
    /// <param name="color">The color of the points.</param>
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

    public void DrawPoints(VertexList points, float size)
    {
      DrawPoints(points, size, false, Color.White);
    }

    public void DrawPoints(VertexList points, float size, Color color)
    {
      DrawPoints(points, size, true, color);
    }

    private void DrawPoints(VertexList points, float size, bool useColorOverride, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        if (useColorOverride)
        {
          Gl.glColor4f(color.R, color.G, color.B, color.A);
          foreach (Vertex vert in points)
            Gl.glVertex2f(vert.Position.X, vert.Position.Y);
        }
        else
        {
          foreach (Vertex vert in points)
          {
            Gl.glColor4f(vert.Color.R, vert.Color.G, vert.Color.B, vert.Color.A);
            Gl.glVertex2f(vert.Position.X, vert.Position.Y);
          }
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
    }

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// The point is transformed by the given transformation matrix before drawing.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    public void DrawPoint(Vector p, Matrix3 transform, float size, Color color)
    {
      DrawPoints(new VectorList() { p }, transform, size, color);    
    }

    public void DrawPoint(Vertex p, Matrix3 transform, float size)
    {
      DrawPoints(new VertexList() { p }, transform, size, false, Color.White);
    }

    public void DrawPoint(Vertex p, Matrix3 transform, float size, Color color)
    {
      DrawPoints(new VertexList() { p }, transform, size, true, color);
    }

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// The points are transformed by the given transformation matrix before drawing.
    /// </summary>
    /// <param name="points">The center of the points in screen space pixels.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the points in pixels.</param>
    /// <param name="color">The color of the points.</param>
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

    public void DrawPoints(VertexList points, Matrix3 transform, float size)
    {
      DrawPoints(points, transform, size, false, Color.White);
    }

    public void DrawPoints(VertexList points, Matrix3 transform, float size, Color color)
    {
      DrawPoints(points, transform, size, true, color);
    }

    private void DrawPoints(VertexList points, Matrix3 transform, float size, bool useColorOverride, Color color)
    {
      Gl.glDisable(Gl.GL_TEXTURE_2D);

      try
      {
        Gl.glPointSize(size);

        Gl.glBegin(Gl.GL_POINTS);

        if (useColorOverride)
        {
          Gl.glColor4f(color.R, color.G, color.B, color.A);
          foreach (Vertex vert in points)
          {
            float x = vert.Position.X;
            float y = vert.Position.Y;
            transform.Transform(ref x, ref y);
            Gl.glVertex2f(x, y);
          }
        }
        else
        {
          foreach (Vertex vert in points)
          {
            Gl.glColor4f(vert.Color.R, vert.Color.G, vert.Color.B, vert.Color.A);
            float x = vert.Position.X;
            float y = vert.Position.Y;
            transform.Transform(ref x, ref y);
            Gl.glVertex2f(x, y);
          }
        }

        Gl.glEnd();
      }
      finally
      {
        Gl.glEnable(Gl.GL_TEXTURE_2D);
      }
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
