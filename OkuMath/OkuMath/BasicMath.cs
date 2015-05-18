using System;

namespace OkuMath
{
  /// <summary>
  /// Defines some basic mathematical functions.
  /// </summary>
  public static class BasicMath
  {
    /// <summary>
    /// Linearly interpolates the two given float values.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The secons value.</param>
    /// <param name="t">The control parameter.</param>
    /// <returns>The interpolated value.</returns>
    public static float Lerp(float a, float b, float t)
    {
      return a + (b - a) * t;
    }

    /// <summary>
    /// Linearly interpolates the two given vectors.
    /// </summary>
    /// <param name="a">The first vector.</param>
    /// <param name="b">The second vector.</param>
    /// <param name="t">The control value.</param>
    /// <returns>The interpolated result vector.</returns>
    public static Vector2f Lerp(Vector2f a, Vector2f b, float t)
    {
      return a + (b - a) * t;
    }

    /// <summary>
    /// Clamps the given float a between min and max.
    /// </summary>
    /// <param name="a">The value to be clamped.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static float Clamp(float a, float min, float max)
    {
      if (a < min)
        return min;
      if (a > max)
        return max;
      return a;
    }

  }
}
