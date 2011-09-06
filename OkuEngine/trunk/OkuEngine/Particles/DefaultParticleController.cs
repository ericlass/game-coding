using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class DefaultParticleController : IParticleController
  {
    public void Update(List<Particle> particles, float dt)
    {
      foreach (Particle p in particles)
      {
        if (!p.IsDead)
          p.Update(dt);
      }
    }

  }
}
