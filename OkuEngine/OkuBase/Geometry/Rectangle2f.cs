using System;
using System.Collections.Generic;
using OkuBase.Geometry;
using OkuMath;

namespace OkuBase.Geometry
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

    public Vector2f GetCenter()
    {
      return (Min + Max) * 0.5f;
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
