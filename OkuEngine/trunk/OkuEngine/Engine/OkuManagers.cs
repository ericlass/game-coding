using System;
using OkuEngine.Driver.Audio;
using OkuEngine.Processes;
using OkuEngine.Events;
using OkuEngine.Scripting;
using OkuEngine.Driver.Renderer;
using OkuEngine.Logging;
using OkuEngine.Input;
using OkuEngine.Resources;

namespace OkuEngine
{
  /// <summary>
  /// Grants global access to all managers of the engine.
  /// </summary>
  public class OkuManagers
  {
    private static OkuManagers _instance = null;

    public static OkuManagers Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuManagers();
        return _instance;
      }
    }

    private InputBase _input = null;
    private ProcessManager _processManager = null;
    private IEventManager _eventManager = null;
    private ScriptManager _scriptManager = null;
    private Logger _logger = null;
    private InputManager _inputManager = null;
    private ResourceCache _resources = null;

    private OkuManagers()
    {
      _input = new InputBase();

      _logger = new Logger();
      _logger.AddWriter(new DebugConsoleLogWriter());

      _eventManager = new EventManager("OkuMainEventManager");
      _inputManager = new InputManager();

      OkuScriptManager scripter = new OkuScriptManager();
      scripter.Initialize();
      _scriptManager = scripter;

      _processManager = new ProcessManager();
    }

    /// <summary>
    /// Gets or sets the input handler.
    /// </summary>
    public InputBase Input
    {
      get 
      {
        if (_input == null)
          _input = new InputBase();
        return _input;
      }
      set { _input = value; }
    }

    /// <summary>
    /// Gets or sets the resource cache.
    /// </summary>
    public ResourceCache ResourceCache
    {
      get { return _resources; }
      set { _resources = value; }
    }

    /// <summary>
    /// Gets or sets the process manager to be used.
    /// </summary>
    public ProcessManager ProcessManager
    {
      get { return _processManager; }
      set { _processManager = value; }
    }

    /// <summary>
    /// Gets or sets the event manager that is used.
    /// </summary>
    public IEventManager EventManager
    {
      get { return _eventManager; }
      set { _eventManager = value; }
    }

    /// <summary>
    /// Gets or sets the script manager that is used.
    /// </summary>
    public ScriptManager ScriptManager
    {
      get { return _scriptManager; }
      set { _scriptManager = value; }
    }

    /// <summary>
    /// Gets or sets the logger that is used.
    /// </summary>
    public Logger Logger
    {
      get { return _logger; }
      set { _logger = value; }
    }

    /// <summary>
    /// Gets or sets the input manager that is used.
    /// </summary>
    public InputManager InputManager
    {
      get { return _inputManager; }
      set { _inputManager = value; }
    }

  }
}
