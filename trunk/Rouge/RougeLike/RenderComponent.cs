using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public class RenderComponent : IComponent
  {
    public const string ComponentId = "render";

    private Entity _owner = null;
    private Mesh _mesh = null;

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public Mesh Mesh
    {
      get { return _mesh; }
      set { _mesh = value; }
    }

    public void Update(float dt)
    {      
    }

    public string Id
    {
      get { return ComponentId; }
    }

  }
}
