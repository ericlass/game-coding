using System;
using System.Collections.Generic;

namespace SimGame
{
  public class SetGameStateAction : IAction
  {
    private IGameDataProvider _data = null;
    private string _targetState = null;

    public SetGameStateAction(IGameDataProvider data, params object[] parameters)
    {
      if (parameters.Length < 1)
        throw new ArgumentException("SetGameStateAction needs one parameter, the target state id!");
    
      _data = data;
      _targetState = parameters[0] as string;
    }

    public bool Update(float dt)
    {
      _data.GameState = _targetState;
      return true;
    }

    public void Cancel()
    {
    }

  }
}
