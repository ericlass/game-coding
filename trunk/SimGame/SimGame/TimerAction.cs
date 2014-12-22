using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimGame
{
  public class TimerAction : IAction
  {
    private float _time = 0;
    private string _eventToFire = null;
    private string _cancelEvent = null;

    public TimerAction(float time, string eventToFire)
    {
      _time = time;
      _eventToFire = eventToFire;
    }

    public TimerAction(float time, string eventToFire, string cancelEvent)
    {
      _time = time;
      _eventToFire = eventToFire;
      _cancelEvent = cancelEvent;
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

    public void Cancel(EventManager manager)
    {
      if (_cancelEvent != null)
        manager.QueueEvent(_cancelEvent);
    }
  }
}
