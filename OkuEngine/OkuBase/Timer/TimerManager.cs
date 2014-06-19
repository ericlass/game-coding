using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Settings;
using OkuBase.Utils;

namespace OkuBase.Timer
{
  /// <summary>
  /// A delegate for timers and intervals.
  /// </summary>
  /// <param name="id">The id of the timer or interval that triggered this event.</param>
  /// <param name="data">The user data that was passed when the interval was created.</param>
  public delegate void TimerEventDelegate(int id, object data);

  /// <summary>
  /// Defines a manager for timers and intervals.
  /// </summary>
  public class TimerManager : Manager
  {
    private Dictionary<int, ITimer> _timers = null;
    private List<int> _clearedIds = null;

    private bool _updating = false;
    private List<ITimer> _queuedTimers = null;

    public override void Initialize(OkuSettings settings)
    {
      _timers = new Dictionary<int, ITimer>();
      _clearedIds = new List<int>();
      _queuedTimers = new List<ITimer>();
    }

    /// <summary>
    /// Creates a new interval with the given milli seconds and delegate and no user data.
    /// </summary>
    /// <param name="millis">The number of milli seconds to pass between the delegate calls.</param>
    /// <param name="onTimer">The delegate to be called at each interval.</param>
    /// <returns>The id of the new interval. Remeber this to be able to stop interval later usiong the Clearinterval function.</returns>
    public int SetInterval(int millis, TimerEventDelegate onTimer)
    {
      return SetInterval(millis, onTimer, null);
    }

    /// <summary>
    /// Creates a new interval with the given milli seconds, delegate and user data.
    /// </summary>
    /// <param name="millis">The number of milli seconds to pass between the delegate calls.</param>
    /// <param name="onTimer">The delegate to be called at each interval.</param>
    /// <param name="data">The user data to be passed to the delegate.</param>
    /// <returns>The id of the new interval. Remeber this to be able to stop interval later usiong the Clearinterval function.</returns>
    public int SetInterval(int millis, TimerEventDelegate onTimer, object data)
    {
      int result = KeySequence.NextValue(KeySequence.TimerSequence);
      Interval inter = new Interval(result, millis, onTimer, data);
      if (_updating)
        _queuedTimers.Add(inter);
      else
        _timers.Add(result, inter);

      return result;
    }

    /// <summary>
    /// Creates a new timer with the given millis and delegate.
    /// </summary>
    /// <param name="millis">The number milli seconds to pass until the delegate is triggered.</param>
    /// <param name="onTimer">The delegate to be called after the given milli seconds passed.</param>
    public void SetTimer(int millis, TimerEventDelegate onTimer)
    {
      SetTimer(millis, onTimer, null);
    }

    /// <summary>
    /// Creates a new timer with the given millis, delegate and user data.
    /// </summary>
    /// <param name="millis">The number milli seconds to pass until the delegate is triggered.</param>
    /// <param name="onTimer">The delegate to be called after the given milli seconds passed.</param>
    /// <param name="data">The user data to be passed to the delegate.</param>
    public void SetTimer(int millis, TimerEventDelegate onTimer, object data)
    {
      int newId = KeySequence.NextValue(KeySequence.TimerSequence);
      Timer timer = new Timer(newId, millis, onTimer, data);
      if (_updating)
        _queuedTimers.Add(timer);
      else
        _timers.Add(newId, timer);
    }

    /// <summary>
    /// Clears the interval with the given id. After this is called, the interval will never be called again.
    /// </summary>
    /// <param name="id">The id of the interval to remove.</param>
    /// <returns>True if the interval was cleared, false if the id was not correct.</returns>
    public bool ClearInterval(int id)
    {
      if (_timers.ContainsKey(id))
      {
        _clearedIds.Add(id);
        return true;
      }
      return false;
    }    

    public override void Update(float dt)
    {
      foreach (int clearedId in _clearedIds)
        _timers.Remove(clearedId);

      _clearedIds.Clear();

      _updating = true;
      foreach (ITimer timer in _timers.Values)
      {
        if (timer.Update(dt))
          _clearedIds.Add(timer.Id);
      }
      _updating = false;

      foreach (ITimer timer in _queuedTimers)
        _timers.Add(timer.Id, timer);

      _queuedTimers.Clear();
    }

    public override void Finish()
    {
      _timers.Clear();
    }

  }
}
