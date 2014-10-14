using System;
using OkuBase.Geometry;

namespace OkuBase.Particles
{
  /// <summary>
  /// Defines a simple effector that applies a static, linear force to the particles.
  /// </summary>
  public class ForceEffector : IParticleEffector
  {
    private bool _enabled = true;
    private Vector2f _force = Vector2f.Zero;
    private Rectangle2f _area;

    /// <summary>
    /// Creates a new force effector.
    /// </summary>
    public ForceEffector()
    {
      _area = new Rectangle2f(-10, -10, 20, 20);
    }

    /// <summary>
    /// Creates a new force effector using the given area.
    /// </summary>
    /// <param name="area">The area of the effector.</param>
    public ForceEffector(Rectangle2f area)
    {
      _area = area;
    }

    /// <summary>
    /// Gets os set if the effector is enabled or not.
    /// </summary>
    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    /// <summary>
    /// Gets or sets the force the effector applies to the particles.
    /// </summary>
    public Vector2f Force
    {
      get { return _force; }
      set { _force = value; }
    }

    /// <summary>
    /// Gets or sets the area in which particles are affected.
    /// </summary>
    public Rectangle2f Area
    {
      get { return _area; }
      set { _area = value; }
    }

    /// <summary>
    /// Effects the given particle.
    /// </summary>
    /// <param name="particle">The particle to be effected.</param>
    /// <param name="dt">The time past since the last update.</param>
    public void Effect(Particle particle, float dt)
    {
      if (_area.IsInside(particle.Position))
        particle.Velocity += _force * dt;
    }

  }
}
