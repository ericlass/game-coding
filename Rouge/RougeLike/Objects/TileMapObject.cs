using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;
using RougeLike.Tiles;

namespace RougeLike.Objects
{
  public class TileMapObject : TileMapObjectBase
  {

    public TileMapObject()
    {
    }

    public TileMapObject(TileData tiles)
    {
      _tileData = tiles;
    }


    public override string ObjectType
    {
      get { return "tilemap"; }
    }

    public override void Update(float dt)
    {
      
    }

    public override void Init()
    {
    }

    protected override StringPairMap DoSave()
    {
      return new StringPairMap();
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

  }
}
