using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public interface IStateMachine
  {
    string CurrentState { get; set; }
  }
}
