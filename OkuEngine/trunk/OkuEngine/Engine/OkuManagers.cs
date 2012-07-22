using System;
using OkuEngine.Driver.Audio;
using OkuEngine.GCC.Processes;
using OkuEngine.GCC.Events;
using OkuEngine.GCC.Scripting;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  public static class OkuManagers
  {
    private static Input _input = null;
    private static ISoundEngine _sound = null;
    private static IRenderer _renderer = null;
    private static ProcessManager _processManager = null;
    private static IEventManager _eventManager = null;
    private static ScriptManager _scriptManager = null;

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

    public static ISoundEngine SoundEngine
    {
      get { return _sound; }
      set { _sound = value; }
    }

    public static IRenderer Renderer
    {
      get { return _renderer; }
      set { _renderer = value; }
    }

    public static ProcessManager ProcessManager
    {
      get { return _processManager; }
      set { _processManager = value; }
    }

    public static IEventManager EventManager
    {
      get { return _eventManager; }
      set { _eventManager = value; }
    }

    public static ScriptManager ScriptManager
    {
      get { return _scriptManager; }
      set { _scriptManager = value; }
    }

  }
}
