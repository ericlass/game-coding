using System;

namespace OkuEngine
{
  /// <summary>
  /// Handles all input of keyboard, mouse and joysticks.
  /// </summary>
  public class InputBase
  {
    private JoystickInput _joysticks = null;
    private KeyboardInput _keyboard = null;
    private MouseInput _mouse = null;

    public InputBase()
    {
    }

    /// <summary>
    /// Updates the states of the keyboard, mouse and all joysticks.
    /// </summary>
    public void Update()
    {
      Joysticks.UpdateAll();
      Keyboard.Update();
      Mouse.Update();
    }

    /// <summary>
    /// Gives access to joysticks.
    /// </summary>
    public JoystickInput Joysticks
    {
      get
      {
        if (_joysticks == null)
          _joysticks = new JoystickInput();
        return _joysticks;
      }
    }

    /// <summary>
    /// Gives access to the current keyboard state.
    /// </summary>
    public KeyboardInput Keyboard
    {
      get
      {
        if (_keyboard == null)
          _keyboard = new KeyboardInput();
        return _keyboard;
      }
    }

    /// <summary>
    /// Gives access to the current mouse position and button states.
    /// </summary>
    public MouseInput Mouse
    {
      get
      {
        if (_mouse == null)
          _mouse = new MouseInput();
        return _mouse;
      }
    }

  }
}
