using System;
using System.Collections.Generic;

namespace SimGame.Objects
{
  /// <summary>
  /// Manages game objects. Correctly handles initialization, updating, rendering and finalization of the registered objects.
  /// </summary>
  public class GameObjectManager
  {
    private Dictionary<string, GameObject> _objects = new Dictionary<string, GameObject>();
    private List<GameObject> _objectList = new List<GameObject>();

    private Comparison<GameObject> CompareObjectsByZIndex = (a, b) => { return a.ZIndex - b.ZIndex; };
    private bool _updating = false;

    public GameObjectManager()
    {
    }

    /// <summary>
    /// Sorts the object list in a stable way.
    /// </summary>
    private void SortStable()
    {
      for (int i = 1; i < _objectList.Count; i++)
      {
        GameObject x = _objectList[i];
        int j = i;
        while (j > 0 && CompareObjectsByZIndex(_objectList[j - 1], x) > 0)
        {
          _objectList[j] = _objectList[j - 1];
          j--;
        }
        _objectList[j] = x;
      }
    }

    /// <summary>
    /// Gets the object with the given id.
    /// </summary>
    /// <param name="id">The id of the object.</param>
    /// <returns>The object with the given id or null if there is no object with this id.</returns>
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

    /// <summary>
    /// Registers a game object with the object manager.
    /// </summary>
    /// <param name="obj">The object to be registered.</param>
    public void Register(GameObject obj)
    {
      if (_objects.ContainsKey(obj.Id))
        throw new ArgumentException("Object with id '" + obj.Id + "' is already registered! Ids must be unique.");

      _objectList.Add(obj);
      if (!_updating)
        SortStable();

      _objects.Add(obj.Id, obj);
    }

    /// <summary>
    /// Registers all of the given game objects with the object manager.
    /// </summary>
    /// <param name="objects">The objects to be registered.</param>
    public void RegisterAll(params GameObject[] objects)
    {
      _updating = true;
      foreach (var obj in objects)
        Register(obj);
      _updating = false;
      SortStable();
    }

    /// <summary>
    /// Registers all of the given game objects with the object manager.
    /// </summary>
    /// <param name="objects">The objects to be registered.</param>
    public void RegisterAll(List<GameObject> objects)
    {
      _updating = true;
      foreach (var obj in objects)
        Register(obj);
      _updating = false;
      SortStable();
    }

    /// <summary>
    /// Unregisters an object from the object manager.
    /// </summary>
    /// <param name="obj">The object to unregister.</param>
    /// <returns>True if the object was removed, else false.</returns>
    public bool Unregister(GameObject obj)
    {
      _objectList.Remove(obj);
      if (!_updating)
        SortStable();
      return _objects.Remove(obj.Id);
    }

    /// <summary>
    /// Unregisters all given objects from the object manager.
    /// </summary>
    /// <param name="objects">The objects to unregister.</param>
    public void UnregisterAll(params GameObject[] objects)
    {
      _updating = true;
      try
      {
        foreach (var obj in objects)
          Unregister(obj);
      }
      finally
      {
        _updating = false;
        SortStable();
      }
    }

    /// <summary>
    /// Unregisters all given objects from the object manager.
    /// </summary>
    /// <param name="objects">The objects to unregister.</param>
    public void UnregisterAll(List<GameObject> objects)
    {
      _updating = true;
      try
      {
        foreach (var obj in objects)
          Unregister(obj);
      }
      finally
      {
        _updating = false;
        SortStable();
      }
    }

    /// <summary>
    /// Initializes all game objects that are registered to this object manager.
    /// </summary>
    public void Initialize()
    {
      foreach (GameObject obj in _objects.Values)
        obj.Initialize();
    }

    /// <summary>
    /// Updates all game objects that are registered to this object manager.
    /// </summary>
    /// <param name="dt">The time since the last frame in seconds.</param>
    public void Update(float dt)
    {
      foreach (GameObject obj in _objects.Values)
        obj.Update(dt);
    }

    /// <summary>
    /// Renders all game objects that are registered to this object manager.
    /// </summary>
    public void Render()
    {
      foreach (GameObject obj in _objectList)
      {
        if (obj.Visible)
        {
          OkuBase.OkuManager.Instance.Graphics.ApplyAndPushTransform(obj.Transform.Translation, obj.Transform.Scale, obj.Transform.Rotation);

          try
          {
            obj.Render();
          }
          finally
          {
            OkuBase.OkuManager.Instance.Graphics.PopTransform();
          }
        }
      }
    }

    /// <summary>
    /// Finalizes all game objects that are registered to this object manager.
    /// </summary>
    public void Finish()
    {
      foreach (GameObject obj in _objects.Values)
        obj.Finish();
    }
  }
}
