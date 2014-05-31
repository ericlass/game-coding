using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;
using RougeLike.Objects;

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

    public ImageBase Image
    {
      get { return _image; }
      set { _image = value; }
    }

    public override void Init()
    {
    }

    public override void Enter(EntityObject entity)
    {
      _speed = 800;
    }

    public override string Update(float dt, EntityObject entity)
    {
      float speedx = (float)entity.GetAttributeValue<NumberValue>("speedx").Value;

      if (entity.Controller.DoMoveLeft(entity))
        speedx -= 200 * dt;

      if (entity.Controller.DoMoveRight(entity))
        speedx += 200 * dt;

      float maxSpeed = (float)entity.GetAttributeValue<NumberValue>("walkspeed").Value;
      speedx = GameUtil.Clamp(speedx, -maxSpeed, maxSpeed);

      entity.GetAttributeValue<NumberValue>("speedx").Value = speedx;

      //Make sure entity is facing into the correct direction
      if (speedx > 0)
        entity.GetAttributeValue<NumberValue>("direction").Value = 1;
      else if (speedx < 0)
        entity.GetAttributeValue<NumberValue>("direction").Value = -1;

      Vector2f pos = entity.Position;
      Vector2f dv = new Vector2f(speedx * dt, _speed * dt);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      
      Rectangle2f hitbox = entity.GetTransformedHitBox();

      float xBound = dv.X > 0 ? hitbox.Max.X : hitbox.Min.X;
      Vector2f topPoint = new Vector2f(hitbox.GetCenter().X, hitbox.Max.Y);
      Vector2f forwardPoint = new Vector2f(xBound, hitbox.GetCenter().Y);

      Vector2f maxMove;
      if (tileMap.CollideMovingPoint(topPoint, dv, out maxMove))
      {
        dv.Y = maxMove.Y;
        _speed = 0;
      }

      if (tileMap.CollideMovingPoint(forwardPoint, dv, out maxMove))
      {
        dv.X = maxMove.X;
        entity.GetAttributeValue<NumberValue>("speedx").Value = 0;
      }

      pos += dv;
      _speed -= 1500 * dt;
      entity.Position = pos;

      string result = null;

      if (_speed <= 0)
        result = FallState.StateId;

      return result;
    }

    public override void Render(EntityObject entity)
    {
      if (_image != null)
        Oku.Graphics.DrawImage(_image, 0, 0, 0, GetDirection(entity), 1, Color.White);
    }

    public override void Leave(EntityObject entity)
    {
    }

    public override void Finish()
    {
      if (_image != null)
        Oku.Graphics.ReleaseImage(_image as Image);
    }
  }
}
