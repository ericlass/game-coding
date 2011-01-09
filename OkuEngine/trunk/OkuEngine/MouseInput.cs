using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Handles access to the mouse cursor position and button states.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class MouseInput
  {
    /// <summary>
    /// Internal struct to get mouse position.
    /// </summary>
    private struct Point
    {
      public int X;
      public int Y;
    }

    private Point _lastPos = new Point();
    private Point _position = new Point();
    private byte[] _buttonState = new byte[256];

    [DllImport("User32.dll")]
    private static extern bool GetKeyboardState(byte[] keyState);

    [DllImport("User32.dll")]
    private static extern bool GetCursorPos(ref Point pos);

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
      GetCursorPos(ref _position);
      GetKeyboardState(_buttonState);
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
    /// Gets if the left mouse button is pressed down or not.
    /// </summary>
    public bool LeftButtonIsDown
    {
      get 
      {
        byte mask = 128;
        return (_buttonState[(int)(Keys.LButton)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the right mouse button is pressed down or not.
    /// </summary>
    public bool RightButtonIsDown
    {
      get
      {
        byte mask = 128;
        return (_buttonState[(int)(Keys.RButton)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the middle mouse button is pressed down or not.
    /// </summary>
    public bool MiddleButtonIsDown
    {
      get
      {
        byte mask = 128;
        return (_buttonState[(int)(Keys.MButton)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the fourth mouse button on a five button mouse is pressed down or not.
    /// This button is usualy used in browsers for "back".
    /// </summary>
    public bool FourthButtonIsDown
    {
      get
      {
        byte mask = 128;
        return (_buttonState[(int)(Keys.XButton1)] & mask) == mask;
      }
    }

    /// <summary>
    /// Gets if the fifth mouse button on a five button mouse is pressed down or not.
    /// This button is usualy used in browsers for "forward".
    /// </summary>
    public bool FifthButtonIsDown
    {
      get
      {
        byte mask = 128;
        return (_buttonState[(int)(Keys.XButton2)] & mask) == mask;
      }
    }

  }
}
