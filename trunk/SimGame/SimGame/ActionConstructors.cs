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
        throw new ArgumentException("TimerAction cannot be created with no parameters!");

      TimerAction action;
      if (parameters.Length == 3)
        action = new TimerAction((IGameDataProvider)parameters[0], (float)parameters[1], (string)parameters[2]);
      else if (parameters.Length == 4)
        action = new TimerAction((IGameDataProvider)parameters[0], (float)parameters[1], (string)parameters[2], (string)parameters[3]);
      else
        throw new ArgumentException("Invalid number of parameters for TimerAction! 3 or 4 required, " + parameters.Length + " received!");

      return action;
    }

    public static SetGameStateAction CreateSetGameStateAction(object[] parameters)
    {
      if (parameters == null)
        throw new ArgumentException("SetGameStateAction cannot be created with no parameters!");

      return new SetGameStateAction(parameters[0] as IGameDataProvider, parameters[1] as string);
    }

  }
}
