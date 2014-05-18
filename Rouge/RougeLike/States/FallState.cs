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
      Vector2f realMovement = Vector2f.Zero;

      string result = null;
      

      if (tilemap.CollideMovingBox(entity.GetTransformedHitBox(), movement, out realMovement))
      {
        if (movement.X != realMovement.X)
          entity.GetAttributeValue<NumberValue>("speedx").Value = 0;

        if (movement.Y != realMovement.Y)
          result = WalkState.StateId;
      }

      Vector2f pos = entity.Position;
      pos.X += realMovement.X;
      pos.Y += realMovement.Y;      
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
