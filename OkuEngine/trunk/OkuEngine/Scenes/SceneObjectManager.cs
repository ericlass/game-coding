using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Manages scene objects like actors and brushes.
  /// </summary>
  public class SceneObjectManager : IStoreable
  {
    private Dictionary<int, SceneObject> _objects = null;

    /// <summary>
    /// Create a new scene object manager.
    /// </summary>
    public SceneObjectManager()
    {
      _objects = new Dictionary<int, SceneObject>();
    }

    /// <summary>
    /// Adds a scene object to the manager.
    /// </summary>
    /// <param name="sceneObject">The scene object to add.</param>
    /// <returns>True if the scene object was added, false if there already is a scene object with the same id.</returns>
    public bool Add(SceneObject sceneObject)
    {
      if (_objects.ContainsKey(sceneObject.Id))
        return false;

      _objects.Add(sceneObject.Id, sceneObject);
      return true;
    }

    /// <summary>
    /// Removes the given scene object from the manager.
    /// </summary>
    /// <param name="sceneObject">The scene object to be removed.</param>
    /// <returns>True if the scene object was removed, false if the manager did not contain the scene object.</returns>
    public bool Remove(SceneObject sceneObject)
    {
      return _objects.Remove(sceneObject.Id);
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
        if (_objects.ContainsKey(id))
          return _objects[id];
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
      if (_objects.ContainsKey(id))
      {
        SceneObject so = _objects[id];
        if (so is T)
          return so as T;
        else
          throw new InvalidCastException("Trying to get a scene object of type " + typeof(T).Name + ", but object with id " + id + " is a " + so.GetType().Name + "!");
      }
      return null;
    }

    public bool Load(XmlNode node)
    {
      if (node != null && node.NodeType == XmlNodeType.Element && node.Name == "sceneobjects")
      {
        XmlNode child = node.FirstChild;
        while (child != null)
        {
          SceneObject so = SceneObjectFactory.Instance.CreateSceneObject(child);
          if (so != null)
          {
            if (!Add(so))
            {
              OkuManagers.Logger.LogError("Duplicate scene object id! " + child.OuterXml);
            }
            KeySequence.SetCurrentValue(KeySequence.SceneObjectSequence, so.Id);
          }
          else
            OkuManagers.Logger.LogError("Could not create scene object! " + child.OuterXml);

          child = child.NextSibling;
        }
      }
      return false;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("sceneobjects");

      foreach (SceneObject so in _objects.Values)
      {
        so.Save(writer);
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
