using System;

namespace SimGame.States
{
  public interface IStateMachine
  {
    string CurrentState { get; }
    void SetCurrentState(string stateId);
  }
}
