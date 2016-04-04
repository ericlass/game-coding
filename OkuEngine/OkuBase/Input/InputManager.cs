using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase.Settings;

namespace OkuBase.Input
{
  public delegate void KeyEventDelegate(Keys key);
  public delegate void MouseEventDelegate(MouseButton button);
  public delegate void MouseWheelEventDelegate(int delta);

  /// <summary>
  /// Defines a manager that handles input processing and key bindings.
  /// </summary>
  public class InputManager : Manager
  {
    private MouseInput _mouse = new MouseInput();
    private KeyboardInput _keyboard = new KeyboardInput();

    /// <summary>
    /// Creates a new input mananger.
    /// </summary>
    public InputManager()
    {
    }

    public event KeyEventDelegate OnKeyPressed;
    public event KeyEventDelegate OnKeyReleased;
    public event MouseEventDelegate OnMousePressed;
    public event MouseEventDelegate OnMouseReleased;
    public event MouseEventDelegate OnMouseDblClick;
    public event MouseWheelEventDelegate OnMouseWheel;

    public MouseInput Mouse
    {
      get { return _mouse; }
    }

    public KeyboardInput Keyboard
    {
      get { return _keyboard; }
    }

    //TODO: Track state of modifier keys (Strg, Shift, Caps)

    internal void KeyPressed(Keys key)
    {
      if (OnKeyPressed != null)
        OnKeyPressed(key);
    }

    internal void KeyReleased(Keys key)
    {
      if (OnKeyReleased != null)
        OnKeyReleased(key);
    }

    internal void MousePressed(MouseButton button)
    {
      if (OnMousePressed != null)
        OnMousePressed(button);
    }

    internal void MouseReleased(MouseButton button)
    {
      if (OnMouseReleased != null)
        OnMouseReleased(button);
    }

    internal void MouseWheel(int delta)
    {
      if (OnMouseWheel != null)
        OnMouseWheel(delta);
    }

    internal void MouseDblClick(MouseButton button)
    {
      if (OnMouseDblClick != null)
        OnMouseDblClick(button);
    }

    public override void Initialize(OkuSettings settings)
    {
    }

    /// <summary>
    /// Updates subsequent inputs.
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