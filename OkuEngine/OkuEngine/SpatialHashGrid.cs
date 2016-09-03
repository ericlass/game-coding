using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkuMath;

namespace OkuEngine
{
  /// <summary>
  /// A spatial hash map that uses a regualr sized grid for hashing.
  /// </summary>
  public class SpatialHashGrid : ISpatialHashMap
  {
    private int _cellSize = 32;

    //Dictionary<GROUP, Dictionary<CELLHASH, SortedSet<ID>>>
    private Dictionary<int, Dictionary<int, SortedSet<int>>> _spatialHashMap = new Dictionary<int, Dictionary<int, SortedSet<int>>>();

    //Dictionary<GROUP, Dictionary<ID, SortedSet<CELLHASH>>>
    private Dictionary<int, Dictionary<int, SortedSet<int>>> _itemHashMap = new Dictionary<int, Dictionary<int, SortedSet<int>>>();

    /// <summary>
    /// Creates a new SpatialHashGrid with a defaul cell size of 32.
    /// </summary>
    public SpatialHashGrid()
    {
    }

    /// <summary>
    /// Creates a new SpatialHashGrid with the given cell size.
    /// </summary>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    public SpatialHashGrid(int cellSize)
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
    /// Adds or updates the given polygon int th grid of the given group.
    /// </summary>
    /// <param name="group">The group index.</param>
    /// <param name="id">The id of the item that is added.</param>
    /// <param name="poly">The poylygon of the item.</param>
    public void AddOrUpdate(int group, int id, Vector2f[] poly)
    {
      //Get or create spatial group map
      Dictionary<int, SortedSet<int>> spatialGroupMap = null;
      if (!_spatialHashMap.ContainsKey(group))
      {
        spatialGroupMap = new Dictionary<int, SortedSet<int>>();
        _spatialHashMap.Add(group, spatialGroupMap);
      }
      else
      {
        spatialGroupMap = _spatialHashMap[group];
      }

      //Get or create item group map
      Dictionary<int, SortedSet<int>> itemGroupMap = null;
      if (!_itemHashMap.ContainsKey(group))
      {
        itemGroupMap = new Dictionary<int, SortedSet<int>>();
        _itemHashMap.Add(group, itemGroupMap);
      }
      else
      {
        itemGroupMap = _itemHashMap[group];
      }

      //If item is already in map, remove it before adding it
      if (itemGroupMap.ContainsKey(id))
      {
        var currentCells = itemGroupMap[id];
        foreach (var cell in currentCells)
        {
          if (spatialGroupMap.ContainsKey(cell))
            spatialGroupMap[cell].Remove(id);
        }

        itemGroupMap.Remove(id);
      }

      //Get cells the AABB of the poly touches
      var aabb = AABBMath.FromPoints(poly);
      var cells = GridMath.CellsOfAABB(aabb.Item1, aabb.Item2, _cellSize);

      //Add poly to spatial and item hash maps
      foreach (var cell in cells)
      {
        int cellHash = cell.GetHashCode();

        if (!spatialGroupMap.ContainsKey(cellHash))
          spatialGroupMap.Add(cellHash, new SortedSet<int>());

        spatialGroupMap[cellHash].Add(id);

        if (!itemGroupMap.ContainsKey(id))
          itemGroupMap.Add(id, new SortedSet<int>());

        itemGroupMap[id].Add(cellHash);
      }
    }

    /// <summary>
    /// Removes the item with the given id and group.
    /// </summary>
    /// <param name="group">The group index.</param>
    /// <param name="id">The id of the item to remove.</param>
    public void Remove(int group, int id)
    {
      if (!_itemHashMap.ContainsKey(group))
        return;

      var itemGroupMap = _itemHashMap[group];

      if (!itemGroupMap.ContainsKey(id))
        return;

      SortedSet<int> cells = itemGroupMap[id];
      itemGroupMap.Remove(id);

      var spatialGroupMap = _spatialHashMap[group];
      foreach (int cell in cells)
      {
        if (spatialGroupMap.ContainsKey(cell))
          spatialGroupMap[cell].Remove(id);
      }
    }

    /// <summary>
    /// Gets all items in the given group that touch any 
    /// of the cells the AABB given by [min, max] touches.
    /// </summary>
    /// <param name="group">The group index.</param>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>A list of all item ids that are inside of or near to the given AABB. Null if the given group index is currently unknown.</returns>
    public SortedSet<int> GetItemsForAABB(int group, Vector2f min, Vector2f max)
    {
      if (!_spatialHashMap.ContainsKey(group))
        return null;

      //Get cells the AABB touches
      var groupMap = _spatialHashMap[group];
      var cells = GridMath.CellsOfAABB(min, max, _cellSize);

      //
      SortedSet<int> result = new SortedSet<int>();
      foreach (var cell in cells)
      {
        int cellHash = cell.GetHashCode();
        if (groupMap.ContainsKey(cellHash))
        {
          foreach (var item in groupMap[cellHash])
            result.Add(item);
        }
      }

      return result;
    }

    /// <summary>
    /// Gets all items in the given group that touch the
    /// same cells as the item with the given id.
    /// </summary>
    /// <param name="group">The group index.</param>
    /// <param name="id">The id of the item.</param>
    /// <returns>A list of all item ids that are near the given item. Null if the given group index or item id is currently unknown.</returns>
    public SortedSet<int> GetItemsNear(int group, int id)
    {
      //Check if group is known in both maps
      if (!_itemHashMap.ContainsKey(group))
        return null;

      if (!_spatialHashMap.ContainsKey(group))
        return null;

      var itemGroupMap = _itemHashMap[group];

      //Check if given id is currently known
      if (!itemGroupMap.ContainsKey(id))
        return null;

      SortedSet<int> result = new SortedSet<int>();
      var spatialGroupMap = _spatialHashMap[group];
      var cellHashes = itemGroupMap[id];
      foreach (var cellHash in cellHashes)
      {
        if (spatialGroupMap.ContainsKey(cellHash))
        {
          foreach (var item in spatialGroupMap[cellHash])
            result.Add(item);
        }
      }

      return result;
    }

    

  }
}
