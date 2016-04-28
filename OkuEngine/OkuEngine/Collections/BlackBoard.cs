using System;
using System.Collections.Generic;

namespace OkuEngine.Collections
{
  /// <summary>
  /// Collections of string keys to objects.
  /// Use the typed getters for convenience.
  /// </summary>
  public class BlackBoard : Dictionary<string, object>
  {
    /// <summary>
    /// Gets or set the value with the given name.
    /// When getting with a non-existing name, null is returned.
    /// When setting, existing values are overwritten.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The value with the given name, or null if there no value with this name.</returns>
    public new object this[string name]
    {
      get
      {
        if (this.ContainsKey(name))
          return base[name];

        return null;
      }
      set
      {
        base[name] = value;
      }
    }

    /// <summary>
    /// Gets the value with the given name as an integer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The value as an integer.</returns>
    public int GetInt(string name)
    {
      return (int)this[name];
    }

    /// <summary>
    /// Gets the value with the given name as an float.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The value as an float.</returns>
    public float GetFloat(string name)
    {
      return (float)this[name];
    }

    /// <summary>
    /// Gets the value with the given name as an string.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The value as an string.</returns>
    public string GetString(string name)
    {
      return this[name] as string;
    }

  }
}
