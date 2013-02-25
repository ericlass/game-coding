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
  public class AttributeStateComponent : IStateComponent
  {
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
      get { return Actor.ActorStateAttributeComponentName; }
    }

    /// <summary>
    /// Gets the attribute for the component.
    /// </summary>
    [JsonPropertyAttribute]
    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    /// <summary>
    /// Copies the component with all of its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public IStateComponent Copy()
    {
      AttributeStateComponent result = new AttributeStateComponent();
      result._attributes = _attributes.Copy();
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
        if (other is AttributeStateComponent)
        {
          AttributeStateComponent attrs = other as AttributeStateComponent;
          _attributes.AddAll(attrs.Attributes, true);
        }
        else
          OkuManagers.Logger.LogError("Trying to merge a " + other.GetType().Name + " with a AttributeStateComponent!");
      }

      return true;
    }

    public bool Load(XmlNode node)
    {
      _attributes = new AttributeMap();
      return _attributes.Load(node);
    }

    public bool Save(XmlWriter writer)
    {
      return _attributes.Save(writer);
    }

    public bool AfterLoad()
    {
      return true;
    }

  }
}
