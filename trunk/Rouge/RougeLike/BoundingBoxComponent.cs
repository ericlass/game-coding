using System;
using OkuBase.Geometry;

namespace RougeLike
{
  public class BoundingBoxComponent : IComponent
  {
    public const string ComponentId = "aabb";

    private Entity _owner = null;
    private Rectangle2f _aabb;

    public string Id
    {
      get { return ComponentId; }
    }

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public Rectangle2f AABB
    {
      get { return _aabb; }
      set { _aabb = value; }
    }

    public void EnterState()
    {
    }
    
    public void Update(float dt)
    {
    }
    
    public void LeaveState()
    {
    }

  }
}
