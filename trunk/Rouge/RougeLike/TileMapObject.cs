using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;

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

    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private Tile[,] _tiles = null;
    private List<Image> _tileImages = null;

    public TileMapObject()
    {
    }

    public override string ObjectType
    {
      get { return "tilemap"; }
    }

    public override void Init()
    {
      _tileWidth = 3;
      _tileHeight = 3;
      _tileImages = GameUtil.LoadSpriteSheet("tiletest.png", _tileWidth, _tileHeight);

      _tiles = new Tile[4, 4];
      for (int y = 0; y < 4; y++)
      {
        for (int x = 0; x < 4; x++)
        {
          _tiles[x, y] = new Tile(true, (y * 4) + x);
        }
      }
    }

    public override void Update(float dt)
    {
      
    }

    public override void Render()
    {
      float wy = (_tiles.GetLength(1) / 2) * -_tileHeight;
      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        float wx = (_tiles.GetLength(0) / 2) * -_tileWidth;
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          Oku.Graphics.DrawImage(_tileImages[_tiles[x,y].TileIndex], wx, wy);
          wx += _tileWidth;
        }
        wy += _tileHeight;
      }
    }

    public override void Finish()
    {
      foreach (Image img in _tileImages)
        Oku.Graphics.ReleaseImage(img);
    }

    protected override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    protected override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }
  }
}
