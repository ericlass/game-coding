using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OkuBase.Platform;

namespace OkuBase.Input
{
  /// <summary>
  /// Handles getting input from the keyboard.
  /// </summary>
  public class KeyboardInput
  {
    private byte[] _lastState = new byte[256];
    private byte[] _state = new byte[256];

    private List<Keys> _pressedKeys = new List<Keys>();
    private List<Keys> _pressedKeysQueue = new List<Keys>();

    private List<Keys> _raisedKeys = new List<Keys>();
    private List<Keys> _raisedKeysQueue = new List<Keys>();

    private char _zero = new char();
    private byte[] _pressedChars = new byte[2];

    public event KeyEventDelegate OnKeyPressed;
    public event KeyEventDelegate OnKeyReleased;

    /// <summary>
    /// Creates a new keyboard input.
    /// </summary>
    public KeyboardInput()
    {
    }

    internal void KeyPressed(Keys key)
    {
      if (OnKeyPressed != null)
        OnKeyPressed(key);

      _pressedKeysQueue.Add(key);
    }

    internal void KeyReleased(Keys key)
    {
      if (OnKeyReleased != null)
        OnKeyReleased(key);

      _raisedKeysQueue.Add(key);
    }

    /// <summary>
    /// Updates the state of all keys of the keyboard. This state is used by
    /// <code>IsDown</code> to check if a key is down or up.
    /// </summary>
    public void Update()
    {
      Array.Copy(_state, _lastState, _state.Length);
      User32.GetKeyboardState(_state);

      var temp = _pressedKeys;
      _pressedKeys = _pressedKeysQueue;
      _pressedKeysQueue = temp;
      _pressedKeysQueue.Clear();

      temp = _raisedKeys;
      _raisedKeys = _raisedKeysQueue;
      _raisedKeysQueue = temp;
      _raisedKeysQueue.Clear();
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
    public bool KeyWasPressed(Keys key)
    {
      return !KeyIsDown(key, _lastState) && KeyIsDown(key, _state);
    }

    /// <summary>
    /// Checks if the key was raised since the last frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>True if the key was raised, else false.</returns>
    public bool KeyWasRaised(Keys key)
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

    /// <summary>
    /// Gets the buttons that have been pressed down since the last frame.
    /// </summary>
    /// <returns>A list of the buttons that have been pressed down.</returns>
    public List<Keys> GetPressedButtons()
    {
      return _pressedKeys;
    }

    /// <summary>
    /// Gets the buttons that have been raised up since the last frame.
    /// </summary>
    /// <returns>A list of the buttons that have been raised up.</returns>
    public List<Keys> GetRaisedButtons()
    {
      return _raisedKeys;
    }

    /// <summary>
    /// Converts the given virtual key code to an ascii character.
    /// </summary>
    /// <param name="key">The virtual key code.</param>
    /// <returns>The char for the given key code or 0 if the given key has no char.</returns>
    public char KeyToChar(Keys key)
    {
      uint virtKey = (uint)(key & Keys.KeyCode);
      //uint virtKey = (uint)key;
      uint scancode = User32.MapVirtualKey(virtKey, 0);

      if (User32.ToAscii(virtKey, scancode, this._state, _pressedChars, 0) == 1)
        return (char)_pressedChars[0];
      else
        return _zero;
    }

  }
}
