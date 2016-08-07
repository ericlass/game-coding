using System;
using OkuMath;
using OkuBase.Graphics;

namespace OkuEngine
{
  public class Mesh
  {
    protected Vector2f[] _positions = null;
    protected Vector2f[] _texCoords = null;
    protected Color[] _colors = null;
    protected PrimitiveType _primitiveType = PrimitiveType.None;

    public Mesh()
    {
    }

    public Mesh(Vector2f[] positions, Vector2f[] texCoords, Color[] colors, PrimitiveType primitiveType)
    {
      _positions = positions;
      _texCoords = texCoords;
      _colors = colors;
      _primitiveType = primitiveType;
    }

    public Vector2f[] Positions
    {
      get { return _positions; }
    }

    public Vector2f[] TexCoords
    {
      get { return _texCoords; }
    }

    public Color[] Colors
    {
      get { return _colors; }
    }

    public PrimitiveType PrimitiveType
    {
      get { return _primitiveType; }
    }

  }
}
