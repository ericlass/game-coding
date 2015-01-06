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
      //Create and set up event queue
      _eventQueue = new EventManager(CreateActionFactory());
      _eventQueue.RegisterHandler(EventIds.GameStart, new EventHandler("setgamestate", "dummy", null));

      //Create and set up state factory
      _stateFactory = new GameStateFactory();
      _stateFactory.RegisterConstructor("dummy", (parameters) => new DummyState());

      //Queue start of game
      _eventQueue.QueueEvent(EventIds.GameStart);
    }
    
    private ActionFactory CreateActionFactory()
    {
      ActionFactory factory = new ActionFactory();
      factory.RegisterConstructor("timer", (parameters) => new TimerAction(this, parameters));
      factory.RegisterConstructor("setgamestate", (parameters) => new SetGameStateAction(this, parameters));
      return factory;
    }

    public override void Update(float dt)
    {
      _eventQueue.Update(dt);
      if (_currentState != null)
        _currentState.Update(this, dt);
    }

    public override void Render()
    {
      if (_currentState != null)
        _currentState.Render(this);
    }
    
    public EventManager EventQueue
    {
      get { return _eventQueue; }
    }

    public string CurrentState
    {
      get { return _currentState == null ? "null" : _currentState.Id; }
    }

    public void SetCurrentState(string stateId, params object[] parameters)
    {
      if (_currentState != null)
        _currentState.Leave(this);

      if (_stateFactory.ContainsType(stateId))
      {
        _currentState = _stateFactory.Create(stateId, parameters);
        _currentState.Enter(this);
        _eventQueue.QueueEvent(EventIds.GameStateChanged);
      }
    }

  }
}
