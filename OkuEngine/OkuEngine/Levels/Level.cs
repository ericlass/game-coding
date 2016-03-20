using System;
using System.Collections.Generic;
using OkuEngine.Systems;
using OkuEngine.Events;

namespace OkuEngine.Levels
{
  public abstract class Level
  {
    private List<Entity> _entities = new List<Entity>();
    private List<EventListener> _listeners = new List<EventListener>();
    private Engine _engine = null;

    public Level()
    {
    }

    //TODO: Change to list that queues an event when entities are added or removed.
    public List<Entity> Entities
    {
      get { return _entities; }
    }

    //TODO: Change to list that queues an event when entities are added or removed.
    public List<EventListener> EventListeners
    {
      get { return _listeners; }
    }

    public Engine Engine
    {
      get { return _engine; }
      set { _engine = value; }
    }

    /// <summary>
    /// Supposed to set up systems and entities before the game loop starts.
    /// </summary>
    public abstract void Init();

    public abstract void Finish();
  }
}
