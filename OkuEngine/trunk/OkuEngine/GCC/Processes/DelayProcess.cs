using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OkuEngine.GCC.Processes
{
  public class DelayProcess : Process
  {
    private float _delay = 0.0f;
    private float _currenTime = 0.0f;

    public DelayProcess(float delay)
    {
      _delay = delay;
    }

    public float Delay
    {
      get { return _delay; }
    }

    public override void OnUpdate(float dt)
    {
      _currenTime += dt;
      if (_currenTime >= _delay)
        Succeed();
    }

  }
}
