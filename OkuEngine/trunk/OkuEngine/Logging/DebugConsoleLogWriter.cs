using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine.Logging
{
  public class DebugConsoleLogWriter : ILogWriter
  {
    public void WriteLine(LogEntry entry)
    {
      System.Diagnostics.Debug.Write(entry.Message);
    }
  }
}
