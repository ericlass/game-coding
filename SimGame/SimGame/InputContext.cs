using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;

namespace SimGame
{
  /// <summary>
  /// Defines an input context that abstracts the input handling.
  /// A context can be enabled or disabled. If it is disabled,
  /// non of the actual keys and button are check and always
  /// assumed to be not pressed.
  /// </summary>
  public class InputContext
  {
    private List<MouseButton> EmptyButtons = new List<MouseButton>();

    private bool _enabled = true;

    /// <summary>
    /// Creates a new, enabled input context.
    /// </summary>
    public InputContext()
    {
    }

    /// <summary>
    /// Creates a new input context that is either enabled or not.
    /// </summary>
    /// <param name="enabled">True if the context is enabled, else False.</param>
    public InputContext(bool enabled)
    {
      _enabled = enabled;
    }

    /// <summary>
    /// Gets the singleton instance of the oku manager.
    /// </summary>
    private OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

    /// <summary>
    /// Gets or sets if the context is enabled or not.
    /// </summary>
    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    /// <summary>
    /// Checks the given key using the given check function.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <param name="checker">The check function.</param>
    /// <returns>If the context is enabled, the result of the checker, else false.</returns>
    private bool CheckKey(Keys key, Func<Keys, bool> checker)
    {
      if (_enabled)
        return checker(key);

      return false;
    }

    /// <summary>
    /// Checks if the given key is currently pressed down.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key is down, else false.</returns>
    public bool KeyIsDown(Keys key)
    {
      return CheckKey(key, Oku.Input.Keyboard.KeyIsDown);
    }

    /// <summary>
    /// Checks if the given key was pressed down since the last frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key was pressed down, else false.</returns>
    public bool KeyPressed(Keys key)
    {
      return CheckKey(key, Oku.Input.Keyboard.KeyPressed);
    }

    /// <summary>
    /// Checks if the given key was raised since the last frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key was raised, else false.</returns>
    public bool KeyRaised(Keys key)
    {
      return CheckKey(key, Oku.Input.Keyboard.KeyRaised);
    }

    /// <summary>
    /// Gets the current X position of the mouse in screen space.
    /// If the context is disabled, -1 is always returned.
    /// </summary>
    public int MouseX
    {
      get { return _enabled ? Oku.Input.Mouse.X : int.MinValue; }
    }

    /// <summary>
    /// Gets the current Y position of the mouse in screen space.
    /// If the context is disabled, -1 is always returned.
    /// </summary>
    public int MouseY
    {
      get { return _enabled ? Oku.Input.Mouse.Y : int.MinValue; }
    }

    /// <summary>
    /// Checks the gven mouse button using the given check function.
    /// </summary>
    /// <param name="button">The mouse button to be checked.</param>
    /// <param name="checker">The check function to be used.</param>
    /// <returns></returns>
    private bool CheckMouseButton(MouseButton button, Func<MouseButton, bool> checker)
    {
      if (_enabled)
        return checker(button);

      return false;
    }

    /// <summary>
    /// Checks if the given mouse button is currently pressed down.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button is pressed down, else false.</returns>
    public bool MouseButtonIsDown(MouseButton button)
    {
      return CheckMouseButton(button, Oku.Input.Mouse.ButtonIsDown);
    }

    /// <summary>
    /// Checks if the given mouse button was pressed down since the last frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was pressed down, else false.</returns>
    public bool MouseButtonPressed(MouseButton button)
    {
      return CheckMouseButton(button, Oku.Input.Mouse.ButtonPressed);
    }

    /// <summary>
    /// Checks if the given mouse button was raised since the last frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was raised, else false.</returns>
    public bool MouseButtonRaised(MouseButton button)
    {
      return CheckMouseButton(button, Oku.Input.Mouse.ButtonRaised);
    }

    /// <summary>
    /// Gets the buttons that have beend pressed down since the last frame.
    /// </summary>
    /// <returns>A list of all buttons that have been pressed.</returns>
    public List<MouseButton> GetPressedButtons()
    {
      if (_enabled)
        return Oku.Input.Mouse.GetPressedButtons();

      return EmptyButtons;
    }

    /// <summary>
    /// Gets the buttons that have beend raised since the last frame.
    /// </summary>
    /// <returns>A list of all buttons that have been raised.</returns>
    public List<MouseButton> GetRaisedButtons()
    {
      if (_enabled)
        return Oku.Input.Mouse.GetRaisedButtons();

      return EmptyButtons;
    } 

  }
}
