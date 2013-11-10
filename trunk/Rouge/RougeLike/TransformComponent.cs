using System;
using OkuBase.Geometry;

namespace RougeLike
{
  public class TransformComponent : IComponent
  {
    public const string ComponentId = "transform";

    private Entity _owner = null;
    private Vector2f _translation = Vector2f.Zero;

    public string Id
    {
      get { return ComponentId; }
    }

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public Vector2f Translation
    {
      get { return _translation; }
      set { _translation = value; }
    }

    public void Update(float dt)
    {
    }

  }
}
