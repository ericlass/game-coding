using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Collections
{
  /// <summary>
  /// Defines a list with a mximum size. If more items are added, the older items are dropped from the list.
  /// </summary>
  /// <typeparam name="T">THe type of the items that a re stored.</typeparam>
  public class SizedList<T>
  {
    private T[] _items = null;
    private int _count = 0;

    /// <summary>
    /// Creates a new sized list with the given size.
    /// </summary>
    /// <param name="size">The maximum size of the list.</param>
    public SizedList(int size)
    {
      _items = new T[size];
    }

    /// <summary>
    /// Adds the given item to the end of the list.
    /// If the list is already completely filled, the oldest
    /// item is dropped so the new items can be added.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <returns>True if another item had to be dropped, else false.</returns>
    public bool Add(T item)
    {
      bool result = false;
      if (_count >= _items.Length)
      {
        for (int i = 0; i < _items.Length - 1; i++)
          _items[i] = _items[i + 1];
        result = true;
        _count--;
      }
      _items[_count] = item;
      _count++;

      return result;
    }

    /// <summary>
    /// Removes the items at the given index.
    /// </summary>
    /// <param name="index">The index of the item to remove.</param>
    public void RemoveAt(int index)
    {
      if (index < 0 || index >= _count)
        throw new IndexOutOfRangeException("Index must be in the range [0.." + _count + "]!");

      for (int i = index; i < _items.Length - 1; i++)
        _items[i] = _items[i + 1];
      _count--;
    }

    /// <summary>
    /// Clears all items from the list.
    /// </summary>
    public void Clear()
    {
      _count = 0;
    }

    /// <summary>
    /// Gets the maximum size of the list.
    /// </summary>
    public int Size
    {
      get { return _items.Length; }
    }

    /// <summary>
    /// Gets the current number of items in the list.
    /// </summary>
    public int Count
    {
      get { return _count; }
    }

    /// <summary>
    /// Gets or sets the item at the given index. 
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <returns>The item at the specified index.</returns>
    public T this[int index]
    {
      get
      {
        if (index < 0 || index >= _count)
          throw new IndexOutOfRangeException("Index must be in the range [0.." + _count + "]!");
        return _items[index];
      }
      set
      {
        if (index < 0 || index >= _count)
          throw new IndexOutOfRangeException("Index must be in the range [0.." + _count + "]!");
        _items[index] = value;
      }
    }

  }
}
