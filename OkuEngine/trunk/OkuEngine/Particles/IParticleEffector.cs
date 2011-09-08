using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public interface IParticleEffector
  {
    bool Enabled { get; set; }
    void Effect(Particle particle, float dt);
  }
}
