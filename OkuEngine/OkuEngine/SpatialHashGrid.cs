using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine
{
  /// <summary>
  /// A spatial hash map that uses a regualr sized grid for hashing.
  /// </summary>
  public class SpatialHashGrid : ISpatialHashMap
  {
    private int _cellSize = 32;
    private Level _level = null;

    //Dictionary<CellHash, List<Entity>>
    //Used for finding which entities are inside each cell
    private Dictionary<int, SortedSet<Entity>> _spatialHashMap = new Dictionary<int, SortedSet<Entity>>();

    //Dictionary<EntityID, List<CellHash>>
    //Used for finding in which cells an item is
    private Dictionary<int, SortedSet<int>> _itemHashMap = new Dictionary<int, SortedSet<int>>();

    /// <summary>
    /// Creates a new SpatialHashGrid with a defaul cell size of 32.
    /// </summary>
    public SpatialHashGrid(Level level)
    {
      _level = level;
    }

    /// <summary>
    /// Creates a new SpatialHashGrid with the given cell size.
    /// </summary>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    public SpatialHashGrid(Level level, int cellSize) : this(level)
    {
      _cellSize = cellSize;
    }

    /// <summary>
    /// Gets the cell size of the grid. This is the width and height of a single cell.
    /// </summary>
    public int CellSize
    {
      get { return _cellSize; }
    }

    /// <summary>
    /// Adds or updates the given entity in the grid.
    /// </summary>
    /// <param name="entity">The entity to add or update</param>
    public void AddOrUpdate(Entity entity)
    {
      if (!entity.ContainsComponent<ShapeComponent>())
        throw new Exception("Entities must contain at least one shape component before being added to the spatial map!");

      SortedSet<int> cellList = null;
      if (!_itemHashMap.ContainsKey(entity.ID))
      {
        cellList = new SortedSet<int>();
        _itemHashMap.Add(entity.ID, cellList);
      }
      else
      {
        cellList = _itemHashMap[entity.ID];
        cellList.Clear();
      }

      var shapes = _level.Engine.GetTransformedShapes(entity);
      foreach (var shape in shapes)
      {
        foreach (var poly in shape.Value)
        {
          var aabb = AABBMath.FromPoints(poly);
          var cells = GridMath.CellsOfAABB(aabb.Item1, aabb.Item2, _cellSize);
          foreach (var cell in cells)
          {
            var cellHash = cell.GetHashCode();
            if (!_spatialHashMap.ContainsKey(cellHash))
              _spatialHashMap.Add(cellHash, new SortedSet<Entity>() { entity });
            else
              _spatialHashMap[cellHash].Add(entity);

            cellList.Add(cellHash);
          }
        }
      }
    }

    /// <summary>
    /// Removes the item with the given id and group.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    public void Remove(Entity entity)
    {
      if (!_itemHashMap.ContainsKey(entity.ID))
        return;

      var cells = _itemHashMap[entity.ID];
      _itemHashMap.Remove(entity.ID);
      foreach (var cell in cells)
      {
        _spatialHashMap[cell].Remove(entity);
        if (_spatialHashMap[cell].Count == 0)
          _spatialHashMap.Remove(cell);
      }
    }

    /// <summary>
    /// Gets all items in the given group that touch any 
    /// of the cells the AABB given by [min, max] touches.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>A list of all entites that are inside of or near to the given AABB. Might be empty, but never null.</returns>
    public SortedSet<Entity> GetItemsForAABB(Vector2f min, Vector2f max)
    {
      //Get cells the AABB touches
      var cells = GridMath.CellsOfAABB(min, max, _cellSize);

      var result = new SortedSet<Entity>();
      foreach (var cell in cells)
      {
        int cellHash = cell.GetHashCode();
        if (_spatialHashMap.ContainsKey(cellHash))
        {
          foreach (var item in _spatialHashMap[cellHash])
          {
            result.Add(item);
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Gets all items in the given group that touch the
    /// same cells as the item with the given id.
    /// </summary>
    /// <param name="entity">The entity to check.</param>
    /// <returns>A list of all entities that are near the given item. Might be empty, but never null.</returns>
    public SortedSet<Entity> GetItemsNear(Entity entity)
    {
      if (!_itemHashMap.ContainsKey(entity.ID))
        throw new Exception("Entity with ID " + entity.ID + " was not added to the spatial hashmap!");

      var result = new SortedSet<Entity>();
      var cells = _itemHashMap[entity.ID];
      foreach (var cell in cells)
      {
        if (_spatialHashMap.ContainsKey(cell))
        {
          var entities =_spatialHashMap[cell];
          foreach (var near in entities)
          {
            if (near.ID != entity.ID)
              result.Add(near);
          }
        }
      }
      return result;
    }

    /// <summary>
    /// Clears all data contained in the hash maps.
    /// </summary>
    public void Clear()
    {
      _spatialHashMap.Clear();
      _itemHashMap.Clear();
    }
  }
}
