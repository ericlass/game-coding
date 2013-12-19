using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using System.Windows.Forms;

namespace RougeLike
{
  class PlayerGameObject : IGameObject
  {
    private Vector2f _position = Vector2f.Zero;
    private Image _sprite = null;

    public string ObjectType
    {
      get { return "player"; }
    }

    public void Init()
    {
      ImageData data = ImageData.FromFile(".\\Content\\Graphics\\player_down_idle.png");
      _sprite = OkuManager.Instance.Graphics.NewImage(data);
    }

    public void Update(float dt)
    {
      float speed = 120.0f * dt;
      float dx = 0;
      float dy = 0;

      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Left))
        dx -= speed;
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Right))
        dx += speed;
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Down))
        dy -= speed;
      if (OkuManager.Instance.Input.Keyboard.KeyIsDown(Keys.Up))
        dy += speed;

      _position.X += dx;
      _position.Y += dy;
    }

    public void Render()
    {
      OkuManager.Instance.Graphics.DrawImage(_sprite, _position.X, _position.Y);
    }

    public void Finish()
    {
      OkuManager.Instance.Graphics.ReleaseImage(_sprite);
    }

    public StringPairMap Save()
    {
      throw new NotImplementedException();
    }

    public void Load(StringPairMap data)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "player";
    }

  }
}
