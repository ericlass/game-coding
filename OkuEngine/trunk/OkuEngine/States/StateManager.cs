using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Collections;
using Newtonsoft.Json;

namespace OkuEngine.States
{
  /// <summary>
  /// Handles a set of entity states.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class StateManager : IStoreable
  {
    /// <summary>
    /// Delegate for the state change event.
    /// </summary>
    public delegate void StateChangedDelegate();

    private string _defaultName = null;
    private HashSet<State> _items = new HashSet<State>();

    private Dictionary<string, State> _stateMap = new Dictionary<string, State>();
    private string _previousStateName = null;
    private string _currentStateName = null;

    public StateManager()
    {
    }

    /// <summary>
    /// Event is fired when the current state is changed.
    /// </summary>
    public event StateChangedDelegate OnStateChange;

    /// <summary>
    /// Gets or sets the name of the default state.
    /// </summary>
    [JsonPropertyAttribute]
    public string DefaultStateName
    {
      get { return _defaultName; }
      set { _defaultName = value; }
    }

    [JsonPropertyAttribute]
    public HashSet<State> Items
    {
      get { return _items; }
      set { _items = value; }
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
      if (_stateMap.ContainsKey(name))
      {
        _previousStateName = _currentStateName;
        _currentStateName = name;
        if (OnStateChange != null)
          OnStateChange();
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the current state object.
    /// </summary>
    /// <returns>The current state object or null if there is no current state.</returns>
    public State GetCurrentState()
    {
      if (_stateMap.ContainsKey(_currentStateName))
        return _stateMap[_currentStateName];
      else
        return null;
    }

    /// <summary>
    /// Adds the given state to the manager.
    /// </summary>
    /// <param name="state">The state to be added.</param>
    /// <returns>True if the state was added, false if there already is a state with the same name.</returns>
    public bool Add(State state)
    {
      if (!_stateMap.ContainsKey(state.Name))
      {
        _items.Add(state);
        _stateMap.Add(state.Name, state);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the given state from manager,
    /// </summary>
    /// <param name="state">The state to be removed.</param>
    /// <returns>True if the state was removed, false if the manager did not contain the state.</returns>
    public bool Remove(State state)
    {
      _items.Remove(state);
      return _stateMap.Remove(state.Name);
    }

    /// <summary>
    /// Clears all states from the manager.
    /// </summary>
    public void Clear()
    {
      _items.Clear();
      _stateMap.Clear();
    }

    public bool AfterLoad()
    {
      _currentStateName = _defaultName;
      _previousStateName = _defaultName;

      _stateMap.Clear();
      foreach (State state in _items)
      {
        if (!state.AfterLoad())
          return false;
        _stateMap.Add(state.Name, state);
      }
      return true;
    }

  }
}
