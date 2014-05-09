using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;

namespace RougeLike.States
{
  public class FallState : StateBase
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
      get { return "fall"; }
    }

    public override void Init()
    {
      _image = GameUtil.LoadImage("mario_fall.png");
    }

    public override void Enter(GameObjectBase gameObject)
    {
      _speed = 0.0f;
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      _speed = Math.Max(_speed + (1500 * dt), 100);

      Vector2f pos = gameObject.Position;
      pos.Y -= _speed * dt;

      //TODO: Check for real collision
      if (pos.Y <= 500)
      {
        pos.Y = 500;
        GameData.Instance.EventQueue.QueueEvent(EventNames.PlayerFallEnd, null);
      }

      gameObject.Position = pos;
    }

    public override void Render(GameObjectBase gameObject)
    {
      Oku.Graphics.DrawImage(_image, 0, 0, 0, GetDirection(gameObject), 1, Color.White);
    }

    public override void Leave(GameObjectBase gameObject)
    {
    }

    public override void Finish()
    {
      Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
