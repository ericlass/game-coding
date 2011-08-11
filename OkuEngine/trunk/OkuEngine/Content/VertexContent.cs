using System;

namespace OkuEngine
{
  public class VertexContent : VisualContent
  {
    private Vector[] _positions = null;
    private Vector[] _texCoords = null;
    private Color[] _colors = null;

    public VertexContent()
    {
    }

    public VertexContent(Vector[] positions)
    {
      _positions = positions;
    }

    public VertexContent(Vector[] positions, Vector[] texCoords)
    {
      _positions = positions;
      _texCoords = texCoords;
    }

    public VertexContent(Vector[] positions, Color[] colors)
    {
      _positions = positions;
      _colors = colors;
    }

    public VertexContent(Vector[] positions, Vector[] texCoords, Color[] colors)
    {
      _positions = positions;
      _texCoords = texCoords;
      _colors = colors;
    }

    public Vector[] Positions
    {
      get { return _positions; }
      set { _positions = value; }
    }

    public Vector[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    public Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

  }
}
