using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Controller;
using RougeLike.Objects;
using RougeLike.States;

namespace RougeLike.Behaviors
{
  public class FallBehavior : IBehavior
  {
    private float _speed = 0.0f;

    public string Update(float dt, EntityObject entity)
    {
      _speed = Math.Min(_speed + (1500 * dt), 800);

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
        result = StateIds.Walk;
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

    public void Begin(EntityObject entity)
    {
      _speed = 0.0f;
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
