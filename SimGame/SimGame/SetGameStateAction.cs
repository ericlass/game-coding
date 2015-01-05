using System;
using System.Collections.Generic;

namespace SimGame
{
  public class SetGameStateAction : IAction
  {
    private IGameDataProvider _data = null;
    private string _targetState = null;

    public SetGameStateAction(IGameDataProvider data, string targetState)
    {
      _data = data;
      _targetState = targetState;
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
