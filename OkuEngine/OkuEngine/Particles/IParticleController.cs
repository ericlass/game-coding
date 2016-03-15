using System;

namespace OkuEngine.Particles
{
  public interface IParticleController
  {
    void Update(Particle particle, float dt);
  }
}
