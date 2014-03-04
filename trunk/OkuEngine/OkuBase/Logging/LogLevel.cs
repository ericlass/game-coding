using System;

namespace OkuBase.Logging
{
  /// <summary>
  /// Determines the log level of a log message.
  /// </summary>
  public enum LogLevel
  {
    /// <summary>
    /// Info level for general information.
    /// </summary>
    Info,
    /// <summary>
    /// Warning level for issues that do not affect the execution of the application.
    /// </summary>
    Warning,
    /// <summary>
    /// Error level for issue that keep the application from working correctly.
    /// </summary>
    Error
  }
}