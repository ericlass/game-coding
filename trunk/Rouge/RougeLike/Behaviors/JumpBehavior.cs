using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Controller;
using RougeLike.Objects;
using RougeLike.States;

namespace RougeLike.Behaviors
{
  public class JumpBehavior : IBehavior
  {
    private float _speed = 0.0f;

    public void Begin(EntityObject entity)
    {
      _speed = 800;
    }

    public string Update(float dt, EntityObject entity)
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
        result = StateIds.Fall;

      return result;
    }

    public void End(EntityObject entity)
    {
    }

    public void Init()
    {
    }

    public void Finish()
    {
    }

  }
}
