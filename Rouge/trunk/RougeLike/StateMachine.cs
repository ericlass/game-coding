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
    private StateTransitions _transitions = new StateTransitions();
    private OnEventDelegate _delegate = null;

    private bool _active = false;
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

    public StateTransitions Transitions
    {
      get { return _transitions; }
    }

    public void Update(float dt)
    {
      _states.Update(dt);
    }

    private OnEventDelegate EventDelegate
    {
      get
      {
        if (_delegate == null)
          _delegate = new OnEventDelegate(OnEvent);

        return _delegate;
      }
    }

    public void Activate()
    {
      if (_active)
        throw new Exception("Trying to active an already active state machine!");

      if (_initialState == null)
        throw new Exception("No initial state defined!");

      foreach (EventId eventId in _transitions.GetEvents())
         GameManager.Instance.EventQueue.AddListener(eventId, EventDelegate);

      _currentState = _initialState;
      _active = true;
    }

    public void Deactivate()
    {
      if (_active)
        throw new Exception("Trying to deactive a non-active state machine!");

      GameManager.Instance.EventQueue.RemoveListener(EventDelegate);
      _active = false;
    }

    public bool IsActive
    {
      get { return _active; }
    }

    public string CurrentStateId
    {
      get { return _currentState; }
      set
      {
        if (!_states.ContainsId(value))
          throw new Exception("Target State \"" + value + "\" is not defined!");

        _currentState = value;
      }
    }

    public State CurrentState
    {
      get { return _states[_currentState]; }
    }

    private void OnEvent(EventId eventId, int data)
    {
      if (!_active)
      {
        OkuManager.Instance.Logging.LogError("Inactive state machine is receiving events!");
        return;
      }

      string target = _transitions.GetTargetState(eventId, _currentState);

      if (target == null)
        return;

      if (!_states.ContainsId(target))
      {
        OkuManager.Instance.Logging.LogError("Target State \"" + target + "\" is not defined!");
        return;
      }

      _currentState = target;
    }

  }
}
