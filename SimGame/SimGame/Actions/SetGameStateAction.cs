using System;
using System.Collections.Generic;

namespace SimGame
{
  public class SetGameStateAction : IAction
  {
    private IStateMachine _stateMachine = null;
    private string _targetState = null;
    private object[] _parameters = null;

    public SetGameStateAction(IStateMachine stateMachine, params object[] parameters)
    {
      if (parameters.Length < 1)
        throw new ArgumentException("SetGameStateAction needs one parameter, the target state id!");

      _stateMachine = stateMachine;
      _targetState = parameters[0] as string;
      _parameters = parameters[1] as object[];
    }

    public bool Update(float dt)
    {
      _stateMachine.SetCurrentState(_targetState, _parameters);
      return true;
    }

    public void Cancel()
    {
    }

  }
}
