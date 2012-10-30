using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Attributes;
using OkuEngine.States;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : StoreableEntity
  {
    private SceneNode _sceneNode = null;
    private ActorType _type = null;
    private StateManager<ActorState> _states = new StateManager<ActorState>();

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
    }

    /// <summary>
    /// Gets the actor type of this actor.
    /// </summary>
    public ActorType Type
    {
      get { return _type; }
    }

    public StateManager<ActorState> States
    {
      get { return _states; }
    }

    /// <summary>
    /// Gets or sets the scene node that is associated with this actor.
    /// </summary>
    public SceneNode SceneNode
    {
      get { return _sceneNode; }
      set { _sceneNode = value; }
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
              //TODO: Add missing attributes on actor itself between type and states
              state.Attributes.Parent = _type.States.States[state.Name].Attributes;
              state.Renderable.Parent = _type.States.States[state.Name].Renderable;
            }
          }
        }
      }

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

      if (_states != null)
        if (!_states.Save(writer))
          return false;

      writer.WriteEndElement();

      return true;
    }

  }
}
