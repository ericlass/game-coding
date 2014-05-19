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

      Rectangle2f thb = entity.GetTransformedHitBox();
      TileType type1 = tileMap.GetTileBelow(thb.Min);
      TileType type2 = tileMap.GetTileBelow(new Vector2f(thb.Max.X, thb.Min.Y));

      if (type1 == TileType.Empty && type2 == TileType.Empty)
        result = FallState.StateId;

      dv = WalkPlayer(pos, dv.X);

      /*Vector2f maxMove = Vector2f.Zero;

      if (tileMap.CollideMovingBox(entity.GetTransformedHitBox(), dv, out maxMove))
      {
        dv = maxMove;
        if (dv.X <= 0.1f && dv.X >= -0.1f)
        {
          dv.X = 0;
          entity.GetAttributeValue<NumberValue>("speedx").Value = 0;
        }
      }*/

      entity.Position = pos + dv;

      _anim.Update(dt);

      return result;
    }

    private Vector2f WalkPlayer(Vector2f pos, float dx)
    {
      if (dx == 0)
        return Vector2f.Zero;

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Vector2f tilePos = tileMap.WorldToTile(pos);
      int startX = (int)tilePos.X;
      int y = (int)tilePos.Y;

      Vector2f tileEndPos = tileMap.WorldToTile(new Vector2f(pos.X + dx, pos.Y));
      int endX = (int)tileEndPos.X;

      Vector2f result = new Vector2f(dx, 0);

      if (dx > 0)
      {
        for (int i = startX; i <= endX; i++)
        {
          Tile tile = tileMap.TileData[i, y];
          Rectangle2f tileRect = tileMap.GetTileRect(i, y);

          switch (tile.TileType)
          {
            case TileType.Empty:
              break;

            case TileType.Filled:
              result.X = Math.Min(result.X, pos.X - tileRect.Min.X);
              break;

            case TileType.SouthEast:
              float part = endX - tileRect.Min.X;
              result.Y += GameUtil.Clamp(part, 0, tileMap.TileData.TileWidth);
              break;

            case TileType.SouthWest:
              part = endX - tileRect.Min.X;
              result.Y -= GameUtil.Clamp(part, 0, tileMap.TileData.TileWidth);
              break;

            case TileType.NorthEast:
              throw new NotImplementedException();

            case TileType.NorthWest:
              throw new NotImplementedException();

            default:
              throw new OkuBase.OkuException("Unsupported tile type: " + tile.TileType.ToString());
          }
        }
      }
      else
      {

      }

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
