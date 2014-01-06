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

    public TileMapObject()
    {
    }

    public override string ObjectType
    {
      get { return "tilemap"; }
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

      //TODO: Load tiles

      /*_tiles = new Tile[4, 4];
      for (int y = 0; y < 4; y++)
      {
        for (int x = 0; x < 4; x++)
        {
          _tiles[x, y] = new Tile(true, (y * 4) + x);
        }
      }*/
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
