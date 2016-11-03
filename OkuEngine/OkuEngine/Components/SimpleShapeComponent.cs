using System;
using System.Collections.Generic;
using OkuEngine.Levels;

namespace OkuEngine.Components
{
  /// <summary>
  /// Defines a simple shape component with a single shape for the whole entity.
  /// </summary>
  public class SimpleShapeComponent : ShapeComponent
  {
    private int _shape = -1;

    /// <summary>
    /// Creates a new shape component without a defined shape.
    /// </summary>
    public SimpleShapeComponent()
    {
    }

    /// <summary>
    /// Creates a new shape component using the given shape id.
    /// </summary>
    /// <param name="shape">The id of the shape from the shape cache.</param>
    public SimpleShapeComponent(int shape)
    {
      _shape = shape;
    }

    /// <summary>
    /// Gets or sets the shape to be used.
    /// </summary>
    public int Shape
    {
      get { return _shape; }
      set
      {
        if (_shape != value)
        {
          var oldShape = _shape;
          _shape = value;
          QueueEvent(EventNames.EntityShapeExchanged, new int[] { oldShape }, new int[] { _shape });
        }
      }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get { return "simpleshape"; }
    }

    /// <summary>
    /// Create a copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override Component Copy()
    {
      return new SimpleShapeComponent(_shape);
    }

    /// <summary>
    /// Gets the shape(s) associated to this component.
    /// </summary>
    /// <returns>The list of shapes ids.</returns>
    internal override List<int> GetShapes(Level currentLevel)
    {
      return new List<int>() { _shape };
    }
  }
}
