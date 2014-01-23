using System;
using System.Collections.Generic;
using OkuBase;


namespace RougeLike
{
  public class ProceduralTileMapObject : TileMapObjectBase
  {
    private int _width = 0;
    private int _height = 0;
    private int _numRooms = 1;

    public int Width
    {
      get { return _width; }
    }

    public int Height
    {
      get { return _height; }
    }

    public int NumberOfRooms
    {
      get { return _numRooms; }
    }

    public override string ObjectType
    {
      get { return "proceduraltilemap"; }
    }

    public override void Init()
    {
      _tileWidth = 16;
      _tileHeight = 16;
      _tileImages = GameUtil.LoadSpriteSheet("walls_bigger.png", 16, 16);

      _tiles = new Tile[_width, _height];

      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          _tiles[x, y] = new Tile(true, 13, -1);
        }
      }

      Random rand = new Random();
      int halfWidth = _width / 2;
      int halfHeight = _height / 2;

      int left = halfWidth - 5;
      int bottom = halfHeight - 5;
      int right = halfWidth + 4;
      int top = halfHeight + 4;

      for (int i = 0; i < _numRooms; i++)
      {
        for (int y = bottom; y <= top; y++)
        {
          for (int x = left; x <= right; x++)
          {
            _tiles[x, y].Tag = i;
            _tiles[x, y].TileIndex = 16;
          }
        }

        left = rand.Next(0, _width - 5);
        bottom = rand.Next(3, _height - 5);
        right = Math.Min(_width - 1, left + rand.Next(4, 10));
        top = Math.Min(_height - 1, bottom + rand.Next(4, 10));
      }

      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          if (IsBorderTile(x, y))
          {
            _tiles[x, y].Walkable = false;
            _tiles[x, y].TileIndex = 10;
          }
        }
      }

    }

    private bool IsBorderTile(int x, int y)
    {
      int thisTag = _tiles[x, y].Tag;

      if (thisTag < 0)
        return false;

      if (x == 0 || x == _tiles.GetLength(0) - 1)
        return true;

      if (_tiles[x - 1, y].Tag < 0)
        return true;

      if (_tiles[x + 1, y].Tag < 0)
        return true;

      if (y == 0 || y == _tiles.GetLength(1) - 1)
        return true;

      if (_tiles[x, y - 1].Tag < 0)
        return true;

      if (_tiles[x, y + 1].Tag < 0)
        return true;

      if (_tiles[x - 1, y - 1].Tag < 0)
        return true;

      if (_tiles[x - 1, y + 1].Tag < 0)
        return true;

      if (_tiles[x + 1, y - 1].Tag < 0)
        return true;

      if (_tiles[x + 1, y + 1].Tag < 0)
        return true;

      return false;
    }

    public override void Update(float dt)
    {
    }

    protected override StringPairMap DoSave()
    {
      StringPairMap result = new StringPairMap();
      result.Add("width", _width.ToString());
      result.Add("height", _height.ToString());
      result.Add("rooms", _numRooms.ToString());
      return result;
    }

    protected override void DoLoad(StringPairMap data)
    {
      _width = int.Parse(data["width"]);
      _height = int.Parse(data["height"]);
      _numRooms = int.Parse(data["rooms"]);

      if (_width <= 0 || _height <= 0 || _numRooms <= 0)
        throw new OkuException("None of width, height or rooms can be <= 0 for a procedural tile map!");
    }
  }
}
