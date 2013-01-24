using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collections
{
  /// <summary>
  /// Defines a list of pairs of objects. The order of the objects does not matter.
  /// </summary>
  /// <typeparam name="T">The type of items to be stored.</typeparam>
  public class PairList<T>
  {
    private Dictionary<T, HashSet<T>> _pairs = new Dictionary<T, HashSet<T>>();

    /// <summary>
    /// Checks if the pair list contains the given pair of values.
    /// </summary>
    /// <param name="itemA">The first item.</param>
    /// <param name="itemB">The second item.</param>
    /// <returns></returns>
    public bool Contains(T itemA, T itemB)
    {
      return (_pairs.ContainsKey(itemA) && _pairs[itemA].Contains(itemB));
    }

    /// <summary>
    /// Add the given pair of items to the pair list.
    /// </summary>
    /// <param name="itemA">The first item.</param>
    /// <param name="itemB">The second item.</param>
    public void Add(T itemA, T itemB)
    {
      if (!Contains(itemA, itemB))
      {
        //Remember both combinations to speed up Contains check
        if (!_pairs.ContainsKey(itemA))
          _pairs.Add(itemA, new HashSet<T>());
        _pairs[itemA].Add(itemB);

        if (!_pairs.ContainsKey(itemB))
          _pairs.Add(itemB, new HashSet<T>());
        _pairs[itemB].Add(itemA);
      }
    }

    /// <summary>
    /// Removes the given pair of items from the pair list.
    /// </summary>
    /// <param name="itemA">The first item.</param>
    /// <param name="itemB">The second item.</param>
    /// <returns>True if the pair was removed, false if the list does not contain the given pair.</returns>
    public bool Remove(T itemA, T itemB)
    {
      if (Contains(itemA, itemB))
      {
        _pairs[itemA].Remove(itemB);
        _pairs[itemB].Remove(itemA);
        _pairs.Remove(itemA);
        _pairs.Remove(itemB);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Clears all pairs from the pair list.
    /// </summary>
    public void Clear()
    {
      _pairs.Clear();
    }

    /// <summary>
    /// Writes a list of distinct values that are contained in the pair list
    /// to the given list.
    /// </summary>
    /// <param name="values">The values are returned here.</param>
    public void GetDistinctValues(ref List<T> values)
    {
      values.Clear();
      values.AddRange(_pairs.Keys);
    }

    /// <summary>
    /// Writes a has set of distinct values that are contained in the pair list
    /// to the given list.
    /// </summary>
    /// <param name="values">The values are returned here.</param>
    public void GetDistinctValues(ref HashSet<T> values)
    {
      values.Clear();
      values.AddRange(_pairs.Keys);
    }

  }
}
