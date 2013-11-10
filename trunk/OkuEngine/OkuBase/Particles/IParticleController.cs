using System;

namespace OkuBase.Particles
{
  public interface IParticleController
  {
    void Update(Particle particle, float dt);
  }
}
