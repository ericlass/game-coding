using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Attributes;
using OkuEngine.States;
using OkuEngine.Events;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : SceneObject
  {
    private ActorType _type = null;
    private StateManager<ActorState> _states = new StateManager<ActorState>();
    private AttributeMap _attributes = new AttributeMap();

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
      _states.OnStateChange += new StateManager<ActorState>.StateChangedDelegate(_states_OnStateChange);
    }

    /// <summary>
    /// Posts an event if the state of the actor was changed.
    /// </summary>
    private void _states_OnStateChange()
    {
      OkuManagers.EventManager.QueueEvent(EventTypes.ActorStateChanged, Id, _states.PreviousName, _states.CurrentName);
    }

    /// <summary>
    /// Gets the actor type of this actor.
    /// </summary>
    public ActorType Type
    {
      get { return _type; }
    }

    /// <summary>
    /// Gets the states that are associated with the actor.
    /// </summary>
    public StateManager<ActorState> States
    {
      get { return _states; }
    }

    /// <summary>
    /// Gets the attributes of the actor.
    /// </summary>
    public AttributeMap Attributes
    {
      get { return _attributes; }
    }

    /// <summary>
    /// Renders the actor with its current state using the given scene.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public override void Render(Scene scene)
    {
      if (_states.CurrentState != null)
        _states.CurrentState.Renderable.RenderInherited(scene);
    }

    /// <summary>
    /// Gets the bounding box of the current state of the actor.
    /// </summary>
    public override AABB BoundingBox
    {
      get
      {
        if (_states.CurrentState != null)
          return _states.CurrentState.BoundingBox;

        return default(AABB);
      }
    }

    /// <summary>
    /// Gets the shape of the current state of the actor.
    /// Can be null if only bounding box is used.
    /// </summary>
    public override Vector[] Shape
    {
      get
      {
        if (_states.CurrentState != null)
          return _states.CurrentState.Shape;

        return null;
      }
    }

    /// <summary>
    /// Gets if the actor is static. An actor is assumed to be never static (false).
    /// </summary>
    public override bool IsStatic
    {
      get { return false; }
    }

    /// <summary>
    /// Loads an actor including its components from the given xml node.
    /// This also adds the actor to the corresponding scene and layer.
    /// </summary>
    /// <param name="node">The node to start loading from.</param>
    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      int actorType = 0;

      string value = node.GetTagValue("type");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          actorType = test;
        else
          return false;
      }

      _type = OkuData.ActorTypes[actorType];
      if (_type == null)
      {
        OkuManagers.Logger.LogError("Could not find actor type with id " + actorType + " for actor " + _name + "!");
        return false;
      }

      //Load actor states
      XmlNode statesNode = node["states"];
      if (statesNode != null)
      {
        if (!_states.Load(statesNode))
          return false;
        else
        {
          // Set up inherting attributes and renderables
          foreach (ActorState state in _states.States.Values)
          {
            if (_type.States.States.ContainsKey(state.Name))
            {
              state.Attributes.Parent = _type.States.States[state.Name].Attributes;
              state.Renderable.Parent = _type.States.States[state.Name].Renderable;
            }
          }
        }
      }

      //Load global actor attributes
      XmlNode attrsNode = node["attributes"];
      if (attrsNode != null)
      {
        if (!_attributes.Load(attrsNode))
          return false;
      }
      _attributes.Parent = _type.Attributes;

      return true;
    }

    /// <summary>
    /// Saves the data of this actor to the given XML writer.
    /// </summary>
    /// <param name="writer">The xml writer to write to.</param>
    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("actor");

      if (!base.Save(writer))
        return false;

      writer.WriteValueTag("type", _type.Id.ToString());

      if (!_attributes.Save(writer))
        return false;
      
      if (_states != null)
        if (!_states.Save(writer))
          return false;

      writer.WriteEndElement();

      return true;
    }

  }
}
