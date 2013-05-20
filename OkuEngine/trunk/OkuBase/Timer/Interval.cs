using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Timer
{
  /// <summary>
  /// Defines an Interval.
  /// </summary>
  class Interval : ITimer
  {
    private int _id = 0;
    private float _millis = 0;
    private TimerEventDelegate _onTimerEvent = null;
    private object _data = null;
    private float _currentMillis = 0;

    /// <summary>
    /// Creates a new interval with the given paramters.
    /// </summary>
    /// <param name="id">The id of the new interval.</param>
    /// <param name="millis">The number of millis seconds that should pass between the intervals.</param>
    /// <param name="onTimer">The delegate that will be colled on every interval.</param>
    /// <param name="data">User definable data that is passed to the delegate.</param>
    public Interval(int id, float millis, TimerEventDelegate onTimer, object data)
    {
      _millis = millis;
      _currentMillis = millis;
      _onTimerEvent = onTimer;
      _data = data;
    }

    /// <summary>
    /// Gets or sets the of the interval.
    /// </summary>
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Gets or sets the milli seconds between the intervals.
    /// </summary>
    public float Millis
    {
      get { return _millis; }
      set { _millis = value; }
    }

    /// <summary>
    /// Gets the milli seconds that are left until the next interval is triggered.
    /// </summary>
    public float CurrentMillis
    {
      get { return _currentMillis; }
    }

    /// <summary>
    /// Gets or sets the delegate that is called at each interval.
    /// </summary>
    public TimerEventDelegate OnTimerEvent
    {
      get { return _onTimerEvent; }
      set { _onTimerEvent = null; }
    }

    /// <summary>
    /// Gets or sets the user data for this interval.
    /// </summary>
    public object Data
    {
      get { return _data; }
      set { _data = value; }
    }

    /// <summary>
    /// Updates the intervals internal counter and fires the specified delegate
    /// if the given number of millis has passed.
    /// </summary>
    /// <param name="dt">The number of seconds passed since the last frame.</param>
    /// <returns>Always false as intervals must be cleared manually.</returns>
    public bool Update(float dt)
    {
      _currentMillis -= dt * 1000.0f;
      if (_currentMillis <= 0)
      {
        _onTimerEvent(_id, _data);
        _currentMillis = _millis;
      }
      return false;
    }

  }
}
