using System;

namespace OkuEngine
{
  /// <summary>
  /// A simple line segment starting at (X1, Y1) and ending at (X2, Y2).
  /// </summary>
  public struct LineSegment
  {
    /// <summary>
    /// The x component of the start point.
    /// </summary>
    public float X1;
    /// <summary>
    /// The y component of the start point.
    /// </summary>
    public float Y1;
    /// <summary>
    /// The x component of the end point.
    /// </summary>
    public float X2;
    /// <summary>
    /// The y component of the end point.
    /// </summary>
    public float Y2;

    /// <summary>
    /// Creates a new line segment and initializes it's fields to the given values.
    /// </summary>
    /// <param name="x1">The x component of the start point.</param>
    /// <param name="y1">The y component of the start point.</param>
    /// <param name="x2">The x component of the end point.</param>
    /// <param name="y2">The y component of the end point.</param>
    public LineSegment(float x1, float y1, float x2, float y2)
    {
      X1 = x1;
      Y1 = y1;
      X2 = x2;
      Y2 = y2;
    }

    /// <summary>
    /// Calculates the length of the line segment.
    /// </summary>
    /// <returns>The length of the line segment.</returns>
    public float Length()
    {
      float a = X1 - X2;
      float b = Y1 - Y2;
      return (float)Math.Sqrt(a * a + b * b);
    }

    /// <summary>
    /// Calculates the left hand normal of the line segment.
    /// </summary>
    /// <returns>The normalized normal of the line segment.</returns>
    public Vector Normal()
    {
      float x = X1 - X2;
      float y = Y1 - Y2;
      Vector result = new Vector(y, -x);
      result.Normalize();
      return result;
    }

    /// <summary>
    /// Uses the line segment formula "p' = p1 + factor * (p2 - p1)" to calculate a point 
    /// on the line segment. The value is expected to be >= 0.0 and &lt;= 1.0.
    /// </summary>
    /// <param name="factor">The factor between the start and the end point. 0 means the start point, 1 means the end point.</param>
    /// <returns>The interpolated point on the line segment.</returns>
    public Vector GetPointAt(float factor)
    {
      return new Vector(X1 + factor * (X2 - X1), Y1 + factor * (Y2 - Y1));
    }

  }
}