using System;
using System.IO;
using System.Xml;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace OkuBase.Geometry
{
  /// <summary>
  /// Contains different data about a set of vertices.
  /// The vertices are expressed by three separate array,
  /// one for each the vertex positions, texture coordinates and colors.
  /// The texture coordinates and colors may be set to null if not needed.
  /// The arrays are expected, but not forced, to be the same length.
  /// Use the Valid property to check if all non-null arrays have the same length. 
  /// </summary>
  public class Vertices
  {
    private Vector2f[] _positions = null;
    private Vector2f[] _texCoords = null;
    private Color[] _colors = null;

    /// <summary>
    /// Creates a new vertex content with no data.
    /// </summary>
    public Vertices()
    {
    }

    /// <summary>
    /// Creates a new vertex content with the given positions.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    public Vertices(Vector2f[] positions)
    {
      _positions = positions;
    }

    /// <summary>
    /// Creates a new vertex content with the given positions and texture coordinates.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    /// <param name="texCoords">The vertex texture coordinates.</param>
    public Vertices(Vector2f[] positions, Vector2f[] texCoords)
    {
      _positions = positions;
      _texCoords = texCoords;
    }

    /// <summary>
    /// Creates a new vertex content with the given positions and color.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    /// <param name="colors">The vertex colors.</param>
    public Vertices(Vector2f[] positions, Color[] colors)
    {
      _positions = positions;
      _colors = colors;
    }

    /// <summary>
    /// Creates a new vertex content with the given positions, texture coordinates and colors.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    /// <param name="texCoords">The vertex texture coordinates.</param>
    /// <param name="colors">The vertex colors.</param>
    public Vertices(Vector2f[] positions, Vector2f[] texCoords, Color[] colors)
    {
      _positions = positions;
      _texCoords = texCoords;
      _colors = colors;
    }

    /// <summary>
    /// Gets or set the array of positions of the vertices.
    /// </summary>
    public Vector2f[] Positions
    {
      get { return _positions; }
      set { _positions = value; }
    }

    /// <summary>
    /// Gets or set the array of texture coordinates of the vertices.
    /// Can be set to null if not needed.
    /// </summary>
    public Vector2f[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    /// <summary>
    /// Gets or set the array of colors of the vertices.
    /// Can be set to null if not needed.
    /// </summary>
    public Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

    /// <summary>
    /// Gets the number of vertices.
    /// </summary>
    public int Count
    {
      get { return _positions.Length; }
    }

    /// <summary>
    /// Gets if the vertex content is valid.
    /// It is valid if the Positions array is not null and
    /// all non-null arrays have the same length.
    /// </summary>
    public bool Valid
    {
      get
      {
        int posLength = _positions == null ? 0 : _positions.Length;
        int texLength = _texCoords == null ? 0 : _texCoords.Length;
        int colLength = _colors == null ? 0 : _colors.Length;
        return (_positions != null) && (posLength == texLength) && (texLength == colLength);
      }
    }

  }
}
