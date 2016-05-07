using System;
using OkuMath;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public abstract class MeshAsset
  {
    protected Vector2f[] _positions = null;
    protected Vector2f[] _texCoords = null;
    protected Color[] _colors = null;
    protected PrimitiveType _primitiveType = PrimitiveType.None;

    public MeshAsset()
    {
    }

    public MeshAsset(Vector2f[] positions, Vector2f[] texCoords, Color[] colors, PrimitiveType primitiveType)
    {
      _positions = positions;
      _texCoords = texCoords;
      _colors = colors;
      _primitiveType = primitiveType;
    }

    public abstract bool IsStatic { get; }

  }
}
