using System;
using System.Collections.Generic;

namespace OkuEngine.Events
{
  public class EventListener
  {
    public List<string> EventNames { get; set; }
    public Action<Event> Handler { get; set; }

    public EventListener()
    {
    }

    public EventListener(string eventName, Action<Event> handler)
    {
      EventNames = new List<string>() { eventName };
      Handler = handler;
    }

    public EventListener(List<string> eventNames, Action<Event> handler)
    {
      EventNames = eventNames;
      Handler = handler;
    }

  }
}
