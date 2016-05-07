using System;

namespace OkuEngine.Assets
{
  public class AssetHandle
  {
    private int _id = 0;
    private AssetType _assetType = AssetType.Undefined;
    private bool _isValid = true;

    internal AssetHandle(int id, AssetType assetType)
    {
      _id = id;
      _assetType = assetType;
    }

    public int ID
    {
      get { return _id; }
    }

    public AssetType AssetType
    {
      get { return _assetType; }
    }

    public bool IsValid
    {
      get { return _isValid; }
    }

    internal void Invalidate()
    {
      _isValid = false;
    }

  }
}
