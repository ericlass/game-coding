using System;
using System.Collections.Generic;
using OkuBase.Particles;

namespace RougeLike.Systems
{
  public class ParticleGameSystem : IGameSystem
  {
    private ParticleSystem<LineEmitter, CollidingParticleController, ImageParticleRenderer> _particleSystem = null;

    public void Init()
    {
      
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Finish()
    {
      throw new NotImplementedException();
    }
  }
}
