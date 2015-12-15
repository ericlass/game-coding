using System;
using System.Collections.Generic;
using OkuEngine.Collections;

namespace OkuEngine.States
{
  public class StateMachine
  {
    private string _initialState = null;
    private HashSet<string> _states = new HashSet<string>();
    private List<Transition> _transitions = new List<Transition>();
    private BlackBoard _blackBoard = new BlackBoard();

    private string _currentState = null;
    private List<Transition> _activeTransitions = new List<Transition>();

    public string InitialState
    {
      get { return _initialState; }
      set { _initialState = value; }
    }

    public HashSet<string> States
    {
      get { return _states; }
      set { _states = value; }
    }

    public List<Transition> Transitions
    {
      get { return _transitions; }
      set { _transitions = value; }
    }

    public BlackBoard Blackboard
    {
      get { return _blackBoard; }
      set { _blackBoard = value; }
    }

    public string CurrentState
    {
      get { return _currentState; }
      set { _currentState = value; }
    }

    public string Update()
    {
      //Go to initial state at first
      if (_currentState == null)
        _currentState = _initialState;

      //Find possible transitions 
      _activeTransitions.Clear();
      foreach (var trans in _transitions)
      {
        if (trans.SourceState == _currentState && trans.ShouldTransition(_blackBoard))
          _activeTransitions.Add(trans);
      }

      //Find possible transition with highest priority
      Transition highest = null;
      foreach (Transition trans in _activeTransitions)
      {
        if (highest == null || highest.Priority < trans.Priority)
          highest = trans;
      }

      //Switch to new state if required
      if (highest != null)
        _currentState = highest.TargetState;

      return _currentState;
    }

    //Should only be called once after setting up the state machine and before running it to make sure the configuration is correct.
    public bool Verify()
    {
      foreach (var trans in _transitions)
      {
        //Check that all transitions have all fields set
        if (trans.TargetState == null)
          return false;
        if (trans.SourceState == null)
          return false;
        if (trans.ShouldTransition == null)
          return false;

        //Check that all states referenced in the transitions exist
        if (!_states.Contains(trans.SourceState))
          return false;

        if (!_states.Contains(trans.SourceState))
          return false;
      }

      //Check that all states, except the initial state, have an incomming transition
      //Check that all states have an outgoing transition
      foreach (var state in _states)
      {
        bool hasIn = false;
        bool hasOut = false;
        foreach (var trans in _transitions)
        {
          hasIn = hasIn || (state == _initialState) || (trans.TargetState == state);
          hasOut = hasOut || (trans.SourceState == state);            
        }

        if (!hasIn || !hasOut)
          return false;
      }

      return true;
    }

  }
}
