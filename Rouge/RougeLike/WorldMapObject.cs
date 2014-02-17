using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class WorldMapObject : TileMapObjectBase
  {
    public override string ObjectType
    {
      get { return "worldmap"; }
    }

    public override void Init()
    {
      _tileImages = GameUtil.LoadSpriteSheet("simple_tiles.png", 16, 16);

      _tiles = new Tile[1000, 75];

      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          _tiles[x, y] = new Tile(true, -1);
        }
      }     

      PerlinNoise noise = new PerlinNoise(Environment.TickCount);
      for (int x = 0; x < _tiles.GetLength(0); x++)
      {
        int floor = (int)(noise.Noise(x, 0, 3, 100) * 15.0f) + (_tiles.GetLength(1) / 3);
        for (int y = 0; y < floor; y++)
        {
          _tiles[x, y].TileIndex = 2;
          _tiles[x, y].Walkable = false;
        }
      }
    }

    public override void Update(float dt)
    {
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

    protected override StringPairMap DoSave()
    {
      return new StringPairMap();
    }

    

  }
}
