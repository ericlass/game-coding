using System;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public class MaterialAsset
  {
    private AssetHandle _texture = null;
    private Color _tint = Color.White;

    public MaterialAsset()
    {
    }

    public MaterialAsset(AssetHandle texture, Color tint)
    {
      _texture = texture;
      _tint = tint;
    }

    public AssetHandle Texture
    {
      get { return _texture; }
      set { _texture = value; }
    }

    public Color Tint
    {
      get { return _tint; }
      set { _tint = value; }
    }

  }
}
