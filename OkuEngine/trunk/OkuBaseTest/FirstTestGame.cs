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

      //result.Graphics.BackgroundColor = Color.Black;

      return result;
    }

    public override void Initialize()
    {
      ImageData data = ImageData.FromFile("pilz.png");
      _image = Oku.Graphics.NewImage(data);
    }

    public override void Update(float dt)
    {
      _angle -= 180 * dt;
      
      /*Vector2f center = Oku.Graphics.Viewport.Center;
      center.X = center.X + (50 * dt);
      Oku.Graphics.Viewport.Center = center;*/

      Vector2f client = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
      Oku.Graphics.Driver.Display.Text = client.ToString();
    }

    public override void Render()
    {
      Oku.Graphics.Driver.DrawImage(_image, 0, 0, _angle, 1, 1, Color.White);
      Oku.Graphics.Driver.DrawPoint(0, 0, 1, Color.Red);
    }

  }
}
