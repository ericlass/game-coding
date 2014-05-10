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

      Vector2f movement = new Vector2f(0, -_speed * dt);
      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      Vector2f realMovement = Vector2f.Zero;
      if (tilemap.MoveBox((gameObject as EntityObject).GetTransformedHitBox(), movement, out realMovement))
        GameData.Instance.EventQueue.QueueEvent(EventNames.PlayerFallEnd, null);

      Vector2f pos = gameObject.Position;
      pos.Y += realMovement.Y;
      pos.X += (float)gameObject.GetAttributeValue<NumberValue>("speedx").Value * dt;
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
