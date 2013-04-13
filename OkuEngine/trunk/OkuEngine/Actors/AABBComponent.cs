using System;
using OkuEngine.States;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that calculates a bounding box
  /// from the renderable or shape components of the same state.
  /// </summary>
  public class AABBComponent : IStateComponent
  {
    public const string ComponentName = "boundingbox";

    private ComponentManager _owner = null;
    private bool _aabbValid = false;
    private Rectangle2f _aabb = new Rectangle2f();

    /// <summary>
    /// Gets or sets the owning state of the component.
    /// </summary>
    public ComponentManager Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string ComponentTypeName
    {
      get { return ComponentName; }
    }

    /// <summary>
    /// Gets the bounding box of the state from the shape or the renderable.
    /// </summary>
    /// <returns>The bounding box of the state.</returns>
    public Rectangle2f GetBoundingBox()
    {
      if (!_aabbValid)
      {
        RenderableComponent renderable = _owner.GetComponent<RenderableComponent>(RenderableComponent.ComponentName);
        CollisionComponent shape = _owner.GetComponent<CollisionComponent>(CollisionComponent.ComponentName);

        if (shape != null && shape.Shape != null)
        {
          _aabb = shape.Shape.GetBoundingBox();
          _aabbValid = true;
        }
        else if (renderable != null && renderable.Renderable != null)
        {
          _aabb = renderable.Renderable.GetBoundingBox();
          _aabbValid = true;
        }
      }

      return _aabb;
    }

    public bool AfterLoad()
    {
      _aabbValid = false;
      return true;
    }

  }
}
