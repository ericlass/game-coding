using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Timer
{
  /// <summary>
  /// Interface for timers.
  /// </summary>
  interface ITimer
  {
    /// <summary>
    /// Gets the id of the timer.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Returns true if the timer wishes to be cleared and never be called again.
    /// </summary>
    /// <param name="dt">The time in seconds that passed since th last frame.</param>
    /// <returns>True if the timer wishes to be cleared and never be called again, else false.</returns>
    bool Update(float dt);
  }
}
