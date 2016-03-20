using System;
using System.Collections.Generic;
using OkuEngine.Events;

namespace OkuEngine
{
  public class Engine
  {
    private EventQueue _eventQueue = null;

    public Func<string, object[], bool> QueueEvent = null;
    public Func<string, object[], bool> TriggerEvent = null;

    public Engine()
    {
      _eventQueue = new EventQueue("okuengine_main");

      TriggerEvent = _eventQueue.TriggerEvent;
      QueueEvent = _eventQueue.QueueEvent;
    }   

  }
}
