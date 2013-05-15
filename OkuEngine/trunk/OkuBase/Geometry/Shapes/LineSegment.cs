using System;
using OkuBase.Utils;

namespace OkuBase.Geometry.Shapes
{
  /// <summary>
  /// A simple line segment starting at (X1, Y1) and ending at (X2, Y2).
  /// </summary>
  public class LineSegment
  {
    private Vector2f _start = Vector2f.Zero;
    private Vector2f _end = Vector2f.Zero;

    /// <summary>
    /// Creates a new line segment and initializes it's fields to the given values.
    /// </summary>
    /// <param name="x1">The x component of the start point.</param>
    /// <param name="y1">The y component of the start point.</param>
    /// <param name="x2">The x component of the end point.</param>
    /// <param name="y2">The y component of the end point.</param>
    public LineSegment(float x1, float y1, float x2, float y2)
    {
      _start = new Vector2f(x1, y1);
      _end = new Vector2f(x2, y2);
    }

    /// <summary>
    /// Creates a new line segment and initializes it's fields to the given values.
    /// </summary>
    /// <param name="p1">The start point of the line segment.</param>
    /// <param name="p2">The end point of the line segment.</param>
    public LineSegment(Vector2f p1, Vector2f p2)
    {
      _start = p1;
      _end = p2;
    }

    /// <summary>
    /// Gets or sets the start point of the line segment.
    /// </summary>
    public Vector2f Start
    {
      get { return _start; }
      set { _start = value; }
    }

    /// <summary>
    /// Gets or sets the end point of the line segment.
    /// </summary>
    public Vector2f End
    {
      get { return _end; }
      set { _end = value; }
    }

    /// <summary>
    /// Calculates the length of the line segment.
    /// </summary>
    /// <returns>The length of the line segment.</returns>
    public float Length()
    {
      float a = _end.X - _start.X;
      float b = _end.Y - _start.Y;
      return (float)Math.Sqrt(a * a + b * b);
    }

    /// <summary>
    /// Calculates the left hand normal of the line segment.
    /// </summary>
    /// <returns>The normalized normal of the line segment.</returns>
    public Vector2f Normal()
    {
      Vector2f result = new Vector2f(_end.Y - _start.Y, -(_end.X - _start.X));
      result.Normalize();
      return result;
    }

    /// <summary>
    /// Uses the line segment formula "p' = p1 + factor * (p2 - p1)" to calculate a point 
    /// on the line segment. The value is expected to be >= 0.0 and &lt;= 1.0.
    /// </summary>
    /// <param name="factor">The factor between the start and the end point. 0 means the start point, 1 means the end point.</param>
    /// <returns>The interpolated point on the line segment.</returns>
    public Vector2f GetPointAt(float factor)
    {
      return OkuMath.InterpolateLinear(_start, _end, factor);
    }

  }
}