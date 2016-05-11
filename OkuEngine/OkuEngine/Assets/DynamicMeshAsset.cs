using System;
using OkuMath;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public class DynamicMeshAsset : MeshAsset
  {
    public DynamicMeshAsset() : base()
    {
    }

    public DynamicMeshAsset(Vector2f[] positions, Vector2f[] texCoords, Color[] colors, PrimitiveType primitiveType) : base(positions, texCoords, colors, primitiveType)
    {
    }

    public override bool IsStatic
    {
      get { return false; }
    }

    public new Vector2f[] Positions
    {
      get { return _positions; }
      set { _positions = value; }
    }

    public new Vector2f[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    public new Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

    public new PrimitiveType PrimitiveType
    {
      get { return _primitiveType; }
      set { _primitiveType = value; }
    }

  }
}
