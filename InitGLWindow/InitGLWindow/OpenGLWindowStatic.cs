using System;
using System.Collections.Generic;

namespace InitGLWindow
{
  /// <summary>
  /// Static part of the OpenGL window. This is required because the WndProc method has to be static.
  /// This part of the class encapsulates the static part to be able have multiple instances.
  /// </summary>
  public partial class OpenGLWindow
  {
    public delegate IntPtr OpenGLWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    private static Dictionary<IntPtr, OpenGLWndProc> _wndProcs = new Dictionary<IntPtr, OpenGLWndProc>();

    /// <summary>
    /// Factory function that creates and initializes a new OpenGLWindow.
    /// </summary>
    /// <param name="wndProc">The WndProc method to be used.</param>
    /// <returns>A new instance of the OpenGLWindow.</returns>
    public static OpenGLWindow Build(OpenGLWndProc wndProc)
    {
      OpenGLWindow result = new OpenGLWindow();
      result.Initialize();
      _wndProcs.Add(result._hwnd, wndProc);
      return result;
    }

    /// <summary>
    /// This is the absolute default window proc function. You should call it whenever you do not handle a message yourself.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <param name="msg">The message.</param>
    /// <param name="wParam">The wParam.</param>
    /// <param name="lParam">The lParam.</param>
    /// <returns>A value depending on how the message was processed.</returns>
    public static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
      switch (msg)
      {
        case WinMessages.DESTROY:
          WinApi.PostQuitMessage(0);
          break;

        default:
          return WinApi.DefWindowProc(hWnd, msg, wParam, lParam);
      }

      return IntPtr.Zero;
    }

    /// <summary>
    /// This is the internal WndProc that forwards all messages to the instances.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <param name="msg">The message.</param>
    /// <param name="wParam">The wParam.</param>
    /// <param name="lParam">The lParam.</param>
    /// <returns>A value depending on how the message was processed.</returns>
    private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
      if (_wndProcs.ContainsKey(hWnd))
        return _wndProcs[hWnd](hWnd, msg, wParam, lParam);
      else
        return DefaultWndProc(hWnd, msg, wParam, lParam);
    }

  }
}