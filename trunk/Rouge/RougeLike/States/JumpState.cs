using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;

namespace RougeLike.States
{
  public class JumpState : StateBase
  {
    private ImageBase _image = null;
    private float _speed = 0.0f;

    private float GetDirection(GameObjectBase gameObject)
    {
      NumberValue direction = gameObject.GetAttributeValue<NumberValue>("direction");
      return (float)direction.Value;
    }

    public override string Id
    {
      get { return "jump"; }
    }

    public override void Init()
    {
      _image = GameUtil.LoadImage("mario_jump.png");
    }

    public override void Enter(GameObjectBase gameObject)
    {
      _speed = 500;
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      Vector2f pos = gameObject.Position;
      pos.Y += _speed * dt;
      _speed -= 100 * dt;
      gameObject.Position = pos;

      if (_speed <= 0)
        GameData.Instance.EventQueue.QueueEvent(EventNames.PlayerJumpStart, null);
    }

    public override void Render(GameObjectBase gameObject)
    {
      Oku.Graphics.DrawImage(_image, 0, 0, 0, GetDirection(gameObject), 1, Color.White);
    }

    public override void Leave(GameObjectBase gameObject)
    {
      throw new NotImplementedException();
    }

    public override void Finish()
    {
      Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
