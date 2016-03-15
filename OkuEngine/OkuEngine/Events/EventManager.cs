using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase;
using OkuBase.Platform;

namespace OkuEngine.Events
{
  /// <summary>
  /// Defines a manager for an event queue.
  /// </summary>
  public class EventManager
  {
    private class Event
    {
      public string Name { get; set; }
      public object Data { get; set; }
    }

    private Dictionary<string, HashSet<EventListenerDelegate>> _listeners = new Dictionary<string, HashSet<EventListenerDelegate>>();
    private List<Event> _backQueue = new List<Event>();
    private List<Event> _activeQueue = new List<Event>();
    private List<Event> _unusedEvents = new List<Event>();

    private string _name = null;

    /// <summary>
    /// Creates a new event mananger with the given name.
    /// </summary>
    /// <param name="name"></param>
    public EventManager(string name)
    {
      _name = name;
    }

    /// <summary>
    /// Gets the name of the event manager.
    /// </summary>
    public string Name
    {
      get { return _name; }
    }

    /// <summary>
    /// Adds a new listener for the given event type to the event manager.
    /// </summary>
    /// <param name="eventName">The type of event to listen to.</param>
    /// <param name="eventDelegate">The delegate to call if the event happens.</param>
    /// <returns>True if the listener was added, false if the listener is already registered for the event.</returns>
    public bool AddListener(string eventName, EventListenerDelegate eventDelegate)
    {
      if (!_listeners.ContainsKey(eventName))
        _listeners.Add(eventName, new HashSet<EventListenerDelegate>());

      if (_listeners[eventName].Contains(eventDelegate))
        return false;

      _listeners[eventName].Add(eventDelegate);
      return true;
    }

    /// <summary>
    /// Removes the given listener for the given event type.
    /// </summary>
    /// <param name="eventName">The event type.</param>
    /// <param name="eventDelegate">The event listener delegate.</param>
    /// <returns>True if the listener was removed, false if the listener was not registered for the event type.</returns>
    public bool RemoveListener(string eventName, EventListenerDelegate eventDelegate)
    {
      if (eventDelegate != null && _listeners.ContainsKey(eventName) && _listeners[eventName].Contains(eventDelegate))
      {
        _listeners[eventName].Remove(eventDelegate);
        //If there are no more listeners for an event, remove it from the map
        if (_listeners[eventName].Count == 0)
        {
          _listeners.Remove(eventName);
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
    /// <param name="eventName">The type of event to trigger.</param>
    /// <param name="eventData">The data of the event.</param>
    /// <returns>True if any listeners where triggered, false if there are no listeners for the event.</returns>
    public bool TriggerEvent(string eventName, params object[] eventData)
    {
      if (_listeners.ContainsKey(eventName))
      {
        foreach (EventListenerDelegate listener in _listeners[eventName])
        {
          listener(eventName, eventData);
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
    /// <param name="eventName">The type of the event.</param>
    /// <param name="eventData">The data of the event.</param>
    /// <returns>True if the event was enqueued, false if there are no listeners for the event.</returns>
    public bool QueueEvent(string eventName, params object[] eventData)
    {
      if (_listeners.ContainsKey(eventName))
      {
        Event ev;

        if (_unusedEvents.Count > 0)
        {
          ev = _unusedEvents.PopLast();
          ev.Name = eventName;
          ev.Data = eventData;
        }
        else
          ev = new Event() { Name = eventName, Data = eventData };

        _activeQueue.Add(ev);
        return true;
      }

      return false;
    }

    /// <summary>
    /// Removes one or all events of the given type from the queue.
    /// </summary>
    /// <param name="eventName">The type of event to remove.</param>
    /// <param name="allOfType">Remove only the last event (false) or all of the given type (true).</param>
    /// <returns>True if any events where removed, else false.</returns>
    public bool AbortEvent(string eventName, bool allOfType)
    {
      bool result = false;
      if (_listeners.ContainsKey(eventName))
      {
        for (int i = _activeQueue.Count - 1; i >= 0; i--)
        {
          if (_activeQueue[i].Name == eventName)
          {
            _unusedEvents.Add(_activeQueue[i]);
            _activeQueue.RemoveAt(i);
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

      _backQueue.Clear();
      //Swap queues
      List<Event> queueToProcess = _activeQueue;      
      _activeQueue = _backQueue;
      _backQueue = queueToProcess;

      //Process events
      for (int i = 0; i < queueToProcess.Count; i++)
      {
        Event current = queueToProcess.PopFirst();
        string eventName = current.Name;
        if (_listeners.ContainsKey(eventName))
        {
          foreach (EventListenerDelegate listener in _listeners[eventName])
            listener(current.Name, current.Data);
        }
        _unusedEvents.Add(current);

        Kernel32.QueryPerformanceCounter(out endTick);
        if (((endTick - startTick) / (float)freq) >= maxTime)
          break;
      }

      //If events are left, copy them into active queue
      bool flushed = queueToProcess.Count == 0;
      if (!flushed)
        _activeQueue.InsertRange(0, queueToProcess);

      return flushed;
    }

  }
}
