using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ForceEffector : IParticleEffector
  {
    private bool _enabled = true;
    private Vector _force = Vector.Zero;
    private Quad _area;

    public ForceEffector()
    {
      _area = new Quad(-10, -10, 20, 20);
    }

    public ForceEffector(Quad area)
    {
      _area = area;
    }

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public Vector Force
    {
      get { return _force; }
      set { _force = value; }
    }

    public Quad Area
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
