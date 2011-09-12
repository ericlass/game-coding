using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Provides a virtual dynamic array. The internal array is resized intelligently.
  /// </summary>
  /// <typeparam name="T">The type of data to be stored.</typeparam>
  public class DynamicArray<T>
  {
    private T[] _internalArray = null;
    private int _count = 0;

    /// <summary>
    /// Create a new dynamic array with the default length of 10.
    /// </summary>
    public DynamicArray()
    {
      _internalArray = new T[10];
    }

    /// <summary>
    /// Creates a new dynamic array with the given length.
    /// </summary>
    /// <param name="capacity"></param>
    public DynamicArray(int capacity)
    {
      _internalArray = new T[capacity];
    }

    /// <summary>
    /// Resizes the internal array to the given new size.
    /// </summary>
    /// <param name="newSize">The new size of the array.</param>
    private void ResizeArray(int newSize)
    {
      Array.Resize<T>(ref _internalArray, newSize);
    }

    /// <summary>
    /// Calculates the next size for the internal array based on the given size.
    /// </summary>
    /// <param name="size">The current size of the array.</param>
    /// <returns>The new size for the array.</returns>
    private int GetNextSize(int size)
    {
      return size + Math.Max(10, Math.Min(1000, (int)(Math.Pow(10, (int)(Math.Log10(size))))));
    }

    /// <summary>
    /// Makes sure that at least the ginven number of entries fits in to the internal array.
    /// </summary>
    /// <param name="capacity">The number of entries the internal array should at least contain.</param>
    public void AsureCapacity(int capacity)
    {
      if (capacity >= _internalArray.Length)
        ResizeArray(GetNextSize(capacity));
    }

    /// <summary>
    /// Gets or sets the current size of the internal array. Note that settings the capacity
    /// trigger resizing the internal which really creates a new one.
    /// </summary>
    public int Capacity
    {
      get { return _internalArray.Length; }
      set { ResizeArray(value); }
    }

    /// <summary>
    /// The current number of entries in this dynamic array.
    /// </summary>
    public int Count
    {
      get { return _count; }
    }

    /// <summary>
    /// Gets the interal array. Please make sure to not store any references to it, as the
    /// array might be recreated if it has to be resized. Any references to it would then
    /// lead to a memory leak.
    /// </summary>
    public T[] InternalArray
    {
      get { return _internalArray; }
    }

    /// <summary>
    /// Gets or sets the value at the given index.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index.</returns>
    public T this[int index]
    {
      get { return _internalArray[index]; }
      set { _internalArray[index] = value; }
    }

    public void Add(T item)
    {
      AsureCapacity(_count + 1);
      _internalArray[_count] = item;
      _count++;
    }

    public void Delete(int index)
    {
      for (int i = index; i < _internalArray.Length - 2; i++)
        _internalArray[i] = _internalArray[i + 1];
      _count--;
    }

  }
}
