using System;
using System.Collections.Generic;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON array value.
  /// </summary>
  public class JSONArray : JSONValue, IList<JSONValue>
  {
    private List<JSONValue> _items = new List<JSONValue>();

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Array; }
    }

    /// <summary>
    /// Gets the value at the given index as an array.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as an array.</returns>
    public JSONArray GetArray(int index)
    {
      return this[index] as JSONArray;
    }

    /// <summary>
    /// Gets the value at the given index as a boolean.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as a boolean.</returns>
    public JSONBool GetBool(int index)
    {
      return this[index] as JSONBool;
    }

    /// <summary>
    /// Gets the value at the given index as null.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as null.</returns>
    public JSONNull GetNull(int index)
    {
      return this[index] as JSONNull;
    }

    /// <summary>
    /// Gets the value at the given index as a number.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as a number.</returns>
    public JSONNumber GetNumber(int index)
    {
      return this[index] as JSONNumber;
    }

    /// <summary>
    /// Gets the value at the given index as an object.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as an object.</returns>
    public JSONObject GetObject(int index)
    {
      return this[index] as JSONObject;
    }

    /// <summary>
    /// Gets the value at the given index as a string.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index as a string.</returns>
    public JSONString GetString(int index)
    {
      return this[index] as JSONString;
    }

    #region IList<JSONValue> Member

    /// <summary>
    /// Searches for the given value and returns the zero base index of it.
    /// </summary>
    /// <param name="item">The value to be found.</param>
    /// <returns>The zero based index of the value, or -1 if the value is not found.</returns>
    public int IndexOf(JSONValue item)
    {
      return _items.IndexOf(item);
    }

    /// <summary>
    /// Insert the given value at the given index of the array.
    /// </summary>
    /// <param name="index">The index of the array.</param>
    /// <param name="item">The value.</param>
    public void Insert(int index, JSONValue item)
    {
      _items.Insert(index, item);
    }

    /// <summary>
    /// Removes the value at the given index.
    /// </summary>
    /// <param name="index">The index of the value to be removed.</param>
    public void RemoveAt(int index)
    {
      _items.RemoveAt(index);
    }

    /// <summary>
    /// Gets or sets the value at the given index.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The value at the given index.</returns>
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

    /// <summary>
    /// Adds the given value to the end of the array.
    /// </summary>
    /// <param name="item">The value to be added.</param>
    public void Add(JSONValue item)
    {
      _items.Add(item);
    }

    /// <summary>
    /// Clears all value from the array.
    /// </summary>
    public void Clear()
    {
      _items.Clear();
    }

    /// <summary>
    /// Check if the array contains the given value.
    /// </summary>
    /// <param name="item">The value to be found.</param>
    /// <returns>True if the value is in the array, else false.</returns>
    public bool Contains(JSONValue item)
    {
      return _items.Contains(item);
    }

    /// <summary>
    /// Copies the entire JSON array to the given array at the given index.
    /// </summary>
    /// <param name="array">The array to copy to.</param>
    /// <param name="arrayIndex">The index to copy to.</param>
    public void CopyTo(JSONValue[] array, int arrayIndex)
    {
      _items.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Gets the number of values the array contains.
    /// </summary>
    public int Count
    {
      get { return _items.Count; }
    }

    /// <summary>
    /// Gets if the array is read only or not.
    /// </summary>
    public bool IsReadOnly
    {
      get { return false; }
    }

    /// <summary>
    /// Removes the given value from the array.
    /// </summary>
    /// <param name="item">The value to be removed.</param>
    /// <returns>True if the value was removed. False if the array does not contain the given value.</returns>
    public bool Remove(JSONValue item)
    {
      return _items.Remove(item);
    }

    #endregion

    #region IEnumerable<JSONValue> Member

    /// <summary>
    /// Gets the enumerator for the array.
    /// </summary>
    /// <returns>The enumerator for the array</returns>
    public IEnumerator<JSONValue> GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    #endregion

    #region IEnumerable Member

    /// <summary>
    /// Gets the enumerator for the array.
    /// </summary>
    /// <returns>The enumerator for the array</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    #endregion
  }
}
