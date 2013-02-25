using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
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
      OkuManagers.Renderer.DrawPoints(_vertices.Positions, _vertices.Colors, _vertices.Count, _size);
    }

    public AABB GetBoundingBox()
    {
      return _vertices.GetAABB();
    }

    public IRenderable Copy()
    {
      RenderablePoints result = new RenderablePoints();
      result._vertices = _vertices.Copy();
      result._size = _size;
      return result;
    }

    public bool AfterLoad()
    {
      return _vertices.AfterLoad();
    }

  }
}
