using System;
using System.Collections.Generic;
using OkuEngine.Assets;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  /// <summary>
  /// Collision shape that is defined by a tile map.
  /// </summary>
  public class TilemapShape : CollisionShape
  {
    private int _tilemap = 0;

    private List<Vector2f[]> _shapes = null;

    /// <summary>
    /// Creates a new tile map shape with the given tile map asset.
    /// </summary>
    /// <param name="tilemap">The tile map assets handle.</param>
    public TilemapShape(int tilemap)
    {
      _tilemap = tilemap;
    }

    public override List<Vector2f[]> GetShapes(Level currentLevel)
    {
      var tilemap = currentLevel.Assets.GetAsset<TilemapAsset>(_tilemap);
      
      if (_shapes == null)
      {
        //TODO: Generate shapes
      }

      return _shapes;
    }

  }
}
