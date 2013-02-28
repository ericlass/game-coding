using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Geometry;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that stores a shape.
  /// </summary>
  class ShapeStateComponent : IStateComponent
  {
    private State _owner = null;
    private Polygon _shape = null;

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
      get { return Actor.ActorStateShapeComponentName; }
    }

    /// <summary>
    /// Gets the shape of this component.
    /// </summary>
    [JsonPropertyAttribute]
    public Polygon Shape
    {
      get { return _shape; }
      set { _shape = value; }
    }

    /// <summary>
    /// Copies the component with all of its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IStateComponent Copy()
    {
      ShapeStateComponent result = new ShapeStateComponent();
      result._shape = _shape.Copy();
      return result;
    }

    /// <summary>
    /// Merges the data of the component with the given one.
    /// </summary>
    /// <param name="other">The component to merge into this component.</param>
    /// <returns>True if the merge was successfull, else false.</returns>
    public bool Merge(IStateComponent other)
    {
      if (other != null)
      {
        if (other is ShapeStateComponent)
        {
          ShapeStateComponent shape = other as ShapeStateComponent;
          _shape = shape.Shape.Copy();
        }
        else
          OkuManagers.Instance.Logger.LogError("Trying to merge a " + other.GetType().Name + " with a ShapeStateComponent!");
      }

      return true;
    }

    public bool AfterLoad()
    {
      return _shape.AfterLoad();
    }

  }
}
