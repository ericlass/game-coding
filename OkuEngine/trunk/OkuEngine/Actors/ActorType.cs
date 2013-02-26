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

    public override bool AfterLoad()
    {
      KeySequence.SetCurrentValue(KeySequence.ActorTypeSequence, Id);
      return _states.AfterLoad() && _attributes.AfterLoad();
    }

  }
}
