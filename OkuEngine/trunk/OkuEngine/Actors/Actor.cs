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
    public const string ActorStateRenderableComponentName = "renderable";
    public const string ActorStateShapeComponentName = "shape";
    public const string ActorStateAttributeComponentName = "attributes";
    public const string ActorStateAABBComponentName = "boundingbox";

    private ActorType _type = null;
    private StateManager<StateInstance> _states = new StateManager<StateInstance>(true);
    private AttributeMap _attributes = new AttributeMap();

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
      _states.OnStateChange += new StateManager<StateInstance>.StateChangedDelegate(_states_OnStateChange);
    }

    /// <summary>
    /// Posts an event if the state of the actor was changed.
    /// </summary>
    private void _states_OnStateChange()
    {
      OkuManagers.EventManager.QueueEvent(EventTypes.ActorStateChanged, Id, _states.PreviousStateName, _states.CurrentStateName);
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
    public StateManager<StateInstance> States
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
      if (_states.GetCurrentState() != null)
      {
        RenderableStateComponent renderable = _states.GetCurrentState().GetComponent<RenderableStateComponent>(ActorStateRenderableComponentName);
        if (renderable != null && renderable.Renderable != null)
          renderable.Renderable.Render(scene);
      }
    }

    /// <summary>
    /// Gets the bounding box of the current state of the actor.
    /// </summary>
    public override AABB BoundingBox
    {
      get
      {
        if (_states.GetCurrentState() != null)
        {
          AABBStateComponent component = _states.GetCurrentState().GetComponent<AABBStateComponent>(ActorStateAABBComponentName);
          if (component != null)
            return component.GetBoundingBox();
        }

        return default(AABB);
      }
    }

    /// <summary>
    /// Gets the shape of the current state of the actor.
    /// Can be null if only bounding box is used.
    /// </summary>
    public override Vector2f[] Shape
    {
      get
      {
        if (_states.GetCurrentState() != null)
        {
          ShapeStateComponent shape = _states.GetCurrentState().GetComponent<ShapeStateComponent>(ActorStateShapeComponentName);
          if (shape != null && shape.Shape != null)
            return shape.Shape.Vertices;
        }

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
      _attributes.Clear();
      _states.Clear();

      string value = node.GetTagValue("type");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          actorType = test;
        else
          return false;
      }

      _type = OkuData.Instance.ActorTypes[actorType];
      if (_type == null)
      {
        OkuManagers.Logger.LogError("Could not find actor type with id " + actorType + " for actor " + _name + "!");
        return false;
      }

      _states.Clear();
      foreach (StateDefinition def in _type.States.Values)
      {
        _states.Add(def.CreateInstance());
      }

      //Load actor states
      XmlNode statesNode = node["states"];
      if (statesNode != null)
      {
        if (!_states.Load(statesNode))
          return false;

        //Add the aabb component manually as it cannot (and shall not) be added in the XML
        foreach (StateBase stat in _states.Values)
        {
          stat.Add(new AABBStateComponent());
          //Also check that all states contain all mandatory components
          if (!stat.Contains(ActorStateRenderableComponentName) && !stat.Contains(ActorStateShapeComponentName))
            OkuManagers.Logger.LogError("Actor state " + stat.Name + " does not have a renderable or shape! At least one of them is needed! " + node.OuterXml);
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
