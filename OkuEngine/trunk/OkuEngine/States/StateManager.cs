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

    public StateManager()
    {      
    }

    public InheritingDictionary<string, T> States
    {
      get { return _states; }
    }

    public T CurrentState
    {
      get { return _currentState; }
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
        return true;
      }
      return false;
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
