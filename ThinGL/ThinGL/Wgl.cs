using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ThinGL
{
  public static class Wgl
  {
    [DllImport("Opengl32.dll")]
    public static extern IntPtr wglCreateContext(IntPtr hdc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglDeleteContext(IntPtr hglrc);

    [DllImport("Opengl32.dll")]
    public static extern IntPtr wglGetProcAddress(string lpszProc);

  }
}
