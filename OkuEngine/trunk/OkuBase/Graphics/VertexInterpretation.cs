using System;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines how vertices should be interpreted.
  /// </summary>
  public enum VertexInterpretation {
    /// <summary>
    /// Draws a polygon ffrom the vertices where the first and the last vertex are not connected.
    /// </summary>
    Polygon,
    /// <summary>
    /// Draws a polygon from the vertices where the first and the last vertex are connected too.
    /// </summary>
    PolygonClosed,
    /// <summary>
    /// Draws a line segment for each pair of vertices.
    /// </summary>
    LineSegments
  }

}