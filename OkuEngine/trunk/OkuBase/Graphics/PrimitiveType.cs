using System;

namespace OkuBase.Graphics
{
  /// <summary>
  /// Defines the draw mode for raw vertex data.
  /// </summary>
  public enum PrimitiveType {
    /// <summary>
    /// Do not draw anything.
    /// </summary>
    None,
    /// <summary>
    /// Draw a point at each vertex.
    /// </summary>
    Points,
    /// <summary>
    /// Draw one line for each pair of vertices.
    /// </summary>
    Lines,
    /// <summary>
    /// Draw a polygon starting at the first vertex and ending at the last.
    /// </summary>
    Polygon,
    /// <summary>
    /// Draw a polygon starting at the first vertex the the last one and also draw a line from the last to the first.
    /// </summary>
    ClosedPolygon,
    /// <summary>
    /// Draw a single triangle for each triplet of vertices.
    /// </summary>
    Triangles,
    /// <summary>
    /// Draws a triangle strip.
    /// </summary>
    TriangleStrip,
    /// <summary>
    /// Draws a triangle fan.
    /// </summary>
    TriangleFan,
    /// <summary>
    /// Draws a quad for each quarttet of vertices.
    /// </summary>
    Quads,
    /// <summary>
    /// Draw a quad strip.
    /// </summary>
    QuadStrip
  }

}