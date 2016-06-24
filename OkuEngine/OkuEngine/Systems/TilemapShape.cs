using System;
using System.Collections.Generic;
using OkuEngine.Assets;
using OkuMath;

namespace OkuEngine.Systems
{
  public class TilemapShape : CollisionShape
  {
    private AssetHandle _tilemap = null;

    public TilemapShape(AssetHandle tilemap)
    {
      _tilemap = tilemap;
    }

    internal override bool Dirty
    {
      //TODO
      get { throw new NotImplementedException(); }
    }

    public override List<Vector2f[]> GetShapes()
    {
      throw new NotImplementedException();
    }

  }
}
