using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class TimerSystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      for (int i = currentLevel.Timers.Count - 1; i >= 0; i--)
      {
        Timer timer = currentLevel.Timers[i];
        if (timer.Update(currentLevel))
          currentLevel.Timers.RemoveAt(i);
      }
    }

  }
}
