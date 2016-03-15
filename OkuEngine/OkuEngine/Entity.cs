using System;
using System.Collections.Generic;
using OkuEngine.Components;

namespace OkuEngine
{
  /// <summary>
  /// Defines a single entity. An entity is nothing but a named collection of components.
  /// </summary>
  public sealed class Entity
  {
    private string _name = null;
    private Dictionary<string, int> _existingComponents = null;
    private List<IComponent> _components = null;

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
    /// Lazily creates the internal list and map. Should be called before accessing them.
    /// </summary>
    private void CheckLists()
    {
      if (_existingComponents == null)
        _existingComponents = new Dictionary<string, int>();

      if (_components == null)
        _components = new List<IComponent>();
    }

    /// <summary>
    /// Adds the given component to the entity.
    /// </summary>
    /// <param name="component">The component to be adeed.</param>
    /// <returns>The entity itself. This allows to chain multiple Add calls.</returns>
    public Entity Add(IComponent component)
    {
      CheckLists();

      if (_existingComponents.ContainsKey(component.Name))
      {
        if (!component.IsMultiAssignable)
          throw new InvalidOperationException("Trying to add a '" + component.Name + "' component twice to entity '" + _name + "' although it is not multi-assignable!");
      }
      else
      {
        _existingComponents.Add(component.Name, 0);
      }

      _existingComponents[component.Name] += 1;
      _components.Add(component);

      return this;
    }

    /// <summary>
    /// Gets the first component with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the component to find.</param>
    /// <returns>The first component with the name, or null if there is no such component.</returns>
    public IComponent GetComponent(string componentName)
    {
      CheckLists();
      return _components.Find(comp => comp.Name == componentName);
    }

    /// <summary>
    /// Gets all components with the given component name.
    /// </summary>
    /// <param name="componentName">The name of the components.</param>
    /// <returns>A list of all components with the given name. Can be empty, but never null.</returns>
    public List<IComponent> GetComponents(string componentName)
    {
      CheckLists();
      return _components.FindAll(comp => comp.Name == componentName);
    }

    /// <summary>
    /// Reomve the given component from the entity.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>The entity itself. This allows chaining multiple Remove calls.</returns>
    public Entity Remove(IComponent component)
    {
      CheckLists();
      _components.Remove(component);
      if (_existingComponents.ContainsKey(component.Name))
      {
        int count = _existingComponents[component.Name];
        count -= 1;

        if (count <= 0)
          _existingComponents.Remove(component.Name);
        else
          _existingComponents[component.Name] = count;
      }
      return this;
    }

    /// <summary>
    /// Removes all components from the entity.
    /// </summary>
    public void Clear()
    {
      _existingComponents.Clear();
      _components.Clear();
    }

  }
}
