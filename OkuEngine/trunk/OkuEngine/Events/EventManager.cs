using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Events
{
  /// <summary>
  /// Defines a manager for an event queue.
  /// </summary>
  public class EventManager : IEventManager
  {
    private const int NumQueues = 2;

    private Dictionary<int, HashSet<EventListenerDelegate>> _listeners = new Dictionary<int, HashSet<EventListenerDelegate>>();
    private List<Event>[] _queues = new List<Event>[NumQueues];
    private int _activeQueue = 0;
    private List<Event> _unusedEvents = new List<Event>();

    private string _name = null;

    /// <summary>
    /// Creates a new event mananger with the given name.
    /// </summary>
    /// <param name="name"></param>
    public EventManager(string name)
    {
      _name = name;

      for (int i = 0; i < NumQueues; i++)
      {
        _queues[i] = new List<Event>();
      }
    }

    /// <summary>
    /// Gets the name of the event manager.
    /// </summary>
    public string Name
    {
      get { return _name; }
    }

    /// <summary>
    /// Gets the current active queue.
    /// </summary>
    private List<Event> ActiveQueue
    {
      get { return _queues[_activeQueue]; }
    }

    /// <summary>
    /// Adds a new listener for the given event type to the event manager.
    /// </summary>
    /// <param name="eventType">The type of event to listen to.</param>
    /// <param name="eventDelegate">The delegate to call if the event happens.</param>
    /// <returns>True if the listener was added, false if the listener is already registered for the event.</returns>
    public bool AddListener(int eventType, EventListenerDelegate eventDelegate)
    {
      if (!_listeners.ContainsKey(eventType))
      {
        _listeners.Add(eventType, new HashSet<EventListenerDelegate>());
      }

      if (_listeners[eventType].Contains(eventDelegate))
      {
        OkuManagers.Logger.LogError("Trying to register '" + eventDelegate.ToString() + "' twice for event '" + eventType + "'!");
        return false;
      }

      _listeners[eventType].Add(eventDelegate);
      return true;
    }

    /// <summary>
    /// Removes the given listener for the given event type.
    /// </summary>
    /// <param name="eventType">The event type.</param>
    /// <param name="eventDelegate">The event listener delegate.</param>
    /// <returns>True if the listener was removed, false if the listener was not registered for the event type.</returns>
    public bool RemoveListener(int eventType, EventListenerDelegate eventDelegate)
    {
      if (eventDelegate != null && _listeners.ContainsKey(eventType) && _listeners[eventType].Contains(eventDelegate))
      {
        _listeners[eventType].Remove(eventDelegate);
        //If there are no more listeners for an event, remove it from the map
        if (_listeners[eventType].Count == 0)
        {
          _listeners.Remove(eventType);
        }
        return true;
      }

      return false;
    }

    /// <summary>
    /// Triggers the given event. Triggering an event means that
    /// the listeners are informed immediatelly, not in the next
    /// run of event processing. Use with caution!
    /// </summary>
    /// <param name="eventType">The type of event to trigger.</param>
    /// <param name="eventData">The data of the event.</param>
    /// <returns>True if any listeners where triggered, false if there are no listeners for the event.</returns>
    public bool TriggerEvent(int eventType, object eventData)
    {
      if (_listeners.ContainsKey(eventType))
      {
        foreach (EventListenerDelegate listener in _listeners[eventType])
        {
          listener(eventType, eventData);
        }
        return true;
      }

      return false;
    }

    /// <summary>
    /// Adds the given event to the event queue.
    /// The listeners will be informed on the next
    /// run of event processing.
    /// </summary>
    /// <param name="eventType">The type of the event.</param>
    /// <param name="eventData">The data of the event.</param>
    /// <returns>True if the event was enqueued, false if there are no listeners for the event.</returns>
    public bool QueueEvent(int eventType, object eventData)
    {
      if (_listeners.ContainsKey(eventType))
      {
        Event ev;

        if (_unusedEvents.Count > 0)
        {
          ev = _unusedEvents.PopLast();
          ev.Set(eventType, eventData);
        }
        else
          ev = new Event(eventType, eventData);

        ActiveQueue.Add(ev);
        return true;
      }

      return false;
    }

    /// <summary>
    /// Removes the one or all event of the given type from the queue.
    /// </summary>
    /// <param name="eventType">The type of event to remove.</param>
    /// <param name="allOfType">Remove only the last event (false) or all of the given type (true).</param>
    /// <returns>True if any events where removed, else false.</returns>
    public bool AbortEvent(int eventType, bool allOfType)
    {
      bool result = false;
      if (_listeners.ContainsKey(eventType))
      {
        List<Event> active = ActiveQueue;
        for (int i = active.Count - 1; i >= 0; i--)
        {
          if (active[i].EventType == eventType)
          {
            _unusedEvents.Add(active[i]);
            active.RemoveAt(i);
            if (!allOfType)
              break;
            result = true;
          }
        }
      }
      return result;
    }

    /// <summary>
    /// Executes a single run of event processing.
    /// </summary>
    /// <param name="maxTime">The maximum time the event processing ios allowed to take.</param>
    /// <returns>True if all events where processed, false if not all events could be processed in the given time.</returns>
    public bool Update(float maxTime)
    {
      long startTick, endTick, freq;
      Kernel32.QueryPerformanceFrequency(out freq);
      Kernel32.QueryPerformanceCounter(out startTick);

      List<Event> queueToProcess = ActiveQueue;
      _activeQueue = (_activeQueue + 1) % NumQueues;
      ActiveQueue.Clear();

      for (int i = 0; i < queueToProcess.Count; i++)
      {
        Event current = queueToProcess.PopFirst();
        int eventType = current.EventType;
        if (_listeners.ContainsKey(eventType))
        {
          foreach (EventListenerDelegate listener in _listeners[eventType])
          {
            listener(current.EventType, current.EventData);
          }
        }
        _unusedEvents.Add(current);

        Kernel32.QueryPerformanceCounter(out endTick);
        if (((endTick - startTick) / (float)freq) >= maxTime)
        {
          System.Diagnostics.Debug.WriteLine("EVENT LOOP: Time ran out!");
          break;
        }
      }

      bool flushed = queueToProcess.Count == 0;
      if (!flushed)
      {
        ActiveQueue.InsertRange(0, queueToProcess);
      }
      return flushed;
    }

  }
}
