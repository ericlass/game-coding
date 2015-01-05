using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public interface IGameDataProvider
  {
    EventManager EventQueue { get; }
    string GameState { get; set; }
  }
}
