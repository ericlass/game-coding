using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a custom vertex with position, texture coordinates and color.
  /// </summary>
  public class Vertex
  {
    private Vector _position = null;
    private Vector _texCoord = null;
    private Color _color = Color.White;

    /// <summary>
    /// Creates a new vertex.
    /// </summary>
    public Vertex()
    {
      _position = new Vector();
      _texCoord = new Vector();
    }

    /// <summary>
    /// Creates a new vertex with the given position.
    /// </summary>
    /// <param name="position">The position.</param>
    public Vertex(Vector position)
    {
      _position = position;
      _texCoord = new Vector();
    }

    /// <summary>
    /// Creates a new vertex with the given position and texture coordinates.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="texCoord">The texture coordinates.</param>
    public Vertex(Vector position, Vector texCoord)
    {
      _position = position;
      _texCoord = texCoord;
    }

    /// <summary>
    /// Creates a new vertex with the given position, texture coordinates and color.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="texCoord">The texture coordinates.</param>
    /// <param name="color">The color of the vertex.</param>
    public Vertex(Vector position, Vector texCoord, Color color)
    {
      _position = position;
      _texCoord = texCoord;
      _color = color;
    }

    /// <summary>
    /// Creates a new vertex with the given position and color.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="color">The color of the vertex.</param>
    public Vertex(Vector position, Color color)
    {
      _position = position;
      _texCoord = new Vector();
      _color = color;
    }

    /// <summary>
    /// Gets or sets the position of the vertex in 2D space.
    /// </summary>
    public Vector Position
    {
      get { return _position; }
      set { _position = value; }
    }

    /// <summary>
    /// Gets or sets the texture coordinates of the vertex.
    /// </summary>
    public Vector TextureCoordinates
    {
      get { return _texCoord; }
      set { _texCoord = value; }
    }

    /// <summary>
    /// Gets or sets the color of the vertex. This can be used to color lines and points or to tint texture mapped meshes.
    /// </summary>
    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

  }
}
