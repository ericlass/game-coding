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

    private Entity _playerEntity = null;

    private GameManager()
    {
      _eventQueue = new EventQueue();
      _entities = new EntityMap();
    }
    
    public void Update(float dt)
    {
      _entities.Update(dt);
      _eventQueue.ProcessEvents();
    }

    public EventQueue EventQueue
    {
      get { return _eventQueue; }
    }

    public Entity PlayerEntity
    {
      get { return _playerEntity; }
    }

    internal void setPlayerEntity(Entity entity)
    {
      _playerEntity = entity;
    }
    
    public EntityMap Entities
    {
      get { return _entities; }
    }

  }
}
