using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;
using JSONator;

namespace RougeLike
{
  public class TileMapObject : TileMapObjectBase
  {
    private string _mapFile = null;

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
      base.Load(data);
      _mapFile = data["mapfile"];
    }

  }
}
