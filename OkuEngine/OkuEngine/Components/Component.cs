using System;

namespace OkuEngine.Components
{
  /// <summary>
  /// Interface for components.
  /// </summary>
  public abstract class Component
  {
    /// <summary>
    /// Components must define a unique name.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Components must define if they can be assigned multiple times to an entity or not.
    /// </summary>
    public abstract bool IsMultiAssignable { get; }

    /// <summary>
    /// Does a full, deep, independent copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public abstract Component Copy();
  }
}
