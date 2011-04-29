using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class ParticleTestGame : OkuGame
  {
    ImageContent _smiley = null;
    float rotation = 0.0f;

    public override void Initialize()
    {
      _smiley = new ImageContent(".\\content\\yinyang.png");
    }

    public override void Update(float dt)
    {
      rotation += dt * 360;
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawImage(_smiley, new Vector(100, 100), rotation);
    }

  }
}
