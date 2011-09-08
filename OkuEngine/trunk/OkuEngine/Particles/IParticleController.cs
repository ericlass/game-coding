using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public interface IParticleController
  {
    void Update(Particle particle, float dt);
  }
}
