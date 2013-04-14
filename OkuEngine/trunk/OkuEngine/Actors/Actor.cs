using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;
using OkuEngine.Attributes;
using OkuEngine.States;
using OkuEngine.Events;
using OkuEngine.Collision;
using Newtonsoft.Json;

namespace OkuEngine.Actors
{
  /// <summary>
  /// Defines a single actor in the game. Not to be confused with an ActorType.
  /// </summary>
  public class Actor : StoreableEntity, ICollidable
  {
    private StateManager _states = new StateManager();
    private ComponentManager _components = new ComponentManager();

    private SceneNode _sceneNode = null;

    /// <summary>
    /// Creates a new actor.
    /// </summary>
    public Actor()
    {
    }

    /// <summary>
    /// Gets or sets the scene node of the actor.
    /// </summary>
    public SceneNode SceneNode
    {
      get { return _sceneNode; }
      set { _sceneNode = value; }
    }

    /// <summary>
    /// Gets or sets the states that are associated with the actor.
    /// </summary>
    [JsonPropertyAttribute]
    public StateManager States
    {
      get { return _states; }
      set { _states = value; }
    }

    /// <summary>
    /// Gets or sets the global components of the actor.
    /// </summary>
    [JsonPropertyAttribute]
    public ComponentManager Components
    {
      get { return _components; }
      set { _components = value; }
    }

    /// <summary>
    /// Renders the actor with its current state using the given scene.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public void Render(Scene scene)
    {
      if (_states.GetCurrentState() != null)
      {
        RenderableComponent renderable = _states.GetCurrentState().Components.GetComponent<RenderableComponent>(RenderableComponent.ComponentName);
        if (renderable != null && renderable.Renderable != null)
          renderable.Renderable.Render(scene);
      }
    }

    /// <summary>
    /// Gets the bounding box of the current state of the actor.
    /// </summary>
    public Rectangle2f BoundingBox
    {
      get
      {
        if (_states.GetCurrentState() != null)
        {
          AABBComponent component = _states.GetCurrentState().Components.GetComponent<AABBComponent>(AABBComponent.ComponentName);
          if (component != null)
            return component.GetBoundingBox();
        }

        return default(Rectangle2f);
      }
    }

    /// <summary>
    /// Gets the bounding circle of the current state of the actor.
    /// </summary>
    public Circle BoundingCircle
    {
      get 
      {
        if (_states.GetCurrentState() != null)
        {
          BoundingCircleComponent component = _states.GetCurrentState().Components.GetComponent<BoundingCircleComponent>(BoundingCircleComponent.ComponentName);
          if (component != null)
            return component.GetBoundingCircle();
        }

        return default(Circle);
      }
    }

    /// <summary>
    /// Gets the shape of the current state of the actor.
    /// Can be null if only bounding box is used.
    /// </summary>
    public Vector2f[] Shape
    {
      get
      {
        if (_states.GetCurrentState() != null)
        {
          CollisionComponent shape = _states.GetCurrentState().Components.GetComponent<CollisionComponent>(CollisionComponent.ComponentName);
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
    public bool IsStatic
    {
      get { return false; }
    }

    /// <summary>
    /// Gets an attribute value for the given name. First looks at the attribute component of the current state.
    /// If it does not contain an attribute with this name, checks the actors global attribute component.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>The value of the attribute or null if there is no attribute with the given name.</returns>
    public AttributeValue GetAttributeValue(string name)
    {
      AttributeComponent attrComp = null;
      if (_states.GetCurrentState().Components.Contains(AttributeComponent.ComponentName))
      {
        attrComp = _states.GetCurrentState().Components.GetComponent<AttributeComponent>(AttributeComponent.ComponentName);
        if (attrComp != null && attrComp.Attributes.ContainsKey(name))
          return attrComp.Attributes[name];
      }

      if (_components.Contains(AttributeComponent.ComponentName))
      {
        attrComp = _components.GetComponent<AttributeComponent>(AttributeComponent.ComponentName);
        if (attrComp != null && attrComp.Attributes.ContainsKey(name))
          return attrComp.Attributes[name];
      }

      return null;
    }

    /// <summary>
    /// Gets the component with the given name. First looks into the components of the current state.
    /// If it does not contain such a component, it looks into the global components of the actor.
    /// </summary>
    /// <typeparam name="T">The type of the component to get.</typeparam>
    /// <param name="name">The name of the component.</param>
    /// <returns>The component for the given name, or null if there is no such component.</returns>
    public T GetComponent<T>(string name) where T : IStateComponent
    {
      T component = _states.GetCurrentState().Components.GetComponent<T>(name);

      if (component != null)
        return component;

      component = _components.GetComponent<T>(name);

      return component;
    }

    public override bool AfterLoad()
    {
      if (!_states.AfterLoad())
        return false;

      foreach (State state in _states.States)
      {
        if (!state.Components.Contains(BoundingCircleComponent.ComponentName))
          state.Components.Add(new BoundingCircleComponent());
      }

      return true;
    }

  }
}
