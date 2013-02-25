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
  /// Defines the basis of an actor.
  /// </summary>
  public class ActorType : StoreableEntity
  {
    private StateManager<State> _states = new StateManager<State>();
    private AttributeMap _attributes = new AttributeMap();

    /// <summary>
    /// Gets the state of the actor type.
    /// </summary>
    [JsonPropertyAttribute]
    public StateManager<State> States
    {
      get { return _states; }
    }

    /// <summary>
    /// Gets the attributes of the actor type.
    /// </summary>
    [JsonPropertyAttribute]
    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    /// <summary>
    /// Loads the actor type from the given XML node.
    /// </summary>
    /// <param name="node">The node to load from.</param>
    /// <returns>True if the actor type was loaded successfully, else false.</returns>
    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode statesNode = node["states"];
      if (statesNode != null)
      {
        if (!_states.Load(statesNode))
          return false;
      }

      XmlNode attrsNode = node["attributes"];
      if (attrsNode != null)
      {
        if (!_attributes.Load(attrsNode))
          return false;
      }

      return true;
    }

    /// <summary>
    /// Saves the actor type to the given xml writer.
    /// </summary>
    /// <param name="writer">The writer to save to.</param>
    /// <returns>True if the actor type was saved successfully, else false.</returns>
    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actortype");

      if (!base.Save(writer))
        return false;

      if (!_attributes.Save(writer))
        return false;
      
      if (_states != null)
        if (!_states.Save(writer))
          return false;

      writer.WriteEndElement();

      return true;
    }

    public override bool AfterLoad()
    {
      return _states.AfterLoad() && _attributes.AfterLoad();
    }

  }
}
