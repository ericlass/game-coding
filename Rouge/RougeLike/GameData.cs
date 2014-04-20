using System;
using System.Collections.Generic;
using RougeLike.States;

namespace RougeLike
{
  public class GameData
  {
    private static GameData _instance = null;

    public static GameData Instance
    {
      get
      {
        if (_instance == null)
          _instance = new GameData();
        return _instance;
      }
    }

    private GameData()
    {
    }

    private bool _debugDraw = false;
    private SceneList _scenes = new SceneList();
    private Scene _activeScene = null;
    private EventQueue _eventQueue = new EventQueue();

    public bool DebugDraw
    {
      get { return _debugDraw; }
      set { _debugDraw = value; }
    }

    public SceneList Scenes
    {
      get { return _scenes; }
      set { _scenes = value; }
    }

    public Scene ActiveScene
    {
      get { return _activeScene; }
      set 
      {
        if (_activeScene != null)
          _activeScene.Finish();

        _activeScene = value;
        _activeScene.Init();
      }
    }

    public EventQueue EventQueue
    {
      get { return _eventQueue; }
      set { _eventQueue = value; }
    }

  }
}
