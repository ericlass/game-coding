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
    private string _name = null;
    private List<IComponent> _components = new List<IComponent>();
    private Entity _template = null;

    public event Action<Entity, IComponent> OnAddComponent;
    public event Action<Entity, IComponent> OnRemoveComponent;
    public event Action<Entity> OnClearComponents;

    /// <summary>
    /// Creates a new entity with the given name.
    /// </summary>
    /// <param name="name">The name of the new entity.</param>
    public Entity(string name)
    {
      _name = name;
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
    /// Adds the given component to the entity.
    /// </summary>
    /// <param name="component">The component to be adeed.</param>
    /// <returns>The entity itself. This allows to chain multiple Add calls.</returns>
    public Entity AddComponent(IComponent component)
    {
      if (!component.IsMultiAssignable && _components.Exists(comp => comp.Name == component.Name))
        throw new InvalidOperationException("Trying to add a '" + component.Name + "' component twice to entity '" + _name + "' although it is not multi-assignable!");

      _components.Add(component);

      if (OnAddComponent != null)
        OnAddComponent(this, component);

      return this;
    }

    /// <summary>
    /// Checks if the entity contains a component with the given name.
    /// </summary>
    /// <param name="componentName">The name of the component.</param>
    /// <returns>True if the entity contains at least one of the components, else false.</returns>
    public bool ContainsComponent<T>() where T : IComponent
    {
      if (_components.Exists(comp => comp.GetType() == typeof(T)))
        return true;

      if (_template != null)
        return _template._components.Exists(comp => comp.GetType() == typeof(T));

      return false;
    }

    /// <summary>
    /// Gets the first component with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the component to find.</param>
    /// <returns>The first component with the name, or null if there is no such component.</returns>
    public T GetComponent<T>() where T : IComponent
    {
      IComponent result = _components.Find(comp => comp.GetType() == typeof(T));

      if (result != null)
        return (T)result;

      if (_template != null)
        result = _template._components.Find(comp => comp.GetType() == typeof(T));

      return (T)result;
    }

    /// <summary>
    /// Gets all components with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the components.</param>
    /// <returns>A list of all components with the given name. Can be empty, but never null.</returns>
    public List<IComponent> GetComponents<T>() where T : IComponent
    {
      List<IComponent> result = _components.FindAll(comp => comp.GetType() == typeof(T));

      if (_template != null)
        result.AddRange(_template._components.FindAll(comp => comp.GetType() == typeof(T)));

      return result;
    }

    /// <summary>
    /// Reomve the given component from the entity.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>True if the component was removed. False if the entity did not contain the component.</returns>
    public bool RemoveComponent(IComponent component)
    {
      bool result = _components.Remove(component);

      if (result && OnRemoveComponent != null)
        OnRemoveComponent(this, component);

      return result;
    }

    /// <summary>
    /// Removes all components from the entity.
    /// </summary>
    public void ClearComponents()
    {
      _components.Clear();

      if (OnClearComponents != null)
        OnClearComponents(this);
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

  }
}
