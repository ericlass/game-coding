using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.States
{
  public interface IStateComponent : IStoreable
  {
    StateBase Owner { get; set; }
    string ComponentName { get; }
    IStateComponent Copy();
  }
}
