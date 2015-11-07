using System;
using OkuEngine.Events;
using OkuEngine.Input;

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

    private EventManager _eventManager = null;
    private InputManager _inputManager = null;

    private OkuManagers()
    {
      _eventManager = new EventManager("OkuMainEventManager");
      _inputManager = new InputManager();
    }

    /// <summary>
    /// Gets or sets the event manager that is used.
    /// </summary>
    public EventManager EventManager
    {
      get { return _eventManager; }
      set { _eventManager = value; }
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
