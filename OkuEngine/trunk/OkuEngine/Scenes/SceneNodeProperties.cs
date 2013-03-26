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
    private int _actorId = 0;
    private Transformation _transform = new Transformation();

    private Actor _actor = null;
    private Transformation _previousTransform = new Transformation();

    /// <summary>
    /// Creates new scene node properties.
    /// </summary>
    internal SceneNodeProperties()
    {
    }

    /// <summary>
    /// Creates properties with the given actor id and name.
    /// </summary>
    /// <param name="actorId">The actor id.</param>
    /// <param name="name">The name.</param>
    internal SceneNodeProperties(int actorId)
    {
      _actorId = actorId;
    }

    /// <summary>
    /// Gets the actor for the scene node.
    /// This can be null if the scene node is only used for transformation.
    /// </summary>
    public Actor Actor
    {
      get { return _actor; }
    }

    /// <summary>
    /// Gets or sets the actor id associated with the scene node.
    /// </summary>
    [JsonPropertyAttribute]
    public int ActorId
    {
      get { return _actorId; }
      set { _actorId = value; }
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
      _actor = OkuData.Instance.Actors[_actorId];
      if (_actor == null)
      {
        OkuManagers.Instance.Logger.LogError("No actor found with the id " + _actorId + " while loading scene node! Is the initialization order correct?");
        return false;
      }

      return _transform.AfterLoad();
    }

  }
}
