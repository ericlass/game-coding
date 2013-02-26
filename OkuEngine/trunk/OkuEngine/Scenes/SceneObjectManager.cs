using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Manages scene objects like actors and brushes.
  /// </summary>
  public class SceneObjectManager : IStoreable
  {
    private HashSet<SceneObject> _objects = new HashSet<SceneObject>();
    private Dictionary<int, SceneObject> _objectMap = new Dictionary<int,SceneObject>();

    /// <summary>
    /// Create a new scene object manager.
    /// </summary>
    public SceneObjectManager()
    {
      _objectMap = new Dictionary<int, SceneObject>();
    }

    /// <summary>
    /// Adds a scene object to the manager.
    /// </summary>
    /// <param name="sceneObject">The scene object to add.</param>
    /// <returns>True if the scene object was added, false if there already is a scene object with the same id.</returns>
    public bool Add(SceneObject sceneObject)
    {
      if (_objectMap.ContainsKey(sceneObject.Id))
        return false;

      _objects.Add(sceneObject);
      _objectMap.Add(sceneObject.Id, sceneObject);

      return true;
    }

    /// <summary>
    /// Removes the given scene object from the manager.
    /// </summary>
    /// <param name="sceneObject">The scene object to be removed.</param>
    /// <returns>True if the scene object was removed, false if the manager did not contain the scene object.</returns>
    public bool Remove(SceneObject sceneObject)
    {
      _objects.Remove(sceneObject);
      return _objectMap.Remove(sceneObject.Id);
    }

    /// <summary>
    /// Gets or sets the scene objects of the manager.
    /// </summary>
    [JsonPropertyAttribute]
    public HashSet<SceneObject> Objects
    {
      get { return _objects; }
      set { _objects = value; }
    }

    /// <summary>
    /// Gets the scene object with the given id.
    /// </summary>
    /// <param name="id">The id of the scene object.</param>
    /// <returns>The scene object with the given id or null if the manager does not contain a scene object with this id.</returns>
    public SceneObject this[int id]
    {
      get
      {
        if (_objectMap.ContainsKey(id))
          return _objectMap[id];
        else
          return null;
      }
    }

    /// <summary>
    /// Gets the scene object with the given id with a specific type.
    /// If the scene object is not of the exact type that is given,
    /// an exception is thrown.
    /// </summary>
    /// <typeparam name="T">The type of object to get.</typeparam>
    /// <param name="id">The id of the scene object to get.</param>
    /// <returns>The scene object with the given id or null if the manager does not contain a scene object with this id.</returns>
    public T Get<T>(int id) where T : SceneObject
    {
      if (_objectMap.ContainsKey(id))
      {
        SceneObject so = _objectMap[id];
        if (so is T)
          return so as T;
        else
          throw new InvalidCastException("Trying to get a scene object of type " + typeof(T).Name + ", but object with id " + id + " is a " + so.GetType().Name + "!");
      }
      return null;
    }

    public bool AfterLoad()
    {
      int maxId = -1;
      foreach (SceneObject obj in _objects)
      {
        if (!obj.AfterLoad())
          return false;
        _objectMap.Add(obj.Id, obj);
        if (obj.Id > maxId)
          maxId = obj.Id;
      }
      KeySequence.SetCurrentValue(KeySequence.SceneObjectSequence, maxId);

      return true;
    }

  }
}
