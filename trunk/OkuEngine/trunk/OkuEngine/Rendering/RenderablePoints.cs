using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase;
using OkuBase.Geometry;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  public class RenderablePoints : IRenderable
  {
    private Vertices _vertices = null;
    private float _size = 2.0f;

    [JsonPropertyAttribute]
    public float Size
    {
      get { return _size; }
      set { _size = value; }
    }

    [JsonPropertyAttribute]
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    public void Update(float dt)
    {
      //Nothing to do for points
    }

    public void Render(Scene scene)
    {
      OkuManager.Instance.Graphics.DrawPoints(_vertices.Positions, _vertices.Colors, _vertices.Count, _size);
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
