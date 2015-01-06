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

    public TimerAction(IGameDataProvider data, params object[] parameters)
    {
      if (parameters.Length < 2)
        throw new ArgumentException("TimerAction needs at least two parameters!");
    
      _data = data;
      
      _time = parameters[0] as float;
      _eventToFire = parameters[1] as string;
      
      if (parameters.Length >= 3)
        _cancelEvent = parameters[2] as string;
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
