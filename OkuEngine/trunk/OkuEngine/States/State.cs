using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines the base for states.
  /// State definition and instance share a lot of data and this base defines them.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class State : IStoreable
  {
    protected string _name = null;
    protected HashSet<IStateComponent> _components = new HashSet<IStateComponent>();

    protected Dictionary<string, IStateComponent> _componentMap = new Dictionary<string, IStateComponent>();

    /// <summary>
    /// Gets the name of the state.
    /// </summary>
    [JsonPropertyAttribute]
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Gets or sets the components of the state.
    /// </summary>
    [JsonPropertyAttribute]
    public HashSet<IStateComponent> Components
    {
      get { return _components; }
      set { _components = value; }
    }

    /// <summary>
    /// Sets the name of the state.
    /// </summary>
    /// <param name="name">The new name of the state.</param>
    internal void SetName(string name)
    {
      _name = name;
    }

    /// <summary>
    /// Adds a new component to the state.
    /// </summary>
    /// <param name="component">The component to be added.</param>
    /// <returns>True if the component was added successfully, false if the state already contains a component of the same type.</returns>
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
    /// Removes the given component from the state.
    /// The owner of the state is set to null by this method.
    /// </summary>
    /// <param name="component">The component to be removed.</param>
    /// <returns>True if the component was removed successfully, false if the state does not contain the given component.</returns>
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
    /// Checks if the state contains a component with the given name.
    /// </summary>
    /// <param name="name">The name of the component.</param>
    /// <returns>True if the state contains a component with the given name, else false.</returns>
    public bool Contains(string name)
    {
      return _componentMap.ContainsKey(name);
    }

    /// <summary>
    /// Gets the number of components the state contains.
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
