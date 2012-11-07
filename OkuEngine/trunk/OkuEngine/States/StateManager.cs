using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.States
{
  public class StateManager<T> : IStoreable where T : EntityState, new()
  {
    private string _defaultName = null;
    private T _currentState = null;
    private InheritingDictionary<string, T> _states = new InheritingDictionary<string, T>();
    private StateManager<T> _parent = null;

    public StateManager()
    {      
    }

    public StateManager(StateManager<T> parent)
    {
      Parent = parent;
    }

    internal InheritingDictionary<string, T> States
    {
      get { return _states; }
    }

    public T CurrentState
    {
      get { return _currentState; }
    }

    public string CurrentName
    {
      get
      {
        if (_currentState != null)
          return _currentState.Name;
        else
          return "";
      }
    }

    public StateManager<T> Parent
    {
      get { return _parent; }
      set
      {
        _parent = value;
        if (_parent != null)
          _states.Parent = _parent.States;
        else
          _states.Parent = null;
      }
    }

    public bool Add(T state)
    {
      if (!_states.ContainsKey(state.Name.ToLower()))
      {
        _states.Add(state.Name.ToLower(), state);
        return true;
      }
      return false;
    }

    public bool MakeCurrent(string stateName)
    {
      T state = _states.GetInheritedValue(stateName.ToLower());
      if (state != null)
      {
        _currentState = state;
        //TODO: Enqueue state change event, but how? I don't know the owner!
        return true;
      }

      return false;
    }

    public T GetState(string stateName)
    {
      return _states.GetInheritedValue(stateName);
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      T firstState = null;

      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "state")
        {
          T state = new T();
          if (!state.Load(child))
            return false;
          if (!Add(state))
          {
            OkuManagers.Logger.LogError("Trying to add state " + state.Name + " twice! " + node.OuterXml);
            return false;
          }

          if (firstState == null)
            firstState = state;
        }

        child = child.NextSibling;
      }

      if (_states.Count > 0)
      {
        _defaultName = node.GetTagValue("default");
        if (_defaultName != null)
        {
          if (_states.ContainsInheritedKey(_defaultName.ToLower()))
            _currentState = _states[_defaultName.ToLower()];
          else
          {
            OkuManagers.Logger.LogError("Could not find default state with name " + _defaultName + "! " + node.OuterXml);
            return false;
          }
        }
        else
        {
          if (firstState != null)
          {
            _currentState = firstState;
            OkuManagers.Logger.LogInfo("No default state defined! Using " + firstState.Name + " instead.");
          }
          else
          {
            OkuManagers.Logger.LogInfo("No default state defined and no alternative state found!");
            return false;
          }
        }
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("states");

      writer.WriteValueTag("default", _defaultName);

      foreach (T state in _states.Values)
      {
        if (!state.Save(writer))
          return false;
      }

      writer.WriteEndElement();

      return true;
    }

  }
}
