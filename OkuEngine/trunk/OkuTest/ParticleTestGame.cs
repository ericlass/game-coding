using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTest
{
  public class ParticleTestGame : OkuGame
  {
    private ParticleSystem<PointEmitter, DefaultParticleController, PointParticleRenderer> _system = null;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      _system = new ParticleSystem<PointEmitter, DefaultParticleController, PointParticleRenderer>(new PointEmitter(), new DefaultParticleController(), new PointParticleRenderer());
      _system.Emitter.Center = new Vector(0, 0);
      _system.Emitter.BirthRate = 200.0f;
      _system.Emitter.AngleVariation = 1.0f;
      _system.Emitter.Speed = 25;
      _system.Emitter.SpeedVariation = 0.5f;
      _system.Emitter.Color = Color.Blue;
      _system.Renderer.PointSize = 5;
    }

    public override void Update(float dt)
    {
      _system.Update(dt);
    }

    public override void Render()
    {
      _system.Draw();
    }

  }
}
