using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine.Logging
{
  /// <summary>
  /// Defines a simple logger.
  /// </summary>
  public class Logger
  {
    private int _maxEntries = 1000;
    private List<LogEntry> _entries = new List<LogEntry>();
    private List<LogEntry> _unusedEntries = new List<LogEntry>();
    private HashSet<ILogWriter> _writers = new HashSet<ILogWriter>();

    /// <summary>
    /// Gets or sets the miximum number of entries the logger stores.
    /// </summary>
    public int MaxEntries
    {
      get { return _maxEntries; }
      set { _maxEntries = value; }
    }

    /// <summary>
    /// Adds a new log writer to the logger.
    /// </summary>
    /// <param name="writer">The write to be added.</param>
    public void AddWriter(ILogWriter writer)
    {
      _writers.Add(writer);
    }

    /// <summary>
    /// Removes the given log writer from the logger.
    /// </summary>
    /// <param name="writer">The writer to be reomved.</param>
    /// <returns>True if the writer was removed, false if the logger does not contain the writer.</returns>
    public bool RemoveWriter(ILogWriter writer)
    {
      return _writers.Remove(writer);
    }

    /// <summary>
    /// Gets the current tick.
    /// </summary>
    /// <returns>The current tick.</returns>
    private long GetCurrentTick()
    {
      long result = 0;
      Kernel32.QueryPerformanceCounter(out result);
      return result;
    }

    /// <summary>
    /// Logs a new log message with the given log level.
    /// </summary>
    /// <param name="level">The level of the log message.</param>
    /// <param name="message">The new log message.</param>
    public void Log(LogLevel level, string message)
    {
      //Only remember a set of log entries and remember unused for later use.
      while (_entries.Count >= _maxEntries)
      {
        _unusedEntries.Add(_entries[_entries.Count - 1]);
        _entries.RemoveAt(_entries.Count - 1);
      }

      //Either create a new log entry or recycle an unused one.
      LogEntry entry = null;
      if (_unusedEntries.Count > 0)
      {
        entry = _unusedEntries[_unusedEntries.Count - 1];
        entry.Level = level;
        entry.Tick = GetCurrentTick();
        entry.Message = message;
      }
      else
        entry = new LogEntry(level, GetCurrentTick(), message);

      _entries.Add(entry);
      foreach (ILogWriter writer in _writers)
      {
        writer.WriteLine(entry);
      }
    }

    /// <summary>
    /// Logs a new message with info log level.
    /// </summary>
    /// <param name="message">The message to be logged.</param>
    public void LogInfo(string message)
    {
      Log(LogLevel.Info, message);
    }

    /// <summary>
    /// Logs a new message with error log level.
    /// </summary>
    /// <param name="message">The message to be logged.</param>
    public void LogError(string message)
    {
      Log(LogLevel.Info, message);
    }

    /// <summary>
    /// Gets the number of log entries the logger currently stores.
    /// This is always &gt;= MaxExntries.
    /// </summary>
    public int Count
    {
      get { return _entries.Count; }
    }

    /// <summary>
    /// Gets the log entry at the given index where 0
    /// points to the oldest entry.
    /// </summary>
    /// <param name="index">The index of the entry.</param>
    /// <returns>The log entry at the given index.</returns>
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
