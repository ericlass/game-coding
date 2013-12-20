using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using System.Windows.Forms;

namespace RougeLike
{
  class PlayerGameObject : GameObjectBase
  {
    private Image _sprite = null;

    public override string ObjectType
    {
      get { return "player"; }
    }

    public override void Init()
    {
      ImageData data = ImageData.FromFile(".\\Content\\Graphics\\player_down_idle.png");
      _sprite = OkuManager.Instance.Graphics.NewImage(data);
    }

    public override void Update(float dt)
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

      Vector2f pos = Position;
      pos.X += dx;
      pos.Y += dy;
      Position = pos;
    }

    public override void Render()
    {
      OkuManager.Instance.Graphics.DrawImage(_sprite, Position.X, Position.Y);
    }

    public override void Finish()
    {
      OkuManager.Instance.Graphics.ReleaseImage(_sprite);
    }

    public override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    public override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "player";
    }
    
  }
}
