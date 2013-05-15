using System;
using System.Collections.Generic;
using OkuBase.Geometry.Intersection;

namespace OkuBase.Geometry.Shapes
{
  /// <summary>
  /// Defines an axis alligned box by its min and max vectors.
  /// </summary>
  public struct Rectangle2f
  {
    /// <summary>
    /// The min vector.
    /// </summary>
    public Vector2f Min;
    /// <summary>
    /// The max vector.
    /// </summary>
    public Vector2f Max;

    /// <summary>
    /// Create a new quad with the given vectors.
    /// </summary>
    /// <param name="min">The min vector.</param>
    /// <param name="max">The max vector.</param>
    public Rectangle2f(Vector2f min, Vector2f max)
    {
      Min = min;
      Max = max;
    }

    /// <summary>
    /// Creates a new quad with the given values.
    /// </summary>
    /// <param name="left">The left border of the quad.</param>
    /// <param name="right">The right border of the quad.</param>
    /// <param name="top">The top border of the quad.</param>
    /// <param name="bottom">The bottom border of the quad.</param>
    public Rectangle2f(float left, float bottom, float width, float height)
    {
      Min = new Vector2f(left, bottom);
      Max = new Vector2f(left + width, bottom + height);
    }

    /// <summary>
    /// Calculates the center of the quad.
    /// </summary>
    /// <returns>The center point of the quad.</returns>
    public Vector2f GetCenter()
    {
      return (Min + Max) * 0.5f;
    }

    /// <summary>
    /// Gets the width of the quad.
    /// </summary>
    public float Width
    {
      get { return Max.X - Min.X; }
    }

    /// <summary>
    /// Gets the height of the quad.
    /// </summary>
    public float Height
    {
      get { return Max.Y - Min.Y; }
    }

    /// <summary>
    /// Gets the four corner points of the AABB as a vector array.
    /// </summary>
    /// <returns>The four corner points in an array.</returns>
    public Vector2f[] GetPoints()
    {
      return GetPoints(Min, Max);
    }

    /// <summary>
    /// Returns the corner points of the bounding box in the given array
    /// which must have a length >= 4. Only the first four entries (0-3) are filled.
    /// </summary>
    /// <param name="points">The array to put in the points.</param>
    public void GetPoints(Vector2f[] points)
    {
      points[0] = Min;
      points[1] = new Vector2f(Min.X, Max.Y);
      points[2] = Max;
      points[3] = new Vector2f(Max.X, Min.Y);
    }

    /// <summary>
    /// Checks if the given point is inside of the AABB.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public bool IsInside(Vector2f point)
    {
      return Intersections.PointInAABB(point, Min, Max);
    }

    /// <summary>
    /// Calculates a bounding box that contains
    /// both this and the given AABB.
    /// </summary>
    /// <param name="other">The bounding box to add.</param>
    /// <returns>A new AABB that contains this and the given AABB.</returns>
    public Rectangle2f Add(Rectangle2f other)
    {
      float minX = Math.Min(Min.X, other.Min.X);
      float minY = Math.Min(Min.Y, other.Min.Y);
      float maxX = Math.Max(Max.X, other.Max.X);
      float maxY = Math.Max(Max.Y, other.Max.Y);

      return new Rectangle2f(new Vector2f(minX, minY), new Vector2f(maxX, maxY));
    }
    
    /// <summary>
    /// Checks if the given AABB is completly inside the AABB.
    /// Also returns true if the AABBs are equal.
    /// </summary>
    /// <param name="other">The AABB to check.</param>
    /// <returns>True f the given AABB is completly inside of the AABB, else false.</returns>
    public bool Contains(Rectangle2f other)
    {
      return Min.X <= other.Min.X && Min.Y <= other.Min.Y && Max.X >= other.Max.X && Max.Y >= other.Max.Y;
    }

    /// <summary>
    /// Checks if the AABB completely contains the given circle.
    /// </summary>
    /// <param name="circle">The circle to check.</param>
    /// <returns>True if the AABB completely contains the given circle, else false.</returns>
    public bool Contains(Circle circle)
    {
      return
        Min.X <= (circle.Center.X - circle.Radius) &&
        Min.Y <= (circle.Center.Y - circle.Radius) &&
        Max.X >= (circle.Center.X + circle.Radius) &&
        Max.Y >= (circle.Center.Y + circle.Radius);
    }
    
    /// <summary>
    /// Check if the AABB intersects with the given AABB.
    /// </summary>
    /// <param name="other">The AABB to check intersection with.</param>
    /// <returns>True if the AABBs intersect, else false.</returns>
    public bool Intersects(Rectangle2f other)
    {
      return Intersections.AABBs(this, other);
    }

    //public bool Intersects(

    /// <summary>
    /// Calculates the point on the perimeter of the aabb theat is closest to the given point.
    /// </summary>
    /// <param name="p">The point.</param>
    /// <returns>The point on the perimeter that is closest to p.</returns>
    public Vector2f GetClosestPoint(Vector2f p)
    {
      Vector2f result = Vector2f.Zero;
      if (IsInside(p))
      {
        Vector2f center = GetCenter();

        float borderX, borderY;
        if (p.X >= center.X)
          borderX = Max.X;
        else
          borderX = Min.X;

        if (p.Y >= center.Y)
          borderY = Max.Y;
        else
          borderY = Min.Y;

        float dx = Math.Abs(p.X - borderX);
        float dy = Math.Abs(p.Y - borderY);
        if (dx < dy)
          return new Vector2f(borderX, p.Y);
        else
          return new Vector2f(p.X, borderY);
      }
      else
      {
        result = p;
        if (result.X > Max.X)
          result.X = Max.X;
        if (result.X < Min.X)
          result.X = Min.X;
        if (result.Y > Max.Y)
          result.Y = Max.Y;
        if (result.Y < Min.Y)
          result.Y = Min.Y;
      }
      return result;
    }

    /// <summary>
    /// Splits the AABB into the given amount of vertical and horizontal cells.
    /// </summary>
    /// <param name="vertical">The number of vertical cells.</param>
    /// <param name="horizontal">The number of horizontal cells.</param>
    /// <returns>An array containing the split AABBs in the order from left-bottom to right top.</returns>
    public Rectangle2f[] Split(int vertical, int horizontal)
    {
      Rectangle2f[] result = new Rectangle2f[vertical * horizontal];
      float xStep = Width / vertical;
      float yStep = Height / horizontal;
      for (int y = 0; y < horizontal - 1; y++)
      {
        for (int x = 0; x < vertical - 1; x++)
        {
          float left = Min.X + (x * xStep);
          float bottom = Min.Y + (y * yStep);

          result[(y * vertical) + x] = new Rectangle2f(new Vector2f(left, bottom), new Vector2f(left + xStep, left + yStep));
        }
      }
      return result;
    }

    /// <summary>
    /// Gets the four corner points of the AABB as a vector array.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>The four corner points in an array.</returns>
    public static Vector2f[] GetPoints(Vector2f min, Vector2f max)
    {
      return new Vector2f[] { min, new Vector2f(min.X, max.Y), max, new Vector2f(max.X, min.Y) };
    }

    /// <summary>
    /// Converts the AABB to string in the format "minX,minY;maxX,maxY".
    /// </summary>
    /// <returns>The AABB as a string in the format "minX,minY;maxX,maxY".</returns>
    public override string ToString()
    {
      return Min.ToString() + ";" + Max.ToString();
    }

  }
}
