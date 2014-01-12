using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using JSONator;

namespace RougeLike
{
  public class TileMapObject : GameObjectBase
  {
    private class Tile
    {
      public bool Walkable { get; set; }
      public int TileIndex { get; set; }

      public Tile()
      {

      }

      public Tile(bool walkable, int tileIndex)
      {
        Walkable = walkable;
        TileIndex = tileIndex;
      }
    }

    private string _mapFile = null;
    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private Tile[,] _tiles = null;
    private List<Image> _tileImages = null;

    private const float CollisionOffset = 0.1f; // Defines a fixed offset for collision detection to handle edge cases

    public TileMapObject()
    {
    }

    public override string ObjectType
    {
      get { return "tilemap"; }
    }

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
      result.X = (int)((p.Y - mapRect.Min.Y) / _tileHeight);
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

    public override void Init()
    {
      string fullPath = Path.Combine(".\\Content\\Maps", _mapFile);
      if (!File.Exists(fullPath))
        throw new OkuException("Map file '" + _mapFile + "' does not exist!");

      JSONObjectValue root = GameUtil.ParseJsonFile(fullPath);

      int width = (int)(root.GetNumber("width").Value);
      int height = (int)(root.GetNumber("height").Value);

      _tileWidth = (int)(root.GetNumber("tilewidth").Value);
      _tileHeight = (int)(root.GetNumber("tileheight").Value);

      _tileImages = GameUtil.LoadSpriteSheet(root.GetString("tilesheet").Value, _tileWidth, _tileHeight);

      JSONArrayValue tiles = root.GetArray("tiles");
      JSONArrayValue images = root.GetArray("images");

      _tiles = new Tile[width, height];
      for (int i = 0; i < tiles.Count; i++)
      {
        JSONArrayValue tileRow = tiles.GetArray(i);
        JSONArrayValue imageRow = images.GetArray(i);
        for (int j = 0; j < tileRow.Count; j++)
        {
          _tiles[j, (width - i - 1)] = new Tile(tileRow.GetBool(j).Value, (int)(imageRow.GetNumber(j).Value));
        }
      }
    }

    public override void Update(float dt)
    {      
    }

    public override void Render()
    {
      Rectangle2f mapRect = GetMapRect();

      float wy = mapRect.Min.Y + (_tileHeight / 2.0f);
      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        float wx = mapRect.Min.X + (_tileWidth / 2.0f);
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          Oku.Graphics.DrawImage(_tileImages[_tiles[x,y].TileIndex], wx, wy);
          if (GameData.Instance.DebugDraw && !_tiles[x,y].Walkable)
          {
            Rectangle2f tileRect = GetTileRect(x, y);
            Oku.Graphics.DrawRectangle(tileRect.Min.X, tileRect.Max.X, tileRect.Min.Y, tileRect.Max.Y, new Color(0, 0, 0, 64));
          }
          wx += _tileWidth;
        }
        wy += _tileHeight;
      }

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

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("mapfile", _mapFile);
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      _mapFile = data["mapfile"];
    }
  }
}
