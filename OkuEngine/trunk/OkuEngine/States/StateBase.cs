using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  //State definition and instance share a lot of data and this base defines them
  public abstract class StateBase : IStoreable
  {
    protected string _name = null;
    protected Dictionary<string, IStateComponent> _components = new Dictionary<string,IStateComponent>();

    public string Name
    {
      get { return _name; }
    }

    internal void SetName(string name)
    {
      _name = name;
    }

    public bool Add(IStateComponent component)
    {
      if (!_components.ContainsKey(component.ComponentName))
      {
        _components.Add(component.ComponentName, component);
        component.Owner = this;
        return true;
      }
      return false;
    }

    public bool Remove(IStateComponent component)
    {
      if (_components.ContainsKey(component.ComponentName))
      {
        _components[component.ComponentName].Owner = null; // Is this really needed?
        _components.Remove(component.ComponentName);
        return true;
      }
      return false;
    }

    public int Count
    {
      get { return _components.Count; }
    }

    public IStateComponent this[string name]
    {
      get
      {
        if (_components.ContainsKey(name))
          return _components[name];
        return null;
      }
    }

    public T GetComponent<T>(string name) where T : IStateComponent
    {
      if (_components.ContainsKey(name))
        return (T)_components[name];
      return default(T);
    }

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
