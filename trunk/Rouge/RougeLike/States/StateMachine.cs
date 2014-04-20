using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class StateMachine
  {
    private Dictionary<string, StateBase> _states = null;
    private List<Transition> _transitions = null;
    private string _currentState = null;

    public StateMachine()
    {
    }

    //Continue: How is the state machine initialized. It has to know all states and transitions to register for the events. In the end they will be loaded from a file.

    //How to get states to register themselves to the state factory? Maybe via reflections?

  }
}
