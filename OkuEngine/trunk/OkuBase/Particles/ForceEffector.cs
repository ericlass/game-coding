using System;
using OkuBase.Geometry;

namespace OkuBase.Particles
{
  public class ForceEffector : IParticleEffector
  {
    private bool _enabled = true;
    private Vector2f _force = Vector2f.Zero;
    private Rectangle2f _area;

    public ForceEffector()
    {
      _area = new Rectangle2f(-10, -10, 20, 20);
    }

    public ForceEffector(Rectangle2f area)
    {
      _area = area;
    }

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public Vector2f Force
    {
      get { return _force; }
      set { _force = value; }
    }

    public Rectangle2f Area
    {
      get { return _area; }
      set { _area = value; }
    }

    public void Effect(Particle particle, float dt)
    {
      if (_area.IsInside(particle.Position))
        particle.Velocity += _force * dt;
    }

  }
}
