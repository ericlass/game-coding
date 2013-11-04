using System;

namespace RougeLike
{
  public class GameManager : IUpdatable
  {
    private static GameManager _instance = null;

    public static GameManager Instance
    {
      get
      {
        if (_instance == null)
          _instance = new GameManager();

        return _instance;
      }
    }

    private EventQueue _eventQueue = null;
    private EntityMap _entities = null;
    private ProcessManager _processes = null;
    private RenderManager _renderer = null;

    private GameManager()
    {
      _eventQueue = new EventQueue();
      _entities = new EntityMap();
      _processes = new ProcessManager();
      _renderer = new RenderManager();
    }
    
    public void Update(float dt)
    {
      _entities.Update(dt);
      _eventQueue.ProcessEvents();
      _processes.Update(dt);
    }

    public EventQueue EventQueue
    {
      get { return _eventQueue; }
    }
    
    public EntityMap Entities
    {
      get { return _entities; }
    }
    
    public ProcessManager Processes
    {
      get { return _processes; }
    }

    public RenderManager Renderer
    {
      get { return _renderer; }
    }

  }
}
