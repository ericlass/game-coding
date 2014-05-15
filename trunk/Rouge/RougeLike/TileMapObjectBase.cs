using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Utils;
using JSONator;
using RougeLike.Attributes;

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

    protected override List<string> DoGetAllAttributes()
    {
      return new List<string>() { "width", "height" };
    }

    protected override IAttributeValue DoGetAttributeValue(string attribute)
    {
      if (attribute == "width")
        return new NumberValue(_tileData.Width);
      else if (attribute == "height")
        return new NumberValue(_tileData.Height);

      return null;
    }

    protected override bool DoSetAttributeValue(string attribute, IAttributeValue value)
    {
      //Width and height are read-only!
      if (attribute == "width" || attribute == "height")
        return true;

      return false;
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
    /// <param name="box">The box to be moved in world space.</param>
    /// <param name="movement">The movement vector.</param>
    /// <param name="maxMove">Returns the movement the box can actually move without intersecting the tile map.</param>
    /// <returns>True if the box collides with the tile map with the given movement, else false.</returns>
    public bool MoveBox(Rectangle2f box, Vector2f movement, out Vector2f maxMove)
    {
      maxMove = movement;

      Rectangle2f mapRect = GetMapRect();
      if (!IntersectionTests.Rectangles(box.Min, box.Max, mapRect.Min, mapRect.Max))
        return false;

      bool result = false;

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
              Tile tile = _tileData[i, j];
              if (tile.TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                float test = (tileRect.Min.X - CollisionOffset) - bound;
                
                //Handle slope tiles
                if (tile.TileType == TileType.NorthEast)
                {
                  if (box.Max.Y < tileRect.Max.Y)
                    test += tileRect.Max.Y - box.Max.Y;
                }
                else if (tile.TileType == TileType.SouthEast)
                {
                  if (box.Min.Y > tileRect.Min.Y)
                    test += box.Min.Y - tileRect.Min.Y;
                }
                
                if (test < disp)
                {
                  result = true;
                  disp = test;
                  continue; //Go to next row on first collision in this row
                }
              }
            }
          }
          maxMove.X = disp;
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
              Tile tile = _tileData[i, j];
              if (tile.TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                float test = (tileRect.Max.X + CollisionOffset) - bound;
                
                //Handle slope tiles
                if (tile.TileType == TileType.NorthWest)
                {
                  if (box.Max.Y < tileRect.Max.Y)
                    test -= tileRect.Max.Y - box.Max.Y;
                }
                else if (tile.TileType == TileType.SouthWest)
                {
                  if (box.Min.Y > tileRect.Min.Y)
                    test -= box.Min.Y - tileRect.Min.Y;
                }
                
                if (test > disp)
                {
                  result = true;
                  disp = test;
                  continue; //Go to next row on first collision in this row
                }
              }
            }
          }
          maxMove.X = disp;
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
              Tile tile = _tileData[i, j];
              if (tile.TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                float test = (tileRect.Min.Y - CollisionOffset) - bound;
                
                //Handle slope tiles
                if (tile.TileType == TileType.NorthEast)
                {
                  if (box.Max.X < tileRect.Max.X)
                    test += tileRect.Max.X - box.Max.X;
                }
                else if (tile.TileType == TileType.NorthWest)
                {
                  if (box.Min.X > tileRect.Min.X)
                    test += box.Min.X - tileRect.Min.X;
                }
                
                if (test < disp)
                {
                  result = true;
                  disp = test;
                  continue; //Go to next row on first collision in this row
                }
              }
            }
          }
          maxMove.Y = disp;
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
              Tile tile = _tileData[i, j];
              if (tile.TileType != TileType.Empty)
              {
                Rectangle2f tileRect = GetTileRect(i, j);
                float test = (tileRect.Max.Y + CollisionOffset) - bound;
                
                //Handle slope tiles
                if (tile.TileType == TileType.SouthEast)
                {
                  if (box.Max.X < tileRect.Max.X)
                    test -= tileRect.Max.X - box.Max.X;
                }
                else if (tile.TileType == TileType.SouthWest)
                {
                  if (box.Min.X > tileRect.Min.X)
                    test -= box.Min.X - tileRect.Min.X;
                }
                
                if (test > disp)
                {
                  result = true;
                  disp = test;
                  continue; //Go to next row on first collision in this row
                }
              }
            }
          }
          maxMove.Y = disp;
        }
      }

      return result;
    }
    
    public bool MovePoint(Vector2f point, Vector2f movement, out Vector2f maxMovement)
    {
      Rectangle2f mapRect = GetMapRect();
      maxMovement = movement;
      
      if (!mapRect.IsInside(point))
        return false;
        
      bool result = false;
      
      if (movement.X != 0)
      {
        Vector2f pointTarget = new Vector2f(point.X + movement.X, point.Y);
        Vector2f startTile = WorldToTile(point);
        Vector2f endTile = WorldToTile(pointTarget);
      
        float disp = movement.X;
        int y = (int)startTile.Y;
      
        if (movement.X > 0)
        {
          for (int x = (int)startTile.X; x <= (int)endTile.X; x++)
          {
            if (_tileData[x, y].TileType != TileType.Empty)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              float test = (tileRect.Min.X - CollisionOffset) - point.X;
              
              //Handle slope tiles
              if (tile.TileType == TileType.NorthEast)
                test += tileRect.Max.Y - point.Y;
              else if (tile.TileType == TileType.SouthEast)
                test += point.Y - tileRect.Min.Y;
              
              if (test < disp)
              {
                result = true;
                disp = test;
                continue;
              }
            }
          }
        }
        else
        {
          for (int x = (int)startTile.X; x >= (int)endTile.X; x**)
          {
            if (_tileData[x, y].TileType != TileType.Empty)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              float test = (tileRect.Max.X + CollisionOffset) - point.X;
              
              //Handle slope tiles
              if (tile.TileType == TileType.NorthWest)
                test -= tileRect.Max.Y - point.Y;
              else if (tile.TileType == TileType.SouthWest)
                test -= point.Y - tileRect.Min.Y;
              
              if (test > disp)
              {
                result = true;
                disp = test;
                continue;
              }
            }
          }
        }
        
        maxMove.X = disp;
      }
      
      if (movement.Y != 0)
      {
        Vector2f pointTarget = new Vector2f(point.X, point.Y + movement.Y);
        Vector2f startTile = WorldToTile(point);
        Vector2f endTile = WorldToTile(pointTarget);
      
        float disp = movement.Y;
        int x = (int)startTile.X;
        
        if (movement.Y > 0)
        {
          for (int y = (int)startTile.Y; y <= (int)endTile.Y; y++)
          {
            if (_tileData[x, y].TileType != TileType.Empty)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              float test = (tileRect.Min.Y - CollisionOffset) - point.Y;
              
              //Handle slope tiles
              if (tile.TileType == TileType.NorthEast)
                test += tileRect.Max.X - point.X;
              else if (tile.TileType == TileType.NorthWest)
                test += point.X - tileRect.Min.X;
              
              if (test < disp)
              {
                result = true;
                disp = test;
                continue;
              }
            }
          }
        }
        else
        {
          for (int y = (int)startTile.Y; y >= (int)endTile.Y; y--)
          {
            if (_tileData[x, y].TileType != TileType.Empty)
            {
              Rectangle2f tileRect = GetTileRect(x, y);
              float test = (tileRect.Max.Y - CollisionOffset) - point.Y;
              
              //Handle slope tiles
              if (tile.TileType == TileType.SouthEast)
                test -= tileRect.Max.X - point.X;
              else if (tile.TileType == TileType.SouthWest)
                test -= point.X - tileRect.Min.X;
              
              if (test > disp)
              {
                result = true;
                disp = test;
                continue;
              }
            }
          }
        }
        
        maxMove.Y = disp;
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
    /// Traces down from the give position to find the next filled tile below it.
    /// </summary>
    /// <param name="pos">The position in world space.</param>
    /// <returns>The value or null if there are no tiles below the given position.</returns>
    public Nullable<float> GetNextLowerY(Vector2f pos)
    {
      Rectangle2f mapRect = GetMapRect();
      if (pos.X < mapRect.Min.X || pos.X > mapRect.Max.X)
        return null;

      Vector2f tileVec = WorldToTile(pos);
      int tx = (int)tileVec.X;
      for (int y = (int)tileVec.Y; y >= 0; y--)
      {
        Tile tile = _tileData[tx, y];
        if (tile.TileType != TileType.Empty)
        {
          Rectangle2f tileRect = GetTileRect(tx, y);
          if (tile.TileType == TileType.Filled || tile.TileType == TileType.NorthEast || tile.TileType == TileType.NorthWest)
            return tileRect.Max.Y;

          if (tile.TileType == TileType.SouthWest)
            return OkuMath.InterpolateLinear(tileRect.Max.Y, tileRect.Min.Y, (pos.X - tileRect.Min.X) / _tileData.TileWidth);

          if (tile.TileType == TileType.SouthEast)
            return OkuMath.InterpolateLinear(tileRect.Min.Y, tileRect.Max.Y, (pos.X - tileRect.Min.X) / _tileData.TileWidth);
        }
      }

      return null;
    }

    public TileType GetTileBelow(Vector2f pos)
    {
      Vector2f tilePos = WorldToTile(pos);
      Tile tile = _tileData[(int)tilePos.X, (int)tilePos.Y - 1];
      return tile.TileType;
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
