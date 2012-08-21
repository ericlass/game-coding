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
    private int _layer = 0;
    private Transformation _transform = new Transformation();
    private AABB _area = new AABB();
    private Color _tint = Color.White;

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
    /// Gets or sets the actor id associated with the scene node.
    /// </summary>
    public int ActorId
    {
      get { return _actorId; }
      set { _actorId = value; }
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

    /// <summary>
    /// Gets the number of the render pass this scene node belongs to.
    /// </summary>
    public int Layer
    {
      get { return _layer; }
      set { _layer = value; }
    }

  }
}
