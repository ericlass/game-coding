﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OkuBase.Input
{
  /// <summary>
  /// Defines a manager that handles input processing and key bindings.
  /// </summary>
  public class InputManager : Manager
  {
    public delegate void KeyEventDelegate(Keys key);

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
    public event KeyEventDelegate OnMousePressed;
    public event KeyEventDelegate OnMouseReleased;

    public MouseInput Mouse
    {
      get { return _mouse; }
    }

    public KeyboardInput Keyboard
    {
      get { return _keyboard; }
    }

    private bool isMouseButton(Keys key)
    {
      return (key == Keys.LButton) || (key == Keys.RButton) || (key == Keys.MButton) || (key == Keys.XButton1) || (key == Keys.XButton2);
    }

    internal void KeyPressed(Keys key)
    {
      if (isMouseButton(key))
        OnMousePressed(key);
      else
        OnKeyPressed(key);
    }

    internal void KeyReleased(Keys key)
    {
      if (isMouseButton(key))
        OnMouseReleased(key);
      else
        OnKeyReleased(key);
    }

    public override void Initialize()
    {
      throw new NotImplementedException();
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
      throw new NotImplementedException();
    }

  }
}
