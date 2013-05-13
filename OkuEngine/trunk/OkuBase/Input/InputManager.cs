using System;
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

    /// <summary>
    /// Creates a new input mananger.
    /// </summary>
    public InputManager()
    {
    }

    public event KeyEventDelegate OnKeyPressed;
    public event KeyEventDelegate OnKeyReleased;

    /// <summary>
    /// Is called when any key action happens. Enqueues the corresponding events.
    /// </summary>
    /// <param name="key">The key that was pressed.</param>
    /// <param name="action">The action that was performed on the key.</param>
    /// <returns>True if the key was handled, else false.</returns>
    public bool OnKeyAction(Keys key, KeyAction action)
    {
      bool handled = false;

      if (action == KeyAction.Down)
        OnKeyPressed(key);
      else
        OnKeyReleased(key);

      return handled;
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
    }

    public override void Finish()
    {
      throw new NotImplementedException();
    }

  }
}
