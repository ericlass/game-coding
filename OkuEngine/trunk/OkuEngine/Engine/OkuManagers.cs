using System;
using OkuEngine.Driver.Audio;
using OkuEngine.GCC.Processes;
using OkuEngine.GCC.Events;
using OkuEngine.GCC.Scripting;
using OkuEngine.Driver.Renderer;
using OkuEngine.Logging;

namespace OkuEngine
{
  /// <summary>
  /// Grants global access to all managers of the engine.
  /// </summary>
  public static class OkuManagers
  {
    private static Input _input = null;
    private static ISoundEngine _sound = null;
    private static IRenderer _renderer = null;
    private static ProcessManager _processManager = null;
    private static IEventManager _eventManager = null;
    private static ScriptManager _scriptManager = null;
    private static Logger _logger = null;

    /// <summary>
    /// Gets or sets the input handler.
    /// </summary>
    public static Input Input
    {
      get 
      {
        if (_input == null)
          _input = new Input();
        return _input;
      }
      set { _input = value; }
    }

    /// <summary>
    /// Gets or sets the sound engine that is used.
    /// </summary>
    public static ISoundEngine SoundEngine
    {
      get { return _sound; }
      set { _sound = value; }
    }

    /// <summary>
    /// Gets or sets the renderer that is used.
    /// </summary>
    public static IRenderer Renderer
    {
      get { return _renderer; }
      set { _renderer = value; }
    }

    /// <summary>
    /// Gets or sets the process manager to be used.
    /// </summary>
    public static ProcessManager ProcessManager
    {
      get { return _processManager; }
      set { _processManager = value; }
    }

    /// <summary>
    /// Gets or sets the event manager that is used.
    /// </summary>
    public static IEventManager EventManager
    {
      get { return _eventManager; }
      set { _eventManager = value; }
    }

    /// <summary>
    /// Gets or sets the script manager that is used.
    /// </summary>
    public static ScriptManager ScriptManager
    {
      get { return _scriptManager; }
      set { _scriptManager = value; }
    }

    /// <summary>
    /// Gets or sets the logger that is used.
    /// </summary>
    public static Logger Logger
    {
      get { return _logger; }
      set { _logger = value; }
    }

  }
}
