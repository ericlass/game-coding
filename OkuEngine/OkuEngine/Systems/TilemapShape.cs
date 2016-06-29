using System;
using System.Collections.Generic;
using OkuEngine.Assets;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class TilemapShape : CollisionShape
  {
    private AssetHandle _tilemap = null;
    private bool _registered = false;
    private bool _dirty = true;

    private List<Vector2f[]> _shapes = null;

    public TilemapShape(AssetHandle tilemap)
    {
      _tilemap = tilemap;
    }

    internal override bool Dirty
    {
      get { return _dirty; }
      set { _dirty = value; }
    }

    public override List<Vector2f[]> GetShapes(Level currentLevel)
    {
      var tilemap = currentLevel.Assets.GetAsset<TilemapAsset>(_tilemap);
      
      if (_shapes == null)
      {
        tilemap.OnModify += () => _dirty = true;
        _registered = true;
      }

      if (_dirty)
      {
        //TODO: Generate shapes
      }

      return null;
    }

  }
}
