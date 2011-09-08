using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class DefaultParticleController : IParticleController
  {
    public void Update(Particle particle, float dt)
    {
      particle.Update(dt);
    }

  }
}
