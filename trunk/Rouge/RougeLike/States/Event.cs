using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.States
{
  /// <summary>
  /// Defines a single event that ocurred.
  /// </summary>
  public class Event
  {
    /// <summary>
    /// Gets or set the id of the event that happened.
    /// </summary>
    public string EventId { get; set; }

    /// <summary>
    /// Gets or set the id of the object that triggered the event. Can be null if no object triggered the event.
    /// </summary>
    public string ObjectId { get; set; }

    /// <summary>
    /// Gets or set additional data regarding the event.
    /// </summary>
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
