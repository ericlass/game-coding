using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public interface IParticleRenderer
  {
    void Render(List<Particle> particles);
  }
}
