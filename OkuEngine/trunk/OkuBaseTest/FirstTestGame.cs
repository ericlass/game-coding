using System;
using System.Collections.Generic;
using System.Text;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Settings;

namespace OkuBaseTest
{
  public class FirstTestGame : OkuGame
  {
    private Image _image = null;
    private float _angle = 0.0f;

    public override OkuSettings Configure()
    {
      OkuSettings result = base.Configure();

      result.Graphics.BackgroundColor = Color.Black;

      return result;
    }

    public override void Initialize()
    {
      ImageData data = ImageData.FromFile("pilz.png");
      _image = Oku.Instance.Graphics.NewImage(data);
    }

    public override void Update(float dt)
    {
      _angle -= 180 * dt;
      Vector2f center = Oku.Instance.Graphics.Viewport.Center;
      center.X = center.X + (50 * dt);
      Oku.Instance.Graphics.Viewport.Center = center;
    }

    public override void Render()
    {
      Oku.Instance.Graphics.Driver.DrawImage(_image, 0, 0, _angle, 1, 1, Color.White);
    }

  }
}
