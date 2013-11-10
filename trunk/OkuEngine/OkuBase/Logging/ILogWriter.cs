using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Logging
{
  public interface ILogWriter
  {
    void WriteLine(LogEntry entry);
  }
}
