using System;

namespace SimGame.States
{
  public interface IGameState
  {
    void Enter(IGameDataProvider data);
    void Update(IGameDataProvider data, float dt);
    void Render(IGameDataProvider data);
    void Leave(IGameDataProvider data);
  }
}
