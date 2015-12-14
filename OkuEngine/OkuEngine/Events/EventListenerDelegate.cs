using System;

namespace OkuEngine.Events
{
  public delegate void EventListenerDelegate(string eventName, params object[] eventData);
}