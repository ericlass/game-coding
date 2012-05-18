using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines an axis alligned box by its min and max vectors.
  /// </summary>
  public struct AABB
  {
    /// <summary>
    /// The min vector.
    /// </summary>
    public Vector Min;
    /// <summary>
    /// The max vector.
    /// </summary>
    public Vector Max;

    /// <summary>
    /// Create a new quad with the given vectors.
    /// </summary>
    /// <param name="min">The min vector.</param>
    /// <param name="max">The max vector.</param>
    public AABB(Vector min, Vector max)
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
    public AABB(float left, float bottom, float width, float height)
    {
      Min = new Vector(left, bottom);
      Max = new Vector(left + width, bottom + height);
    }

    /// <summary>
    /// Calculates the center of the quad.
    /// </summary>
    /// <returns>The center point of the quad.</returns>
    public Vector GetCenter()
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
    public Vector[] GetPoints()
    {
      return GetPoints(Min, Max);
    }

    /// <summary>
    /// Gets the four corner points of the AABB as a vector array.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <returns>The four corner points in an array.</returns>
    public static Vector[] GetPoints(Vector min, Vector max)
    {
      return new Vector[] { min, new Vector(min.X, max.Y), max, new Vector(max.X, min.Y) };
    }

  }
}
