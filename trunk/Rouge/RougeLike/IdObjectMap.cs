using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class IdObjectMap<T> where T : IIdObject
  {
    protected Dictionary<string, T> _objects = new Dictionary<string, T>();
    
    public bool Add(T obj)
    {
      if (_objects.ContainsKey(obj.Id))
        return false;
        
      _objects.Add(obj.Id, obj);
      return true;
    }
    
    public bool Remove(T obj)
    {
      if (!_objects.ContainsKey(obj.Id))
        return false;
        
      _objects.Remove(obj.Id);
      return true;
    }
    
    public T this[string id]
    {
      get
      {
        if (!_objects.ContainsKey(id))
          return default(T);
          
        return _objects[id];
      }
    }
    
    public void Clear()
    {
      _objects.Clear();
    }
    
    public bool Contains(T obj)
    {
      return _objects.ContainsKey(obj.Id);
    }
    
    public bool ContainsId(string id)
    {
      return _objects.ContainsKey(id);
    }

    internal Dictionary<string, T> Items
    {
      get { return _objects; }
    }
      
  }
}
