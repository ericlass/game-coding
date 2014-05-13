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

    public const string StateId = "jump";

    private float GetDirection(EntityObject entity)
    {
      NumberValue direction = entity.GetAttributeValue<NumberValue>("direction");
      return (float)direction.Value;
    }

    public override string Id
    {
      get { return StateId; }
    }

    public override void Init()
    {
      _image = GameUtil.LoadImage("mario_jump.png");
    }

    public override void Enter(EntityObject entity)
    {
      _speed = 800;
    }

    public override string Update(float dt, EntityObject entity)
    {
      float speedx = (float)entity.GetAttributeValue<NumberValue>("speedx").Value;

      Vector2f pos = entity.Position;
      //TODO: Check for collision
      pos.Y += _speed * dt;
      pos.X += speedx * dt;
      _speed -= 1500 * dt;
      entity.Position = pos;

      string result = null;

      if (_speed <= 0)
        result = FallState.StateId;

      return result;
    }

    public override void Render(EntityObject entity)
    {
      Oku.Graphics.DrawImage(_image, 0, 0, 0, GetDirection(entity), 1, Color.White);
    }

    public override void Leave(EntityObject entity)
    {
    }

    public override void Finish()
    {
      Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
