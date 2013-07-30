using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuEngine.Scenes;
using Newtonsoft.Json;

namespace OkuEngine.Rendering
{
  public class RenderableMesh : IRenderable
  {
    private Mesh _mesh = null;

    [JsonPropertyAttribute]
    public Mesh Mesh
    {
      get { return _mesh; }
      set { _mesh = value; }
    }

    public void Update(float dt)
    {
      //Nothing to do for mesh
    }

    public void Render(Scene scene)
    {
       OkuManager.Instance.Graphics.DrawMesh(_mesh);
    }

    public Rectangle2f GetBoundingBox()
    {
      return _mesh.Vertices.Positions.GetBoundingBox();
    }

    public Circle GetBoundingCircle()
    {
      if (_mesh.Vertices.Positions != null)
        return _mesh.Vertices.Positions.GetBoundingCircleCentered();

      return default(Circle);
    }

    public bool AfterLoad()
    {
      return true;
    }

  }
}
