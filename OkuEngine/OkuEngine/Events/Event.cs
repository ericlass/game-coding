using System;
using System.Collections.Generic;

namespace OkuEngine.Events
{
  public class Event
  {
    public string Name { get; set; }
    public object[] Data { get; set; }

    public Event()
    {
    }

    public Event(string name, object[] data)
    {
      Name = name;
      Data = data;
    }

  }
}
