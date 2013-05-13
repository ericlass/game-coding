using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuBase.Platform
{
  /// <summary>
  /// Wraps functions from user32.dll.
  /// </summary>
  class User32
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
      //public System.Drawing.Point p;
    }

    public const uint WM_QUIT = 0x0012;
    public const uint WM_PAINT = 0x000F;
    public const uint WM_MOUSEWHEEL = 0x020A;
    public const uint WM_KEYDOWN = 0x0100;
    public const uint WM_KEYUP = 0x0101;

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

  }
}
