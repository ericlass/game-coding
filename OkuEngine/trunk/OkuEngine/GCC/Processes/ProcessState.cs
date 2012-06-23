using System;

namespace OkuEngine.GCC.Processes
{
  public enum ProcessState
  {
    Uninitialized,
    Removed,
    Running,
    Paused,
    Succeeded,
    Failed,
    Aborted
  }
}