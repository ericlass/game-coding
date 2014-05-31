using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike.Tiles
{
  public class TileData
  {
    private Tile[,] _tiles = null;
    private ImageBase _tileImages = null;
    private int _tileWidth = 0;
    private int _tileHeight = 0;

    public TileData(Tile[,] tiles, ImageBase images, int tileWidth, int tileHeight)
    {
      _tiles = tiles;
      _tileImages = images;
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

    public ImageBase Images
    {
      get { return _tileImages; }
      set { _tileImages = value; }
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

    public Rectangle2f GetTileTexCoords(int x, int y)
    {
      int imageIndex = _tiles[x, y].ImageIndex;

      float fwidth = (float)_tileImages.Width;
      float left = (imageIndex * _tileWidth) / fwidth;
      float right = left + (_tileWidth / fwidth);

      float top = 1.0f;
      float bottom = 0.0f;

      return new Rectangle2f(left, bottom, right - left, top - bottom);
    }

  }
}
