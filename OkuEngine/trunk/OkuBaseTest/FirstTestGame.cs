using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Audio;
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
    private Source _source = null;
    private RenderTarget _target = null;

    private int _counter = 0;
    private int _intervalId = 0;

    private Mesh _text = null;

    public override OkuSettings Configure()
    {
      OkuSettings result = base.Configure();

      result.Graphics.BackgroundColor = Color.Black;
      //result.Graphics.TextureFilter = TextureFilter.NearestNeighbor;

      return result;
    }

    public override void Initialize()
    {
      ImageData data = ImageData.FromFile("pilz.png");
      _image = Oku.Graphics.NewImage(data);

      SpriteFont font = new SpriteFont("Calibri", 12.0f, FontStyle.Regular, true);
      _text = font.GetStringMesh("Hello World!", 0, 0, Color.White);

      Oku.Input.OnKeyPressed += new KeyEventDelegate(Input_OnKeyPressed);
      Oku.Input.OnMouseReleased += new MouseEventDelegate(Input_OnMouseReleased);

      Sound sound = Sound.FromFile("sinus.wav");
      _source = Oku.Audio.NewSource(sound);

      _target = Oku.Graphics.NewRenderTarget(400, 300);
    }

    public void Input_OnMouseReleased(MouseButton button)
    {
      if (button == MouseButton.Left)
      {
        _position = Oku.Graphics.ScreenToWorld(Oku.Input.Mouse.X, Oku.Input.Mouse.Y);
        Oku.Graphics.Title = _position.ToString();
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
      if (key == Keys.S)
      {
        Oku.Audio.Play(_source);
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
      Oku.Graphics.SetRenderTarget(_target);
      Oku.Graphics.BackgroundColor = Color.Magenta;
      Oku.Graphics.Clear();

      Oku.Graphics.DrawImage(_image, _position.X, _position.Y, _angle, 1, 1, _tint);
      Oku.Graphics.DrawPoint(0, 0, 1, Color.Red);
      Oku.Graphics.DrawMesh(_text);

      Oku.Graphics.SetRenderTarget(null);
      Oku.Graphics.BackgroundColor = Color.Black;
      Oku.Graphics.Clear();
      
      //Oku.Graphics.DrawImage(_target, 0, 0);
      Oku.Graphics.DrawScreenAlignedQuad(_target);
    }

  }
}
