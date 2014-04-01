using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace RougeLike
{
  public class TileData
  {
    private Tile[,] _tiles = null;
    private List<ImageBase> _images = null;
    private int _tileWidth = 0;
    private int _tileHeight = 0;

    public TileData(Tile[,] tiles, List<ImageBase> images, int tileWidth, int tileHeight)
    {
      _tiles = tiles;
      _images = images;
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

    public List<ImageBase> Images
    {
      get { return _images; }
      set { _images = value; }
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

    public ImageBase GetImage(int x, int y)
    {
      return _images[_tiles[x, y].ImageIndex];
    }

  }
}
