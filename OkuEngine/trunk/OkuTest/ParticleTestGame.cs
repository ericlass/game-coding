using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class ParticleTestGame : OkuGame
  {
    private ImageInstance _smiley = null;
    private float _rotation = 0.0f;
    private Vector _pos1 = new Vector(100, 100);

    public override void Initialize()
    {
      ImageContent content = new ImageContent(".\\content\\smiley.png");
      _smiley = new ImageInstance(content);
      _smiley.TintColor = Color.Green;
    }

    public override void Update(float dt)
    {
      _rotation += dt * 90;
    }

    public override void Render()
    {
      _smiley.Draw(_pos1, _rotation);
    }

  }
}
