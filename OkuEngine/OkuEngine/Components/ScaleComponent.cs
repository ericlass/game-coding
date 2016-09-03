using System;
using OkuMath;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that defines a scale factor for two dimensions.
  /// </summary>
  public class ScaleComponent : Component
  {
    private Vector2f _scale = Vector2f.One;

    /// <summary>
    /// Creates a new scale component that does not scale.
    /// </summary>
    public ScaleComponent()
    {
    }

    /// <summary>
    /// Creates a new scale component with the given scale.
    /// </summary>
    /// <param name="scale"></param>
    public ScaleComponent(Vector2f scale)
    {
      _scale = scale;
    }

    /// <summary>
    /// Gets or sets the scale factors in X and Y coordinates.
    /// </summary>
    public Vector2f Scale
    {
      get { return _scale; }
      set
      {
        _scale = value;
        QueueEvent(EventNames.EntityScaled);
      }
    }

    /// <summary>
    /// Gets if the component can be assigned multiple times to the same entity.
    /// </summary>
    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get { return "scale"; }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override Component Copy()
    {
      return new ScaleComponent(_scale);
    }

  }
}
