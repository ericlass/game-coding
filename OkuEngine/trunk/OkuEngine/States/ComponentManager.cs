using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines a manager for components. Allows fast access by name.
  /// </summary>
  public class ComponentManager : IStoreable
  {
    protected HashSet<IStateComponent> _components = new HashSet<IStateComponent>();
    protected Dictionary<string, IStateComponent> _componentMap = new Dictionary<string, IStateComponent>();

    [JsonPropertyAttribute]
    public HashSet<IStateComponent> Components
    {
      get { return _components; }
      set { _components = value; }
    }

    /// <summary>
    /// Adds a new component to the manager.
    /// </summary>
    /// <param name="component">The component to be added.</param>
    /// <returns>True if the component was added successfully, false if the manager already contains a component of the same type.</returns>
    public bool Add(IStateComponent component)
    {
      if (!_componentMap.ContainsKey(component.ComponentTypeName))
      {
        _components.Add(component);
        _componentMap.Add(component.ComponentTypeName, component);
        component.Owner = this;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the given component from the manager.
    /// The owner of the component is set to null by this method.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>True if the component was removed successfully, false if the manager does not contain the given component.</returns>
    public bool Remove(IStateComponent component)
    {
      if (_componentMap.ContainsKey(component.ComponentTypeName))
      {
        _components.Remove(component);
        _componentMap[component.ComponentTypeName].Owner = null; // Is this really needed?
        _componentMap.Remove(component.ComponentTypeName);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Checks if the manager contains a component with the given name.
    /// </summary>
    /// <param name="name">The name of the component.</param>
    /// <returns>True if the manager contains a component with the given name, else false.</returns>
    public bool Contains(string name)
    {
      return _componentMap.ContainsKey(name);
    }

    /// <summary>
    /// Gets the number of components the manager contains.
    /// </summary>
    public int Count
    {
      get { return _components.Count; }
    }

    /// <summary>
    /// Gets the component with the given name.
    /// </summary>
    /// <param name="name">The name of the component.</param>
    /// <returns>The component with the given name or null if their is not component with this name.</returns>
    public IStateComponent this[string name]
    {
      get
      {
        if (_componentMap.ContainsKey(name))
          return _componentMap[name];
        return null;
      }
    }

    /// <summary>
    /// Gets the component with the given name and the specified type.
    /// Throws a cast exception if a wrong type is given.
    /// </summary>
    /// <typeparam name="T">The type of component to get.</typeparam>
    /// <param name="name">The name of the component to get.</param>
    /// <returns>The component with the given name or null if their is not component with this name.</returns>
    public T GetComponent<T>(string name) where T : IStateComponent
    {
      if (_componentMap.ContainsKey(name))
        return (T)_componentMap[name];
      return default(T);
    }

    public bool AfterLoad()
    {
      _componentMap.Clear();
      foreach (IStateComponent component in _components)
      {
        if (!component.AfterLoad())
          return false;
        component.Owner = this;
        _componentMap.Add(component.ComponentTypeName, component);
      }
      return true;
    }

  }
}
