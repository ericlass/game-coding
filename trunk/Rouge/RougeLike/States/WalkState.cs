﻿using System;
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

      Vector2f movement = WalkPlayer(entity.GetTransformedHitBox(), dv.X);

      if (movement.X != dv.X)
        entity.GetAttributeValue<NumberValue>("speedx").Value = 0;

      entity.Position = pos + movement;

      _anim.Update(dt);

      return result;
    }

    private Vector2f WalkPlayer(Rectangle2f hitbox, float dx)
    {
      if (dx == 0)
        return Vector2f.Zero;

      Vector2f bottomCenter = new Vector2f(hitbox.GetCenter().X, hitbox.Min.Y);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      float possibleX = dx;
      //Check if movement means collision
      if (possibleX > 0)
      {
        Vector2f topTile = tileMap.WorldToTile(hitbox.Max);
        Vector2f leftTile = tileMap.WorldToTile(bottomCenter);
        Vector2f rightTile = tileMap.WorldToTile(new Vector2f(hitbox.Max.X + dx, bottomCenter.Y));
        
        int left = (int)leftTile.X;
        int right = (int)rightTile.X;
        int bottom = (int)leftTile.Y;
        int top = (int)topTile.Y;

        for (int y = bottom; y <= top; y++)
        {
          for (int x = left; x <= right; x++)
          {
            Tile tile = tileMap.TileData[x, y];
            Tile tileLeft = tileMap.TileData[x - 1, y];
            if (tile.TileType == TileType.Filled || tile.TileType == TileType.NorthEast || tile.TileType == TileType.NorthWest)
            {
              if (tileLeft.TileType != TileType.SouthEast)
              {
                Rectangle2f tileRect = tileMap.GetTileRect(x, y);
                possibleX = tileRect.Min.X - hitbox.Max.X;
              }
            }
          }
        }
      }
      else
      {
        Vector2f topTile = tileMap.WorldToTile(hitbox.Max);
        Vector2f rightTile = tileMap.WorldToTile(bottomCenter);
        Vector2f leftTile = tileMap.WorldToTile(new Vector2f(hitbox.Min.X + dx, bottomCenter.Y));

        int left = (int)leftTile.X;
        int right = (int)rightTile.X;
        int bottom = (int)leftTile.Y;
        int top = (int)topTile.Y;

        for (int y = bottom; y <= top; y++)
        {
          for (int x = right; x >= left; x--)
          {
            Tile tile = tileMap.TileData[x, y];
            Tile tileRight = tileMap.TileData[x + 1, y];
            if (tile.TileType == TileType.Filled || tile.TileType == TileType.NorthEast || tile.TileType == TileType.NorthWest)
            {
              if (tileRight.TileType != TileType.SouthWest)
              {
                Rectangle2f tileRect = tileMap.GetTileRect(x, y);
                possibleX = (tileRect.Max.X - hitbox.Min.X);
              }
            }
          }
        }
      }

      // Move player along terrain
      Vector2f startTile = tileMap.WorldToTile(bottomCenter);
      Vector2f endTile = tileMap.WorldToTile(new Vector2f(bottomCenter.X + possibleX, bottomCenter.Y));

      int startX = (int)startTile.X;
      int endX = (int)endTile.X;
      int ty = (int)startTile.Y;

      Vector2f result = new Vector2f(possibleX, 0);

      if (startX == endX)
      {
        Tile tile = tileMap.TileData[startX, ty];
        Rectangle2f tileRect = tileMap.GetTileRect(startX, ty);

        switch (tile.TileType)
        {
          case TileType.Empty:
            Tile tileBelow = tileMap.TileData[startX, ty - 1];

            if (tileBelow.TileType == TileType.SouthWest)
              result.Y = -possibleX;
            else if (tileBelow.TileType == TileType.SouthEast)
              result.Y = possibleX;

            break;

          case TileType.Filled:
          case TileType.NorthEast:
          case TileType.NorthWest:
            result.Y = tileRect.Max.Y - bottomCenter.Y;
            break;

          case TileType.SouthEast:
            result.Y = possibleX;
            break;

          case TileType.SouthWest:
            result.Y = -possibleX;
            break;

          default:
            throw new NotSupportedException("Unsupported tile type: " + tile.TileType.ToString());
        }
      }
      else
      {
        System.Diagnostics.Debug.WriteLine("NOT IMPLEMENTED!");
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
