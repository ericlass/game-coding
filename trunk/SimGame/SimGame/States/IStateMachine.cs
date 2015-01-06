using System;

namespace SimGame
{
  public interface IStateMachine
  {
    string CurrentState { get; }
    void SetCurrentState(string stateId, params object[] parameters);
  }
}
