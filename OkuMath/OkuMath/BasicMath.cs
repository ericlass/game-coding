using System;

namespace OkuMath
{
  /// <summary>
  /// Defines some basic mathematical functions.
  /// </summary>
  public static class BasicMath
  {
    private const float PiDiv180 = (float)(Math.PI / 180.0);
    private const float C180DivPi = (float)(180.0 / Math.PI);

    /// <summary>
    /// Converts angle degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    public static float DegreesToRadians(float degrees)
    {
      return PiDiv180 * degrees;
    }

    /// <summary>
    /// Converts angle radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    public static float RadiansToDegrees(float radians)
    {
      
      return C180DivPi * radians;
    }

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
    /// Linearly interpolates the two given vectors.
    /// </summary>
    /// <param name="a">The first vector.</param>
    /// <param name="b">The second vector.</param>
    /// <param name="t">The control value.</param>
    /// <returns>The interpolated result vector.</returns>
    public static Vector3f Lerp(Vector3f a, Vector3f b, float t)
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
    public static Vector4f Lerp(Vector4f a, Vector4f b, float t)
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

    /// <summary>
    /// Returns 0 if a is less than edge, otherwise it returns 1.
    /// </summary>
    /// <param name="a">The value.</param>
    /// <param name="edge">The threshold value.</param>
    /// <returns>0 if a is less than edge, otherwise 1.</returns>
    public static float Step(float a, float edge)
    {
      return a < edge ? 0.0f : 1.0f;
    }

    /// <summary>
    /// Returns 0.0 if a &lt;= edge0 and 1.0 if a &gt;= edge1 and performs smooth
    /// Hermite interpolation between 0 and 1 when edge0 &lt; a &lt; edge1.
    /// This is useful in cases where you would want a threshold function with a smooth transition.
    /// </summary>
    /// <param name="a">The value.</param>
    /// <param name="edge1">The lower threshold.</param>
    /// <param name="edge2">The upper threshold.</param>
    /// <returns>0.0 if a &lt;= edge0, 1.0 if a &gt;= edge1 and
    /// a value between 0 and 1 when edge0 &lt; a &lt; edge1.</returns>
    public static float SmoothStep(float a, float edge1, float edge2)
    {
      float t = Clamp((a - edge1) / (edge2 - edge1), 0.0f, 1.0f);
      return t * t * (3.0f - 2.0f * t);
    }

    /// <summary>
    /// Calculates the sine of the given angle (in degrees) using the
    /// Bhaskara I's sine approximation formula. CAUTION: This only work
    /// for angle between 0 and 180 degrees! The formula is remarkably
    /// accurate in this range.
    /// </summary>
    /// <param name="angle">The angle in degrees.</param>
    /// <returns>The approximate sine of the angle.</returns>
    public static float SineApproximation(float angle)
    {
      return (4 * angle * (180 - angle)) / (40500 - angle * (180 - angle));
    }

  }
}
