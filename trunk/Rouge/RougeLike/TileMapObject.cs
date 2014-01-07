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

    public Vector2f WorldToTile(Vector2f p)
    {
      Vector2f result = Vector2f.Zero;
      result.X = (int)((p.X - Position.X) / _tileWidth);
      result.X = (int)((p.Y - Position.Y) / _tileHeight);
      return result;
    }

    public Vector2f MoveBox(Rectangle2f box, Vector2f movement)
    {
      Vector2f min = WorldToTile(box.Min);
      Vector2f max = WorldToTile(box.Max);

      float bound = 0;

      if (movement.X > 0)
        bound = box.Max.X;
      else
        bound = box.Min.X;

      //TODO: Continue
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
          _tiles[j, i] = new Tile(tileRow.GetBool(j).Value, (int)(imageRow.GetNumber(j).Value));
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
