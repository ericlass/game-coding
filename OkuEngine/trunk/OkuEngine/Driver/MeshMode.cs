using System;

namespace OkuEngine
{
  public enum MeshMode
  {
    /// <summary>
    /// Every group of three vertices are treated as one triangle. 
    /// So a vertex list with 6 vertices will result in two seperate triangles.
    /// </summary>
    Triangles,
    /// <summary>
    /// The first three vertices are treated as the first traingle. 
    /// From there on, the next vertex an the two last vertices of the previous
    /// triangle are used to form the next triangle.
    /// </summary>
    TriangleStrip,
    /// <summary>
    /// The first vertex is treated as the center of a fan. The following groups 
    /// of two vertices are now connected to the first one to form a triangle.
    /// </summary>
    TriangleFan,
    /// <summary>
    /// Every group of four vertices is treated as a seperate quad. So a 
    /// vertex list with 8 vertices will result in two quads.
    /// </summary>
    Quads,
    /// <summary>
    /// The first two vertices form the first quad. From there on, each 
    /// following group of two vertices is combined with the previous group
    /// of two to form the next quad.
    /// </summary>
    QuadStrip,
    /// <summary>
    /// Additionally to the vertices, a seperate index array must given. It 
    /// contains indexes of vertices in the vertex list that form a triangle.
    /// Each group of three indices form a seperated triangle. This way multiple
    /// triangles can share vertices at the same position.
    /// </summary>
    Indexed
  }

}