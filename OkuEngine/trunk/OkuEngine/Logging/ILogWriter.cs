using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine.Logging
{
  public interface ILogWriter
  {
    void WriteLine(LogEntry entry);
  }
}
