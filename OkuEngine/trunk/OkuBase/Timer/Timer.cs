using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Timer
{
  /// <summary>
  /// Defines an timer. A timer only fires once and is automatically cleared.
  /// </summary>
  class Timer : ITimer
  {
    private int _id = 0;
    private float _millis = 0;
    private TimerEventDelegate _onTimerEvent = null;
    private object _data = null;

    /// <summary>
    /// Creates a new timer with the given paramters.
    /// </summary>
    /// <param name="id">The id of the new timer.</param>
    /// <param name="millis">The number of millis seconds that should pass between the timers.</param>
    /// <param name="onTimer">The delegate that will be colled on every timer.</param>
    /// <param name="data">User definable data that is passed to the delegate.</param>
    public Timer(int id, float millis, TimerEventDelegate onTimer, object data)
    {
      _millis = millis;
      _onTimerEvent = onTimer;
      _data = data;
    }

    /// <summary>
    /// Gets or sets the of the timer.
    /// </summary>
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Gets or sets the milli seconds between the timers.
    /// </summary>
    public float Millis
    {
      get { return _millis; }
      set { _millis = value; }
    }

    /// <summary>
    /// Gets or sets the delegate that is called at each timer.
    /// </summary>
    public TimerEventDelegate OnTimerEvent
    {
      get { return _onTimerEvent; }
      set { _onTimerEvent = null; }
    }

    /// <summary>
    /// Gets or sets the user data for this timer.
    /// </summary>
    public object Data
    {
      get { return _data; }
      set { _data = value; }
    }

    /// <summary>
    /// Updates the timers internal counter and fires the specified delegate
    /// if the given number of millis has passed.
    /// </summary>
    /// <param name="dt">The number of seconds passed since the last frame.</param>
    /// <returns>True if the delegate was triggered, else false.</returns>
    public bool Update(float dt)
    {
      _millis -= dt * 1000.0f;
      bool done = _millis <= 0;
      if (done)
        _onTimerEvent(_id, _data);
      return done;
    }

  }
}
