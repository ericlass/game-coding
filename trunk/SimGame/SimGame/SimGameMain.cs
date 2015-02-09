using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Settings;
using SimGame.Events;
using SimGame.States;
using SimGame.Objects;
using SimGame.Game;

namespace SimGame
{
  public class SimGameMain : OkuGame, IGameDataProvider
  {
    private EventManager _eventQueue = null;
    private GameObjectManager _objectManager = null;
    private Dictionary<string, IGameState> _states = null;

    private string _currentStateName = null;
    private IGameState _currentState = null;

    public override OkuSettings Configure()
    {
      OkuSettings settings = base.Configure();

      settings.Graphics.DpiAware = true;
      settings.Graphics.Width = 1920;
      settings.Graphics.Height = 1080;
      settings.Graphics.BackgroundColor = Color.Black;
      settings.Graphics.TextureFilter = TextureFilter.NearestNeighbor;

      settings.Audio.DriverName = "null";

      return settings;
    }

    public override void Initialize()
    {
      _objectManager = new GameObjectManager();

      //Create and set up event queue
      _eventQueue = new EventManager(_objectManager);
      _eventQueue.RegisterHandler(EventIds.GameStart, new SimGame.Events.EventHandler("game", "setstate", new object[] { "playing" }));

      // Register virtual "game" object
      _objectManager.Register(new GameObject("game") { TriggerActionHandler = TriggerAction });
      CreateStates();
      
      //Queue start of game
      _eventQueue.QueueEvent(EventIds.GameStart);
    }

    private void CreateStates()
    {
      _states = new Dictionary<string, IGameState>();
      _states.Add("dummy", new DummyState(Color.Silver));
      _states.Add("playing", new PlayingState());
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
      _objectManager.Render();
      if (_currentState != null)
        _currentState.Render(this);
    }
    
    public EventManager EventQueue
    {
      get { return _eventQueue; }
    }

    public string CurrentState
    {
      get { return _currentStateName; }
    }

    public void SetCurrentState(string stateId)
    {
      if (_currentState != null)
        _currentState.Leave(this);

      if (_states.ContainsKey(stateId))
      {
        _currentStateName = stateId;
        _currentState = _states[_currentStateName];
        _currentState.Enter(this);
        _eventQueue.QueueEvent(EventIds.GameStateChanged);
      }
      else
        throw new ArgumentException("Unknown game state: " + stateId);
    }

    public void TriggerAction(GameObject obj, string actionId, object[] parameters)
    {
      if (actionId == "setstate")
      {
        SetCurrentState(parameters[0] as string);
      }
    }
    
    public string GetContentPath()
    {
      return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Content");
    }

    public GameObjectManager ObjectManager
    {
      get { return _objectManager; }
    }

  }
}
