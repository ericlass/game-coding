using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ArrayList<T>
  {
    private T[] _internalArray = null;
    private int _count = 0;

    public ArrayList()
    {
      _internalArray = new T[10];
    }

    public ArrayList(int capacity)
    {
      _internalArray = new T[capacity];
    }

    private void ResizeArray(int newSize)
    {
      Array.Resize<T>(ref _internalArray, newSize);
    }

    private int GetNextSize(int size)
    {
      return size + Math.Max(10, Math.Min(1000, (int)(Math.Pow(10, (int)(Math.Log10(size))))));
    }

    public void AsureCapacity(int capacity)
    {
      if (capacity >= _internalArray.Length)
        ResizeArray(GetNextSize(capacity));
    }

    public int Capacity
    {
      get { return _internalArray.Length; }
      set { ResizeArray(value); }
    }

    public int Count
    {
      get { return _count; }
    }

    public T[] InternalArray
    {
      get { return _internalArray; }
    }

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
