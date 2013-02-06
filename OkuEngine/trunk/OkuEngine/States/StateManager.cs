﻿using System;
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
    /// <summary>
    /// Delegate for the change event.
    /// </summary>
    public delegate void StateChangedDelegate();

    private Dictionary<string, T> _states = new Dictionary<string, T>();
    private string _defaultName = null;
    private string _previousStateName = null;
    private string _currentStateName = null;
    private bool _overwriteStates = false;

    public StateManager()
    {
    }

    /// <summary>
    /// Creates a new state manager defining if existing
    /// statets are overwritten while loading or not.
    /// </summary>
    /// <param name="overwriteStates">If true, existing states are overwritten when the Load() method is executed.</param>
    public StateManager(bool overwriteStates)
    {
      _overwriteStates = overwriteStates;
    }

    /// <summary>
    /// Event is fired when the current state is changed.
    /// </summary>
    public event StateChangedDelegate OnStateChange;

    public bool OverwriteStates
    {
      get { return _overwriteStates; }
    }

    /// <summary>
    /// Gets or sets the name of the default state.
    /// </summary>
    public string DefaultStateName
    {
      get { return _defaultName; }
      set { _defaultName = value; }
    }

    /// <summary>
    /// Gets or sets the name of the previous state.
    /// </summary>
    public string PreviousStateName
    {
      get { return _currentStateName; }
    }

    /// <summary>
    /// Gets or sets the name of the current state.
    /// </summary>
    public string CurrentStateName
    {
      get { return _currentStateName; }
    }

    /// <summary>
    /// Sets the current state.
    /// </summary>
    /// <param name="name">The name of the new current state.</param>
    /// <returns>True if the state was set successfully, false if there is no state with the given name.</returns>
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

    /// <summary>
    /// Gets the current state object.
    /// </summary>
    /// <returns>The current state object or null if there is no current state.</returns>
    public T GetCurrentState()
    {
      if (_states.ContainsKey(_currentStateName))
        return _states[_currentStateName];
      else
        return null;
    }

    /// <summary>
    /// Adds the given state to the manager.
    /// </summary>
    /// <param name="state">The state to be added.</param>
    /// <returns>True if the state was added, false if there already is a state with the same name.</returns>
    public bool Add(T state)
    {
      if (!_states.ContainsKey(state.Name))
      {
        _states.Add(state.Name, state);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the given state from manager,
    /// </summary>
    /// <param name="state">The state to be removed.</param>
    /// <returns>True if the state was removed, false if the manager did not contain the state.</returns>
    public bool Remove(T state)
    {
      return _states.Remove(state.Name);
    }

    /// <summary>
    /// Clears all states from the manager.
    /// </summary>
    public void Clear()
    {
      _states.Clear();
    }

    /// <summary>
    /// Gets the number of states the manager contains.
    /// </summary>
    public int Count
    {
      get { return _states.Count; }
    }

    /// <summary>
    /// Gets a list of all states the manager contains.
    /// </summary>
    public List<T> Values
    {
      get { return new List<T>(_states.Values); }
    }

    public bool Load(XmlNode node)
    {
      _defaultName = node.GetTagValue("default");
      _currentStateName = _defaultName;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.Trim().ToLower() == "state")
        {
          string name = child.GetTagValue("name");

          T state = new T();
          if (!state.Load(child))
            OkuManagers.Logger.LogError("Could not load state " + name + "! " + child.OuterXml);

          if (_overwriteStates)
          {
            if (_states.ContainsKey(name))
              _states[name].Merge(state);
            else
              Add(state);
          }
          else
          {
            if (!Add(state))
            {
              OkuManagers.Logger.LogError("State " + name + " is defined twice! " + child.OuterXml);
            }
          }
        }

        child = child.NextSibling;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("states");
      foreach (KeyValuePair<string, T> state in _states)
      {
        if (!state.Value.Save(writer))
          return false;
      }
      writer.WriteEndElement();

      return true;
    }

  }
}
