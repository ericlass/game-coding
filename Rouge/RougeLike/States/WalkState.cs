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

    private float GetDirection(GameObjectBase gameObject)
    {
      NumberValue direction = gameObject.GetAttributeValue<NumberValue>("direction");
      return (float)direction.Value;
    }

    public override string Id
    {
      get { return "walk"; }
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

    public override void Enter(GameObjectBase gameObject)
    {
      _anim.Restart();
    }

    public override void Update(float dt, GameObjectBase gameObject)
    {
      float accel = 1500;
      float maxSpeed = 300;

      float speed = (float)gameObject.GetAttributeValue<NumberValue>("speedx").Value;

      bool leftDown = Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.A);
      bool rightDown = Oku.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.D);

      if (rightDown)
        speed = Math.Min(speed + ((accel * dt)), maxSpeed);

      if (leftDown)
        speed = Math.Max(speed - ((accel * dt)), -maxSpeed);

      if (!leftDown && !rightDown)
      {
        speed *= 0.99f;
        if (speed > -10 && speed < 10)
          speed = 0;
      }

      Oku.Graphics.Title = speed.ToString();
      gameObject.GetAttributeValue<NumberValue>("speedx").Value = speed;

      Rectangle2f hitbox = (gameObject as EntityObject).HitBox;
      Vector2f pos = gameObject.Position;
      pos = pos + new Vector2f(speed * dt, 0);
      float bottom = pos.Y + hitbox.Min.Y;

      Vector2f bottomCenter = new Vector2f(pos.X, bottom);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      TileType type = tileMap.GetTileBelow(bottomCenter);

      if (type == TileType.Empty)
      {
        GameData.Instance.EventQueue.QueueEvent(EventNames.PlayerFallStart, null);
      }
      else
      {
        Nullable<float> y = tileMap.GetNextLowerY(bottomCenter);
        if (y != null)
          pos.Y = y.Value - hitbox.Min.Y;
      }

      gameObject.Position = pos;

      _anim.Update(dt);
    }

    public override void Render(GameObjectBase gameObject)
    {
      if (gameObject.GetAttributeValue<NumberValue>("speedx").Value == 0.0f)
        Oku.Graphics.DrawImage(_anim.Frames[0], 0, 0, 0, GetDirection(gameObject), 1, Color.White);
      else
        Oku.Graphics.DrawImage(_anim.CurrentFrame, 0, 0, 0, GetDirection(gameObject), 1, Color.White);
    }

    public override void Leave(GameObjectBase gameObject)
    {
    }

    public override void Finish()
    {
      foreach (ImageBase img in _anim.Frames)
        Oku.Graphics.ReleaseImage(img as Image);
    }
  }
}
