using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public interface IGameState
  {
    string Id { get; }

    void Enter(IGameDataProvider data);
    void Update(IGameDataProvider data, float dt);
    void Render(IGameDataProvider data);
    void Leave(IGameDataProvider data);
  }
}
