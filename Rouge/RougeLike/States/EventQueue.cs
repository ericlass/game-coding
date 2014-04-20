using System;
using System.Collections.Generic;
using OkuBase;

namespace RougeLike.States
{
  public delegate void OnEventDelegate(string eventId, object data);

  public class EventQueue
  {
    private Dictionary<string, HashSet<OnEventDelegate>> _listeners = new Dictionary<string, HashSet<OnEventDelegate>>();
    private List<Event> _activeQueue = new List<Event>();
    private List<Event> _backgroundQueue = new List<Event>();

    public bool AddListener(string eventId, OnEventDelegate listener)
    {
      if (!_listeners.ContainsKey(eventId))
        _listeners.Add(eventId, new HashSet<OnEventDelegate>());

      return _listeners[eventId].Add(listener);
    }

    // Removes listener from one specific eventId
    public bool RemoveListener(string eventId, OnEventDelegate listener)
    {
      if (!_listeners.ContainsKey(eventId))
        return false;

      return _listeners[eventId].Remove(listener);
    }

    //Removes listener from ALL events
    public bool RemoveListener(OnEventDelegate listener)
    {
      bool result = false;

      foreach (HashSet<OnEventDelegate> listeners in _listeners.Values)
        result = result || listeners.Remove(listener);

      return result;
    }

    public void QueueEvent(string eventId, object data)
    {
      _activeQueue.Add(new Event(eventId, data));
    }

    public void TriggerEvent(string eventId, object data)
    {
      if (!_listeners.ContainsKey(eventId))
        return;

      foreach (OnEventDelegate listener in _listeners[eventId])
        listener(eventId, data);
    }

    private void SwapQueues()
    {
      List<Event> temp = _backgroundQueue;
      _backgroundQueue = _activeQueue;
      _activeQueue = temp;
    }

    public void ProcessEvents()
    {
      SwapQueues();

      foreach (Event ev in _backgroundQueue)
      {
        try
        {
          TriggerEvent(ev.Id, ev.Data);
        }
        catch (Exception e)
        {
          OkuManager.Instance.Logging.LogError("Error processing eventId [" + ev.Id + ", " + ev.Data + "]! Cause: " + e.Message);
        }
      }

      _backgroundQueue.Clear();
    }

    /// <summary>
    /// Clears the event queue. This includes all queued events AND all listeners.
    /// </summary>
    public void Clear()
    {
      _activeQueue.Clear();
      _backgroundQueue.Clear();
      _listeners.Clear();
    }

  }
}
