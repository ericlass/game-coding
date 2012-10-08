using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// The InheritingDictionary can have a parent dictionary.
  /// </summary>
  /// <typeparam name="K">The type of the key.</typeparam>
  /// <typeparam name="V">The type of the value.</typeparam>
  public class InheritingDictionary<K, V> : Dictionary<K, V>
  {
    private InheritingDictionary<K, V> _parent = null;

    /// <summary>
    /// Gets or set the parent dictionary of the dictionary.
    /// </summary>
    public InheritingDictionary<K, V> Parent
    {
      get { return _parent; }
      set { _parent = value; }
    }

    /// <summary>
    /// Gets the value with the given key. If the dictionary
    /// has a value for the key, it is returned. If not,
    /// the parent dictionary is queried recursivly.
    /// If no parent is defined, this behaves like a usual
    /// dictionary.
    /// </summary>
    /// <param name="key">The key of the value to get.</param>
    /// <returns>The value for the given key, or null if there is no value for the key.</returns>
    public V GetInheritedValue(K key)
    {
      if (ContainsKey(key))
        return this[key];
      else if (_parent != null)
        return _parent.GetInheritedValue(key);

      return default(V);
    }

  }
}
