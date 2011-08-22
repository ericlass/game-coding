using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public interface IParticleEmitter
  {
    void Emit(List<Particle> particles, float dt);
  }
}
