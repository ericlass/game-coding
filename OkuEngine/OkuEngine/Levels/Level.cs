using System;
using System.Collections.Generic;
using OkuEngine.Collections;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Systems;

namespace OkuEngine.Levels
{
  /// <summary>
  /// Defines a single level for the game.
  /// </summary>
  public abstract class Level
  {
    private List<Entity> _entities = new List<Entity>(100);
    private List<EventListener> _listeners = new List<EventListener>(50);
    private EventQueue _eventQueue = new EventQueue("level");
    private BlackBoard _variables = new BlackBoard();
    private List<InputContext> _inputContexts = new List<InputContext>(10);
    private List<RenderTask> _renderQueue = new List<RenderTask>();

    private EngineAPI _api = null;
    private bool _initialized = false;

    /// <summary>
    /// Gets the list of entities of this level.
    /// </summary>
    internal List<Entity> Entities
    {
      get { return _entities; }
    }

    /// <summary>
    /// Gets the list of event listeners of this level.
    /// </summary>
    internal List<EventListener> EventListeners
    {
      get { return _listeners; }
    }

    /// <summary>
    /// Gets the event queue of this level.
    /// </summary>
    internal EventQueue EventQueue
    {
      get { return _eventQueue; }
    }

    /// <summary>
    /// Gets the variables of this level.
    /// </summary>
    internal BlackBoard Variables
    {
      get { return _variables; }
    }

    /// <summary>
    /// Gets if the level was already initialized or not.
    /// </summary>
    internal bool Initialized
    {
      get { return _initialized; }
    }

    /// <summary>
    /// Gets the list of input contexts.
    /// </summary>
    internal List<InputContext> InputContexts
    {
      get { return _inputContexts; }
    }

    /// <summary>
    /// Gets the render queue for this level.
    /// </summary>
    internal List<RenderTask> RenderQueue
    {
      get { return _renderQueue; }
    }

    /// <summary>
    /// Initializes the level, but only if it was not initialized already.
    /// </summary>
    internal void DoInit()
    {
      if (!_initialized)
      {
        _api = new EngineAPI(this);
        Init();
        _initialized = true;
      }
    }

    /// <summary>
    /// Finishes the level, but only if it was initializes before.
    /// </summary>
    internal void DoFinish()
    {
      if (_initialized)
      {
        Finish();
        _initialized = false;
      }
    }

    /// <summary>
    /// Gets the API with all functions of the engine.
    /// </summary>
    public EngineAPI API
    {
      get { return _api; }
    }

    /// <summary>
    /// Called once when the level is activated the first time.
    /// Supposed to set up systems and entities before the game loop starts.
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// Called once when the level should clean up all it's data.
    /// </summary>
    protected abstract void Finish();
  }
}
