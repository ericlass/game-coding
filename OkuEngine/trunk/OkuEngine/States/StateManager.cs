using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Collections;

namespace OkuEngine.States
{
  /// <summary>
  /// Handles a set of entity states.
  /// </summary>
  public class StateManager<T> : IStoreable where T : StateBase, new()
  {
    public delegate void StateChangedDelegate();

    private Dictionary<string, T> _states = new Dictionary<string, T>();
    private string _defaultName = null;
    private string _previousStateName = null;
    private string _currentStateName = null;
    private bool _overwriteStates = false;

    public StateManager()
    {
    }

    public StateManager(bool overwriteStates)
    {
      _overwriteStates = overwriteStates;
    }

    public event StateChangedDelegate OnStateChange;

    public bool OverwriteStates
    {
      get { return _overwriteStates; }
    }

    public string DefaultStateName
    {
      get { return _defaultName; }
      set { _defaultName = value; }
    }

    public string PreviousStateName
    {
      get { return _currentStateName; }
    }

    public string CurrentStateName
    {
      get { return _currentStateName; }
    }

    public bool SetCurrentState(string name)
    {
      if (_states.ContainsKey(name))
      {
        _previousStateName = _currentStateName;
        _currentStateName = name;
        OnStateChange();
        return true;
      }
      return false;
    }

    public T GetCurrentState()
    {
      if (_states.ContainsKey(_currentStateName))
        return _states[_currentStateName];
      else
        return null;
    }

    public bool Add(T state)
    {
      if (!_states.ContainsKey(state.Name))
      {
        _states.Add(state.Name, state);
        return true;
      }
      return false;
    }

    public bool Remove(T state)
    {
      return _states.Remove(state.Name);
    }

    public void Clear()
    {
      _states.Clear();
    }

    public int Count
    {
      get { return _states.Count; }
    }

    public List<T> Values
    {
      get { return new List<T>(_states.Values); }
    }

    public bool Load(XmlNode node)
    {
      _defaultName = node.GetTagValue("default");

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.Trim().ToLower() == "state")
        {
          string name = child.GetTagValue("name");

          T state = null;
          if (_overwriteStates)
          {
            if (_states.ContainsKey(name))
              state = _states[name];
          }

          if (state == null)
            state = new T();

          if (state.Load(child))
          {
            //TODO: Log
          }

          if (_overwriteStates)
          {
            if (_states.ContainsKey(name))
              _states[name] = state;
            else
              Add(state);
          }
          else
          {
            if (!Add(state))
            {
              //TODO: Log
            }
          }
        }

        child = child.NextSibling;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

  }
}
