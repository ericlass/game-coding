using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Utils;
using JSONator;

namespace RougeLike
{
  public abstract class TileMapObjectBase : GameObjectBase
  {
    private Color DebugTintColor = new Color(0, 0, 0, 64);

    protected TileData _tileData = null;

    private const float CollisionOffset = 0.1f; // Defines a fixed offset for collision detection to handle edge cases

    public abstract override string ObjectType { get; }
    public abstract override void Update(float dt);

    public Rectangle2f GetMapRect()
    {
      float mapWidth = _tileData.Width * _tileData.TileWidth;
      float mapHeight = _tileData.Height * _tileData.TileHeight;

      float mapLeft = Position.X - (mapWidth * 0.5f);
      float mapBottom = Position.Y - (mapHeight * 0.5f);

      return new Rectangle2f(mapLeft, mapBottom, mapWidth, mapHeight);
    }

    public Vector2f WorldToTile(Vector2f p)
    {
      Rectangle2f mapRect = GetMapRect();
      Vector2f result = Vector2f.Zero;
      result.X = (int)((p.X - mapRect.Min.X) / _tileData.TileWidth);
      result.Y = (int)((p.Y - mapRect.Min.Y) / _tileData.TileHeight);
      return result;
    }

    public Rectangle2f GetTileRect(int x, int y)
    {
      Rectangle2f mapRect = GetMapRect();

      float left = mapRect.Min.X + (x * _tileData.TileWidth);
      float bottom = mapRect.Min.Y + (y * _tileData.TileHeight);

      return new Rectangle2f(left, bottom, _tileData.TileWidth, _tileData.TileHeight);
    }

    public bool IsInside(Vector2f p)
    {
      return GetMapRect().IsInside(p);
    }

    public Vector2f MoveBox(Rectangle2f box, Vector2f movement)
    {
      Rectangle2f mapRect = GetMapRect();
      if (!IntersectionTests.Rectangles(box.Min, box.Max, mapRect.Min, mapRect.Max))
        return movement;

      Vector2f result = Vector2f.Zero;

      if (movement.X != 0)
      {
        if (movement.X > 0)
        {
          int left = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Min.X - mapRect.Min.X) / _tileData.TileWidth)));
          int right = Math.Max(0, Math.Min(_tileData.Width - 1, (int)(((box.Max.X + movement.X) - mapRect.Min.X) / _tileData.TileWidth)));
          int bottom = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileData.TileHeight)));
          int top = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileData.TileHeight)));

          float bound = box.Max.X;
          float disp = movement.X;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (_tileData[i, j].TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                disp = Math.Min(disp, (tileRect.Min.X - CollisionOffset) - bound);
              }
            }
          }
          result.X = disp;
        }
        else
        {
          int left = Math.Max(0, Math.Min(_tileData.Width - 1, (int)(((box.Min.X + movement.X) - mapRect.Min.X) / _tileData.TileWidth)));
          int right = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Max.X - mapRect.Min.X) / _tileData.TileWidth)));
          int bottom = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileData.TileHeight)));
          int top = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileData.TileHeight)));

          float bound = box.Min.X;
          float disp = movement.X;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (_tileData[i, j].TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                disp = Math.Max(disp, (tileRect.Max.X + CollisionOffset) - bound);
              }
            }
          }
          result.X = disp;
        }
      }

      if (movement.Y != 0)
      {
        if (movement.Y > 0)
        {
          int left = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Min.X - mapRect.Min.X) / _tileData.TileWidth)));
          int right = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Max.X - mapRect.Min.X) / _tileData.TileWidth)));
          int bottom = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileData.TileHeight)));
          int top = Math.Max(0, Math.Min(_tileData.Height - 1, (int)(((box.Max.Y + movement.Y) - mapRect.Min.Y) / _tileData.TileHeight)));

          float bound = box.Max.Y;
          float disp = movement.Y;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (_tileData[i, j].TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                disp = Math.Min(disp, (tileRect.Min.Y - CollisionOffset) - bound);
              }
            }
          }
          result.Y = disp;
        }
        else
        {
          int left = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Min.X - mapRect.Min.X) / _tileData.TileWidth)));
          int right = Math.Max(0, Math.Min(_tileData.Width - 1, (int)((box.Max.X - mapRect.Min.X) / _tileData.TileWidth)));
          int bottom = Math.Max(0, Math.Min(_tileData.Height - 1, (int)(((box.Min.Y + movement.Y) - mapRect.Min.Y) / _tileData.TileHeight)));
          int top = Math.Max(0, Math.Min(_tileData.Height - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileData.TileHeight)));

          float bound = box.Min.Y;
          float disp = movement.Y;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (_tileData[i, j].TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                disp = Math.Max(disp, (tileRect.Max.Y + CollisionOffset) - bound);
              }
            }
          }
          result.Y = disp;
        }
      }

      return result;
    }

    public int CountTilesOnLine(Vector2f start, Vector2f end, int max)
    {
      Vector2f rayDir = end - start;

      if (rayDir.X == 0.0f && rayDir.Y == 0.0f)
        return 0;

      Rectangle2f mapRect = GetMapRect();
      if (!mapRect.IsInside(start))
      {
        throw new NotImplementedException("");
      }

      Vector2f startTile = WorldToTile(start);
      int x = (int)startTile.X;
      int y = (int)startTile.Y;

      Vector2f endTile = WorldToTile(end);

      int stepX = Math.Sign(rayDir.X);
      int stepY = Math.Sign(rayDir.Y);

      Rectangle2f startTileRect = GetTileRect(x, y);
      
      float tMaxX;
      float tDeltaX = _tileData.TileWidth / Math.Abs(rayDir.X);
      if (stepX > 0)
      {
        tMaxX = (startTileRect.Max.X - start.X) / (end.X - start.X);
      }
      else
      {
        tMaxX = (start.X - startTileRect.Min.X) / (start.X - end.X);
      }

      float tMaxY;
      float tDeltaY = _tileData.TileHeight / Math.Abs(rayDir.Y);
      if (stepY > 0)
      {
        tMaxY = (startTileRect.Max.Y - start.Y) / (end.Y - start.Y);
      }
      else
      {
        tMaxY = (start.Y - startTileRect.Min.Y) / (start.Y - end.Y);
      }

      int xLast = (int)GameUtil.Clamp(endTile.X + stepX, 0.0f, _tileData.Width);
      int yLast = (int)GameUtil.Clamp(endTile.Y + stepY, 0.0f, _tileData.Height);

      int result = 0;
      while (true)
      {
        if (_tileData[x, y].TileType != TileType.Empty)
        {
          result++;
          if (result >= max)
            break;
        }

        if (tMaxX < tMaxY)
        {
          x += stepX;
          if (x == xLast)
            break;
          tMaxX += tDeltaX;
        }
        else
        {
          y += stepY;
          if (y == yLast)
            break;
          tMaxY += tDeltaY;
        }
      }

      return result;
    }

    /// <summary>
    /// Calculates the color of the light at the given tile.
    /// </summary>
    /// <param name="x">The x coordinate of the tile.</param>
    /// <param name="y">The y coordinate of the tile.</param>
    /// <param name="light">The light to calculate.</param>
    /// <returns>The color of the light at the given tile.</returns>
    public Color GetLightValue(int x, int y, LightObject light)
    {
      float value = 1.0f;

      Vector2f center = GetTileRect(x, y).GetCenter();

      Vector2f lightPos = Vector2f.Zero;
      switch (light.LightType)
      {
        case LightType.Point:
          lightPos = light.Position;
          break;

        case LightType.Infinit:
          lightPos = center + (light.Direction * 1000.0f);
          break;

        default:
          throw new OkuException("Unsupported light type: '" + light.LightType.ToString() + "'!");
      }

      int count = CountTilesOnLine(center, lightPos, 5);
      value = 1.0f - (count / 5.0f);

      float attenuation = 1.0f;
      if (light.LightType != LightType.Infinit)
      {
        attenuation = GameUtil.Saturate(1.0f - Vector2f.Distance(center, lightPos) / light.Radius);
        attenuation *= attenuation;
      }

      value *= GameUtil.Saturate(attenuation * light.Power);

      if (value > 0.5f)
        System.Threading.Thread.Sleep(0);

      return light.Color * value;
    }

    public override void Render()
    {
      Rectangle2f mapRect = GetMapRect();

      Vector2f leftBottom = new Vector2f(Oku.Graphics.Viewport.Left, Oku.Graphics.Viewport.Bottom);
      leftBottom = WorldToTile(leftBottom);
      Vector2f rightTop = new Vector2f(Oku.Graphics.Viewport.Right, Oku.Graphics.Viewport.Top);
      rightTop = WorldToTile(rightTop);

      int left = Math.Max(0, (int)leftBottom.X);
      int right = Math.Min(_tileData.Width - 1, (int)rightTop.X + 1);
      int bottom = Math.Max(0, (int)leftBottom.Y);
      int top = Math.Min(_tileData.Height - 1, (int)rightTop.Y);

      float mapLeft = mapRect.Min.X;
      float mapBottom = mapRect.Min.Y;

      PlayerObject player = GameData.Instance.ActiveScene.GameObjects.GetObjectById("playerid") as PlayerObject;

      float maxDist = _tileData.TileWidth * 20;

      List<LightObject> lights = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfType<LightObject>();

      SpriteBatch batch = new SpriteBatch();
      batch.Begin();
      float wy = mapBottom + (bottom * _tileData.TileHeight) + (_tileData.TileHeight / 2);
      for (int y = bottom; y <= top; y++)
      {
        float wx = mapLeft + (left * _tileData.TileWidth) + (_tileData.TileWidth / 2);
        for (int x = left; x <= right; x++)
        {
          Tile tile = _tileData[x, y];
          if (tile.TileType != TileType.Empty)
          {
            Color tint = Color.White;

            if (lights.Count > 0)
            {
              tint = Color.Black;
              foreach (LightObject light in lights)
              {
                tint += GetLightValue(x, y, light);
              }
            }

            batch.Add(_tileData.GetImage(x, y), new Vector2f(wx, wy), tint);
          }

          wx += _tileData.TileWidth;
        }
        wy += _tileData.TileHeight;
      }
      batch.End();
      batch.Draw();

      if (GameData.Instance.DebugDraw)
      {
        for (int i = 0; i < _tileData.Width + 1; i++)
        {
          float x = mapRect.Min.X + (i * _tileData.TileWidth);
          Oku.Graphics.DrawLine(x, mapRect.Min.Y, x, mapRect.Max.Y, 1.0f, Color.Green);
        }
        for (int i = 0; i < _tileData.Height + 1; i++)
        {
          float y = mapRect.Min.Y + (i * _tileData.TileHeight);
          Oku.Graphics.DrawLine(mapRect.Min.X, y, mapRect.Max.X, y, 1.0f, Color.Green);
        }
      }
    }

    public override void Finish()
    {
      foreach (Image img in _tileData.Images)
        Oku.Graphics.ReleaseImage(img);
    }    

  }
}
