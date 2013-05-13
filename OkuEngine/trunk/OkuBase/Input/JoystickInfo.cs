using System;
using System.Text;
using OkuBase.Platform;

namespace OkuBase.Input
{
  /// <summary>
  /// Contains the information about one single joystick.
  /// </summary>
  public class JoystickInfo
  {
    private uint _id = 0;
    private uint _lastButtons = 0;
    private uint _buttons = 0;
    private JOYCAPS _caps;

    /// <summary>
    /// Creates a new joystick with the given ID and capabilities.
    /// </summary>
    /// <param name="id">The joysticks ID.</param>
    /// <param name="caps">The joysticks capabilities.</param>
    public JoystickInfo(uint id, JOYCAPS caps)
    {
      _id = id;
      _caps = caps;
    }

    /// <summary>
    /// Creates a new joystick with the given ID and capabilities and initializes it with the given state.
    /// </summary>
    /// <param name="id">The joysticks ID.</param>
    /// <param name="caps">The joysticks capabilities.</param>
    /// <param name="state">The joysticks current state.</param>
    public JoystickInfo(uint id, JOYCAPS caps, JOYINFOEX state)
    {
      _id = id;
      _caps = caps;
      SetState(state);
    }

    /// <summary>
    /// Sets the current state of the joystick.
    /// </summary>
    /// <param name="state">The joysticks current state.</param>
    public void SetState(JOYINFOEX state)
    {
      _lastButtons = _buttons;
      _buttons = state.dwButtons;
      X = (state.dwXpos - _caps.wXmin) / (float)(_caps.wXmax - _caps.wXmin);
      Y = (state.dwYpos - _caps.wYmin) / (float)(_caps.wYmax - _caps.wYmin);
      Z = (state.dwZpos - _caps.wZmin) / (float)(_caps.wZmax - _caps.wZmin);
      U = (state.dwUpos - _caps.wUmin) / (float)(_caps.wUmax - _caps.wUmin);
      V = (state.dwVpos - _caps.wVmin) / (float)(_caps.wVmax - _caps.wVmin);
      R = (state.dwRpos - _caps.wRmin) / (float)(_caps.wRmax - _caps.wRmin);
      PointOfViewAngle = state.dwPOV / 100.0f;
    }

    /// <summary>
    /// Checks if the button with the given index is currently pressed or not in the given button state.
    /// </summary>
    /// <param name="buttonIndex">The index of the button. Must be in the range 0..NumberOfButtons.</param>
    /// <param name="buttonState">The button state to get the current state of the button from.</param>
    /// <returns>True if the button is down, else false.</returns>
    private bool ButtonIsDown(int buttonIndex, uint buttonState)
    {
      uint mask = (uint)Math.Pow(2, buttonIndex);
      return (buttonState & mask) == mask;
    }

    /// <summary>
    /// Checks if the given button is down at the moment.
    /// </summary>
    /// <param name="buttonIndex">The number of the button to check. Must be in the range 0..NumberOfButtons.</param>
    /// <returns>True if the button is down, else false.</returns>
    public bool ButtonIsDown(int buttonIndex)
    {
      return ButtonIsDown(buttonIndex, _buttons);
    }

    /// <summary>
    /// Checks if the given button is hold down.
    /// </summary>
    /// <param name="buttonIndex">The number of the button to check. Must be in the range 0..NumberOfButtons.</param>
    /// <returns>True if the button is hold down, else false.</returns>
    public bool ButtonIsHoldDown(int buttonIndex)
    {
      return ButtonIsDown(buttonIndex, _lastButtons) && ButtonIsDown(buttonIndex, _buttons);
    }

    /// <summary>
    /// Checks if the given button was pressed down since the last frame.
    /// </summary>
    /// <param name="buttonIndex">The number of the button to check. Must be in the range 0..NumberOfButtons.</param>
    /// <returns>True if the button was pressed down, else false.</returns>
    public bool ButtonPressed(int buttonIndex)
    {
      return !ButtonIsDown(buttonIndex, _lastButtons) && ButtonIsDown(buttonIndex, _buttons);
    }

    /// <summary>
    /// Checks if the given button was raised since the last frame.
    /// </summary>
    /// <param name="buttonIndex">The number of the button to check. Must be in the range 0..NumberOfButtons.</param>
    /// <returns>True if the button was raised, else false.</returns>
    public bool ButtonRaised(int buttonIndex)
    {
      return ButtonIsDown(buttonIndex, _lastButtons) && !ButtonIsDown(buttonIndex, _buttons);
    }

    /// <summary>
    /// Gets or sets the joystick ID used to query the joysticks state with the Win-API methods.
    /// </summary>
    public uint ID
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Gets the number of buttons of the joystick.
    /// </summary>
    public int NumberOfButtons
    {
      get { return (int)_caps.wNumButtons; }
    }

    /// <summary>
    /// Gets the number of axis ths joystick has.
    /// </summary>
    public int NumberOfAxis
    {
      get { return (int)_caps.wNumAxes; }
    }
    
    /// <summary>
    /// Gets or sets the current X-coordinate in the range 0.0-1.0.
    /// </summary>
    public float X { get; set; }
    
    /// <summary>
    /// Gets or sets the current Y-coordinate in the range 0.0-1.0.
    /// </summary>
    public float Y { get; set; }
    
    /// <summary>
    /// Gets or sets the current Z-coordinate in the range 0.0-1.0.
    /// </summary>
    public float Z { get; set; }
    
    /// <summary>
    /// Gets or sets the current position of the rudder or fourth joystick axis in the range 0.0-1.0.
    /// </summary>
    public float R { get; set; }
    
    /// <summary>
    /// Gets or sets the current fifth axis position in the range 0.0-1.0.
    /// </summary>
    public float U { get; set; }

    /// <summary>
    /// Gets or sets the current sixth axis position in the range 0.0-1.0.
    /// </summary>
    public float V { get; set; }
   
    /// <summary>
    /// Gets or sets the current angle of the point-of-view control. Values for this member are in the range 0 through 359.99. These values represent the angle, in degrees, of each view.
    /// </summary>
    public float PointOfViewAngle { get; set; }

    /// <summary>
    /// Creates a string representation of the current joystick state. Should only be used for debugging.
    /// </summary>
    /// <returns>A string representation of the current joystick state.</returns>
    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.AppendLine("Buttons: " + NumberOfButtons);
      builder.AppendLine("Axis: " + NumberOfAxis);
      builder.AppendLine("X: " + X);
      builder.AppendLine("Y: " + Y);
      builder.AppendLine("Z: " + Z);
      builder.AppendLine("R: " + R);
      builder.AppendLine("U: " + U);
      builder.AppendLine("V: " + V);
      builder.AppendLine("Point Of View: " + PointOfViewAngle);
      builder.AppendLine("Buttons: " + Convert.ToString(_buttons, 2).PadLeft(NumberOfButtons, '0'));
      return builder.ToString();
    }

  }
}
