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
    private static string ClassNameBase = "OpenGLWindow";
    private static Dictionary<IntPtr, OpenGLWindow> _glWindows = new Dictionary<IntPtr, OpenGLWindow>();

    /// <summary>
    /// Factory function that creates and initializes a new OpenGLWindow.
    /// </summary>
    /// <returns>A new instance of the OpenGLWindow.</returns>
    public static OpenGLWindow Build()
    {
      OpenGLWindow result = new OpenGLWindow(ClassNameBase + _glWindows.Count);
      result.Initialize();
      _glWindows.Add(result._hwnd, result);
      return result;
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
      //During window creation it is possible that _glWindows does not contain the window yet, so use the DefWindowProc.
      if (_glWindows.ContainsKey(hWnd))
        return _glWindows[hWnd].InstanceWndProc(hWnd, msg, wParam, lParam);
      else
        return WinApi.DefWindowProc(hWnd, msg, wParam, lParam);
    }

  }
}