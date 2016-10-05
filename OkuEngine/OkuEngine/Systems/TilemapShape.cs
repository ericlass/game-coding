using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  /// <summary>
  /// Collision shape that is defined by a tile map.
  /// </summary>
  public class TilemapShape : CollisionShape
  {
    private Tilemap _tilemap = null;
    private List<int> _shapes = null;

    /// <summary>
    /// Creates a new tile map shape with the given tile map asset.
    /// </summary>
    /// <param name="tilemap">The tile map assets handle.</param>
    public TilemapShape(Tilemap tilemap)
    {
      _tilemap = tilemap;
      _tilemap.OnChangeCollision += Tilemap_OnChangeCollision;
    }

    private void Tilemap_OnChangeCollision(Vector2i obj)
    {
      FireChangeEvent();
      //TODO: Update changed shape
    }

    public override List<int> GetShapes(Level currentLevel)
    {
      if (_shapes == null)
      {
        //TODO: Generate shapes and register with cache
      }

      return _shapes;
    }

  }
}
