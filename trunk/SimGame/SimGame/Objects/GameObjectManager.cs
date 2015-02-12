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

    public GameObjectManager()
    {
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
      _objectList.Sort(CompareObjectsByZIndex);

      _objects.Add(obj.Id, obj);
    }

    /// <summary>
    /// Unregisters an object from the object manager.
    /// </summary>
    /// <param name="obj">The object to unregister.</param>
    /// <returns>True if the object was removed, else false.</returns>
    public bool Unregister(GameObject obj)
    {
      _objectList.Remove(obj);
      _objectList.Sort(CompareObjectsByZIndex);
      return _objects.Remove(obj.Id);
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
