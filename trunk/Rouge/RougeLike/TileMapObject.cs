using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;

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
      Oku.Graphics.ApplyAndPushTransform(Position, OkuBase.Geometry.Vector2f.One, 0);
      for (int i = 0; i < _tiles.Count; i++)
      {
        Oku.Graphics.DrawImage(_tiles[i], ((i - _tiles.Count / 2) * 10.0f), 0);
      }
      Oku.Graphics.PopTransform();
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
