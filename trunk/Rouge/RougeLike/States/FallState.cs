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

    public const string StateId = "fall";

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
      _image = GameUtil.LoadImage("mario_fall.png");
    }

    public override void Enter(EntityObject entity)
    {
      _speed = 0.0f;
    }

    public override string Update(float dt, EntityObject entity)
    {
      _speed = Math.Min(_speed + (1500 * dt), 800);

      float speedx = (float)entity.GetAttributeValue<NumberValue>("speedx").Value;

      if (Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A))
        speedx -= 200 * dt;

      if (Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D))
        speedx += 200 * dt;

      speedx = GameUtil.Clamp(speedx, -300, 300);

      entity.GetAttributeValue<NumberValue>("speedx").Value = speedx;

      Vector2f movement = new Vector2f(speedx * dt, -_speed * dt);

      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      string result = null;

      Rectangle2f hitbox = entity.GetTransformedHitBox();

      float xBound = movement.X > 0 ? hitbox.Max.X : hitbox.Min.X;
      Vector2f bottomPoint = new Vector2f(hitbox.GetCenter().X, hitbox.Min.Y);
      Vector2f forwardPoint = new Vector2f(xBound, hitbox.GetCenter().Y);

      Vector2f dv = movement;
      Vector2f realMovement;
      if (tilemap.CollideMovingPoint(bottomPoint, movement, out realMovement))
      {
        dv.Y = realMovement.Y;
        result = WalkState.StateId;
      }

      if (tilemap.CollideMovingPoint(forwardPoint, movement, out realMovement))
      {
        dv.X = realMovement.X;
        entity.GetAttributeValue<NumberValue>("speedx").Value = 0;
      }

      Vector2f pos = entity.Position;
      pos += dv;
      entity.Position = pos;

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
