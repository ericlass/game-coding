using System;
using SimGame.Events;
using SimGame.States;

namespace SimGame
{
  public interface IGameDataProvider : IStateMachine, IEventQueueContainer
  {
  }
}
