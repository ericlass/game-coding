using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OkuEngine
{
  public enum MouseButton
  {
    Left = (int)Keys.LButton,
    Right = (int)Keys.RButton,
    Middle = (int)Keys.MButton,
    Fourth = (int)Keys.XButton1,
    Fifth = (int)Keys.XButton2
  }

  /// <summary>
  /// Handles access to the mouse cursor position and button states.
  /// </summary>
  public class MouseInput
  {
    private User32.Point _lastPos = new User32.Point();
    private User32.Point _position = new User32.Point();
    private byte[] _lastButtonState = new byte[256];
    private byte[] _buttonState = new byte[256];

    private bool _pressedButtonsValid = false;
    private List<MouseButton> _pressedButtons = new List<MouseButton>();

    private bool _raisedButtonsValid = false;
    private List<MouseButton> _raisedButtons = new List<MouseButton>();

    private float _wheelDelta = 0;

    /// <summary>
    /// Creates a new mouse input.
    /// </summary>
    public MouseInput()
    {
    }

    /// <summary>
    /// Updates the current position and buttons states that are used internally.
    /// </summary>
    public void Update()
    {
      _lastPos = _position;
      User32.GetCursorPos(ref _position);
      Array.Copy(_buttonState, _lastButtonState, _buttonState.Length);
      User32.GetKeyboardState(_buttonState);

      _pressedButtonsValid = false;
      _raisedButtonsValid = false;
    }

    /// <summary>
    /// Gets the absolute vertical coordinate of the mouse cursor in screen space.
    /// </summary>
    public int X
    {
      get { return _position.X; }
    }

    /// <summary>
    /// Gets the absolute horizontal coordinate of the mouse cursor in screen space.
    /// </summary>
    public int Y
    {
      get { return _position.Y; }
    }

    /// <summary>
    /// Gets the change in the vertical coordinate of the mouse cursor in screen space
    /// since the last call to <code>Update</code>.
    /// </summary>
    public int RelativeX
    {
      get { return _lastPos.X - _position.X; }
    }

    /// <summary>
    /// Gets the change in the horizontal coordinate of the mouse cursor in screen space
    /// since the last call to <code>Update</code>.
    /// </summary>
    public int RelativeY
    {
      get { return _lastPos.Y - _position.Y; }
    }

    /// <summary>
    /// Check if the given button is down in the given state.
    /// </summary>
    /// <param name="button">The button to e checked.</param>
    /// <param name="state">The button state array.</param>
    /// <returns>True if the button is down, else False.</returns>
    private bool ButtonIsDown(MouseButton button, byte[] state)
    {
      byte mask = 128;
      return (state[(int)(button)] & mask) == mask;
    }

    /// <summary>
    /// Checks if the given button is currently pressed down. Returns true as long as the button is pressed down.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button is pressed down right now, else false.</returns>
    public bool ButtonIsDown(MouseButton button)
    {
      return ButtonIsDown(button, _buttonState);
    }

    /// <summary>
    /// Checks if the given button is currently hold down, that is it is pressed down now and was also pressed down last frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button is hold down, else false.</returns>
    public bool ButtonIsHoldDown(MouseButton button)
    {
      return ButtonIsDown(button, _lastButtonState) && ButtonIsDown(button, _buttonState);
    }

    /// <summary>
    /// Checks if the given button was pressed down since the last frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was pressed, else false.</returns>
    public bool ButtonPressed(MouseButton button)
    {
      return !ButtonIsDown(button, _lastButtonState) && ButtonIsDown(button, _buttonState);
    }

    /// <summary>
    /// Checks if the given button was raised since the last frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was raised, else false.</returns>
    public bool ButtonRaised(MouseButton button)
    {
      return ButtonIsDown(button, _lastButtonState) && !ButtonIsDown(button, _buttonState);
    }

    /// <summary>
    /// Gets the buttons that have been pressed down since the last frame.
    /// </summary>
    /// <returns>A list of the buttons that have been pressed down.</returns>
    public List<MouseButton> GetPressedButtons()
    {
      if (!_pressedButtonsValid)
      {
        _pressedButtons.Clear();
        foreach (MouseButton btn in Enum.GetValues(typeof(MouseButton)))
        {
          if (ButtonPressed(btn))
            _pressedButtons.Add(btn);
        }
        _pressedButtonsValid = true;
      }
      return _pressedButtons;
    }

    /// <summary>
    /// Gets the buttons that have been raised up since the last frame.
    /// </summary>
    /// <returns>A list of the buttons that have been raised up.</returns>
    public List<MouseButton> GetRaisedButtons()
    {
      if (!_raisedButtonsValid)
      {
        _raisedButtons.Clear();
        foreach (MouseButton btn in Enum.GetValues(typeof(MouseButton)))
        {
          if (ButtonRaised(btn))
            _raisedButtons.Add(btn);
        }
        _raisedButtonsValid = true;
      }
      return _raisedButtons;
    }

    /// <summary>
    /// Gets the amount of lines the mouse wheel has scrolled.
    /// </summary>
    public float WheelDelta
    {
      get { return _wheelDelta; }
      set { _wheelDelta = value; }
    }

    /// <summary>
    /// Gets if the mouse wheel has been scrolled or not.
    /// </summary>
    public bool WheelSpinned
    {
      get { return _wheelDelta != 0.0f; }
    }

  }
}
