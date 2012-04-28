using System;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Contains different data about a set of vertices.
  /// The vertices are expressed by three separate array,
  /// one for each the vertex positions, texture coordinates and colors.
  /// The texture coordinates and colors may be set to null if not needed.
  /// The arrays are expected, but not forced, to be the same length.
  /// Use the Valid property to check if all non-null arrays have the same length. 
  /// </summary>
  public class VertexContent : VisualContent
  {
    private Vector[] _positions = null;
    private Vector[] _texCoords = null;
    private Color[] _colors = null;

    /// <summary>
    /// Creates a new vertex content with no data.
    /// </summary>
    public VertexContent()
    {
    }

    /// <summary>
    /// Creates a new vertex content with the given positions.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    public VertexContent(Vector[] positions)
    {
      _positions = positions;
    }

    /// <summary>
    /// Creates a new vertex content with the given positions and texture coordinates.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    /// <param name="texCoords">The vertex texture coordinates.</param>
    public VertexContent(Vector[] positions, Vector[] texCoords)
    {
      _positions = positions;
      _texCoords = texCoords;
    }

    /// <summary>
    /// Creates a new vertex content with the given positions and color.
    /// </summary>
    /// <param name="positions">The vertex positions.</param>
    /// <param name="colors">The vertex colors.</param>
    public VertexContent(Vector[] positions, Color[] colors)
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
    public VertexContent(Vector[] positions, Vector[] texCoords, Color[] colors)
    {
      _positions = positions;
      _texCoords = texCoords;
      _colors = colors;
    }

    /// <summary>
    /// Gets or set the array of positions of the vertices.
    /// </summary>
    public Vector[] Positions
    {
      get { return _positions; }
      set { _positions = value; }
    }

    /// <summary>
    /// Gets or set the array of texture coordinates of the vertices.
    /// Can be set to null if not needed.
    /// </summary>
    public Vector[] TexCoords
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

    /// <summary>
    /// Loads a vertex data from a file.
    /// </summary>
    /// <param name="filename">The name and path of the file.</param>
    public void Load(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.Open);
      try
      {
        Load(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    /// Loads a vertex data from a stream.
    /// </summary>
    /// <param name="stream">The stream to load the vertex data from.</param>
    public void Load(Stream stream)
    {
      _positions = null;
      _colors = null;
      _texCoords = null;

      StreamReader reader = new StreamReader(stream);
      string line = reader.ReadLine();
      while (line != null)
      {
        line = line.Trim().ToLower();
        string[] keyValue = line.Split('=');

        if (keyValue.Length == 2)
        {
          string key = keyValue[0].Trim();
          string value = keyValue[1].Trim();

          if (key == "pos")
            _positions = Converter.ParseVectors(value);
          else if (key == "col")
            _colors = Converter.ParseColors(value);
          else if (key == "tex")
            _texCoords = Converter.ParseVectors(value);
        }

        line = reader.ReadLine();
      }
    }

    /// <summary>
    /// Saves the vertex data to the given file.
    /// </summary>
    /// <param name="filename">The name and path of the file.</param>
    public void Save(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
      try
      {
        Save(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    /// Saves the vertex data to the given stream.
    /// </summary>
    /// <param name="stream">The stream to save to.</param>
    public void Save(Stream stream)
    {
      StreamWriter writer = new StreamWriter(stream);

      if (_positions != null)
        writer.WriteLine("pos=" + _positions.ToOkuString());
      if (_colors != null)
        writer.WriteLine("col=" + _colors.ToOkuString());
      if (_texCoords != null)
        writer.WriteLine("tex=" + _texCoords.ToOkuString());

      writer.Flush();
    }

  }
}
