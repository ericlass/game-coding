using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class Event
  {
    public string EventId { get; set; }
    public string ObjectId { get; set; }
    public object Data { get; set; }
    
    public Event(string id, object data)
    {
      EventId = id;
      Data = data;
    }

    public Event(string id, object data, string objectId)
    {
      EventId = id;
      Data = data;
      ObjectId = objectId;
    }
    
  }
}
