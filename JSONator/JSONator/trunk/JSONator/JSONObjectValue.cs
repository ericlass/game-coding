using System;
using System.Collections.Generic;

namespace JSONator
{
  public class JSONObjectValue : JSONValue
  {
    private Dictionary<string, JSONValue> _members = new Dictionary<string, JSONValue>();

    public override JSONValueType ValueType
    {
      get { return JSONValueType.Object; }
    }

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

    public List<string> Names
    {
      get { return new List<string>(_members.Keys); }
    }

    public bool Contains(string name)
    {
      if (name == null)
        return false;

      return _members.ContainsKey(name);
    }

    public void Add(string name, JSONValue node)
    {
      if (name == null)
        throw new InvalidOperationException("NULL name is not allowed!");

      if (_members.ContainsKey(name))
        throw new InvalidOperationException("JSON object already contains a member with the name \"" + name + "\"!");

      _members.Add(name, node);
    }

    public bool Remove(string name)
    {
      return _members.Remove(name);
    }

    public int Count
    {
      get { return _members.Count; }
    }

  }
}
