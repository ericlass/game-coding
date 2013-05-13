using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuBase.Platform
{
  public class Kernel32
  {
    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern Int32 GetLastError();

    [DllImport("Kernel32.dll")]
    public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

    [DllImport("Kernel32.dll")]
    public static extern bool QueryPerformanceFrequency(out long lpFrequency);

  }
}
