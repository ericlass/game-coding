using System;

namespace OkuEngine.Events
{
  public delegate void EventListenerDelegate(int eventType, params object[] eventData);
}