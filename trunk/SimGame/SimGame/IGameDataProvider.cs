using System;
using SimGame.Events;
using SimGame.States;
using SimGame.Objects;

namespace SimGame
{
  public interface IGameDataProvider : IStateMachine, IEventQueueContainer
  {
    string GetContentPath();
    GameObjectManager ObjectManager { get; }
  }
}
