using System;
using System.Collections.Generic;

namespace OkuEngine.Particles
{
  public interface IParticleRenderer
  {
    void Render(List<Particle> particles);
  }
}
