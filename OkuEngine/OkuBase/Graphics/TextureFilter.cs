﻿using System;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines methods for texture filtering.
  /// </summary>
  public enum TextureFilter
  {
    /// <summary>
    /// Nearest neighbor interpolation using Manhattan Distance.
    /// </summary>
    NearestNeighbor,
    /// <summary>
    /// Linear Interpolation.
    /// </summary>
    Linear
  }
}