using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PointEmitter : ParticleEmitter
  {
    private Vector _center = Vector.Zero;

    public override void Emit(List<Particle> particles, float dt)
    {
      int numParticles = GetNumParticleToEmit(dt);
      for (int i = 0; i < numParticles; i++)
      {
        Particle p = AddParticle(particles);
        p.Position = _center;
        p.OldPosition = _center;
      }
    }

    public Vector Center
    {
      get { return _center; }
      set { _center = value; }
    }

  }
}
