using System;

namespace RougeLike
{
  public class GameManager
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

    private Entity _playerEntity = null;

    private GameManager()
    {
      _eventQueue = new EventQueue();
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

  }
}
