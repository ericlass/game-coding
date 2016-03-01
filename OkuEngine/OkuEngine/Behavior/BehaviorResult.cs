using System;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Defines the possible result of a behavior.
  /// What the single values exactly mean is determined by the actual beahvior.
  /// </summary>
  public enum BehaviorResult
  {
    /// <summary>
    /// Means the behavior is not finished and need further processing to finish.
    /// </summary>
    None,
    /// <summary>
    /// Means the behavior processing failed.
    /// </summary>
    Fail,
    /// <summary>
    /// Means the behavior completed successfully.
    /// </summary>
    Success
  }
}
