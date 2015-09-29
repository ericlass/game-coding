using System;

namespace OkuMath
{
  /// <summary>
  /// Defines circle functions.
  /// </summary>
  public static class CircleMath
  {
    /// <summary>
    /// Calculates the half width of a circle at the given "height" h.
    /// Imagine a circle with the center point at the origin [0,0] of a coordinate system.
    /// The value given by h is treated as a value on the the vertical axis. It has to
    /// be in the range -1.0 - 1.0. The return value then gives you the half width the
    /// circle has on the horizontal axis at that h value.
    /// For h = 0.0 this is 1.0, or more precisely, the full radius of the circle.
    /// For h = 1 or h = -1, it would be 0.
    /// </summary>
    /// <param name="h">The height at which the width is calculated.</param>
    /// <returns>The width of the circle in the range 0.0 - 1.0.</returns>
    public static float HalfWidthOfCircle(float h)
    {
      return (float)Math.Sin(Math.Acos(h));
    }
  }
}
