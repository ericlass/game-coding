using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Logging
{
  public class DebugConsoleLogWriter : ILogWriter
  {
    public void WriteLine(LogEntry entry)
    {
      System.Diagnostics.Debug.WriteLine(entry.Message);
    }
  }
}
