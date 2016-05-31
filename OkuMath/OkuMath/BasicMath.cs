using System;

namespace OkuMath
{
  /// <summary>
  /// Defines some basic mathematical functions.
  /// MIGRATED TO OkuMath!!!
  /// </summary>
  public static class BasicMath
  {
    private const float OneDegreeInRadians = (float)(Math.PI / 180.0);
    private const float OneRadianInDegrees = (float)(180.0 / Math.PI);

    /// <summary>
    /// Converts angle degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    public static float DegreesToRadians(float degrees)
    {
      return OneDegreeInRadians * degrees;
    }

    /// <summary>
    /// Converts angle radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    public static float RadiansToDegrees(float radians)
    {
      
      return OneRadianInDegrees * radians;
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
    /// Linearly interpolates the two given values.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The secons value.</param>
    /// <param name="t">The control parameter.</param>
    /// <returns>The interpolated value.</returns>
    public static double Lerp(double a, double b, double t)
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
    /// Interpolates between a and b using cosine interpolation. m controls the amount of interpolation.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <param name="m">The control paramters.</param>
    /// <returns>The interpolated value.</returns>
    public static float InterpolateCosine(float a, float b, float m)
    {
      float f = (1.0f - (float)Math.Cos(m * 3.1415927f)) * 0.5f;
      return a * (1.0f - f) + b * f;
    }

    /// <summary>
    /// Interpolates a value between y1 and y2 taking into account y0 and y3.
    /// </summary>
    /// <param name="y0">The first value.</param>
    /// <param name="y1">The second value.</param>
    /// <param name="y2">The third value.</param>
    /// <param name="y3">The fourth value.</param>
    /// <param name="m">The control paramter.</param>
    /// <returns>The interpolated value.</returns>
    public static float InterpolateCubic(float y0, float y1, float y2, float y3, float m)
    {
      float a0, a1, a2, a3, m2;

      m2 = m * m;
      a0 = y3 - y2 - y0 + y1;
      a1 = y0 - y1 - a0;
      a2 = y2 - y0;
      a3 = y1;

      return (a0 * m * m2 + a1 * m2 + a2 * m + a3);
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
    /// Clamps the given value a between min and max.
    /// </summary>
    /// <param name="a">The value to be clamped.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static double Clamp(double a, double min, double max)
    {
      if (a < min)
        return min;
      if (a > max)
        return max;
      return a;
    }

    /// <summary>
    /// Clamps the given value a between min and max.
    /// </summary>
    /// <param name="a">The value to be clamped.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static int Clamp(int a, int min, int max)
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

    /// <summary>
    /// Signed ceiling function. If the value is positive, it
    /// acts just like the normal ceiling. If the value is negative,
    /// the next smaller value is returned, so -1.5 returns -2 instead
    /// of -1.
    /// </summary>
    /// <param name="value">The value to process.</param>
    /// <returns>The ceiling of the given value.</returns>
    public static int SignedCeiling(float value)
    {
      if (value >= 0)
        return (int)Math.Ceiling(value);
      else
        return (int)Math.Floor(value);
    }

    /// <summary>
    /// Signed floor function. If the value is positive, it
    /// acts just like the normal floor. If the value is negative,
    /// the next bigger value is returned, so -1.5 returns -1 instead
    /// of -2.
    /// </summary>
    /// <param name="value">The value to process.</param>
    /// <returns>The ceiling of the given value.</returns>
    public static float SignedFloor(float value)
    {
      if (value >= 0)
        return (int)Math.Floor(value);
      else
        return (int)Math.Ceiling(value);
    }

    /// <summary>
    /// Signed max function. Returns the value with the biggest absolute value.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>The value with the biggest absolute value.</returns>
    public static float SignedMax(float a, float b)
    {
      if (Math.Abs(a) > Math.Abs(b))
        return a;
      else
        return b;
    }

    /// <summary>
    /// Signed max function. Returns the value with the biggest absolute value.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>The value with the biggest absolute value.</returns>
    public static int SignedMax(int a, int b)
    {
      if (Math.Abs(a) > Math.Abs(b))
        return a;
      else
        return b;
    }

    /// <summary>
    /// Signed max function. Returns the value with the lowest absolute value.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>The value with the lowest absolute value.</returns>
    public static float SignedMin(float a, float b)
    {
      if (Math.Abs(a) < Math.Abs(b))
        return a;
      else
        return b;
    }

    /// <summary>
    /// Signed max function. Returns the value with the lowest absolute value.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>The value with the lowest absolute value.</returns>
    public static int SignedMin(int a, int b)
    {
      if (Math.Abs(a) < Math.Abs(b))
        return a;
      else
        return b;
    }

    /// <summary>
    /// Calculates easing in or out.
    /// Positive strength creates easing in, negative easing out.
    /// </summary>
    /// <param name="strength">Controls how much the curve is eased.</param>
    /// <param name="t">The "time" parameter. Ranges from 0.0 to 1.0.</param>
    /// <returns>The eased value at the given time. Ranges from 0.0 to 1.0.</returns>
    public static float Easing(int strength, float t)
    {
      if (strength == 0)
        return t;

      float result = t;

      if (strength < 0)
        result = 1 - result;

      int max = strength < 0 ? strength * -1 : strength;
      for (int i = 0; i < max; i++)
      {
        result *= result;
      }
      if (strength < 0)
        result = 1 - result;

      return result;
    }

  }
}
