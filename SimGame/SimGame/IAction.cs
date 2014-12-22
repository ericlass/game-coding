using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public interface IAction
  {
    bool Update(float dt, EventManager manager);
  }
}
