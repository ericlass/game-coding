using System;
using System.Collections.Generic;
using OkuBase;
using OkuEngine.Collections;
using OkuEngine.Events;
using OkuEngine.Levels;


namespace OkuEngine
{
  internal class Engine
  {
    private static Engine _instance = null;

    public static Engine Instance
    {
      get
      {
        if (_instance == null)
          _instance = new Engine();
        return _instance;
      }
    }

    private EngineFunctions _functions = null;
    private EventQueue _eventQueue = null;
    private EngineVariables _variables = null;
    private OkuManager _oku = null;
    private Level _currentLevel;

    private Engine()
    {
      _functions = new EngineFunctions();
      _eventQueue = new EventQueue("okuengine_main");
      _variables = new EngineVariables();
      _oku = OkuManager.Instance;
    }

    public EngineFunctions Functions
    {
      get { return _functions; }
      set { _functions = value; }
    }

    public EventQueue EventQueue
    {
      get { return _eventQueue; }
      set { _eventQueue = value; }
    }

    public EngineVariables Variables
    {
      get { return _variables; }
      set { _variables = value; }
    }

    public OkuManager Oku
    {
      get { return _oku; }
      set { _oku = value; }
    }

    public Level CurrentLevel
    {
      get { return _currentLevel; }
      set { _currentLevel = value; }
    }

    /*private EventQueue _eventQueue = null;

    public Func<string, object[], bool> QueueEvent = null;
    public Func<string, object[], bool> TriggerEvent = null;

    public Engine()
    {
      _eventQueue = new EventQueue("okuengine_main");

      QueueEvent = _eventQueue.QueueEvent;
      TriggerEvent = _eventQueue.TriggerEvent;      
    }

    /// <summary>
    /// Gets or sets the time delta since the last frame.
    /// </summary>
    public float DeltaTime { get; internal set; }

    public OkuManager OkuBase
    {
      get { return OkuManager.Instance; }
    }*/

  }
}
