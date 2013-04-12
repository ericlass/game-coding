using System;

namespace OkuEngine
{
  /// <summary>
  /// Defines a circle with a center and a radius.
  /// </summary>
  public struct Circle
  {
    public Vector2f Center;
    public float Radius;

    /// <summary>
    /// Creates a new circle with the given center and radius.
    /// </summary>
    /// <param name="center">The center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(Vector2f center, float radius)
    {
      Center = center;
      Radius = radius;
    }

    /// <summary>
    /// Gets a number of points on the circle.
    /// They can be used to draw the circle as a polygon.
    /// </summary>
    /// <param name="points">The number of points.</param>
    /// <returns>The points of the circle.</returns>
    public Vector2f[] GetPoints(int points)
    {
      return PolygonFactory.Circle(Center.X, Center.Y, Radius, points);
    }

    /// <summary>
    /// Calculates a bounding circle for the given AABB.
    /// </summary>
    /// <param name="aabb">The AABB.</param>
    /// <returns>The calculated bounding circle.</returns>
    public static Circle FromAABB(Rectangle2f aabb)
    {
      Vector2f center = aabb.GetCenter();
      return new Circle(center, Vector2f.Distance(center, aabb.Max));
    }

  }
}