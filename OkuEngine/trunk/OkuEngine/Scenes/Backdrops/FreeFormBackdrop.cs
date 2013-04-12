using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;
using OkuEngine.Rendering;
using OkuEngine.Collections;
using Newtonsoft.Json;

namespace OkuEngine.Scenes.Backdrops
{
  /// <summary>
  /// Defines a free form backdrop that consists of a backgound
  /// image and freely definable shapes.
  /// The background image is split into slices for more efficient rendering.
  /// </summary>
  public class FreeFormBackdrop : Backdrop
  {
    private const int MaxImageDimensions = 1024;
    private const int ImageSliceSize = 256;

    private Vector2f _offset = Vector2f.Zero;
    private int _imageId = 0;
    private Polygon[] _shapes = null;
    private float _width = 0.0f;
    private float _height = 0.0f;

    private ImageContent _image = null;
    private RegularGrid _grid = null;
    private Dictionary<Vector2i, Vertices> _sliceData = new Dictionary<Vector2i, Vertices>();
    private DynamicArray<Vector2f> _vertPoints = new DynamicArray<Vector2f>();
    private DynamicArray<Vector2f> _vertTexCoords = new DynamicArray<Vector2f>();
    private DynamicArray<Color> _vertColors = new DynamicArray<Color>();

    /// <summary>
    /// Gets the shapes for collision detection.
    /// </summary>
    [JsonPropertyAttribute]
    public override Polygon[] Shapes
    {
      get { return _shapes; }
      set { _shapes = value; }
    }

    [JsonPropertyAttribute]
    public override float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    [JsonPropertyAttribute]
    public override float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    [JsonPropertyAttribute]
    public Vector2f Offset
    {
      get { return _offset; }
      set { _offset = value; }
    }

    [JsonPropertyAttribute]
    public int ImageId
    {
      get { return _imageId; }
      set { _imageId = value; }
    }

    /// <summary>
    /// Update the background. In this case does nothing.
    /// </summary>
    /// <param name="dt">The time delta in seconds.</param>
    public override void Update(float dt)
    {      
    }

    /// <summary>
    /// Renders the free form backdrop.
    /// </summary>
    /// <param name="scene">The scene to be used for rendering.</param>
    public override void Render(Scene scene)
    {
      Vector2i min = Vector2i.Zero;
      Vector2i max = Vector2i.Zero;

      Rectangle2f viewportBox = scene.Viewport.GetBoundingBox();

      _grid.GetCellsIntersecting(viewportBox, ref min, ref max);

      //Collect vertex data in arrays for more efficient rendering
      _vertPoints.Clear();
      _vertTexCoords.Clear();
      _vertColors.Clear();
      for (int y = min.Y; y <= max.Y; y++)
      {
        for (int x = min.X; x <= max.X; x++)
        {
          Vector2i index = new Vector2i(x, y);
          if (_sliceData.ContainsKey(index))
          {
            Vertices verts = _sliceData[index];

            _vertPoints.AddRange(verts.Positions);
            _vertTexCoords.AddRange(verts.TexCoords);
            _vertColors.AddRange(verts.Colors);
          }
        }
      }

      //Render everything at once
      OkuDrivers.Instance.Renderer.DrawMesh(_vertPoints.InternalArray, _vertTexCoords.InternalArray, _vertColors.InternalArray, _vertPoints.Count, OkuEngine.Driver.Renderer.DrawMode.Quads, _image);
    }

    /// <summary>
    /// Initializes the sclices of the backdrop that are later
    /// used for efficient rendering.
    /// </summary>
    private void InitializeSlices()
    {
      _sliceData.Clear();

      _width = 0;
      _height = 0;

      if (_image != null)
      {
        _width = _image.Width;
        _height = _image.Height;
      }
      else
      {
        if (_shapes != null && _shapes.Length > 0)
        {
          Rectangle2f total = new Rectangle2f();
          foreach (Polygon poly in _shapes)
          {
            total = total.Add(poly.Vertices.GetBoundingBox());
          }
          _width = total.Width;
          _height = total.Height;
        }
      }

      _grid = new RegularGrid(_width, _height, ImageSliceSize);
      _grid.Centered = true;

      Vector2i minCell = _grid.GetMinCell();
      Vector2i maxCell = _grid.GetMaxCell();

      Rectangle2f cellBounds;
      for (int y = minCell.Y; y <= maxCell.Y; y++)
      {
        for (int x = minCell.X; x <= maxCell.X; x++)
        {
          _grid.GetCellBounds(x, y, true, out cellBounds);
          Vector2f[] points = Rectangle2f.GetPoints(cellBounds.Min, cellBounds.Max);
          Vector2f[] texCoords = Rectangle2f.GetPoints(cellBounds.Min, cellBounds.Max);
          for (int i = 0; i < texCoords.Length; i++)
          {
            Vector2f texCoord = texCoords[i];
            texCoord.X = (texCoord.X - _grid.Left) / _grid.Width;
            texCoord.Y = (texCoord.Y - _grid.Bottom) / _grid.Height;
            texCoords[i] = texCoord;
          }
          Color[] colors = new Color[] { Color.White, Color.White, Color.White, Color.White };

          Vertices verts = new Vertices(points, texCoords, colors);
          _sliceData.Add(new Vector2i(x, y), verts);
        }
      }
    }

    public override bool AfterLoad()
    {
      _image = OkuData.Instance.Images[_imageId];
      if (_image == null)
      {
        OkuManagers.Instance.Logger.LogError("Could not find image with id " + _imageId + "!");
        return false;
      }

      InitializeSlices();

      return true;
    }
  }
}
