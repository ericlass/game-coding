using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace RougeLike
{
  public class TileMapObject : GameObjectBase
  {
    private List<Image> _tiles = null;

    public override string ObjectType
    {
      get { return "tilemap"; }
    }

    public override void Init()
    {
      _tiles = GameUtil.LoadSpriteSheet("tiletest.png", 3, 3);
    }

    public override void Update(float dt)
    {
      
    }

    public override void Render()
    {
      for (int i = 0; i < _tiles.Count; i++)
      {
        Oku.Graphics.DrawImage(_tiles[i], ((i - _tiles.Count / 2) * 10.0f), 0);
      }
    }

    public override void Finish()
    {
      foreach (Image img in _tiles)
      {
        Oku.Graphics.ReleaseImage(img);
      }
    }

    public override StringPairMap DoSave()
    {
      throw new NotImplementedException();
    }

    public override void DoLoad(StringPairMap data)
    {
      throw new NotImplementedException();
    }
  }
}
