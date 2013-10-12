using System;
using System.Collections.Generic;

namespace JSONator
{
  public class JSONArrayValue : JSONValue, IList<JSONValue>
  {
    private List<JSONValue> _items = new List<JSONValue>();

    public override JSONValueType ValueType
    {
      get { return JSONValueType.Array; }
    }

    #region IList<JSONValue> Member

    public int IndexOf(JSONValue item)
    {
      return _items.IndexOf(item);
    }

    public void Insert(int index, JSONValue item)
    {
      _items.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      _items.RemoveAt(index);
    }

    public JSONValue this[int index]
    {
      get
      {
        return _items[index];
      }
      set
      {
        _items[index] = value;
      }
    }

    #endregion

    #region ICollection<JSONValue> Member

    public void Add(JSONValue item)
    {
      _items.Add(item);
    }

    public void Clear()
    {
      _items.Clear();
    }

    public bool Contains(JSONValue item)
    {
      return _items.Contains(item);
    }

    public void CopyTo(JSONValue[] array, int arrayIndex)
    {
      _items.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get { return _items.Count; }
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public bool Remove(JSONValue item)
    {
      return _items.Remove(item);
    }

    #endregion

    #region IEnumerable<JSONValue> Member

    public IEnumerator<JSONValue> GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    #endregion

    #region IEnumerable Member

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    #endregion
  }
}
