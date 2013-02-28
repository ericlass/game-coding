using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Attributes;
using OkuEngine.States;
using OkuEngine.Events;
using Newtonsoft.Json;

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

    private int _actorTypeId = 0;
    private ActorType _type = null;
    private StateManager<State> _states = new StateManager<State>(true);
    private AttributeMap _attributes = new AttributeMap();

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
      _states.OnStateChange += new StateManager<State>.StateChangedDelegate(_states_OnStateChange);
    }

    /// <summary>
    /// Posts an event if the state of the actor was changed.
    /// </summary>
    private void _states_OnStateChange()
    {
      OkuManagers.Instance.EventManager.QueueEvent(EventTypes.ActorStateChanged, Id, _states.PreviousStateName, _states.CurrentStateName);
    }

    /// <summary>
    /// Gets or sets the id of the type of the actor.
    /// </summary>
    [JsonPropertyAttribute]
    public int ActorTypeId
    {
      get { return _actorTypeId; }
      set { _actorTypeId = value; }
    }

    /// <summary>
    /// Gets the states that are associated with the actor.
    /// </summary>
    [JsonPropertyAttribute]
    public StateManager<State> States
    {
      get { return _states; }
      set { _states = value; }
    }

    /// <summary>
    /// Gets the attributes of the actor.
    /// </summary>
    [JsonPropertyAttribute]
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
      set
      {
      }
    }

    /// <summary>
    /// Gets if the actor is static. An actor is assumed to be never static (false).
    /// </summary>
    public override bool IsStatic
    {
      get { return false; }
    }

    public override bool AfterLoad()
    {
      _type = OkuData.Instance.ActorTypes[_actorTypeId];
      if (_type == null)
      {
        OkuManagers.Instance.Logger.LogError("Could not find actor type with id " + _actorTypeId + " for actor " + _name + "!");
        return false;
      }
      return _states.AfterLoad();
    }

  }
}
