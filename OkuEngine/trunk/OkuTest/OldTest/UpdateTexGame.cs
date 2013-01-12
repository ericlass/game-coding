using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OkuEngine;

namespace OkuTest
{
  class UpdateTexGame : OkuGame
  {
    ImageContent _content = null;
    Bitmap[] _leds = null;
    int _current;

    float _lastTime = 0;

    public override void Initialize()
    {
      OkuManagers.Renderer.ClearColor = OkuEngine.Color.White;

      _leds = new Bitmap[4];
      _leds[0] = new Bitmap(".\\content\\led_red.png");
      _leds[1] = new Bitmap(".\\content\\led_green.png");
      _leds[2] = new Bitmap(".\\content\\led_blue.png");
      _leds[3] = new Bitmap(".\\content\\led_yellow.png");

      _content = new ImageContent(_leds[0]);
    }

    public override void Update(float dt)
    {
      float currentTime = _lastTime + dt;

      if (Math.Floor(currentTime) > Math.Floor(_lastTime))
      {
        _current = (int)(currentTime) % 4;
        _content.Update(0, 0, _content.Width, _content.Height, _leds[_current]);
      }

      _lastTime = currentTime;
    }

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawImage(_content, new Vector2f(0, 0));
    }

  }
}
