using System;

namespace OkuMath
{
  public static class AABBMath
  {
    /// <summary>
    /// Calculates the squared distance of the point p to the AABB defined by [min,max].
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <param name="p">The point.</param>
    /// <returns>The squared distance of the point to the AABB.</returns>
    public static float SquaredDistanceToPoint(Vector2f min, Vector2f max, Vector2f p)
    {
      float result = 0.0f;

      if (p.X < min.X)
        result += (min.X - p.X) * (min.X - p.X);
      if (p.X > max.X)
        result += (p.X - max.X) * (p.X - max.X);

      if (p.Y < min.Y)
        result += (min.Y - p.Y) * (min.Y - p.Y);
      if (p.Y > max.Y)
        result += (p.Y - max.Y) * (p.Y - max.Y);

      return result;
    }

    /// <summary>
    /// Calculates the center point of the AABB defined by the given min and max vectors.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>The center of the AABB.</returns>
    public static Vector2f Center(Vector2f min, Vector2f max)
    {
      return (max - min) * 0.5f;
    }

    /// <summary>
    /// Calculates the bounding box of the given points.
    /// This uses the naive algorithm that checks all points.
    /// </summary>
    /// <param name="points">The points.</param>
    /// <returns>A tuple with the minimum point in Item1 and the maximum point in Item2.</returns>
    public static Tuple<Vector2f, Vector2f> FromPoints(Vector2f[] points)
    {
      Vector2f min = new Vector2f(float.MaxValue, float.MaxValue);
      Vector2f max = new Vector2f(float.MinValue, float.MinValue);

      min.X = float.MaxValue;
      min.Y = float.MaxValue;

      max.X = float.MinValue;
      max.Y = float.MinValue;

      foreach (Vector2f vec in points)
      {
        min.X = Math.Min(min.X, vec.X);
        min.Y = Math.Min(min.Y, vec.Y);
        max.X = Math.Max(max.X, vec.X);
        max.Y = Math.Max(max.Y, vec.Y);
      }

      return new Tuple<Vector2f, Vector2f>(min, max);
    }

    /// <summary>
    /// Checks if the AABB completely contains the given circle.
    /// </summary>
    /// <param name="circle">The circle to check.</param>
    /// <returns>True if the AABB completely contains the given circle, else false.</returns>
    public static bool ContainsCircle(Vector2f min, Vector2f max, Vector2f center, float radius)
    {
      return
        min.X <= (center.X - radius) &&
        min.Y <= (center.Y - radius) &&
        max.X >= (center.X + radius) &&
        max.Y >= (center.Y + radius);
    }

    /// <summary>
    /// Checks if the given rectangle defined by [min1,max1] completly contains the rectangle defined by [min2,max2].
    /// Also returns true if the AABBs are equal.
    /// </summary>
    /// <param name="min1">The minimum point of the first rectangle.</param>
    /// <param name="max1">The maximum point of the first rectangle.</param>
    /// <param name="min2">The minimum point of the second rectangle.</param>
    /// <param name="max2">The maximum point of the second rectangle.</param>
    /// <returns>True if the given AABB is completly inside of the AABB, else false.</returns>
    public static bool ContainsAABB(Vector2f min1, Vector2f max1, Vector2f min2, Vector2f max2)
    {
      return min1.X <= min2.X && min1.Y <= min2.Y && max1.X >= max2.X && max1.Y >= max2.Y;
    }

  }
}
