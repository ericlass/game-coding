using System;
using System.Collections.Generic;

namespace OkuEngine.Events
{
  public class EventListener
  {
    public List<string> EventNames { get; set; }
    public Action<Event, Engine> Handler { get; set; }

    public EventListener()
    {
    }

    public EventListener(string eventName, Action<Event, Engine> handler)
    {
      EventNames = new List<string>() { eventName };
      Handler = handler;
    }

    public EventListener(List<string> eventNames, Action<Event, Engine> handler)
    {
      EventNames = eventNames;
      Handler = handler;
    }

  }
}
