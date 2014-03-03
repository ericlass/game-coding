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
    protected class Tile
    {
      public bool Walkable { get; set; }
      public int TileIndex { get; set; }
      public int Tag { get; set; }

      public Tile()
      {

      }

      public Tile(bool walkable, int tileIndex)
      {
        Walkable = walkable;
        TileIndex = tileIndex;
      }

      public Tile(bool walkable, int tileIndex, int tag) : this(walkable, tileIndex)
      {
        Tag = tag;
      }

    }

    private Color DebugTintColor = new Color(0, 0, 0, 64);

    protected int _tileWidth = 16;
    protected int _tileHeight = 16;
    protected Tile[,] _tiles = null;
    protected List<Image> _tileImages = null;

    private const float CollisionOffset = 0.1f; // Defines a fixed offset for collision detection to handle edge cases

    public abstract override string ObjectType { get; }
    public abstract override void Update(float dt);

    public Rectangle2f GetMapRect()
    {
      float mapWidth = _tiles.GetLength(0) * _tileWidth;
      float mapHeight = _tiles.GetLength(1) * _tileHeight;

      float mapLeft = Position.X - (mapWidth * 0.5f);
      float mapBottom = Position.Y - (mapHeight * 0.5f);

      return new Rectangle2f(mapLeft, mapBottom, mapWidth, mapHeight);
    }

    public Vector2f WorldToTile(Vector2f p)
    {
      Rectangle2f mapRect = GetMapRect();
      Vector2f result = Vector2f.Zero;
      result.X = (int)((p.X - mapRect.Min.X) / _tileWidth);
      result.Y = (int)((p.Y - mapRect.Min.Y) / _tileHeight);
      return result;
    }

    public Rectangle2f GetTileRect(int x, int y)
    {
      Rectangle2f mapRect = GetMapRect();

      float left = mapRect.Min.X + (x * _tileWidth);
      float bottom = mapRect.Min.Y + (y * _tileHeight);

      return new Rectangle2f(left, bottom, _tileWidth, _tileHeight);
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
          int left = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Min.X - mapRect.Min.X) / _tileWidth)));
          int right = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)(((box.Max.X + movement.X) - mapRect.Min.X) / _tileWidth)));
          int bottom = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileHeight)));
          int top = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileHeight)));

          float bound = box.Max.X;
          float disp = movement.X;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (!_tiles[i, j].Walkable)
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
          int left = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)(((box.Min.X + movement.X) - mapRect.Min.X) / _tileWidth)));
          int right = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Max.X - mapRect.Min.X) / _tileWidth)));
          int bottom = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileHeight)));
          int top = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileHeight)));

          float bound = box.Min.X;
          float disp = movement.X;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (!_tiles[i, j].Walkable)
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
          int left = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Min.X - mapRect.Min.X) / _tileWidth)));
          int right = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Max.X - mapRect.Min.X) / _tileWidth)));
          int bottom = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Min.Y - mapRect.Min.Y) / _tileHeight)));
          int top = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)(((box.Max.Y + movement.Y) - mapRect.Min.Y) / _tileHeight)));

          float bound = box.Max.Y;
          float disp = movement.Y;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (!_tiles[i, j].Walkable)
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
          int left = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Min.X - mapRect.Min.X) / _tileWidth)));
          int right = Math.Max(0, Math.Min(_tiles.GetLength(0) - 1, (int)((box.Max.X - mapRect.Min.X) / _tileWidth)));
          int bottom = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)(((box.Min.Y + movement.Y) - mapRect.Min.Y) / _tileHeight)));
          int top = Math.Max(0, Math.Min(_tiles.GetLength(1) - 1, (int)((box.Max.Y - mapRect.Min.Y) / _tileHeight)));

          float bound = box.Min.Y;
          float disp = movement.Y;
          for (int j = bottom; j <= top; j++)
          {
            for (int i = left; i <= right; i++)
            {
              if (!_tiles[i, j].Walkable)
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

    public int CountTilesOnLine(Vector2f start, Vector2f end)
    {
      Vector2f rayDir = end - start;

      if (rayDir.X == 0.0f && rayDir.Y == 0.0f)
        return 0;

      Rectangle2f mapRect = GetMapRect();
      if (!mapRect.IsInside(start))
      {
        throw new NotImplementedException("");
      }

      if (!mapRect.IsInside(end))
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
      float tDeltaX = _tileWidth / Math.Abs(rayDir.X);
      if (stepX > 0)
      {
        tMaxX = (startTileRect.Max.X - start.X) / (end.X - start.X);
      }
      else
      {
        tMaxX = (start.X - startTileRect.Min.X) / (start.X - end.X);
      }

      float tMaxY;
      float tDeltaY = _tileHeight / Math.Abs(rayDir.Y);
      if (stepY > 0)
      {
        tMaxY = (startTileRect.Max.Y - start.Y) / (end.Y - start.Y);
      }
      else
      {
        tMaxY = (start.Y - startTileRect.Min.Y) / (start.Y - end.Y);
      }

      int xLast = (int)endTile.X + stepX;
      int yLast = (int)endTile.Y + stepY;

      int result = 0;
      while (true)
      {
        if (!_tiles[x, y].Walkable)
          result++;

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

    public Color GetLightValue(int x, int y, LightObject light)
    {
      float value = 1.0f;

      Vector2f center = GetTileRect(x, y).GetCenter();

      int count = Math.Min(6, CountTilesOnLine(center, light.Position));
      value = 1.0f - (count / 6.0f);

      float attenuation = GameUtil.Saturate(1.0f - Vector2f.Distance(center, light.Position) / light.Radius);
      attenuation *= attenuation;

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
      int right = Math.Min(_tiles.GetLength(0) - 1, (int)rightTop.X + 1);
      int bottom = Math.Max(0, (int)leftBottom.Y);
      int top = Math.Min(_tiles.GetLength(1) - 1, (int)rightTop.Y);

      float mapLeft = mapRect.Min.X;
      float mapBottom = mapRect.Min.Y;

      PlayerObject player = GameData.Instance.ActiveScene.GameObjects.GetObjectById("playerid") as PlayerObject;

      float maxDist = _tileWidth * 20;

      List<LightObject> lights = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfType<LightObject>();

      SpriteBatch batch = new SpriteBatch();
      batch.Begin();
      float wy = mapBottom + (bottom * _tileHeight);
      for (int y = bottom; y <= top; y++)
      {
        float wx = mapLeft + (left * _tileWidth);
        for (int x = left; x <= right; x++)
        {
          Tile tile = _tiles[x, y];
          if (tile.TileIndex >= 0)
          {
            Color tint = Color.Black;

            foreach (LightObject light in lights)
            {
              tint += GetLightValue(x, y, light);
            }

            batch.Add(_tileImages[_tiles[x, y].TileIndex], new Vector2f(wx, wy), tint);

            if (GameData.Instance.DebugDraw && !_tiles[x, y].Walkable)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              Oku.Graphics.DrawRectangle(tileRect.Min.X, tileRect.Max.X, tileRect.Min.Y, tileRect.Max.Y, DebugTintColor);
            }
          }

          wx += _tileWidth;
        }
        wy += _tileHeight;
      }
      batch.End();
      batch.Draw();

      if (GameData.Instance.DebugDraw)
      {
        for (int i = 0; i < _tiles.GetLength(0) + 1; i++)
        {
          float x = mapRect.Min.X + (i * _tileWidth);
          Oku.Graphics.DrawLine(x, mapRect.Min.Y, x, mapRect.Max.Y, 1.0f, Color.Green);
        }
        for (int i = 0; i < _tiles.GetLength(1) + 1; i++)
        {
          float y = mapRect.Min.Y + (i * _tileHeight);
          Oku.Graphics.DrawLine(mapRect.Min.X, y, mapRect.Max.X, y, 1.0f, Color.Green);
        }
      }
    }

    public override void Finish()
    {
      foreach (Image img in _tileImages)
        Oku.Graphics.ReleaseImage(img);
    }    

  }
}
