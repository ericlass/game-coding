using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.Tiles
{
  public class TileData
  {
    private Tile[,] _tiles = null;
    private string _tileImageName = null;
    private int _tileWidth = 0;
    private int _tileHeight = 0;

    public TileData(Tile[,] tiles, string imageName, int tileWidth, int tileHeight)
    {
      _tiles = tiles;
      _tileImageName = imageName;
      _tileWidth = tileWidth;
      _tileHeight = tileHeight;
    }

    public Tile this[int x, int y]
    {
      get { return _tiles[x, y]; }
    }

    public Tile[,] Tiles
    {
      get { return _tiles; }
      set { _tiles = value; }
    }

    public string TileImageName
    {
      get { return _tileImageName; }
      set { _tileImageName = value; }
    }

    public int Width
    {
      get { return _tiles.GetLength(0); }
    }

    public int Height
    {
      get { return _tiles.GetLength(1); }
    }

    public int TileWidth
    {
      get { return _tileWidth; }
    }

    public int TileHeight
    {
      get { return _tileHeight; }
    }

  }
}
