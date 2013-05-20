using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuBase.Timer;
using OkuBase.Input;

namespace OkuBaseTest
{
  public class FirstTestGame : OkuGame
  {
    private Image _image = null;
    private float _angle = 0.0f;
    private Vector2f _position = Vector2f.Zero;
    private Color _tint = Color.White;

    private int _counter = 0;
    private int _intervalId = 0;

    public override OkuSettings Configure()
    {
      OkuSettings result = base.Configure();

      result.Graphics.BackgroundColor = Color.Black;

      return result;
    }

    public override void Initialize()
    {
      ImageData data = ImageData.FromFile("pilz.png");
      _image = Oku.Graphics.NewImage(data);

      Oku.Input.OnKeyPressed += new KeyEventDelegate(Input_OnKeyPressed);
      Oku.Input.OnMouseReleased += new MouseEventDelegate(Input_OnMouseReleased);
    }

    public void Input_OnMouseReleased(MouseButton button)
    {
      if (button == MouseButton.Left)
      {
        _position = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
      }
    }

    public void Input_OnKeyPressed(Keys key)
    {
      if (key == Keys.Space && _counter <= 0)
      {
        _counter = 5;
        _intervalId = Oku.Timer.SetInterval(1000, new TimerEventDelegate(OnInterval));
      }
      if (key == Keys.T)
      {
        Oku.Timer.SetTimer(1000, new TimerEventDelegate(OnTimer));
      }
    }

    private void OnInterval(int id, object data)
    {
      Random rand = new Random();
      _position = new Vector2f(rand.Next(-350, 350), rand.Next(-250, 250));

      _counter -= 1;
      if (_counter <= 0)
        Oku.Timer.ClearInterval(_intervalId);
    }

    private void OnTimer(int id, object data)
    {
      _tint = Color.RandomColor(new Random());
    }

    public override void Update(float dt)
    {
      _angle -= 180 * dt;
    }

    public override void Render()
    {
      Oku.Graphics.Driver.DrawImage(_image, _position.X, _position.Y, _angle, 1, 1, _tint);
      Oku.Graphics.Driver.DrawPoint(0, 0, 1, Color.Red);
    }

  }
}
