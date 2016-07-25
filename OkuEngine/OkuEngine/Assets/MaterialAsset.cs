using System;
using OkuBase.Graphics;

namespace OkuEngine.Assets
{
  public class MaterialAsset : Asset
  {
    private int _texture = 0;
    private Color _tint = Color.White;

    public MaterialAsset()
    {
    }

    public MaterialAsset(int texture, Color tint)
    {
      _texture = texture;
      _tint = tint;
    }

    public int Texture
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
