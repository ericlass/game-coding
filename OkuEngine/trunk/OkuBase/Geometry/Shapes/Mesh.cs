using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Graphics;

namespace OkuBase.Geometry.Shapes
{
  /// <summary>
  /// Defines a mesh with vertices and an optional texture.
  /// </summary>
  public class Mesh
  {
    private Vertices _vertices = null;
    private Image _texture = null;
    private PrimitiveType _primitiveType = PrimitiveType.ClosedPolygon;

    /// <summary>
    /// Creates a new mesh with no data.
    /// </summary>
    public Mesh()
    {
    }

    /// <summary>
    /// Creates a new image with the given data.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="texture">The texture to use for the mesh (can be null).</param>
    /// <param name="type">The type of primitives to form from the vertices.</param>
    public Mesh(Vertices vertices, Image texture, PrimitiveType type)
    {
      _vertices = vertices;
      _texture = texture;
      _primitiveType = type;
    }

    /// <summary>
    /// Gets or sets the vertices of the mesh.
    /// </summary>
    public Vertices Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    /// <summary>
    /// Gets or sets the texture of the mesh.
    /// </summary>
    public Image Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    /// <summary>
    /// Gets or sets the type of primitive that the vertices form for drawing.
    /// </summary>
    public PrimitiveType PrimitiveType
    {
      get { return _primitiveType; }
      set { _primitiveType = value; }
    }

  }
}
