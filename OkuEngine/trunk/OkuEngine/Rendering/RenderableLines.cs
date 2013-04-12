using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Driver.Renderer;
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
        OkuDrivers.Instance.Renderer.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, VertexInterpretation.PolygonClosed);
      else
        OkuDrivers.Instance.Renderer.DrawLines(_vertices.Positions, _vertices.Colors, _vertices.Count, _width, VertexInterpretation.Polygon);
    }

    public Rectangle2f GetBoundingBox()
    {
      return _vertices.GetAABB();
    }

    public IRenderable Copy()
    {
      RenderableLines result = new RenderableLines();
      result._closed = _closed;
      result._vertices = _vertices.Copy();
      result._width = _width;
      return result;
    }

    public bool AfterLoad()
    {
      return _vertices.AfterLoad();
    }

  }
}
