﻿using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Controller;
using RougeLike.Objects;
using RougeLike.States;
using RougeLike.Tiles;

namespace RougeLike.Behaviors
{
  public class WalkBehavior : IBehavior
  {
    public void Begin(EntityObject entity)
    {
    }

    public string Update(float dt, EntityObject entity)
    {
      if (entity.Controller.DoJump(entity))
        return StateIds.Jump;

      float accel = 1500;
      float maxSpeed = (float)entity.GetAttributeValue<NumberValue>("walkspeed").Value;

      float speed = (float)entity.GetAttributeValue<NumberValue>("speedx").Value;

      bool leftDown = entity.Controller.DoMoveLeft(entity);
      bool rightDown = entity.Controller.DoMoveRight(entity);

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
        speed -= (1000 * dt) * Math.Sign(speed);
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
      TileType type1 = tileMap.GetTileBelow(new Vector2f(thb.Min.X, thb.Min.Y + 0.001f));
      TileType type2 = tileMap.GetTileBelow(new Vector2f(thb.Max.X, thb.Min.Y + 0.001f));

      if (type1 == TileType.Empty && type2 == TileType.Empty)
        result = StateIds.Fall;

      Vector2f movement = WalkPlayer(entity.GetTransformedHitBox(), dv.X);

      if (movement.X != dv.X)
        entity.GetAttributeValue<NumberValue>("speedx").Value = 0;

      entity.Position = pos + movement;

      return result;
    }

    private Vector2f WalkPlayer(Rectangle2f hitbox, float dx)
    {
      if (dx == 0)
        return Vector2f.Zero;

      Vector2f bottomCenter = new Vector2f(hitbox.GetCenter().X, hitbox.Min.Y + 0.0001f);

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
                possibleX = (tileRect.Max.X - hitbox.Min.X) + 0.0f;
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

      for (int x = startX; x <= endX; x++)
      {
        Tile tile = tileMap.TileData[x, ty];
        Rectangle2f tileRect = tileMap.GetTileRect(x, ty);

        float moveStartX = 0;
        float moveEndX = 0;

        if (possibleX > 0)
        {
          moveStartX = Math.Max(bottomCenter.X, tileRect.Min.X);
          moveEndX = Math.Min(bottomCenter.X + possibleX, tileRect.Max.X);
        }
        else
        {
          moveStartX = Math.Min(bottomCenter.X, tileRect.Max.X);
          moveEndX = Math.Max(bottomCenter.X + possibleX, tileRect.Min.X);
        }

        float moveDX = moveEndX - moveStartX;

        switch (tile.TileType)
        {
          case TileType.Empty:
            Tile tileBelow = tileMap.TileData[x, ty - 1];
            Rectangle2f tileBelowRect = tileMap.GetTileRect(x, ty - 1);

            if (tileBelow.TileType == TileType.SouthWest)
              result.Y -= moveDX > 0 ? Math.Min(moveDX, bottomCenter.Y - tileBelowRect.Min.Y) : Math.Max(moveDX, tileBelowRect.Max.Y - bottomCenter.Y);
            else if (tileBelow.TileType == TileType.SouthEast)
              result.Y += moveDX > 0 ? Math.Min(moveDX, tileBelowRect.Max.Y - bottomCenter.Y) : Math.Max(moveDX, tileBelowRect.Min.Y - bottomCenter.Y);

            break;

          case TileType.Filled:
          case TileType.NorthEast:
          case TileType.NorthWest:
            result.Y = tileRect.Max.Y - bottomCenter.Y;
            break;

          case TileType.SouthEast:
            result.Y += moveDX > 0 ? Math.Min(moveDX, tileRect.Max.Y - bottomCenter.Y) : Math.Max(moveDX, tileRect.Min.Y - bottomCenter.Y);
            break;

          case TileType.SouthWest:
            result.Y -= moveDX > 0 ? Math.Min(moveDX, bottomCenter.Y - tileRect.Min.Y) : Math.Max(moveDX, bottomCenter.Y - tileRect.Max.Y);
            break;

          default:
            throw new NotSupportedException("Unsupported tile type: " + tile.TileType.ToString());
        }
      }

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