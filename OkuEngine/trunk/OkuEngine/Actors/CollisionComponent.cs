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
  class CollisionComponent : IStateComponent
  {
    public const string ComponentName = "collision";

    private ComponentManager _owner = null;
    private Polygon _shape = null;

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
    /// Gets the shape of this component.
    /// </summary>
    [JsonPropertyAttribute]
    public Polygon Shape
    {
      get { return _shape; }
      set { _shape = value; }
    }

    public bool AfterLoad()
    {
      if (_shape != null)
        return _shape.AfterLoad();
      else
        return true;
    }

  }
}
