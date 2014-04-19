using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Geometry
{
  /// <summary>
  /// Defines a vertex buffer which can be used to draw static
  /// meshes with maximum performance. The vertices will be stored
  /// in graphics card memory (most likely).
  /// </summary>
  public class VertexBuffer
  {
    private int _id = KeySequence.NextValue(KeySequence.BufferSequence);
    private Vertex[] _vertices = null;

    /// <summary>
    /// Creates a new, empty vertex buffer.
    /// </summary>
    public VertexBuffer()
    {
    }

    /// <summary>
    /// Creates a new verex buffer with the given vertices.
    /// </summary>
    /// <param name="vertices">The vertices of the vertex buffer.</param>
    public VertexBuffer(Vertex[] vertices)
    {
      _vertices = vertices;
    }

    /// <summary>
    /// Gets the id of the vertex buffer.
    /// </summary>
    public int Id
    {
      get { return _id; }
    }

    /// <summary>
    /// Gets or sets the vertices assigned to the vertex buffer.
    /// </summary>
    public Vertex[] Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

  }
}
