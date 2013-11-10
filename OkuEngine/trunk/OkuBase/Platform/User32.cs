using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuBase.Platform
{
  /// <summary>
  /// Wraps functions from user32.dll.
  /// </summary>
  public class User32
  {
    /// <summary>
    /// Internal struct to get mouse position.
    /// </summary>
    public struct Point
    {
      public int X;
      public int Y;
    } 

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMessage
    {
      public IntPtr handle;
      public uint msg;
      public IntPtr wParam;
      public IntPtr lParam;
      public uint time;
    }

    public const uint WM_QUIT           = 0x0012;
    public const uint WM_PAINT          = 0x000F;
    public const uint WM_MOUSEWHEEL     = 0x020A;
    public const uint WM_KEYDOWN        = 0x0100;
    public const uint WM_KEYUP          = 0x0101;
    public const uint WM_LBUTTONDBLCLK  = 0x0203;
    public const uint WM_LBUTTONDOWN    = 0x0201;
    public const uint WM_LBUTTONUP      = 0x0202;
    public const uint WM_MBUTTONDBLCLK  = 0x0209;
    public const uint WM_MBUTTONDOWN    = 0x0207;
    public const uint WM_MBUTTONUP      = 0x0208;
    public const uint WM_RBUTTONDBLCLK  = 0x0206;
    public const uint WM_RBUTTONDOWN    = 0x0204;
    public const uint WM_RBUTTONUP      = 0x0205;
    public const uint WM_XBUTTONDBLCLK  = 0x020D;
    public const uint WM_XBUTTONDOWN    = 0x020B;
    public const uint WM_XBUTTONUP      = 0x020C;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PeekMessage(out NativeMessage lpMsg, HandleRef hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

    [DllImport("user32.dll")]
    public static extern bool TranslateMessage([In] ref NativeMessage lpMsg);

    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage([In] ref NativeMessage lpMsg);

    [DllImport("User32.dll")]
    public static extern bool GetKeyboardState(byte[] keyState);

    [DllImport("User32.dll")]
    public static extern bool GetCursorPos(ref Point pos);

    [DllImport("User32.dll")]
    public static extern int ToAscii(uint virtKey, uint scanCode, byte[] keyState, byte[] characters, uint flags);

    [DllImport("User32.dll")]
    public static extern uint MapVirtualKey(uint code, uint mapType);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

  }
}
