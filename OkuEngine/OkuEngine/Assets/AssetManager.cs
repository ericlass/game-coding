using System;
using System.Collections.Generic;

namespace OkuEngine.Assets
{
  public class AssetManager
  {
    private List<object> _assets = new List<object>();

    public AssetManager()
    {
      _assets.Add(null); //Index 0 always means null
    }

    public int AddAsset(Asset asset)
    {
      _assets.Add(asset);
      return _assets.Count - 1;
    }

    public object GetAsset(int handle)
    {
      if (handle < 0 || handle >= _assets.Count)
        return null;
      else
        return _assets[handle];
    }

    public T GetAsset<T>(int handle) where T : class
    {
      return GetAsset(handle) as T;
    }

    public void RemoveAsset(int handle)
    {
      if (handle >= 0 && handle < _assets.Count)
      {
        object asset = _assets[handle];
        //TODO: Free resource from renderer, sound or whatever
        _assets[handle] = null;
      }
    }

    public void UpdateAsset(Asset asset)
    {
      asset.SetFlags(AssetFlags.Updated);
      //TODO: The rest (?)
    }

  }
}
