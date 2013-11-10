using System;
using System.Collections.Generic;

namespace OkuBase.Particles
{
  public interface IParticleRenderer
  {
    void Render(List<Particle> particles);
  }
}
