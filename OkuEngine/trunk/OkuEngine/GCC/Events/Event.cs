using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Events
{
  internal class Event
  {
    private int _eventType = 0;
    private object _eventData = null;

    public Event(int eventType, object eventData)
    {
      _eventType = eventType;
      _eventData = eventData;
    }

    internal void Set(int eventType, object eventData)
    {
      _eventType = eventType;
      _eventData = eventData;
    }

    public int EventType
    {
      get { return _eventType; }
    }

    public object EventData
    {
      get { return _eventData; }
    }

  }
}
