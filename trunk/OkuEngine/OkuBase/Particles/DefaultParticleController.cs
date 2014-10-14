using System;

namespace OkuBase.Particles
{
  /// <summary>
  /// Defines a simple particle controller that moves the particle according to its velocity
  /// and updates the energy accordingly.
  /// </summary>
  public class DefaultParticleController : IParticleController
  {
    /// <summary>
    /// Updates the given particle.
    /// </summary>
    /// <param name="particle">The particle to be updated.</param>
    /// <param name="dt">The amount of time that passed since the last update.</param>
    public void Update(Particle particle, float dt)
    {
      particle.OldPosition = particle.Position;

      if (!particle.Velocity.IsZero())
        particle.Position = particle.Position + (particle.Velocity * dt);

      particle.Energy -= dt;
    }

  }
}
