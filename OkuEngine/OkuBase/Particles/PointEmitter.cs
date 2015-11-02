using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuBase.Particles
{
  public class PointEmitter : ParticleEmitter
  {
    private Vector2f _center = Vector2f.Zero;

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

    public Vector2f Center
    {
      get { return _center; }
      set { _center = value; }
    }

  }
}
