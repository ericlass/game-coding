using System;

namespace OkuEngine.Particles
{
  /// <summary>
  /// Particle effectors are used to change the properties of particles.
  /// </summary>
  public interface IParticleEffector
  {
    /// <summary>
    /// Gets or sets if the effector is enabled or not.
    /// </summary>
    bool Enabled { get; set; }

    /// <summary>
    /// Finally effects the given particle. This may change any property of the particle.
    /// </summary>
    /// <param name="particle">The particle to be effected.</param>
    /// <param name="dt">The time past since the last update.</param>
    void Effect(Particle particle, float dt);
  }
}
