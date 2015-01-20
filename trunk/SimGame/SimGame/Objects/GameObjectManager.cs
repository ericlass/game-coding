using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  public class GameObjectManager
  {
    private Dictionary<string, GameObjectWrapper> _objects = new Dictionary<string, GameObjectWrapper>();

    public GameObjectManager()
    {
    }

    public GameObjectWrapper this[string id]
    {
      get 
      {
        if (_objects.ContainsKey(id))
          return _objects[id];
        else
          return null;
      }
    }

    public void Register(GameObjectWrapper obj)
    {
      if (_objects.ContainsKey(obj.Id))
        throw new ArgumentException("Object with id '" + obj.Id + "' is already registered! Ids must be unique.");

      _objects.Add(obj.Id, obj);
    }

    public bool Unregister(GameObjectWrapper obj)
    {
      return _objects.Remove(obj.Id);
    }

    public void Update(float dt)
    {
      foreach (GameObjectWrapper obj in _objects.Values)
      {
        obj.Update(dt);
      }
    }

  }
}
