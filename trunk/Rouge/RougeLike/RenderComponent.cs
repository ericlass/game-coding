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
    private Animation _animation = null;

    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    public Animation Animation
    {
      get { return _animation; }
      set { _animation = value; }
    }

    public void EnterState()
    {
      _animation.Restart();
    }
    
    public void Update(float dt)
    {
      _animation.Update(dt);
    }
    
    public void LeaveState()
    {
    }

    public string Id
    {
      get { return ComponentId; }
    }

  }
}
