using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  public class RenderableLines : IRenderable
  {
    private Vertices _vertices = null;
    private float _width = 1.0f;
    private bool _closed = true;

    /// <summary>
    /// Gets or sets the width of the line in pixels.
    /// </summary>
    [JsonPropertyAttribute]
    public float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Gets or sets of the line is closed by connection the last and first vertex.
    /// </summary>
    [JsonPropertyAttribute]
    public bool Closed
    {
      get { return _closed; }
      set { _closed = value; }
    }

    /// <summary>
    /// Gets or sets the vertices.
    /// </summary>
    [JsonPropertyAttribute]
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    public void Update(float dt)
    {
      //Nothing to for lines
    }

    public void Render(Scene scene)
    {
      if (_closed)
        OkuManager.Instance.Graphics.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, LineMode.PolygonClosed);
      else
        OkuManager.Instance.Graphics.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, LineMode.Polygon);
    }

    public Rectangle2f GetBoundingBox()
    {
      return _vertices.Positions.GetBoundingBox();
    }

    public Circle GetBoundingCircle()
    {
      if (_vertices.Positions != null)
        return _vertices.Positions.GetBoundingCircleCentered();

      return default(Circle);
    }

    public bool AfterLoad()
    {
      return true;
    }

  }
}
