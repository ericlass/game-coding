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
  public class SimGameMain : OkuGame
  {
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
      Global.Objects = new GameObjectManager();
      Global.Content = new Content.ContentCache(GameConstants.ContentPath);

      //Create and set up event queue
      Global.EventQueue = new EventManager(Global.Objects);
      Global.EventQueue.RegisterHandler(EventIds.GameStart, new SimGame.Events.EventHandler("game", "setstate", new object[] { "playing" }));

      // Register virtual "game" object
      Global.Objects.Register(new GameObject("game", new VirtualGameObject(this)));
      CreateStates();
      
      //Queue start of game
      Global.EventQueue.QueueEvent(EventIds.GameStart);
    }

    private void CreateStates()
    {
      _states = new Dictionary<string, IGameState>();
      _states.Add("dummy", new DummyState(Color.Silver));
      _states.Add("playing", new PlayingState());
    }
    
    public override void Update(float dt)
    {
      Global.Objects.Update(dt);
      Global.EventQueue.Update(dt);
      if (_currentState != null)
        _currentState.Update(dt);
    }

    public override void Render()
    {
      Global.Objects.Render();
      if (_currentState != null)
        _currentState.Render();
    }
    
    public EventManager EventQueue
    {
      get { return Global.EventQueue; }
    }

    public string CurrentState
    {
      get { return _currentStateName; }
    }

    public void SetCurrentState(string stateId)
    {
      if (_currentState != null)
        _currentState.Leave();

      if (_states.ContainsKey(stateId))
      {
        _currentStateName = stateId;
        _currentState = _states[_currentStateName];
        _currentState.Enter();
        Global.EventQueue.QueueEvent(EventIds.StateChanged);
      }
      else
        throw new ArgumentException("Unknown game state: " + stateId);
    }
    
  }
}
