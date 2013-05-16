using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuBase.Platform
{
  public static class Opengl32
  {
    [DllImport("Opengl32.dll")]
    public static extern IntPtr wglCreateContext(IntPtr hdc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

    [DllImport("Opengl32.dll")]
    public static extern bool wglDeleteContext(IntPtr hglrc);

  }
}
