using System;
using OkuBase;

namespace RougeLike
{
  // Must be used this way:
  // 1. Create object (obviously mandatory)
  // 2. Setup States (optional, but that makes no sense)
  // 3. Setup transitions (optional, you can still change states manually)
  // 4. Set initial state (mandatory)
  // 5. Activate()
  // When finished us Deactivate() to unregister listener!
  public class StateMachine : IUpdatable
  {
    private StateMap _states = new StateMap();

    private string _initialState = null;
    private string _currentState = null;

    public StateMachine()
    {
    }

    public StateMachine(string initialState)
    {
      _initialState = initialState;
    }

    public StateMap States
    {
      get { return _states; }
    }

    public void Update(float dt)
    {
      State current = CurrentState;
      if (current != null)
        current.Update(dt);
    }

    public string CurrentStateId
    {
      get { return _currentState; }
      set
      {
        if (!_states.ContainsId(value))
          throw new Exception("Target State \"" + value + "\" is not defined!");

        System.Diagnostics.Debug.WriteLine("State change: " + _currentState + "->" + value);

        State current = CurrentState;
        if (current != null)
          current.Leave();
          
        _currentState = value;
        CurrentState.Enter();
      }
    }

    public State CurrentState
    {
      get
      {
        if (_currentState == null)
          return null;

        return _states[_currentState];
      }
    }

  }
}
