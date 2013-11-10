using System;

namespace OkuBase.Particles
{
  public class DefaultParticleController : IParticleController
  {
    public void Update(Particle particle, float dt)
    {
      particle.Update(dt);
    }

  }
}
