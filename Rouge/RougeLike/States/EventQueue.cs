using System;
using System.Collections.Generic;
using OkuBase;

namespace RougeLike.States
{
  public delegate void OnEventDelegate(string eventId, object data, string objectId);

  /// <summary>
  /// Defines a simple event queue that can be used to queue events and inform registered listeners about them.
  /// </summary>
  public class EventQueue
  {
    private Dictionary<string, HashSet<OnEventDelegate>> _listeners = new Dictionary<string, HashSet<OnEventDelegate>>();
    private List<Event> _activeQueue = new List<Event>();
    private List<Event> _backgroundQueue = new List<Event>();

    /// <summary>
    /// Adds a new listener for the given event id.
    /// </summary>
    /// <param name="eventId">The id of the event.</param>
    /// <param name="listener">The listener that is interessted in the event.</param>
    /// <returns>True if the listener was registered, false if it was already registered.</returns>
    public bool AddListener(string eventId, OnEventDelegate listener)
    {
      if (!_listeners.ContainsKey(eventId))
        _listeners.Add(eventId, new HashSet<OnEventDelegate>());

      return _listeners[eventId].Add(listener);
    }

    /// <summary>
    /// Removes a listener from a single event.
    /// </summary>
    /// <param name="eventId">The event to remove the listener from.</param>
    /// <param name="listener">The lsitener to remove.</param>
    /// <returns>True if the listener was removed. False if the listener was not registered for the event at all.</returns>
    public bool RemoveListener(string eventId, OnEventDelegate listener)
    {
      if (!_listeners.ContainsKey(eventId))
        return false;

      return _listeners[eventId].Remove(listener);
    }

    /// <summary>
    /// Cmopletely removes the listener from ALL events he is registered for.
    /// </summary>
    /// <param name="listener">The listener to remove.</param>
    /// <returns>True if the listener was removed from at least one event, else false.</returns>
    public bool RemoveListener(OnEventDelegate listener)
    {
      bool result = false;

      foreach (HashSet<OnEventDelegate> listeners in _listeners.Values)
        result = result || listeners.Remove(listener);

      return result;
    }

    /// <summary>
    /// Queues a new event. The event will be signaled to the listeners the next time the events are processes with the ProcessEvents() method.
    /// </summary>
    /// <param name="eventId">The id of the event.</param>
    /// <param name="data">Additional data for the event.</param>
    public void QueueEvent(string eventId, object data)
    {
      QueueEvent(eventId, data, null);
    }

    /// <summary>
    /// Queues a new event. The event will be signaled to the listeners the next time the events are processes with the ProcessEvents() method.
    /// </summary>
    /// <param name="eventId">The id of the event.</param>
    /// <param name="data">Additional data for the event.</param>
    /// <param name="objectId">The id of the object that triggered the event.</param>
    public void QueueEvent(string eventId, object data, string objectId)
    {
      _activeQueue.Add(new Event(eventId, data, objectId));
    }

    /// <summary>
    /// Triggers a new event. The event will be signaled immediately to the listeners.
    /// </summary>
    /// <param name="eventId">The id of the event.</param>
    /// <param name="data">Additional data for the event.</param>
    /// <param name="objectId">The id of the object that triggered the event.</param>
    public void TriggerEvent(string eventId, object data, string objectId)
    {
      if (!_listeners.ContainsKey(eventId))
        return;

      foreach (OnEventDelegate listener in _listeners[eventId])
        listener(eventId, data, objectId);
    }

    /// <summary>
    /// Triggers a new event. The event will be signaled immediately to the listeners.
    /// </summary>
    /// <param name="eventId">The id of the event.</param>
    /// <param name="data">Additional data for the event.</param>
    public void TriggerEvent(string eventId, object data)
    {
      TriggerEvent(eventId, data, null);
    }

    /// <summary>
    /// Swaps the two internal event queues.
    /// </summary>
    private void SwapQueues()
    {
      List<Event> temp = _backgroundQueue;
      _backgroundQueue = _activeQueue;
      _activeQueue = temp;
    }

    /// <summary>
    /// Processes the events that were queued since the last processing and signals them to all registered listeners.
    /// </summary>
    public void ProcessEvents()
    {
      SwapQueues();

      foreach (Event ev in _backgroundQueue)
      {
        try
        {
          TriggerEvent(ev.EventId, ev.Data, ev.ObjectId);
        }
        catch (Exception e)
        {
          OkuManager.Instance.Logging.LogError("Error processing eventId [" + ev.EventId + ", " + ev.Data + "]! Cause: " + e.Message);
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
