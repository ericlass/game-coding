using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ForceEffector : IParticleEffector
  {
    private bool _enabled = true;
    private Vector2f _force = Vector2f.Zero;
    private AABB _area;

    public ForceEffector()
    {
      _area = new AABB(-10, -10, 20, 20);
    }

    public ForceEffector(AABB area)
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

    public AABB Area
    {
      get { return _area; }
      set { _area = value; }
    }

    public void Effect(Particle particle, float dt)
    {
      if (Intersections.PointInAABB(particle.Position, _area.Min, _area.Max))
        particle.Velocity += _force * dt;
    }

  }
}
