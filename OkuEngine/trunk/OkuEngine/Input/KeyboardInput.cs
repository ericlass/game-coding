using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Handles getting input from the keyboard.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class KeyboardInput
  {
    private byte[] _state = new byte[256];

    [DllImport("User32.dll")]
    private static extern bool GetKeyboardState(byte[] keyState);

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
      GetKeyboardState(_state);
    }

    /// <summary>
    /// Checks if the given key is currently pressed down or not. This function always
    /// uses the keyboard state that was loaded in the last call of the <code>Update</code>
    /// method.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key is pressed down, else false.</returns>
    public bool ButtonIsDown(Keys key)
    {
      byte mask = 128;
      return (_state[(int)key] & mask) == mask;
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
