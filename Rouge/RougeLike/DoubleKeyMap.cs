using System;
using System.Collections.Generic;

namespace RougeLike
{
  public class DoubleKeyMap<K1, K2, V>
  {
    private Dictionary<K1, Dictionary<K2, V>> _map = new Dictionary<K1, Dictionary<K2, V>>();
    
    public DoubleKeyMap()
    {
    }
    
    public bool Contains(K1 key1)
    {
      return _map.ContainsKey(key1);
    }
    
    public bool Contains(K1 key1, K2 key2)
    {
      if (!Contains(key1))
        return false;
        
      return _map[key1].ContainsKey(key2);
    }
    
    public void Add(K1 key1, K2 key2, V value)
    {
      if (Contains(key1, key2))
        throw new Exception("Map already contains a value for the key pair " + key1 + " + " + key2 + "!");
        
      if (!Contains(key1))
        _map.Add(key1, new Dictionary<K2, V>());

      _map[key1].Add(key2, value);
    }
    
    public bool Remove(K1 key1, K2 key2)
    {
      if (!Contains(key1, key2))
        return false;
      
      _map[key1].Remove(key2);
      
      //If map is empty, remove it too
      if (_map[key1].Count == 0)
        _map.Remove(key1);
      
      return true;
    }

    public List<V> GetAllValues()
    {
      List<V> result = new List<V>();

      foreach (K1 key in _map.Keys)
      {
        foreach (V value in _map[key].Values)
        {
          result.Add(value);
        }
      }

      return result;
    }
    
    public V this[K1 key1, K2 key2]
    {
      get
      {
        if (!Contains(key1, key2))
          throw new Exception("Map does not contain a value for the key pair " + key1 + " + " + key2 + "!");
          
        return _map[key1][key2];
      }
      set
      {
        if (!Contains(key1, key2))
          throw new Exception("Map does not contain a value for the key pair " + key1 + " + " + key2 + "!");
          
        _map[key1][key2] = value;
      }
    }
    
  }
}