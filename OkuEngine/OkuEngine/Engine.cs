using System;
using System.Collections.Generic;
using OkuBase;
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

      QueueEvent = _eventQueue.QueueEvent;
      TriggerEvent = _eventQueue.TriggerEvent;      
    }

    /// <summary>
    /// Gets or sets the time delta since the last frame.
    /// </summary>
    public float DeltaTime { get; internal set; }

    public OkuManager OkuBase
    {
      get { return OkuManager.Instance; }
    }

  }
}
