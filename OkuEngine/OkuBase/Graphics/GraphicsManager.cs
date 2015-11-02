using System;
using System.Drawing;
using OkuBase.Collections;
using OkuBase.Driver;
using OkuBase.Settings;
using OkuBase.Geometry;
using OkuMath;

namespace OkuBase.Graphics
{
  public class GraphicsManager : Manager
  {
    private IGraphicsDriver _driver = null;
    private ViewPort _viewport = null;
    private GraphicsSettings _settings = null;
    private RenderTarget _renderTarget = null;

    private Vector2f[] _quad = new Vector2f[4];
    private Color[] _quadColor = new Color[4];
    private DynamicArray<Color> _colors = new DynamicArray<Color>();

    private void OnViewportChange(ViewPort sender)
    {
      _driver.SetViewport(sender.Left, sender.Right, sender.Bottom, sender.Top);
    }

    internal IGraphicsDriver Driver
    {
      get { return _driver; }
    }

    public ViewPort Viewport
    {
      get { return _viewport; }
    }

    public Color BackgroundColor
    {
      get { return _settings.BackgroundColor; }
      set
      {
        _settings.BackgroundColor = value;
        _driver.SetBackgroundColor(value);
      }
    }

    /// <summary>
    /// Gets or sets the title of the display.
    /// </summary>
    public string Title
    {
      get { return _driver.Display.Text; }
      set { _driver.Display.Text = value; }
    }

    /// <summary>
    /// Gets the width of the current display in pixels.
    /// This is either the window or the current render target.
    /// </summary>
    public int DisplayWidth
    {
      get { return _renderTarget == null ? _driver.Display.ClientSize.Width : _renderTarget.Width; }
    }

    /// <summary>
    /// Gets the height of the current display in pixels.
    /// This is either the window or the current render target.
    /// </summary>
    public int DisplayHeight
    {
      get { return _renderTarget == null ? _driver.Display.ClientSize.Height : _renderTarget.Height; }
    }

    public override void Initialize(OkuSettings settings)
    {
      if (settings.Graphics.DpiAware)
        Platform.User32.SetProcessDPIAware();

      _driver = OkuManager.Instance.Drivers.GraphicsDriver;
      _driver.Initialize(settings.Graphics);
      _settings = settings.Graphics;

      _viewport = new ViewPort(settings.Graphics.Width, settings.Graphics.Height);
      _viewport.Change += new ViewPortChangeEventHandler(OnViewportChange);
    }

    public override void Update(float dt)
    {
      _driver.Update(dt);
    }

    public override void Finish()
    {
      _driver.Finish();
    }

    /// <summary>
    /// Converts the given screen pixel coordinates to display client coordinates.
    /// The origin for these coordinates is in the lower left corner.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The client space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    public Vector2f ScreenToDisplay(int x, int y)
    {
      Point p = _driver.Display.PointToClient(new Point((int)x, (int)y));
      return new Vector2f(p.X, (_driver.Display.ClientSize.Height - 1) - p.Y);
    }

    /// <summary>
    /// Converts the given screen pixel coordinates to world coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The world space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    public Vector2f ScreenToWorld(int x, int y)
    {
      Vector2f pDist = ScreenToDisplay(x, y);

      float wx = BasicMath.Lerp(_viewport.Left, _viewport.Right, pDist.X / _driver.Display.ClientSize.Width);
      float wy = BasicMath.Lerp(_viewport.Bottom, _viewport.Top, pDist.Y / _driver.Display.ClientSize.Height);

      return new Vector2f(wx, wy);
    }

    /// <summary>
    /// Sets a rectangular area of the screen where drawing will happen. 
    /// Everything outside of the specified area will not be drawn and
    /// kept form the previous frame.
    /// The area is specified in display space pixel coordinates and are inclusive.
    /// </summary>
    /// <param name="left">The left border of the scissor rectangle.</param>
    /// <param name="right">The right border of the scissor rectangle.</param>
    /// <param name="width">The width of the scissor rectangle.</param>
    /// <param name="height">The height of the scissor rectangle.</param>
    public void SetScissorRectangle(int left, int right, int width, int height)
    {
      _driver.SetScissorRectangle(left, right, width, height);
    }

    /// <summary>
    /// Clear the scissor rectangle so that thw whole screen is redrawn again.
    /// </summary>
    public void ClearScissorRectangle()
    {
      _driver.ClearScissorRectangle();
    }

    /// <summary>
    /// Gets the factor by which the DPI setting of the system is higher than usual (96 dpi).
    /// </summary>
    /// <returns>The DPI factor.</returns>
    public float GetDpiScale()
    {
      System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
      float result = g.DpiX / 96.0f;
      return result;
    }

    public void SetDisplaySize(int width, int height)
    {
      _driver.Display.Size = new Size(width, height);
    }

    #region Images

    public Image NewImage(ImageData data, bool compressed)
    {
      Image result = new Image(data, compressed);
      _driver.InitImage(result);
      return result;
    }

    public Image NewImage(ImageData data)
    {
      return NewImage(data, false);
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
      _driver.UpdateImage(image, x, y, width, height, data);
    }

    public void ReleaseImage(Image image)
    {
      _driver.ReleaseImage(image);
    }

    public RenderTarget NewRenderTarget(int width, int height)
    {
      RenderTarget result = new RenderTarget(width, height);
      _driver.InitRenderTarget(result);
      return result;
    }

    public void SetRenderTarget(RenderTarget target)
    {
      _driver.SetRenderTarget(target);
      _renderTarget = target;
    }

    public void ReleaseRenderTarget(RenderTarget target)
    {
      _driver.ReleaseRenderTarget(target);
      _renderTarget = null;
    }

    #endregion

    #region Rendering

    internal void Begin()
    {
      _driver.Begin();
    }

    internal void End()
    {
      _driver.End();
    }

    public void BeginScreenSpace()
    {
      _driver.BeginScreenSpace();
    }

    public void EndScreenSpace()
    {
      _driver.EndScreenSpace();
    }

    /// <summary>
    /// Clears the screen or current render target with the current background color.
    /// </summary>
    public void Clear()
    {
      _driver.Clear();
    }

    /// <summary>
    /// Draws the given image at the given position, rotating and scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="sx">The scale factor on the x axis.</param>
    /// <param name="sy">The scale factor on the y axis.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageBase image, float x, float y, float rotation, float sx, float sy, Color tint)
    {
      _driver.DrawImage(image, x, y, rotation, sx, sy, tint);
    }

    /// <summary>
    /// Draws the given image at the given position.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    public void DrawImage(ImageBase image, float x, float y)
    {
      _driver.DrawImage(image, x, y, 0, 1, 1, Color.White);
    }

    /// <summary>
    /// Draws the given image at the given position. The image is tinted with given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    public void DrawImage(ImageBase image, float x, float y, Color tint)
    {
      _driver.DrawImage(image, x, y, 0, 1, 1, tint);
    }

    /// <summary>
    /// Draws the given image on a screen aligned quad so it fills the whole 
    /// screen using the given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="tint">The color tint the image with.</param>
    public void DrawScreenAlignedQuad(ImageBase image, Color tint)
    {
      _driver.DrawScreenAlignedQuad(image, tint);
    }

    /// <summary>
    /// Draws the given image on a screen aligned quad so it fills the whole screen.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    public void DrawScreenAlignedQuad(ImageBase image)
    {
      _driver.DrawScreenAlignedQuad(image, Color.White);
    }

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="x1">The x coordinate of the start point.</param>
    /// <param name="y1">The y coordinate of the start point.</param>
    /// <param name="x2">The x coordinate of the end point.</param>
    /// <param name="y2">The y coordinate of the end point.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    public void DrawLine(float x1, float y1, float x2, float y2, float width, Color color)
    {
      _driver.DrawLine(x1, y1, x2, y2, width, color);
    }

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and colors.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw the lines with.</param>
    /// <param name="colors">The colors belonging to the vertices. Has to be same length as vertices.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    public void DrawLines(Vector2f[] vertices, Color[] colors, int count, float width, LineMode interpretation)
    {
      _driver.DrawLines(vertices, colors, count, width, interpretation);
    }

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw the lines with.</param>
    /// <param name="color">The color of the all lines.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    public void DrawLines(Vector2f[] vertices, Color color, int count, float width, LineMode interpretation)
    {
      _colors.Clear();
      for (int i = 0; i < vertices.Length; i++)
        _colors.Add(color);

      _driver.DrawLines(vertices, _colors.InternalArray, count, width, interpretation);
    }

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="x">The x coordinate of the point.</param>
    /// <param name="y">The y coordinate of the point.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    public void DrawPoint(float x, float y, float size, Color color)
    {
      _driver.DrawPoint(x, y, size, color);
    }

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in world space pixels.</param>
    /// <param name="colors">The color values belonging to the points. Must be same length as points.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="size">The size of the points in pixels.</param>
    public void DrawPoints(Vector2f[] points, Color[] colors, int count, float size)
    {
      _driver.DrawPoints(points, colors, count, size);
    }


    /// <summary>
    /// Draws a generic mesh using the given parameters.
    /// </summary>
    /// <param name="points">The coordinates of the vertices of the mesh in world space. Must not be null.</param>
    /// <param name="texCoords">The normalized texture coordinates of the vertices. Must be same length as points. If null, no texture is applied.</param>
    /// <param name="colors">The colors of the vertices. Must be same length as points. If null, white is used as default color.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="type">The type of primitive used to draw the given vertices.</param>
    /// <param name="texture">The texture to be applied. If not null, texCoords must also be given.</param>
    public void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, ImageBase texture)
    {
      _driver.DrawMesh(points, texCoords, colors, count, type, texture);
    }

    public void DrawMesh(Mesh mesh)
    {
      _driver.DrawMesh(mesh.Vertices.Positions, mesh.Vertices.TexCoords, mesh.Vertices.Colors, mesh.Vertices.Count, mesh.PrimitiveType, mesh.Texture);
    }

    public void DrawRectangle(float left, float right, float bottom, float top, Color color)
    {
      _quad[0].X = left;
      _quad[0].Y = bottom;

      _quad[1].X = left;
      _quad[1].Y = top;

      _quad[2].X = right;
      _quad[2].Y = top;

      _quad[3].X = right;
      _quad[3].Y = bottom;

      _quadColor[0] = color;
      _quadColor[1] = color;
      _quadColor[2] = color;
      _quadColor[3] = color;

      _driver.DrawMesh(_quad, null, _quadColor, 4, PrimitiveType.Quads, null);
    }

    /// <summary>
    /// Draws the given vertex buffer using the given texture.
    /// </summary>
    /// <param name="vbuffer">The vertex buffer to draw.</param>
    /// <param name="texture">The texture to be used, can be null.</param>
    public void DrawVertexBuffer(VertexBuffer vbuffer, PrimitiveType ptype, ImageBase texture)
    {
      _driver.DrawVertexBuffer(vbuffer, ptype, texture);
    }

    #endregion

    #region Shaders

    public ShaderProgram NewShaderProgram(Shader vertexShader, Shader pixelShader)
    {
      ShaderProgram program = new ShaderProgram(vertexShader, pixelShader);
      if (!_driver.InitShaderProgram(program))
        throw new OkuException("Could not initialize shader program! See debug output for details.");
      return program;
    }

    public void UseShaderProgram(ShaderProgram program)
    {
      _driver.UseShaderProgram(program);
    }

    public void SetShaderFloat(ShaderProgram program, string name, params float[] values)
    {
      _driver.SetShaderFloat(program, name, values);
    }

    public void SetShaderTexture(ShaderProgram program, string name, ImageBase image)
    {
      _driver.SetShaderTexture(program, name, image);
    }

    public void ReleaseShaderProgram(ShaderProgram program)
    {
      _driver.ReleaseShaderProgram(program);
    }

    #endregion

    #region Transform

    /// <summary>
    /// Pushes the current transformation onto the stack and applies the given transformation.
    /// </summary>
    /// <param name="translation">The amount to translate.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="angle">The angle to rotate.</param>
    public void ApplyAndPushTransform(Vector2f translation, Vector2f scale, float angle)
    {
      _driver.ApplyAndPushTransform(translation, scale, angle);
    }

    /// <summary>
    /// Pops the current transformation from the stack.
    /// </summary>
    public void PopTransform()
    {
      _driver.PopTransform();
    }

    #endregion

    #region Vertex Buffers

    /// <summary>
    /// Initializes the given vertex buffer.
    /// </summary>
    /// <param name="vbuffer">The buffer to be initialized.</param>
    public void InitVertexBuffer(VertexBuffer vbuffer)
    {
      _driver.InitVertexBuffer(vbuffer);
    }

    /// <summary>
    /// Updates the vertices of the given vertex buffer.
    /// </summary>
    /// <param name="vbuffer">The buffer to be updated.</param>
    public void UpdateVertexBuffer(VertexBuffer vbuffer)
    {
      _driver.UpdateVertexBuffer(vbuffer);
    }

    /// <summary>
    /// Release the memory assigned to a vertex buffer.
    /// </summary>
    /// <param name="vbuffer">The buffer to be released.</param>
    public void ReleaseVertexBuffer(VertexBuffer vbuffer)
    {
      _driver.ReleaseVertexBuffer(vbuffer);
    }

    #endregion

  }
}
