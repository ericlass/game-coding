using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.States;
using OkuEngine.Attributes;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a state component that contains a series of attributes.
  /// </summary>
  public class AttributeComponent : IStateComponent
  {
    public const string ComponentName = "attributes";

    private State _owner = null;
    private AttributeMap _attributes = null;

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
    /// Gets the attribute for the component.
    /// </summary>
    [JsonPropertyAttribute]
    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    public bool AfterLoad()
    {
      return true;
    }

  }
}
