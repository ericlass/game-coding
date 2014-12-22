using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public class SwitchStateAction : IAction
  {
    private string _targetState = null;
    private IStateMachine _stateMachine = null;

    public SwitchStateAction(string targetState, IStateMachine stateMachine)
    {
      _targetState = targetState;
      _stateMachine = stateMachine;
    }

    public bool Update(float dt, EventManager manager)
    {
      _stateMachine.CurrentState = _targetState;
      return true;
    }

    public void Cancel(EventManager manager)
    {
    }

  }
}
