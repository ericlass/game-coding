using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Settings;
using SimGame.Events;
using SimGame.States;
using SimGame.Objects;

namespace SimGame
{
  public class SimGameMain : OkuGame, IGameDataProvider, IGameObject
  {
    private EventManager _eventQueue = null;
    private IGameState _currentState = null;
    private GameObjectManager _objectManager = null;
    private Dictionary<string, IGameState> _states = null;

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
      _objectManager = new GameObjectManager();

      //Create and set up event queue
      _eventQueue = new EventManager(_objectManager);
      _eventQueue.RegisterHandler(EventIds.GameStart, new SimGame.Events.EventHandler("game.setstate", new object[] { "dummy" }));

      //Queue start of game
      _eventQueue.QueueEvent(EventIds.GameStart);

      _objectManager.Register(new GameObjectWrapper("game", this, _eventQueue));
      CreateStates();
    }

    private void CreateStates()
    {
      _states = new Dictionary<string, IGameState>();
      _states.Add("dummy", new DummyState(Color.Silver));
    }
    
    public override void Update(float dt)
    {
      _objectManager.Update(dt);
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

    public void SetCurrentState(string stateId)
    {
      if (_currentState != null)
        _currentState.Leave(this);

      if (_states.ContainsKey(stateId))
      {
        _currentState = _states[stateId];
        _currentState.Enter(this);
        _eventQueue.QueueEvent(EventIds.GameStateChanged);
      }
    }

    #region Unused GameObject methods
    public void Init(GameObjectWrapper wrapper)
    {      
    }

    public void Update(float dt, GameObjectWrapper wrapper)
    {
    }

    public void Finish(GameObjectWrapper wrapper)
    {
    }
    #endregion

    public void TriggerAction(string actionId, object[] parameters)
    {
      if (actionId == "setstate")
      {
        SetCurrentState(parameters[0] as string);
      }
    }

  }
}
