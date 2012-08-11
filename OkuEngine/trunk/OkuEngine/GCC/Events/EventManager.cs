using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Events
{
  public class EventManager : IEventManager
  {
    private const int NumQueues = 2;

    private Dictionary<int, HashSet<EventListenerDelegate>> _listeners = new Dictionary<int, HashSet<EventListenerDelegate>>();
    private List<Event>[] _queues = new List<Event>[NumQueues];
    private int _activeQueue = 0;
    private List<Event> _unusedEvents = new List<Event>();

    private string _name = null;

    public EventManager(string name)
    {
      _name = name;

      for (int i = 0; i < NumQueues; i++)
      {
        _queues[i] = new List<Event>();
      }
    }

    public string Name
    {
      get { return _name; }
    }

    private List<Event> ActiveQueue
    {
      get { return _queues[_activeQueue]; }
    }

    public bool AddListener(int eventType, EventListenerDelegate eventDelegate)
    {
      if (!_listeners.ContainsKey(eventType))
      {
        _listeners.Add(eventType, new HashSet<EventListenerDelegate>());
      }

      if (!_listeners[eventType].Contains(eventDelegate))
      {
        //TODO: Log warning that listener is registered twice
        return false;
      }

      _listeners[eventType].Add(eventDelegate);
      return true;
    }

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

    public bool QueueEvent(int eventType, object eventData)
    {
      if (eventData != null && _listeners.ContainsKey(eventType))
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
