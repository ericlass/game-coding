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

    private bool _screenSpace = false;
    private ScissorRect _scissor = null;
    private ShaderProgram _shader = null;
    private Vector2f[] _vertPos = null;
    private Vector2f[] _vertTex = null;
    private Color[] _vertColors = null;
    private PrimitiveType _primitiveType = PrimitiveType.None;
    private ImageBase _texture = null;
    private Vector2f _translation = Vector2f.Zero;
    private Vector2f _scale = Vector2f.One;
    private float _angle = 0.0f;

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

    /// <summary>
    /// Clears the screen or current render target with the current background color.
    /// </summary>
    public void Clear()
    {
      _driver.Clear();
    }

    public void DrawImage(ImageBase image, Color tint)
    {
      Mesh mesh = Mesh.ForImage(image, tint);

      _driver.VertexPositions = mesh.Vertices.Positions;
      _driver.VertexTexCoords = mesh.Vertices.TexCoords;
      _driver.VertexColors = mesh.Vertices.Colors;

      _driver.Texture = image;
      _driver.PrimitiveType = mesh.PrimitiveType;

      _driver.Draw(0, mesh.Vertices.Positions.Length);
    }

    public void DrawImage(ImageBase image)
    {
      DrawImage(image, Color.White);
    }

    /// <summary>
    /// Draws the given image on a screen aligned quad so it fills the whole 
    /// screen using the given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="tint">The color tint the image with.</param>
    public void DrawScreenAlignedQuad(ImageBase image, Color tint)
    {
      _driver.VertexPositions = new Vector2f[] {
        new Vector2f(0, 0),
        new Vector2f(0, _settings.Height),
        new Vector2f(_settings.Width, 0),
        new Vector2f(_settings.Width, _settings.Height)
      };

      _driver.VertexTexCoords = new Vector2f[] {
        new Vector2f(0, 0),
        new Vector2f(0, 1),
        new Vector2f(1, 0),
        new Vector2f(1, 1)
      };

      _driver.VertexColors = new Color[] {
        tint,
        tint,
        tint,
        tint
      };

      _driver.Texture = image;
      _driver.PrimitiveType = PrimitiveType.TriangleStrip;
      _driver.ScreenSpace = true;

      _driver.Draw(0, 4);
    }

    /// <summary>
    /// Draws the given image on a screen aligned quad so it fills the whole screen.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    public void DrawScreenAlignedQuad(ImageBase image)
    {
      DrawScreenAlignedQuad(image, Color.White);
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
      _driver.VertexPositions = new Vector2f[] { new Vector2f(x1, y1), new Vector2f(x2, y2) };
      _driver.VertexColors = new Color[] { color, color };
      _driver.VertexTexCoords = null;

      _driver.LineWidth = width;
      _driver.PrimitiveType = PrimitiveType.Lines;

      _driver.Draw(0, 2);
    }

    private PrimitiveType LineModeToPrimitiveType(LineMode mode)
    {
      switch (mode)
      {
        case LineMode.Polygon:
          return PrimitiveType.Polygon;
        case LineMode.PolygonClosed:
          return PrimitiveType.ClosedPolygon;
        case LineMode.LineSegments:
          return PrimitiveType.Lines;
        default:
          throw new OkuException("Unsupported line mode: " + mode.ToString());
      }
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
    public void DrawLines(Vector2f[] vertices, Color[] colors, int count, float width, LineMode mode)
    {
      _driver.VertexPositions = vertices;
      _driver.VertexColors = colors;
      _driver.VertexTexCoords = null;

      _driver.LineWidth = width;
      _driver.PrimitiveType = LineModeToPrimitiveType(mode);

      _driver.Draw(0, count);
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
    public void DrawLines(Vector2f[] vertices, Color color, int count, float width, LineMode mode)
    {
      Color[] colors = new Color[vertices.Length];
      for (int i = 0; i < colors.Length; i++)
        colors[i] = color;

      DrawLines(vertices, colors, count, width, mode);
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
      _driver.VertexPositions = new Vector2f[] { new Vector2f(x, y) };
      _driver.VertexColors = new Color[] { color };

      _driver.PrimitiveType = PrimitiveType.Points;
      _driver.PointSize = size;

      _driver.Draw(0, 1);
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
      _driver.VertexPositions = points;
      _driver.VertexColors = colors;

      _driver.PrimitiveType = PrimitiveType.Points;
      _driver.PointSize = size;

      _driver.Draw(0, 1);
    }

    public void DrawMesh(Mesh mesh)
    {
      _driver.VertexPositions = mesh.Vertices.Positions;
      _driver.VertexTexCoords = mesh.Vertices.TexCoords;
      _driver.VertexColors = mesh.Vertices.Colors;

      _driver.PrimitiveType = mesh.PrimitiveType;
      _driver.Texture = mesh.Texture;

      _driver.Draw(0, mesh.Vertices.Count);
    }

    public void Draw(int first, int count)
    {
      _driver.Draw(first, count);
    }

    public void DrawInstanced(int first, int count, int primcount)
    {
      _driver.DrawInstanced(first, count, primcount);
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

    public void SetShaderValue(string name, params float[] values)
    {
      _driver.SetShaderValue(name, values);
    }

    public void SetShaderValue(string name, ImageBase image)
    {
      _driver.SetShaderValue(name, image);
    }

    public void ReleaseShaderProgram(ShaderProgram program)
    {
      _driver.ReleaseShaderProgram(program);
    }

    #endregion

    #region Transform

    public void PushTransform()
    {
      _driver.PushTransform();
    }

    /// <summary>
    /// Pops the current transformation from the stack.
    /// </summary>
    public void PopTransform()
    {
      _driver.PopTransform();
    }

    #endregion

    public Vector2f[] VertexPositions
    {
      get { return _vertPos; }
      set
      {
        _vertPos = value;
        _driver.VertexPositions = value;
      }
    }

    public Vector2f[] VertexTexCoords
    {
      get { return _vertTex; }
      set
      {
        _vertTex = value;
        _driver.VertexTexCoords = value;
      }
    }

    public Color[] VertexColors
    {
      get { return _vertColors; }
      set
      {
        _vertColors = value;
        _driver.VertexColors = value;
      }
    }

    public PrimitiveType PrimitiveType
    {
      get { return _primitiveType; }
      set
      {
        if (_primitiveType != value)
        {
          _primitiveType = value;
          _driver.PrimitiveType = value;
        }
      }
    }

    public ImageBase Texture
    {
      get { return _texture; }
      set
      {
        _texture = value;
        _driver.Texture = value;
      }
    }

    public Color BackgroundColor
    {
      get { return _settings.BackgroundColor; }
      set
      {
        _settings.BackgroundColor = value;
        _driver.BackgroundColor = value;
      }
    }

    public RenderTarget RenderTarget
    {
      get { return _renderTarget; }
      set
      {
        _renderTarget = value;
        _driver.RenderTarget = value;
      }
    }

    public ScissorRect ScissorRectangle
    {
      get { return _scissor; }
      set
      {
        _scissor = value;
        _driver.ScissorRectangle = value;
      }
    }

    public Vector2f Translation
    {
      get { return _translation; }
      set
      {
        _translation = value;
        _driver.Translation = value;
      }
    }

    public Vector2f Scale
    {
      get { return _scale; }
      set
      {
        _scale = value;
        _driver.Scale = value;
      }
    }

    public float Angle
    {
      get { return _angle; }
      set
      {
        _angle = value;
        _driver.Angle = value;
      }
    }

    public bool ScreenSpace
    {
      get { return _screenSpace; }
      set
      {
        if (_screenSpace != value)
        {
          _screenSpace = value;
          _driver.ScreenSpace = value;
        }
      }
    }

    public ShaderProgram Shader
    {
      get { return _shader; }
      set
      {
        _shader = value;
        _driver.Shader = value;
      }
    }

  }
}
