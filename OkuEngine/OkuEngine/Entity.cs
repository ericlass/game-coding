using System;
using System.Collections.Generic;
using OkuEngine.Components;
using OkuEngine.Events;

namespace OkuEngine
{
  /// <summary>
  /// Defines a single entity. An entity is nothing but a named collection of components.
  /// </summary>
  public sealed class Entity
  {
    private static int _entityId = 0;

    private string _name = null;
    private List<Component> _components = new List<Component>();
    private Entity _template = null;
    private int _id = -1;
    private EngineAPI _engine = null;

    /// <summary>
    /// Creates a new entity with the given name.
    /// </summary>
    /// <param name="name">The name of the new entity.</param>
    public Entity(string name)
    {
      _name = name;

      _entityId += 1;
      _id = _entityId;
    }

    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets the ID of the entity, which is unique and stable during the runtime of the application.
    /// </summary>
    internal int ID
    {
      get { return _id; }
    }

    /// <summary>
    /// Gets or sets the template this entity inherits its components from.
    /// If an entity has a template, it inherits its components. If the entity
    /// has a component that the template has also, the one in this entity overrides
    /// the one in the template.
    /// </summary>
    public Entity Template
    {
      get { return _template; }
      set { _template = value; }
    }

    /// <summary>
    /// Private getter for the engine API.
    /// </summary>
    internal EngineAPI Engine
    {
      get { return _engine; }
      set { _engine = value; }
    }

    /// <summary>
    /// Forwards a component event to the levels event queue.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="component">The component that triggered the event.</param>
    internal void QueueComponentEvent(string eventName, Component component)
    {
      Engine.QueueEvent(eventName, this, component);
    }

    /// <summary>
    /// Adds the given component to the entity.
    /// </summary>
    /// <param name="component">The component to be adeed.</param>
    /// <returns>The entity itself. This allows to chain multiple Add calls.</returns>
    public Entity AddComponent(Component component)
    {
      if (_components.Contains(component))
        return this;

      if (!component.IsMultiAssignable && _components.Exists(comp => comp.Name == component.Name))
        throw new InvalidOperationException("Trying to add a '" + component.Name + "' component twice to entity '" + _name + "' although it is not multi-assignable!");

      _components.Add(component);
      component.SetOwner(this);

      Engine?.QueueEvent(EventNames.EntityComponentAdded, this, component);

      return this;
    }

    /// <summary>
    /// Checks if the entity contains a component with the given name.
    /// </summary>
    /// <param name="componentName">The name of the component.</param>
    /// <returns>True if the entity contains at least one of the components, else false.</returns>
    public bool ContainsComponent<T>() where T : Component
    {
      if (_components.Exists(comp => comp is T))
        return true;

      if (_template != null)
        return _template._components.Exists(comp => comp is T);

      return false;
    }

    /// <summary>
    /// Gets the first component with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the component to find.</param>
    /// <returns>The first component with the name, or null if there is no such component.</returns>
    public T GetComponent<T>() where T : Component
    {
      Component result = _components.Find(comp => comp is T);

      if (result != null)
        return (T)result;

      if (_template != null)
        result = _template._components.Find(comp => comp is T);

      return (T)result;
    }

    /// <summary>
    /// Gets all components with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the components.</param>
    /// <returns>A list of all components with the given name. Can be empty, but never null.</returns>
    public List<Component> GetComponents<T>() where T : Component
    {
      List<Component> result = _components.FindAll(comp => comp is T);

      if (result.Count == 0 && _template != null)
        result.AddRange(_template._components.FindAll(comp => comp is T));

      return result;
    }

    /// <summary>
    /// Reomve the given component from the entity.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>True if the component was removed. False if the entity did not contain the component.</returns>
    public bool RemoveComponent(Component component)
    {
      bool result = _components.Remove(component);

      if (result)
      {
        Engine?.QueueEvent(EventNames.EntityComponentRemoved, component);
        component.SetOwner(null);
      }

      return result;
    }

    /// <summary>
    /// Removes all components from the entity.
    /// </summary>
    public void ClearComponents()
    {
      _components.Clear();
      Engine?.QueueEvent(EventNames.EntityComponentsCleared);
    }

    /// <summary>
    /// Creates a copy of the entity including all components.
    /// </summary>
    /// <param name="copyName">The name of the entity copy.</param>
    /// <returns>A copy of the entity.</returns>
    public Entity Copy(string copyName)
    {
      Entity result = new Entity(copyName);

      foreach (var comp in _components)
        result._components.Add(comp.Copy());

      return result;
    }

    /// <summary>
    /// Updates all components of the entity. Has to be called each frame.
    /// </summary>
    /// <param name="dt">Time past since the last frame in seconds.</param>
    public void Update(float dt)
    {
      foreach (var comp in _components)
        comp.Update(dt);
    }

  }
}
