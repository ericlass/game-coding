using System;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class Timer
  {
    private static int _lastId = 0;

    private static int NextID
    {
      get
      {
        _lastId += 1;
        return _lastId;
      }
    }

    private int _id = NextID;
    private float _time = 0.0f;
    private float _currentTime = 0.0f;
    private bool _repeat = false;
    private string _event = null;

    public Timer(float time, string eventName, bool repeat)
    {
      _time = time;
      _currentTime = time;
      _repeat = repeat;
      _event = eventName;
    }

    public int ID
    {
      get { return _id; }
    }

    public bool Update(Level currentLevel)
    {
      _currentTime -= currentLevel.Engine.DeltaTime;
      if (_currentTime <= 0.0f)
      {
        currentLevel.Engine.QueueEvent(_event);

        if (_repeat)
          _currentTime = _currentTime + _time;
        else
          return true;
      }

      return false;
    }

  }
}
