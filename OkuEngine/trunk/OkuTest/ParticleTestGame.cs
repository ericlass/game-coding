using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using OkuEngine;

namespace OkuTest
{
  public class ParticleTestGame : OkuGame
  {
    private ParticleSystem<LineEmitter, DefaultParticleController, PointParticleRenderer> _system = null;
    private ForceEffector _eff = null;

    public override void Initialize()
    {
      OkuDrivers.Renderer.ClearColor = Color.White;

      _system = new ParticleSystem<LineEmitter, DefaultParticleController, PointParticleRenderer>(new LineEmitter(), new DefaultParticleController(), new PointParticleRenderer());
      //_system.Emitter.Center = new Vector(0, 0);
      _system.Emitter.Start = new Vector(-100, 0);
      _system.Emitter.End = new Vector(100, 0);
      _system.Emitter.NormalDirection = false;
      _system.Emitter.BirthRate = 200.0f;
      _system.Emitter.Angle = 90;
      _system.Emitter.AngleVariation = 0.05f;
      _system.Emitter.Speed = 250;
      _system.Emitter.SpeedVariation = 0.2f;
      _system.Emitter.Color = Color.Blue;

      _system.Renderer.PointSize = 3;

      _eff = new ForceEffector(new Quad(-300, -300, 600, 600));
      _eff.Force = new Vector(0, -200);
      _system.Effectors.Add(_eff);
    }

    public override void Update(float dt)
    {
      dt = dt * 0.5f;

      float torque = 90 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Left))
        _system.Emitter.Angle += torque;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(Keys.Right))
        _system.Emitter.Angle -= torque;

      _system.Update(dt);

      Thread.Sleep(10);
    }

    public override void Render(int pass)
    {
      //OkuDrivers.Renderer.DrawLines(_eff.Area.GetVertices(), Color.Red, 4, 1, VertexInterpretation.PolygonClosed);

      if (_system.Emitter is LineEmitter)
      {
        OkuDrivers.Renderer.DrawLine(_system.Emitter.Start, _system.Emitter.End, 2.0f, Color.Green);
      }

      _system.Draw();      
    }

  }
}
