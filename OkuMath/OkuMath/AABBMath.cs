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

  }
}
