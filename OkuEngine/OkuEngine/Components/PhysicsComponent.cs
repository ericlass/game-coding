using System;

namespace OkuEngine.Components
{
  public class PhysicsComponent : IComponent
  {
    private float _gravityMultiplier = 1.0f;
    private float _bounce = 0.5f;
    private float _mass = 1.0f;

    public PhysicsComponent()
    {
    }

    public PhysicsComponent(float gravityMultiplier, float bounce, float mass)
    {
      _gravityMultiplier = gravityMultiplier;
      _bounce = bounce;
      _mass = mass;
    }

    public bool IsMultiAssignable
    {
      get{ return false; }
    }

    public string Name
    {
      get{ return "physics"; }
    }

    public IComponent Copy()
    {
      return new PhysicsComponent(_gravityMultiplier, _bounce, _mass);
    }

  }
}
