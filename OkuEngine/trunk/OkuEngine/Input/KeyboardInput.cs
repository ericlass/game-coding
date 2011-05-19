using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Handles getting input from the keyboard.
  /// </summary>
  public class KeyboardInput
  {
    private byte[] _lastState = new byte[256];
    private byte[] _state = new byte[256];

    /// <summary>
    /// Creates a new keyboard input.
    /// </summary>
    public KeyboardInput()
    {
    }

    /// <summary>
    /// Updates the state of all keys of the keyboard. This state is used by
    /// <code>IsDown</code> to check if a key is down or up.
    /// </summary>
    public void Update()
    {
      Array.Copy(_state, _lastState, _state.Length);
      User32.GetKeyboardState(_state);
    }

    /// <summary>
    /// Checks if the given key is currently pressed down or not. This function always
    /// uses the keyboard state that was loaded in the last call of the <code>Update</code>
    /// method.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <param name="state">An array that contains the key states.</param>
    /// <returns>True if the key is pressed down, else false.</returns>
    private bool KeyIsDown(Keys key, byte[] state)
    {
      byte mask = 128;
      return (state[(int)key] & mask) == mask;
    }

    /// <summary>
    /// Checks if the given key is pressed down now.
    /// </summary>
    /// <param name="key">The key to be checked.</param>
    /// <returns>True if the key is pressed down right now, else false.</returns>
    public bool KeyIsDown(Keys key)
    {
      return KeyIsDown(key, _state);
    }

    /// <summary>
    /// Checks if the given key is hold down.
    /// </summary>
    /// <param name="key">The key to be checked.</param>
    /// <returns>True if the key is hold down, else false.</returns>
    public bool KeyIsHoldDown(Keys key)
    {
      return KeyIsDown(key, _lastState) && KeyIsDown(key, _state);
    }

    /// <summary>
    /// Checks if the key was pressed down since the last frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key was pressed, else false.</returns>
    public bool KeyPressed(Keys key)
    {
      return !KeyIsDown(key, _lastState) && KeyIsDown(key, _state);
    }

    /// <summary>
    /// Checks if the key was raised since the last frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key was raised, else false.</returns>
    public bool KeyRaised(Keys key)
    {
      return KeyIsDown(key, _lastState) && !KeyIsDown(key, _state);
    }

    /// <summary>
    /// Gets if the caps lock is toggled (indicator light on the keyboard is on) or not.
    /// </summary>
    public bool CapsLockActive
    {
      get
      {
        byte mask = 1;
        return (_state[(int)(Keys.CapsLock)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the scroll lock is toggled (indicator light on the keyboard is on) or not.
    /// </summary>
    public bool ScrollLockActive
    {
      get
      {
        byte mask = 1;
        return (_state[(int)(Keys.Scroll)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the num lock is toggled (indicator light on the keyboard is on) or not.
    /// </summary>
    public bool NumLockActive
    {
      get
      {
        byte mask = 1;
        return (_state[(int)(Keys.NumLock)] & mask) == mask;
      }
    }

  }
}
