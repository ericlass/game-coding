using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public static class ActionConstructors
  {
    public static TimerAction CreateTimerAction(object[] parameters)
    {
      if (parameters == null)
        throw new ArgumentException("Timer action cannot be created with no parameters!");

      TimerAction action;
      if (parameters.Length == 2)
        action = new TimerAction((float)parameters[0], (string)parameters[1]);
      else if (parameters.Length == 3)
        action = new TimerAction((float)parameters[0], (string)parameters[1], (string)parameters[2]);
      else
        throw new ArgumentException("Invalid number of parameters for TimerAction! Two parameters are required: Time(float); Event(string)");

      return action;
    }

    public static SwitchStateAction CreateSwitchStateAction(object[] parameters)
    {
      if (parameters == null || parameters.Length != 2)
        throw new ArgumentException("SwitchState action cannot be created with no parameters! Two parameters are required: TargetState(string); StateMachine(IStateMachine)");

      return new SwitchStateAction((string)parameters[0], (IStateMachine)parameters[1]);
    }
  }
}
