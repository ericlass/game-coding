using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  public class Event
  {
    public string Id { get; set; }
    public object Data { get; set; }
    
    public Event(string id, object data)
    {
      Id = id;
      Data = data;
    }
    
  }
}
