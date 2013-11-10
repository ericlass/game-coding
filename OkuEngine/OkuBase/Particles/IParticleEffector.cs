using System;

namespace OkuBase.Particles
{
  public interface IParticleEffector
  {
    bool Enabled { get; set; }
    void Effect(Particle particle, float dt);
  }
}
