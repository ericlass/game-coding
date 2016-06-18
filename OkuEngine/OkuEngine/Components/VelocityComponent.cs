using System;
using OkuMath;

namespace OkuEngine.Components
{
  public class VelocityComponent : IComponent
  {
    public Vector2f _velocity = Vector2f.Zero;

    public VelocityComponent()
    {
    }

    public VelocityComponent(Vector2f velocity)
    {
      _velocity = velocity;
    }

    public Vector2f Velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return "velocity"; }
    }

    public IComponent Copy()
    {
      return new VelocityComponent(_velocity);
    }

  }
}
