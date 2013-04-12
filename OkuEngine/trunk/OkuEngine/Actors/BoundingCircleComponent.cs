using System;
using System.Collections.Generic;
using System.Text;
using OkuEngine.Geometry;
using OkuEngine.States;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that calculates a bounding circle
  /// from the renderable or shape components of the same state.
  /// </summary>
  class BoundingCircleComponent : IStateComponent
  {
    public const string ComponentName = "boundingcircle";

    private State _owner = null;
    private Circle _circle = new Circle();
    private bool _circleValid = false;

    /// <summary>
    /// Gets or sets the owning state of the component.
    /// </summary>
    public State Owner
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
    /// Gets the bounding circle.
    /// </summary>
    /// <returns>The bounding circle.</returns>
    public Circle GetBoundingCircle()
    {
      if (!_circleValid)
      {
        RenderableComponent renderable = _owner.GetComponent<RenderableComponent>(RenderableComponent.ComponentName);
        CollisionComponent shape = _owner.GetComponent<CollisionComponent>(CollisionComponent.ComponentName);

        if (shape != null && shape.Shape != null)
        {
          _circle = shape.Shape.Vertices.GetBoundingCircleCentered();
          _circleValid = true;
        }
        else if (renderable != null && renderable.Renderable != null)
        {
          //TODO: This is inefficient. The renderables should create the bounding circle themselves.
          _circle = Circle.FromAABB(renderable.Renderable.GetBoundingBox());
          _circleValid = true;
        }
      }

      return _circle;
    }

    public bool AfterLoad()
    {
      _circleValid = false;
      return true;
    }

  }
}
