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
    /// Adds the given component to the entity.
    /// </summary>
    /// <param name="component">The component to be adeed.</param>
    /// <returns>The entity itself. This allows to chain multiple Add calls.</returns>
    public Entity AddComponent(IComponent component)
    {
      if (!component.IsMultiAssignable && this.ContainsComponent(component.Name))
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
    public bool ContainsComponent(string componentName)
    {
      return _components.Exists(comp => comp.Name == componentName);
    }

    /// <summary>
    /// Gets the first component with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the component to find.</param>
    /// <returns>The first component with the name, or null if there is no such component.</returns>
    public IComponent GetComponent(string componentName)
    {
      return _components.Find(comp => comp.Name == componentName);
    }

    /// <summary>
    /// Gets all components with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the components.</param>
    /// <returns>A list of all components with the given name. Can be empty, but never null.</returns>
    public List<IComponent> GetComponents(string componentName)
    {
      return _components.FindAll(comp => comp.Name == componentName);
    }

    /// <summary>
    /// Reomve the given component from the entity.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>True if the component was removed. False if the entity did not contain the component.</returns>
    public bool RemoveComponent(IComponent component)
    {
      bool result = _components.Remove(component);

      if (OnRemoveComponent != null)
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

  }
}
