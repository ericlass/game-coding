using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using OkuEngine;

namespace OkuTest
{
  public class ParticleTestGame : OkuGame
  {
    private ParticleSystem<PointEmitter, DefaultParticleController, PointParticleRenderer> _system = null;
    private ForceEffector _eff = null;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      _system = new ParticleSystem<PointEmitter, DefaultParticleController, PointParticleRenderer>(new PointEmitter(), new DefaultParticleController(), new PointParticleRenderer());
      _system.Emitter.Center = new Vector(0, 0);
      _system.Emitter.BirthRate = 200.0f;
      _system.Emitter.Angle = -90;
      _system.Emitter.AngleVariation = 0.05f;
      _system.Emitter.Speed = 250;
      _system.Emitter.SpeedVariation = 0.2f;
      _system.Emitter.Color = Color.Blue;
      _system.Renderer.PointSize = 3;

      _eff = new ForceEffector(new Quad(-300, 300, -300, 300));
      _eff.Force = new Vector(0, 200);
      _system.Effectors.Add(_eff);
    }

    public override void Update(float dt)
    {
      float torque = 90 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Left))
        _system.Emitter.Angle -= torque;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Right))
        _system.Emitter.Angle += torque;

      _system.Update(dt);

      Thread.Sleep(10);
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLines(_eff.Area.GetVertices(), 1, Color.Red, VertexInterpretation.PolygonClosed);
      _system.Draw();      
    }

  }
}
