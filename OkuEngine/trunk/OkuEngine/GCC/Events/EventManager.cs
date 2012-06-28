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
    private List<BaseEvent>[] _queues = new List<BaseEvent>[NumQueues];
    private int _activeQueue = 0;

    private string _name = null;

    public EventManager(string name)
    {
      _name = name;

      for (int i = 0; i < NumQueues; i++)
      {
        _queues[i] = new List<BaseEvent>();
      }
    }

    public string Name
    {
      get { return _name; }
    }

    private List<BaseEvent> ActiveQueue
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

    public bool TriggerEvent(BaseEvent eventData)
    {
      if (eventData != null && _listeners.ContainsKey(eventData.EventType))
      {
        foreach (EventListenerDelegate listener in _listeners[eventData.EventType])
        {
          listener(eventData);
        }
        return true;
      }

      return false;
    }

    public bool QueueEvent(BaseEvent eventData)
    {
      if (eventData != null && _listeners.ContainsKey(eventData.EventType))
      {
        ActiveQueue.Add(eventData);
        return true;
      }

      return false;
    }

    public bool AbortEvent(int eventType, bool allOfType)
    {
      bool result = false;
      if (_listeners.ContainsKey(eventType))
      {
        List<BaseEvent> active = ActiveQueue;
        for (int i = active.Count - 1; i >= 0; i--)
        {
          if (active[i].EventType == eventType)
          {
            active.RemoveAt(i);
            if (!allOfType)
              break;
            result = true;
          }
        }
      }
      return result;
    }

    public bool Update()
    {
      return Update(float.MaxValue);
    }

    public bool Update(float maxTime)
    {
      long startTick, endTick, freq;
      Kernel32.QueryPerformanceFrequency(out freq);
      Kernel32.QueryPerformanceCounter(out startTick);

      List<BaseEvent> queueToProcess = ActiveQueue;
      _activeQueue = (_activeQueue + 1) % NumQueues;
      ActiveQueue.Clear();

      for (int i = 0; i < queueToProcess.Count; i++)
      {
        BaseEvent current = queueToProcess.PopFirst();
        int eventType = current.EventType;
        if (_listeners.ContainsKey(eventType))
        {
          foreach (EventListenerDelegate listener in _listeners[eventType])
          {
            listener(current);
          }
        }

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
