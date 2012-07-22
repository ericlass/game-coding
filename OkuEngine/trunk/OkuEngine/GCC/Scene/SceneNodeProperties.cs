using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  /// <summary>
  /// Stores properties of a scene node.
  /// </summary>
  public class SceneNodeProperties
  {
    private int _actorId = 0;
    private string _name = null;
    private Transformation _transform = new Transformation();
    private AABB _area = new AABB();
    private Color _tint = Color.White;

    /// <summary>
    /// Creates new properties with default values.
    /// </summary>
    public SceneNodeProperties()
    {
    }

    /// <summary>
    /// Creates properties with the given actor id an name.
    /// </summary>
    /// <param name="actorId">The actor id.</param>
    /// <param name="name">The name.</param>
    public SceneNodeProperties(int actorId, string name)
    {
      _actorId = actorId;
      _name = name;
    }

    /// <summary>
    /// Gets or sets the actor id associated with the scene node.
    /// </summary>
    public int ActorId
    {
      get { return _actorId; }
      set { _actorId = value; }
    }

    /// <summary>
    /// Gets or sets the name of the scene node.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets or sets the bouding box of the scene node.
    /// </summary>
    public AABB Area
    {
      get { return _area; }
      set { _area = value; }
    }

    /// <summary>
    /// Gets or sets the tint color of the scene node.
    /// </summary>
    public Color Tint
    {
      get { return _tint; }
      set { _tint = value; }
    }

    /// <summary>
    /// Gets or sets the transformation of the scene node.
    /// </summary>
    public Transformation Transform
    {
      get { return _transform; }
      set { _transform = value; }
    }

  }
}
