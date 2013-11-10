using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public struct Event
  {
    public EventId EventId;
    public int Data;
    
    public Event(EventId eventId, int data)
    {
      EventId = eventId;
      Data = data;
    }
    
  }
}
