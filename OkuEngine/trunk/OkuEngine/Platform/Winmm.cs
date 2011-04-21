using System;
using System.Runtime.InteropServices;

namespace OkuEngine
{
  /// <summary>
  /// Contains extended information about the joystick position, point-of-view position, and button state.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct JOYINFOEX
  {
    /// <summary>
    /// Size, in bytes, of this structure. Use System.Runtime.InteropServices.Marshal.SizeOf(...) to initialize this.
    /// </summary>
    public uint dwSize;
    /// <summary>
    /// Flags indicating the valid information returned in this structure. Members that do not contain valid information are set to zero.
    /// </summary>
    public uint dwFlags;
    /// <summary>
    /// Current X-coordinate.
    /// </summary>
    public uint dwXpos;
    /// <summary>
    /// Current Y-coordinate.
    /// </summary>
    public uint dwYpos;
    /// <summary>
    /// Current Z-coordinate.
    /// </summary>
    public uint dwZpos;
    /// <summary>
    /// Current position of the rudder or fourth joystick axis.
    /// </summary>
    public uint dwRpos;
    /// <summary>
    /// Current fifth axis position.
    /// </summary>
    public uint dwUpos;
    /// <summary>
    /// Current sixth axis position.
    /// </summary>
    public uint dwVpos;
    /// <summary>
    /// Current state of the 32 joystick buttons. The value of this member can be set to any combination of JOY_BUTTON n flags, where n is a value in the range of 1 through 32 corresponding to the button that is pressed.
    /// </summary>
    public uint dwButtons;
    /// <summary>
    /// Current button number that is pressed.
    /// </summary>
    public uint dwButtonNumber;
    /// <summary>
    /// Current position of the point-of-view control. Values for this member are in the range 0 through 35,900. These values represent the angle, in degrees, of each view multiplied by 100.
    /// </summary>
    public uint dwPOV;
    /// <summary>
    /// Reserved; do not use.
    /// </summary>
    public uint dwReserved1;
    /// <summary>
    /// Reserved; do not use.
    /// </summary>
    public uint dwReserved2;
  }

  /// <summary>
  /// The JOYINFO structure contains information about the joystick position and button state.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct JOYINFO
  {
    /// <summary>
    /// Current X-coordinate.
    /// </summary>
    public uint wXpos;
    /// <summary>
    /// Current Y-coordinate.
    /// </summary>
    public uint wYpos;
    /// <summary>
    /// Current Z-coordinate.
    /// </summary>
    public uint wZpos;
    /// <summary>
    /// Current state of joystick buttons.
    /// </summary>
    public uint wButtons;
  }

  /// <summary>
  /// The JOYCAPS structure contains information about the joystick capabilities.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public struct JOYCAPS 
  {
    /// <summary>
    /// Manufacturer identifier.
    /// </summary>
    public ushort wMid;
    /// <summary>
    /// Product identifier.
    /// </summary>
    public ushort wPid;
    /// <summary>
    /// Null-terminated string containing the joystick product name.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string szPname;
    /// <summary>
    /// Minimum X-coordinate.
    /// </summary>
    public uint wXmin;
    /// <summary>
    /// Maximum X-coordinate.
    /// </summary>
    public uint wXmax;
    /// <summary>
    /// Minimum Y-coordinate.
    /// </summary>
    public uint wYmin;
    /// <summary>
    /// Maximum Y-coordinate.
    /// </summary>
    public uint wYmax;
    /// <summary>
    /// Minimum Z-coordinate.
    /// </summary>
    public uint wZmin;
    /// <summary>
    /// Maximum Z-coordinate.
    /// </summary>
    public uint wZmax;
    /// <summary>
    /// Number of joystick buttons.
    /// </summary>
    public uint wNumButtons;
    /// <summary>
    /// Smallest polling frequency supported when captured by the joySetCapture function.
    /// </summary>
    public uint wPeriodMin;
    /// <summary>
    /// Largest polling frequency supported when captured by joySetCapture.
    /// </summary>
    public uint wPeriodMax;
    /// <summary>
    /// Minimum rudder value. The rudder is a fourth axis of movement.
    /// </summary>
    public uint wRmin;
    /// <summary>
    /// Maximum rudder value. The rudder is a fourth axis of movement.
    /// </summary>
    public uint wRmax;
    /// <summary>
    /// Minimum u-coordinate (fifth axis) values.
    /// </summary>
    public uint wUmin;
    /// <summary>
    /// Maximum u-coordinate (fifth axis) values.
    /// </summary>
    public uint wUmax;
    /// <summary>
    /// Minimum v-coordinate (sixth axis) values.
    /// </summary>
    public uint wVmin;
    /// <summary>
    /// Maximum v-coordinate (sixth axis) values.
    /// </summary>
    public uint wVmax;
    /// <summary>
    /// Joystick capabilities.
    /// </summary>
    public uint wCaps;
    /// <summary>
    /// Maximum number of axes supported by the joystick.
    /// </summary>
    public uint wMaxAxes;
    /// <summary>
    /// Number of axes currently in use by the joystick.
    /// </summary>
    public uint wNumAxes;
    /// <summary>
    /// Maximum number of buttons supported by the joystick.
    /// </summary>
    public uint wMaxButtons;
    /// <summary>
    /// Null-terminated string containing the registry key for the joystick.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string szRegKey;
    /// <summary>
    /// Null-terminated string identifying the joystick driver OEM.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szOEMVxD;
  } 

  /// <summary>
  /// Wrapper class for the Winmm.dll. Currently only most common joystick functions are supported.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class Winmm
  {
    public static uint MMSYSERR_BASE = 0;
    public static uint MMSYSERR_BADDEVICEID = MMSYSERR_BASE + 2;
    public static uint MMSYSERR_NODRIVER = MMSYSERR_BASE + 6;
    public static uint MMSYSERR_INVALPARAM = MMSYSERR_BASE + 11;

    public static uint JOYERR_BASE = 160;
    public static uint JOYERR_NOERROR = 0;
    public static uint JOYERR_PARMS = JOYERR_BASE + 5;
    public static uint JOYERR_UNPLUGGED = JOYERR_BASE + 7;    

    public static uint JOY_RETURNX = 0x00000001;
    public static uint JOY_RETURNY = 0x00000002;
    public static uint JOY_RETURNZ = 0x00000004;
    public static uint JOY_RETURNR = 0x00000008;
    public static uint JOY_RETURNU = 0x00000010;    /* axis 5 */
    public static uint JOY_RETURNV = 0x00000020;     /* axis 6 */
    public static uint JOY_RETURNPOV = 0x00000040;
    public static uint JOY_RETURNBUTTONS = 0x00000080;
    public static uint JOY_RETURNALL = JOY_RETURNX | JOY_RETURNY | JOY_RETURNZ | JOY_RETURNR | JOY_RETURNU | JOY_RETURNV | JOY_RETURNPOV | JOY_RETURNBUTTONS;

    public static uint JOY_BUTTON1 = 0x00000001;
    public static uint JOY_BUTTON2 = 0x00000002;
    public static uint JOY_BUTTON3 = 0x00000004;
    public static uint JOY_BUTTON4 = 0x00000008;
    public static uint JOY_BUTTON5 = 0x00000010;
    public static uint JOY_BUTTON6 = 0x00000020;
    public static uint JOY_BUTTON7 = 0x00000040;
    public static uint JOY_BUTTON8 = 0x00000080;
    public static uint JOY_BUTTON9 = 0x00000100;
    public static uint JOY_BUTTON10 = 0x00000200;
    public static uint JOY_BUTTON11 = 0x00000400;
    public static uint JOY_BUTTON12 = 0x00000800;
    public static uint JOY_BUTTON13 = 0x00001000;
    public static uint JOY_BUTTON14 = 0x00002000;
    public static uint JOY_BUTTON15 = 0x00004000;
    public static uint JOY_BUTTON16 = 0x00008000;
    public static uint JOY_BUTTON17 = 0x00010000;
    public static uint JOY_BUTTON18 = 0x00020000;
    public static uint JOY_BUTTON19 = 0x00040000;
    public static uint JOY_BUTTON20 = 0x00080000;
    public static uint JOY_BUTTON21 = 0x00100000;
    public static uint JOY_BUTTON22 = 0x00200000;
    public static uint JOY_BUTTON23 = 0x00400000;
    public static uint JOY_BUTTON24 = 0x00800000;
    public static uint JOY_BUTTON25 = 0x01000000;
    public static uint JOY_BUTTON26 = 0x02000000;
    public static uint JOY_BUTTON27 = 0x04000000;
    public static uint JOY_BUTTON28 = 0x08000000;
    public static uint JOY_BUTTON29 = 0x10000000;
    public static uint JOY_BUTTON30 = 0x20000000;
    public static uint JOY_BUTTON31 = 0x40000000;
    public static uint JOY_BUTTON32 = 0x80000000;

    /// <summary>
    /// The joyGetNumDevs function queries the joystick driver for the number of joysticks it supports.
    /// </summary>
    /// <remarks>Use the joyGetPos function to determine whether a given joystick is physically attached to the system. If the specified joystick is not connected, joyGetPos returns a JOYERR_UNPLUGGED error value.</remarks>
    /// <returns>The joyGetNumDevs function returns the number of joysticks supported by the current driver or zero if no driver is installed.</returns>
    [DllImport("Winmm.dll")]
    public static extern uint joyGetNumDevs();

    /// <summary>
    /// The joyGetPos function queries a joystick for its position and button status.
    /// </summary>
    /// <param name="joyID">Identifier of the joystick to be queried. Valid values for uJoyID range from zero (JOYSTICKID1) to 15, except for Windows NT 4.0. For Windows NT 4.0, valid values are limited to JOYSTICKID1 and JOYSTICKID2.</param>
    /// <param name="joyInfo">Pointer to a JOYINFO structure that contains the position and button status of the joystick.</param>
    /// <returns>Returns JOYERR_NOERROR if successful or one of the following error values: MMSYSERR_NODRIVER, MMSYSERR_INVALPARAM, JOYERR_UNPLUGGED.</returns>
    [DllImport("Winmm.dll")]
    public static extern uint joyGetPos(uint joyID, ref JOYINFO joyInfo);

    /// <summary>
    /// The joyGetPosEx function queries a joystick for its position and button status.
    /// </summary>
    /// <param name="joyID">Identifier of the joystick to be queried. Valid values for uJoyID range from zero (JOYSTICKID1) to 15, except for Windows NT 4.0. For Windows NT 4.0, valid values are limited to JOYSTICKID1 and JOYSTICKID2.</param>
    /// <param name="joyInfo">Pointer to a JOYINFOEX structure that contains extended position information and button status of the joystick. You must set the dwSize and dwFlags members or joyGetPosEx will fail. The information returned from joyGetPosEx depends on the flags you specify in dwFlags.</param>
    /// <returns>Returns JOYERR_NOERROR if successful or one of the following error values: MMSYSERR_NODRIVER, MMSYSERR_INVALPARAM, MMSYSERR_BADDEVICEID, JOYERR_UNPLUGGED, JOYERR_PARMS.</returns>
    [DllImport("Winmm.dll")]
    public static extern uint joyGetPosEx(uint joyID, ref JOYINFOEX joyInfo);

    /// <summary>
    /// The joyGetDevCaps function queries a joystick to determine its capabilities.
    /// </summary>
    /// <param name="joyID">Identifier of the joystick to be queried. Valid values for uJoyID range from -1 to 15. A value of -1 enables retrieval of the szRegKey member of the JOYCAPS structure whether a device is present or not. For Windows NT 4.0, valid values are limited to zero (JOYSTICKID1) and JOYSTICKID2.</param>
    /// <param name="joyCaps">Pointer to a JOYCAPS structure to contain the capabilities of the joystick.</param>
    /// <param name="size">Size, in bytes, of the JOYCAPS structure.</param>
    /// <returns>Returns JOYERR_NOERROR if successful or one of the following error values: MMSYSERR_NODRIVER, MMSYSERR_INVALPARAM.</returns>
    [DllImport("Winmm.dll")]
    public static extern uint joyGetDevCaps(uint joyID, ref JOYCAPS joyCaps, uint size);

  }
}
