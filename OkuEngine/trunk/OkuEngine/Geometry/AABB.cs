﻿using System;
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
    /// Checks if the given point is inside of the AABB.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <returns>True if the point is inside the AABB, else false.</returns>
    public bool IsInside(Vector point)
    {
      return Intersections.PointInAABB(point, Min, Max);
    }

    /// <summary>
    /// Calculates a bounding box that contains
    /// both this and the given AABB.
    /// </summary>
    /// <param name="other">The bounding box to add.</param>
    /// <returns>A new AABB that contains this and the given AABB.</returns>
    public AABB Add(AABB other)
    {
      float minX = Math.Min(Min.X, other.Min.X);
      float minY = Math.Min(Min.Y, other.Min.Y);
      float maxX = Math.Max(Max.X, other.Max.X);
      float maxY = Math.Max(Max.Y, other.Max.Y);

      return new AABB(new Vector(minX, minY), new Vector(maxX, maxY));
    }
    
    /// <summary>
    /// Checks if the given AABB is completly inside the AABB.
    /// Also returns true if the AABBs are equal.
    /// </summary>
    /// <param name="other">The AABB to check.</param>
    /// <returns>True f the given AABB is completly inside of the AABB, else false.</returns>
    public bool Contains(AABB other)
    {
      return Min.X <= other.Min.X && Min.Y <= other.Min.Y && Max.X >= other.Max.X && Max.Y >= other.Max.Y;
    }
    
    /// <summary>
    /// Check if the AABB intersects with the given AABB.
    /// </summary>
    /// <param name="other">The AABB to check intersection with.</param>
    /// <returns>True if the AABBs intersect, else false.</returns>
    public bool Intersects(AABB other)
    {
      return Intersections.AABBs(this, other);
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
