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

      if (Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A))
        speedx -= 200 * dt;

      if (Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D))
        speedx += 200 * dt;

      speedx = GameUtil.Clamp(speedx, -300, 300);

      entity.GetAttributeValue<NumberValue>("speedx").Value = speedx;      

      if (speedx > 0)
        entity.GetAttributeValue<NumberValue>("direction").Value = 1;
      else if (speedx < 0)
        entity.GetAttributeValue<NumberValue>("direction").Value = -1;

      Vector2f pos = entity.Position;
      Vector2f dv = new Vector2f(speedx * dt, _speed * dt);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      
      Rectangle2f hitbox = entity.GetTransformedHitBox();
      
      float xBound = dv > 0 ? hitBox.Max.X : hitBox.Min.X;
      Vector2f[] collisionPoints = new Vector2f[] { new Vector2f(hitbox.GetCenter().X, hitbox.Max.Y), new Vector2f(xBound, hitbox.GetCenter().Y) };
      
      bool collision = false;
      Vector2f maxMove = dv;
      foreach (Vector2f cp : collisionPoints)
      {
        Vector2f maxD;
        if (tileMap.CollideMovingPoint(cp, dv, out maxD))
        {
          collision = true;
          maxMove.X = GameUtil.ClosestToZero(maxMove.X, maxD.X);
          maxMove.Y = GameUtil.ClosestToZero(maxMove.Y, maxD.Y);
        }
      }
      
      if (collision)
      {
        if (maxMove.X != dv.X)
        {
          dv.X = 0;
          entity.GetAttributeValue<NumberValue>("speedx").Value = 0;
        }

        if (maxMove.Y != dv.Y)
        {
          dv.Y = 0;
          _speed = 0;
        }
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
