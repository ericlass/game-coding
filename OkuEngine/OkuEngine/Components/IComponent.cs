﻿using System;

namespace OkuEngine.Components
{
  /// <summary>
  /// Interface for components.
  /// </summary>
  public interface IComponent
  {
    /// <summary>
    /// Components must define a unique name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Components must define if they can be assigned multiple times to an entity or not.
    /// </summary>
    bool IsMultiAssignable { get; }
  }
}