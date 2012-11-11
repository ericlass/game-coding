using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Events
{
  /// <summary>
  /// Defines a single event.
  /// </summary>
  internal class Event
  {
    private int _eventType = 0;
    private object _eventData = null;

    /// <summary>
    /// Creates a new event with the given typ and date.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="eventData">The data of the event.</param>
    public Event(int eventType, object eventData)
    {
      _eventType = eventType;
      _eventData = eventData;
    }

    /// <summary>
    /// Sets the config of the event.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="eventData">The data of the event.</param>
    internal void Set(int eventType, object eventData)
    {
      _eventType = eventType;
      _eventData = eventData;
    }

    /// <summary>
    /// Gets the type of the event.
    /// </summary>
    public int EventType
    {
      get { return _eventType; }
    }

    /// <summary>
    /// Gets the data of the event.
    /// </summary>
    public object EventData
    {
      get { return _eventData; }
    }

  }
}
