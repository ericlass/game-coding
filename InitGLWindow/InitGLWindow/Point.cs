using System;
using System.Runtime.InteropServices;

namespace InitGLWindow
{
  [StructLayout(LayoutKind.Sequential)]
  public struct POINT
  {
    public int X;
    public int Y;
  }
}