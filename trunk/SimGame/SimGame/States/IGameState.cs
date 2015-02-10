using System;

namespace SimGame.States
{
  public interface IGameState
  {
    void Enter();
    void Update(float dt);
    void Render();
    void Leave();
  }
}
