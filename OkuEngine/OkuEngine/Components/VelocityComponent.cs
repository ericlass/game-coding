using System;
using OkuMath;

namespace OkuEngine.Components
{
  /// <summary>
  /// Defines the velocity of an entity in world units per second.
  /// </summary>
  public class VelocityComponent : Component
  {
    public Vector2f _velocity = Vector2f.Zero;

    /// <summary>
    /// Creates a new velocaity component.
    /// </summary>
    public VelocityComponent()
    {
    }

    /// <summary>
    /// Creates a new velocity component with the given velocity.
    /// </summary>
    /// <param name="velocity">The velocity in world untis per second.</param>
    public VelocityComponent(Vector2f velocity)
    {
      _velocity = velocity;
    }

    /// <summary>
    /// Gets or set the velocity in world untis per second.
    /// </summary>
    public Vector2f Velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }

    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    public override string Name
    {
      get { return "velocity"; }
    }

    public override Component Copy()
    {
      return new VelocityComponent(_velocity);
    }

  }
}
