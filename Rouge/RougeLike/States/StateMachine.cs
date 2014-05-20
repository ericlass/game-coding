using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class StateMachine
  {
    private StateMap _states = new StateMap();
    private string _initialState = null;
    private EntityObject _gameObject = null;

    private string _currentState = null;
    private bool _initialized = false;

    public StateMachine()
    {
    }

    public StateMachine(EntityObject gameObject)
    {
      _gameObject = gameObject;
    }

    public StateMap States
    {
      get { return _states; }
    }

    public string InitialState
    {
      get { return _initialState; }
      set { _initialState = value; }
    }

    public EntityObject GameObject
    {
      get { return _gameObject; }
      set { _gameObject = value; }
    }

    public string CurrentState
    {
      get { return _currentState; }
      set
      {
        if (_currentState != null)
          _states[_currentState].Leave(_gameObject);

        if (!_states.ContainsKey(value))
          throw new OkuBase.OkuException("State '" + value + "' is not available in this state machine!");

        System.Diagnostics.Debug.WriteLine("Entity '" + _gameObject.Id + "' state change: " + _currentState + " -> " + value);

        _currentState = value;
        _states[_currentState].Enter(_gameObject);
      }
    }

    public void Init()
    {
      if (_initialized)
        throw new OkuBase.OkuException("Cannot initialize a state machine that has already been initialized!");

      _currentState = _initialState;

      foreach (StateBase state in _states.Values)
        state.Init();

      _initialized = true;
    }

    public void Update(float dt)
    {
      string next = _states[_currentState].Update(dt, _gameObject);
      if (next != null)
        CurrentState = next;
    }

    public void Render()
    {
      _states[_currentState].Render(_gameObject);
    }

    public void Finish()
    {
      if (!_initialized)
        throw new OkuBase.OkuException("Cannot finish a state machine that has not been initialized!");

      foreach (StateBase state in _states.Values)
        state.Finish();

      _initialized = false;
    }

    public void Clear()
    {
      if (_initialized)
        throw new OkuBase.OkuException("Cannot clear a state machine that is already initialized! Finish it first!");

      _states.Clear();
    }

    //How to get states to register themselves to the state factory? Maybe via reflections?
    //-> With Reflections, just like the other factories.

  }
}
