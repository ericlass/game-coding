using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine.Logging
{
  public class Logger
  {
    private int _maxEntries = 1000;
    private List<LogEntry> _entries = new List<LogEntry>();
    private HashSet<ILogWriter> _writers = new HashSet<ILogWriter>();

    public int MaxEntries
    {
      get { return _maxEntries; }
      set { _maxEntries = value; }
    }

    public void AddWriter(ILogWriter writer)
    {
      _writers.Add(writer);
    }

    public bool RemoveWriter(ILogWriter writer)
    {
      return _writers.Remove(writer);
    }

    private long GetCurrentTick()
    {
      long result = 0;
      Kernel32.QueryPerformanceCounter(out result);
      return result;
    }

    public void Log(LogLevel level, string message)
    {
      //TODO: Should be optimized to store removed entries and reuse them
      if (_entries.Count > _maxEntries)
      {
        _entries.RemoveRange(0, _entries.Count - (_maxEntries + 1));
      }

      LogEntry entry = new LogEntry(level, GetCurrentTick(), message);
      _entries.Add(entry);
      foreach (ILogWriter writer in _writers)
      {
        writer.WriteLine(entry);
      }
    }

    public void LogInfo(string message)
    {
      Log(LogLevel.Info, message);
    }

    public void LogError(string message)
    {
      Log(LogLevel.Info, message);
    }

    public int Count
    {
      get { return _entries.Count; }
    }

    public LogEntry this[int index]
    {
      get { return _entries[index]; }
    }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      foreach (LogEntry entry in _entries)
      {
        builder.Append(entry.ToString());
        builder.Append(Environment.NewLine);
      }
      return builder.ToString();
    }

  }
}
