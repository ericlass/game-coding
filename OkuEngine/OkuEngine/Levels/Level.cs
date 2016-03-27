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
    private LevelEngineLocator _engine = new LevelEngineLocator();

    private bool _initialized = false;

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

    //TODO: Replace this with component locator
    public LevelEngineLocator Engine
    {
      get { return _engine; }
    }

    /// <summary>
    /// Initializes the level, but only if it was not initialized already.
    /// </summary>
    public void DoInit()
    {
      if (!_initialized)
      {
        Init();
        _initialized = true;
      }
    }

    /// <summary>
    /// Supposed to set up systems and entities before the game loop starts.
    /// </summary>
    public abstract void Init();

    public abstract void Finish();
  }
}
