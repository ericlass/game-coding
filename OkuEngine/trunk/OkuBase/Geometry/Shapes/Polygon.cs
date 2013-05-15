using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuBase.Utils;

namespace OkuBase.Geometry.Shapes
{
  /// <summary>
  /// Defines a static 2D polygon as a series of vertices.
  /// </summary>
  public class Polygon
  {
    private Vector2f[] _vertices = null;

    /// <summary>
    /// Create a new polygon.
    /// </summary>
    public Polygon()
    {
    }

    /// <summary>
    /// Gets the vertices of the polygon.
    /// If you change any of the vertices you must call 
    /// the Invalidate() method to make sure cached data is refreshed.
    /// </summary>
    public Vector2f[] Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    /// <summary>
    /// Searches for the vertex that is closest to the given point.
    /// </summary>
    /// <param name="point">The point to find the nearest vertex for.</param>
    /// <param name="distance">The distance to the nearest vertex is returned here.</param>
    /// <returns>The index of the nearest vertex.</returns>
    public int GetNearestVertex(Vector2f point, out float distance)
    {
      return _vertices.ClosestPoint(point, out distance);
    }

    /// <summary>
    /// Checks if the polygon is clockwise or counter-clockwise.
    /// </summary>
    /// <returns>True if the polygon is clockwise, else false.</returns>
    public bool IsClockwise()
    {
      float total = 0.0f;
      for (int i = 0; i < _vertices.Length; i++)
      {
        int j = (i + 1) % _vertices.Length;
        total += (_vertices[j].X - _vertices[i].X) * (_vertices[j].Y + _vertices[i].Y);
      }
      return total >= 0.0f;
    }

    public override string ToString()
    {
      return _vertices == null ? "" : _vertices.ToOkuString();
    }

  }
}
