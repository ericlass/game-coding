using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine.Logging
{
  public class LogEntry
  {
    private LogLevel _level = LogLevel.Info;
    private long _tick = 0;
    private string _message = null;

    public LogEntry(LogLevel level, long tick, string message)
    {
      _level = level;
      _tick = tick;
      _message = message;
    }

    public LogLevel Level
    {
      get { return _level; }
      set { _level = value; }
    }

    public long Tick
    {
      get { return _tick; }
      set { _tick = value; }
    }
    
    public string Message
    {
      get { return _message; }
      set { _message = value; }
    }
    
    public override string ToString()
    {
      return "[" + _level.ToString() + "] - " + _tick + " - " + _message;
    }

  }
}
