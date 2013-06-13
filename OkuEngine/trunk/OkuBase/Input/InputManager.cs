using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase.Settings;

namespace OkuBase.Input
{
  /// <summary>
  /// Defines a manager that handles input processing and key bindings.
  /// </summary>
  public class InputManager : Manager
  {
    private MouseInput _mouse = new MouseInput();
    private KeyboardInput _keyboard = new KeyboardInput();
    private IInputHandler _handler = null;

    /// <summary>
    /// Creates a new input mananger.
    /// </summary>
    public InputManager()
    {
    }

    public MouseInput Mouse
    {
      get { return _mouse; }
    }

    public KeyboardInput Keyboard
    {
      get { return _keyboard; }
    }

    public IInputHandler InputHandler
    {
      get { return _handler; }
      set { _handler = value; }
    }

    internal void KeyPressed(Keys key)
    {
      if (_handler != null)
        _handler.KeyPressed(key);
    }

    internal void KeyReleased(Keys key)
    {
      if (_handler != null)
        _handler.KeyReleased(key);
    }

    internal void MousePressed(MouseButton button)
    {
      if (_handler != null)
        _handler.MousePressed(button);
    }

    internal void MouseReleased(MouseButton button)
    {
      if (_handler != null)
        _handler.MouseReleased(button);
    }

    internal void MouseWheel(int delta)
    {
      if (_handler != null)
        _handler.MouseWheel(delta);
    }

    internal void MouseDblClick(MouseButton button)
    {
      if (_handler != null)
        _handler.MouseDblClick(button);
    }

    public override void Initialize(OkuSettings settings)
    {
    }

    /// <summary>
    /// Enqueues any currently active state events,
    /// </summary>
    public override void Update(float dt)
    {
      _mouse.Update();
      _keyboard.Update();
    }

    public override void Finish()
    {
    }

  }
}
