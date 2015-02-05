using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  public class GameObjectManager
  {
    private Dictionary<string, GameObject> _objects = new Dictionary<string, GameObject>();

    public GameObjectManager()
    {
    }

    public GameObject this[string id]
    {
      get
      {
        if (_objects.ContainsKey(id))
          return _objects[id];
        else
          return null;
      }
    }

    public void Register(GameObject obj)
    {
      if (_objects.ContainsKey(obj.Id))
        throw new ArgumentException("Object with id '" + obj.Id + "' is already registered! Ids must be unique.");

      _objects.Add(obj.Id, obj);
    }

    public bool Unregister(GameObject obj)
    {
      return _objects.Remove(obj.Id);
    }

    public void Initialize()
    {
      foreach (GameObject obj in _objects.Values)
        obj.Initialize();
    }

    public void Update(float dt)
    {
      foreach (GameObject obj in _objects.Values)
        obj.Update(dt);
    }

    public void Render()
    {
      foreach (GameObject obj in _objects.Values)
        obj.Render();
    }

    public void Finish()
    {
      foreach (GameObject obj in _objects.Values)
        obj.Finish();
    }
  }
}
