using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Settings;

namespace SimGame
{
  public class SimGameMain : OkuGame, IGameDataProvider
  {
    private EventManager _eventQueue = null;
    private IGameState _currentState = null;
    private GameStateFactory _stateFactory = null;

    public override OkuSettings Configure()
    {
      OkuSettings settings = base.Configure();

      settings.Graphics.Width = 1024;
      settings.Graphics.Height = 768;
      settings.Graphics.BackgroundColor = Color.Black;

      return settings;
    }

    public override void Initialize()
    {
      ActionFactory factory = new ActionFactory();

      factory.RegisterConstructor("timer", ActionConstructors.CreateTimerAction);
      factory.RegisterConstructor("setgamestate", ActionConstructors.CreateSetGameStateAction);

      _eventQueue = new EventManager(factory);
      _eventQueue.RegisterHandler(EventIds.GameStart, new EventHandler("setgamestate", this, "dummy"));

      _stateFactory = new GameStateFactory();
      _stateFactory.RegisterConstructor("dummy", GameStateConstructors.CreateDummyState);

      _eventQueue.QueueEvent(EventIds.GameStart);
    }

    public override void Update(float dt)
    {
      _eventQueue.Update(dt);
      _currentState.Update(this, dt);
    }

    public override void Render()
    {
      _currentState.Render(this);
    }
    
    public EventManager EventQueue
    {
      get { return _eventQueue; }
    }

    public string GameState
    {
      get
      {
        return _currentState == null ? "none" : _currentState.Id;
      }
      set
      {
        if (_currentState != null)
          _currentState.Leave(this);

        if (_stateFactory.ContainsType(value))
        {
          _currentState = _stateFactory.Create(value, null); //TODO: Need parameters!
          _currentState.Enter(this);
          _eventQueue.QueueEvent(EventIds.GameStateChanged);
        }
      }
    }

  }
}
