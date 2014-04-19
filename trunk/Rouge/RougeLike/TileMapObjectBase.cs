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
  /// <summary>
  /// Defines the base for all tile map objects with rendering and some helper functions.
  /// </summary>
  public abstract class TileMapObjectBase : GameObjectBase
  {
    private Color DebugTintColor = new Color(0, 0, 0, 64);

    protected TileData _tileData = null;
    private VertexBuffer _vbuffer = null;

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

    /// <summary>
    /// Converts the given point from world to tile space.
    /// </summary>
    /// <param name="p">The point to be converted.</param>
    /// <returns>The point in tile space.</returns>
    public Vector2f WorldToTile(Vector2f p)
    {
      Rectangle2f mapRect = GetMapRect();
      Vector2f result = Vector2f.Zero;
      result.X = (int)((p.X - mapRect.Min.X) / _tileData.TileWidth);
      result.Y = (int)((p.Y - mapRect.Min.Y) / _tileData.TileHeight);
      return result;
    }

    /// <summary>
    /// Calculates the area the tile at the given index takes up.
    /// </summary>
    /// <param name="x">The x coordinate of the tile.</param>
    /// <param name="y">The y coordinate of the tile.</param>
    /// <returns>The area of the tile.</returns>
    public Rectangle2f GetTileRect(int x, int y)
    {
      Rectangle2f mapRect = GetMapRect();

      float left = mapRect.Min.X + (x * _tileData.TileWidth);
      float bottom = mapRect.Min.Y + (y * _tileData.TileHeight);

      return new Rectangle2f(left, bottom, _tileData.TileWidth, _tileData.TileHeight);
    }

    /// <summary>
    /// Checks if the given point is inside the tile map area.
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <returns>True if the point is inside the tile map, else false.</returns>
    public bool IsInside(Vector2f p)
    {
      return GetMapRect().IsInside(p);
    }

    /// <summary>
    /// Checks if the given box can be moved through the tile map as given by the movement vector.
    /// </summary>
    /// <param name="box">The box to be moved.</param>
    /// <param name="movement">The movement vector.</param>
    /// <returns>The movement the box can actually move without intersecting the tile map.</returns>
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

    /// <summary>
    /// Counts how many tiles a line segment defined by [start, end] touches.
    /// The max parameter can be used to opt out early.
    /// </summary>
    /// <param name="start">The start of the line segment.</param>
    /// <param name="end">The end of the line segment.</param>
    /// <param name="max">The maximum number of tiles to count.</param>
    /// <returns>The number of tiles the line segment touches.</returns>
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
    /// Renders the tile map.
    /// </summary>
    public override void Render()
    {
      Rectangle2f mapRect = GetMapRect();

      if (_vbuffer == null)
      {
        //Generate vertex buffer on-the-fly
        List<Vertex> vertices = new List<Vertex>();
        for (int y = 0; y < _tileData.Height; y++)
        {
          for (int x = 0; x < _tileData.Width; x++)
          {
            Tile tile = _tileData[x, y];
            if (tile.TileType != TileType.Empty)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              Rectangle2f texCoord = _tileData.GetTileTexCoords(x, y);

              Vertex v = new Vertex();
              v.VX = tileRect.Min.X;
              v.VY = tileRect.Min.Y;
              v.TX = texCoord.Min.X;
              v.TY = texCoord.Min.Y;
              v.R = 255;
              v.G = 255;
              v.B = 255;
              v.A = 255;
              vertices.Add(v);

              v = new Vertex();
              v.VX = tileRect.Min.X;
              v.VY = tileRect.Max.Y;
              v.TX = texCoord.Min.X;
              v.TY = texCoord.Max.Y;
              v.R = 255;
              v.G = 255;
              v.B = 255;
              v.A = 255;
              vertices.Add(v);

              v = new Vertex();
              v.VX = tileRect.Max.X;
              v.VY = tileRect.Max.Y;
              v.TX = texCoord.Max.X;
              v.TY = texCoord.Max.Y;
              v.R = 255;
              v.G = 255;
              v.B = 255;
              v.A = 255;
              vertices.Add(v);

              v = new Vertex();
              v.VX = tileRect.Max.X;
              v.VY = tileRect.Min.Y;
              v.TX = texCoord.Max.X;
              v.TY = texCoord.Min.Y;
              v.R = 255;
              v.G = 255;
              v.B = 255;
              v.A = 255;
              vertices.Add(v);
            }
          }
        }

        VertexBuffer buffer = new VertexBuffer();
        buffer.Vertices = vertices.ToArray();

        Oku.Graphics.InitVertexBuffer(buffer);
        _vbuffer = buffer;
      }

      //Draw vertex buffer
      Oku.Graphics.DrawVertexBuffer(_vbuffer, PrimitiveType.Quads, _tileData.Images);

      // Debug drawing
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
      Oku.Graphics.ReleaseImage(_tileData.Images as Image);
    }    

  }
}
