using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimGame
{
  public class TimerAction : IAction
  {
    private float _time = 0;
    private string _eventToFire = null;

    public TimerAction(float time)
    {
      _time = time;
    }

    public TimerAction(float time, string eventToFire)
    {
      _time = time;
      _eventToFire = eventToFire;
    }

    public bool Update(float dt, EventManager manager)
    {
      _time -= dt;
      if (_time <= 0)
      {
        manager.QueueEvent(_eventToFire);
        return true;
      }

      return false;
    }

  }
}
