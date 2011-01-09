using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuEngine
{
  /// <summary>
  /// Wraps functions from user32.dll.
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  class User32
  {
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMessage
    {
      public IntPtr handle;
      public uint msg;
      public IntPtr wParam;
      public IntPtr lParam;
      public uint time;
      public System.Drawing.Point p;
    }

    public const uint WM_QUIT = 0x0012;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PeekMessage(out NativeMessage lpMsg, HandleRef hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

    [DllImport("user32.dll")]
    public static extern bool TranslateMessage([In] ref NativeMessage lpMsg);

    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage([In] ref NativeMessage lpMsg);

  }
}
