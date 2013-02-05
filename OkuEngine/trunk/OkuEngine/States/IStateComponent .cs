using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines the interface for a state component.
  /// </summary>
  public interface IStateComponent : IStoreable
  {
    /// <summary>
    /// Gets or sets the ownering state of the component.
    /// </summary>
    StateBase Owner { get; set; }

    /// <summary>
    /// Gets the name of the component. This must be a
    /// unique identifier as it is used in the XML.
    /// </summary>
    string ComponentName { get; }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    IStateComponent Copy();

    /// <summary>
    /// Merges the values of the given state into this state.
    /// </summary>
    /// <param name="other">The state to merge values from.</param>
    /// <returns>True if the merging was successful, else false.</returns>
    bool Merge(IStateComponent other);
  }
}
