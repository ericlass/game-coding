using System;
using OkuMath;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public class StaticMeshAsset : MeshAsset
  {
    public StaticMeshAsset() : base()
    {
    }

    public StaticMeshAsset(Vector2f[] positions, Vector2f[] texCoords, Color[] colors, PrimitiveType primitiveType) : base(positions, texCoords, colors, primitiveType)
    {
    }

    public override bool IsStatic
    {
      get { return true; }
    }

  }
}
