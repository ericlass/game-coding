using System;
using System.Collections.Generic;

namespace OkuEngine
{
  /// <summary>
  /// Stores a list of variables as key value pairs. The vriables are indexed by a string.
  /// To get or set variables use the generic Get and Set methods.
  /// </summary>
  public class VariableList
  {
    private Dictionary<string, object> _values = new Dictionary<string, object>();

    /// <summary>
    /// Creates a new, empty VariableList.
    /// </summary>
    public VariableList()
    {
    }

    /// <summary>
    /// Checks if a variable with the given name exists.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <returns>True if the variable exists, else false.</returns>
    public bool Contains(string name)
    {
      return _values.ContainsKey(name);
    }

    /// <summary>
    /// Gets the value of the variable with the given name. If there currently is no variable
    /// with this name, the default value of the generic type is returned. Note that this method
    /// uses type casting. If you try read a variable with a type other than the one you wrote
    /// it with, there will be an InvalidTypeCast exception.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    /// <param name="name">The name of the variable.</param>
    /// <returns>The value of the variable or default(T) if the variable does not exists.</returns>
    public T Get<T>(string name)
    {
      if (_values.ContainsKey(name))
        return (T)_values[name];
      else
        return default(T);
    }

    /// <summary>
    /// Gets the value of the variable with the given name. If there currently is no variable
    /// with this name, the given defaultValue is returned. Note that this method
    /// uses type casting. If you try read a variable with a type other than the one you wrote
    /// it with, there will be an InvalidTypeCast exception.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    /// <param name="name">The name of the variable.</param>
    /// <param name="defaultValue">The default value that will be returned if there is no variable with the given name.</param>
    /// <returns>The value of the variable, or the given defaultValue if there is no variable with the given name.</returns>
    public T GetDef<T>(string name, T defaultValue)
    {
      if (_values.ContainsKey(name))
        return (T)_values[name];
      else
        return defaultValue;
    }

    /// <summary>
    /// Sets the given variable to the given value.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    /// <param name="name">The name of the variable.</param>
    /// <param name="value">The new value of the variable.</param>
    public void Set<T>(string name, T value)
    {
      if (_values.ContainsKey(name))
        _values[name] = value;
      else
        _values.Add(name, value);
    }

    /// <summary>
    /// Clears all items in the variable list.
    /// </summary>
    public void Clear()
    {
      _values.Clear();
    }

    /// <summary>
    /// Remove the variable with the given name from the list.
    /// </summary>
    /// <param name="name">The name of the variable to be removed.</param>
    /// <returns>True if the variable has been removed, False if no variable with this name exists in the list.</returns>
    public bool Remove(string name)
    {
      return _values.Remove(name);
    }

    /// <summary>
    /// Gets the number of variables stored in the variable list.
    /// </summary>
    public int Count
    {
      get { return _values.Count; }
    }

  }
}
