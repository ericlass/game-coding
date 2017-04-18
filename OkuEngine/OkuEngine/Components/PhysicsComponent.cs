using System;

namespace OkuEngine.Components
{
  public class PhysicsComponent : Component
  {
    private float _gravityMultiplier = 1.0f;
    private float _bounce = 0.5f;
    private float _mass = 1.0f;

    public PhysicsComponent()
    {
    }

    public PhysicsComponent(float gravityMultiplier, float bounce, float mass)
    {
      GravityMultiplier = gravityMultiplier;
      Bounce = bounce;
      Mass = mass;
    }

    public override bool IsMultiAssignable
    {
      get{ return false; }
    }

    public override string Name
    {
      get{ return "physics"; }
    }

    public float Mass { get => _mass; set => _mass = value; }

    public float Bounce { get => _bounce; set => _bounce = value; }

    public float GravityMultiplier { get => _gravityMultiplier; set => _gravityMultiplier = value; }

    public override Component Copy()
    {
      return new PhysicsComponent(GravityMultiplier, Bounce, Mass);
    }

  }
}
