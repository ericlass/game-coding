using System;
using System.Collections.Generic;

namespace RougeLike
{
  public class KeyPair<K1, K2>
  {
    private K1 _key1 = default(K1);
    private K2 _key2 = default(K2);
    
    public KeyPair(K1 key1, K2 key2)
    {
      _key1 = key1;
      _key2 = key2;
    }
    
    public K1 Key1
    {
      get { return _key1; }
    }
    
    public K2 Key2
    {
      get { return _key2; }
    }
    
  }

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

    public void Clear()
    {
      _map.Clear();
    }
    
    public List<KeyPair<K1, K2>> GetKeys()
    {
      List<KeyPair<K1, K2>> result = new List<KeyPair<K1, K2>>();
      foreach (K1 k1 in _map.Keys)
      {
        foreach (K2 k2 in _map[k1].Keys)
        {
          result.Add(new KeyPair<K1, K2>(k1, k2));
        }
      }
      return result;
    }
    
  }
}