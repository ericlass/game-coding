using System;

namespace OkuEngine.Processes
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