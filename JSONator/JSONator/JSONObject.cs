using System;
using System.Collections.Generic;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON object value which is a collection of named JSON values.
  /// </summary>
  public class JSONObject : JSONValue
  {
    private Dictionary<string, JSONValue> _members = new Dictionary<string, JSONValue>();

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    public override JSONValueType ValueType
    {
      get { return JSONValueType.Object; }
    }

    /// <summary>
    /// Gets or sets the value of the member with the given name.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The value of the member or null if the object does not contain a member with the given name.</returns>
    public JSONValue this[string name]
    {
      get
      {
        if (_members.ContainsKey(name))
          return _members[name];
        else
          return null;
      }
      set
      {
        if (value == null)
          throw new NullReferenceException();

        if (_members.ContainsKey(name))
          _members[name] = value;
        else
          _members.Add(name, value);
      }
    }

    /// <summary>
    /// Gets a list of the name of all members of the object.
    /// </summary>
    public List<string> Names
    {
      get { return new List<string>(_members.Keys); }
    }

    /// <summary>
    /// Checks if the object contains a member with the given name.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>True if the object contains a member with the given name, else false.</returns>
    public bool Contains(string name)
    {
      if (name == null)
        return false;

      return _members.ContainsKey(name);
    }

    /// <summary>
    /// Adds a member with the given name and value.
    /// </summary>
    /// <param name="name">The name of the new member.</param>
    /// <param name="value">The value of the new member.</param>
    public void Add(string name, JSONValue value)
    {
      if (name == null)
        throw new InvalidOperationException("NULL name is not allowed!");

      if (_members.ContainsKey(name))
        throw new InvalidOperationException("JSON object already contains a member with the name \"" + name + "\"!");

      _members.Add(name, value);
    }

    /// <summary>
    /// Removes the member with the given name.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>True if the member was removed. False if the object does not contain a member with the given name.</returns>
    public bool Remove(string name)
    {
      return _members.Remove(name);
    }

    /// <summary>
    /// Gets the number of member the object contains.
    /// </summary>
    public int Count
    {
      get { return _members.Count; }
    }

    /// <summary>
    /// Gets the member with the given name as a JSON array value.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON array value.</returns>
    public JSONArray GetArray(string name)
    {
      return (this[name] as JSONArray);
    }

    /// <summary>
    /// Gets the member with the given name as a JSON bool.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON bool value.</returns>
    public JSONBool GetBool(string name)
    {
      return (this[name] as JSONBool);
    }

    /// <summary>
    /// Gets the member with the given name as a JSON null value.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON null value.</returns>
    public JSONNull GetNull(string name)
    {
      return (this[name] as JSONNull);
    }

    /// <summary>
    /// Gets the member with the given name as a JSON number value.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON number value.</returns>
    public JSONNumber GetNumber(string name)
    {
      return (this[name] as JSONNumber);
    }

    /// <summary>
    /// Gets the member with the given name as a JSON object value.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON object value.</returns>
    public JSONObject GetObject(string name)
    {
      return (this[name] as JSONObject);
    }

    /// <summary>
    /// Gets the member with the given name as a JSON string value.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <returns>The member as a JSON string value.</returns>
    public JSONString GetString(string name)
    {
      return (this[name] as JSONString);
    }

  }
}
