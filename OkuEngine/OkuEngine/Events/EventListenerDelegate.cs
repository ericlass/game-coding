using System;

namespace OkuEngine.Events
{
  public delegate void EventListenerDelegate(string eventType, params object[] eventData);
}