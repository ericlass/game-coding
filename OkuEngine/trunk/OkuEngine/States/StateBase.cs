using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines the base for states.
  /// State definition and instance share a lot of data and this base defines them.
  /// </summary>
  public abstract class StateBase : IStoreable
  {
    protected string _name = null;
    protected Dictionary<string, IStateComponent> _components = new Dictionary<string,IStateComponent>();

    /// <summary>
    /// Gets the name of the state.
    /// </summary>
    public string Name
    {
      get { return _name; }
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
      if (!_components.ContainsKey(component.ComponentTypeName))
      {
        _components.Add(component.ComponentTypeName, component);
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
      if (_components.ContainsKey(component.ComponentTypeName))
      {
        _components[component.ComponentTypeName].Owner = null; // Is this really needed?
        _components.Remove(component.ComponentTypeName);
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
      return _components.ContainsKey(name);
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
        if (_components.ContainsKey(name))
          return _components[name];
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
      if (_components.ContainsKey(name))
        return (T)_components[name];
      return default(T);
    }

    /// <summary>
    /// Merges the components of the state with the components of the given state.
    /// Duplicate components are merged too.
    /// </summary>
    /// <param name="state">The state to merge with.</param>
    public void Merge(StateBase state)
    {
      foreach (KeyValuePair<string, IStateComponent> comp in state._components)
      {
        if (_components.ContainsKey(comp.Key))
          _components[comp.Key].Merge(comp.Value);
        else
          Add(comp.Value);
      }
    }

    //Is overriden by the descendants to do additional loading.
    public virtual bool Load(XmlNode node)
    {
      _name = node.GetTagValue("name");
      return _name != null;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("state");

      writer.WriteValueTag("name", _name);

      foreach (KeyValuePair<string, IStateComponent> component in _components)
      {
        if (!component.Value.Save(writer))
          return false;
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
