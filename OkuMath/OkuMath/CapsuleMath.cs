using System;

namespace OkuMath
{
  /// <summary>
  /// Defines math funtions for capsules. A capsule is defined by a central
  ///  line segment and a radius and is a swept circle.
  /// </summary>
  public static class CapsuleMath
  {
    /// <summary>
    /// Checks the given point p is inside the area of the capsule defined by [a,b] and radius.
    /// </summary>
    /// <param name="a">The start of the capsules line segment.</param>
    /// <param name="b">The end of the capsules line segment.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="p">The point to be checked.</param>
    /// <returns>True if the point is inside the capsule, else false.</returns>
    public static bool PointIsInside(Vector2f a, Vector2f b, float radius, Vector2f p)
    {
      float rs = radius * radius;
      return LineMath.SquaredDistanceToPoint(a, b, p) <= rs;
    }

  }
}
