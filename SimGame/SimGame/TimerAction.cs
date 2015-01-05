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
    private IGameDataProvider _data = null;

    public TimerAction(IGameDataProvider data, float time, string eventToFire)
    {
      _time = time;
      _eventToFire = eventToFire;
      _data = data;
    }

    public TimerAction(IGameDataProvider data, float time, string eventToFire, string cancelEvent)
    {
      _time = time;
      _eventToFire = eventToFire;
      _data = data;
      _cancelEvent = cancelEvent;
    }

    public bool Update(float dt)
    {
      _time -= dt;
      if (_time <= 0)
      {
        _data.EventQueue.QueueEvent(_eventToFire);
        return true;
      }

      return false;
    }

    public void Cancel()
    {
      if (_cancelEvent != null)
        _data.EventQueue.QueueEvent(_cancelEvent);
    }
  }
}
