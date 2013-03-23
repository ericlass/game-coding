using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Actors;
using OkuEngine.Collision;
using Newtonsoft.Json;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Stores properties of a scene node.
  /// </summary>
  public class SceneNodeProperties : IStoreable
  {
    private int _objectId = 0;
    private Transformation _transform = new Transformation();

    private SceneObject _object = null;
    private Transformation _previousTransform = new Transformation();

    /// <summary>
    /// Creates new scene node properties.
    /// </summary>
    internal SceneNodeProperties()
    {
    }

    /// <summary>
    /// Creates properties with the given object id and name.
    /// </summary>
    /// <param name="objectId">The object id.</param>
    /// <param name="name">The name.</param>
    internal SceneNodeProperties(int objectId)
    {
      _objectId = objectId;
    }

    /// <summary>
    /// Gets the scene object for the scene node.
    /// This can be null if the scene node is only used for transformation.
    /// </summary>
    public SceneObject SceneObject
    {
      get { return _object; }
    }

    /// <summary>
    /// Gets or sets the object id associated with the scene node.
    /// </summary>
    [JsonPropertyAttribute]
    public int ObjectId
    {
      get { return _objectId; }
      set { _objectId = value; }
    }

    /// <summary>
    /// Gets or sets the transformation of the scene node.
    /// </summary>
    [JsonPropertyAttribute]
    public Transformation Transform
    {
      get { return _transform; }
      set { _transform = value; }
    }

    /// <summary>
    /// Gets or sets the previous transformation of the scene node.
    /// </summary>
    public Transformation PreviousTransform
    {
      get { return _previousTransform; }
      set { _previousTransform = value; }
    }

    public bool AfterLoad()
    {
      _object = OkuData.Instance.SceneObjects[_objectId];
      if (_object == null)
      {
        OkuManagers.Instance.Logger.LogError("No scene object found with the id " + _objectId + " while loading scene node! Is the initialization order correct?");
        return false;
      }

      return _transform.AfterLoad();
    }

  }
}
