using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Components
{
  public class TilemapShapeComponent : ShapeComponent
  {
    private Tilemap _tilemap = null;
    private List<int> _tilemapShapes = new List<int>(100);
    private bool _updateNeeded = true;
    private List<Vector2i> _tileToBeUpdated = new List<Vector2i>(20);

    public TilemapShapeComponent()
    {
    }

    public TilemapShapeComponent(Tilemap tilemap)
    {
      _tilemap = tilemap;
      _tilemap.OnChangeCollision += TilemapChangeCollision;
    }

    private void TilemapChangeCollision(Vector2i obj)
    {
      _tileToBeUpdated.Add(obj);
    }

    public Tilemap Tilemap
    {
      get { return _tilemap; }
      set
      {
        if (_tilemap != null)
          _tilemap.OnChangeCollision -= TilemapChangeCollision;

        if (_tilemap != value)
        {
          _tilemap = value;
          _updateNeeded = true;
          //Change is communicated later when updating the shape cache
        }

        if (_tilemap != null)
          _tilemap.OnChangeCollision += TilemapChangeCollision;
      }
    }

    public override string Name
    {
      get{ return "tilemapshape"; }
    }

    public override Component Copy()
    {
      return new TilemapShapeComponent(_tilemap);
    }

    internal override List<int> GetShapes(Level currentLevel)
    {
      //Full recalculation of the whole tilemap
      if (_updateNeeded)
      {
        //Clean up existing shapes
        foreach (var shapeId in _tilemapShapes)
        {
          currentLevel.ShapeCache.RemoveEntry(shapeId);
        }

        //Calculate shapes for all tiles
        for (int ty = 0; ty <= _tilemap.Height; ty++)
        {
          for (int tx = 0; tx <= _tilemap.Width; tx++)
          {
            byte col = _tilemap.GetCollision(tx, ty);

            if (col > Tilemap.CollisionNone)
            {
              Vector2f[] shape = GetTileShape(tx, ty);

              //Add tile shape to shape cache
              int shapeId = currentLevel.ShapeCache.CreateEntry();
              currentLevel.ShapeCache.BufferData(shapeId, shape);
              _tilemapShapes.Add(shapeId);
            }
          }
        }

        _updateNeeded = false;
      }

      //Recalculate single updated tiles
      foreach (var tile in _tileToBeUpdated)
      {
        int index = (tile.Y * _tilemap.Width) + tile.X;
        if (index >= 0 && index < _tilemapShapes.Count)
        {
          int shapeId = _tilemapShapes[index];
          currentLevel.ShapeCache.BufferData(shapeId, GetTileShape(tile.X, tile.Y));
        }
      }
      _tileToBeUpdated.Clear();

      return _tilemapShapes;
    }

    /// <summary>
    /// Calculates the tile shape at the given tile position.
    /// The returned shape is in object space.
    /// </summary>
    /// <param name="tx">The x coordinate of the tile.</param>
    /// <param name="ty">The y coordinate of the tile.</param>
    /// <returns>The shape of the tile at the given position.</returns>
    private Vector2f[] GetTileShape(int tx, int ty)
    {
      //Tile boundaries
      float tileLeft = tx * _tilemap.TileWidth;
      float tileRight = tileLeft + _tilemap.TileWidth;
      float tileBottom = ty * _tilemap.TileHeight;
      float tileTop = tileBottom + _tilemap.TileHeight;

      //Tile corner points
      Vector2f tLeftBottom = new Vector2f(tileLeft, tileBottom);
      Vector2f tLeftTop = new Vector2f(tileLeft, tileTop);
      Vector2f tRightTop = new Vector2f(tileRight, tileTop);
      Vector2f tRightBottom = new Vector2f(tileRight, tileBottom);

      //Create tile lines depending on tile type
      byte col = _tilemap.GetCollision(tx, ty);
      switch (col)
      {
        case Tilemap.CollisionFull:
          return new Vector2f[] { tLeftBottom, tLeftTop, tRightTop, tRightBottom };

        case Tilemap.CollisionNorthEast:
          return new Vector2f[] { tLeftTop, tRightTop, tRightBottom };

        case Tilemap.CollisionNorthWest:
          return new Vector2f[] { tLeftBottom, tLeftTop, tRightTop };

        case Tilemap.CollisionSouthEast:
          return new Vector2f[] { tLeftBottom, tRightTop, tRightBottom };

        case Tilemap.CollisionSouthWest:
          return new Vector2f[] { tLeftBottom, tLeftTop, tRightBottom };

        default:
          throw new InvalidOperationException("Unknown tile collision type: " + col);
      }
    }

  }
}
