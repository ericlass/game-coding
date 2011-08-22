using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public interface IParticleController
  {
    void Update(List<Particle> particles, float dt);
  }
}
