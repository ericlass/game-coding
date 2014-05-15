using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Attributes;

namespace RougeLike.States
{
  public class WalkState : StateBase
  {
    private Animation _anim = null;

    public const string StateId = "walk";

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
      ImageBase frame0Img = GameUtil.LoadImage("mario_idle.png");
      ImageBase frame1Img = GameUtil.LoadImage("mario_right.png");

      _anim = new Animation();
      _anim.Frames.Add(frame0Img);
      _anim.Frames.Add(frame1Img);
      _anim.FrameTime = 50;
      _anim.Loop = true;
    }

    public override void Enter(EntityObject entity)
    {
      _anim.Restart();
    }

    public override string Update(float dt, EntityObject entity)
    {
      if (Oku.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.W))
        return JumpState.StateId;

      float accel = 1500;
      float maxSpeed = 300;

      float speed = (float)entity.GetAttributeValue<NumberValue>("speedx").Value;

      bool leftDown = Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A);
      bool rightDown = Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D);

      if (rightDown)
      {
        speed = Math.Min(speed + ((accel * dt)), maxSpeed);
        entity.GetAttributeValue<NumberValue>("direction").Value = 1;
      }

      if (leftDown)
      {
        speed = Math.Max(speed - ((accel * dt)), -maxSpeed);
        entity.GetAttributeValue<NumberValue>("direction").Value = -1;
      }

      if (!leftDown && !rightDown)
      {
        speed *= 0.99f;
        if (speed > -10 && speed < 10)
          speed = 0;
      }

      entity.GetAttributeValue<NumberValue>("speedx").Value = speed;

      Rectangle2f hitbox = entity.HitBox;
      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Vector2f pos = entity.Position;
      Vector2f dv = new Vector2f(speed * dt, 0);

      float bottom = pos.Y + hitbox.Min.Y;
      Vector2f bottomCenter = new Vector2f(pos.X, bottom);

      string result = null;
      
      TileType type = tileMap.GetTileBelow(bottomCenter);

      Oku.Graphics.Title = type.ToString();

      if (type == TileType.Empty)
      {
        result = FallState.StateId;
      }
      else
      {
        //This makes sure the player moves one the terrain including the slopes
        Nullable<float> y = tileMap.GetNextLowerY(bottomCenter);
        if (y != null)
          dv.Y = y.Value - bottom;
      }

      Vector2f maxMove = Vector2f.Zero;

      if (tileMap.MovePoint(bottomCenter, dv, out maxMove))
        dv = maxMove;

      entity.Position = pos + dv;

      _anim.Update(dt);

      return result;
    }

    public override void Render(EntityObject entity)
    {
      if (entity.GetAttributeValue<NumberValue>("speedx").Value == 0.0f)
        Oku.Graphics.DrawImage(_anim.Frames[0], 0, 0, 0, GetDirection(entity), 1, Color.White);
      else
        Oku.Graphics.DrawImage(_anim.CurrentFrame, 0, 0, 0, GetDirection(entity), 1, Color.White);
    }

    public override void Leave(EntityObject entity)
    {
    }

    public override void Finish()
    {
      foreach (ImageBase img in _anim.Frames)
        Oku.Graphics.ReleaseImage(img as Image);
    }
  }
}
