using OkuBase;
using OkuBase.Graphics;
using OkuMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Assets
{
  public class AssetManager
  {
    private List<object> _assets = new List<object>();

    public AssetManager()
    {
      _assets.Add(null); //Index 0 always means null
    }

    private AssetHandle AddAsset(object asset, AssetType assetType)
    {
      _assets.Add(asset);
      return new AssetHandle(_assets.Count - 1, assetType);
    }

    public AssetHandle AddImage(ImageData imageData)
    {
      Image image = OkuManager.Instance.Graphics.NewImage(imageData);
      return AddAsset(image, AssetType.Image);
    }

    public AssetHandle AddMesh(MeshAsset mesh)
    {
      return AddAsset(mesh, mesh.IsStatic ? AssetType.StaticMesh : AssetType.DynamicMesh);
    }

    public AssetHandle AddMaterial(MaterialAsset material)
    {
      return AddAsset(material, AssetType.Material);
    }

    public object GetAsset(AssetHandle handle)
    {
      int id = handle.ID;
      if (id < 0 || id >= _assets.Count)
        return null;
      else
        return _assets[id];
    }

    public T GetAsset<T>(AssetHandle handle) where T : class
    {
      return GetAsset(handle) as T;
    }

    public void RemoveAsset(AssetHandle handle)
    {
      int id = handle.ID;
      if (id >= 0 && id < _assets.Count)
      {
        object asset = _assets[id];
        //TODO: Free resource from renderer, sound or whatever
        _assets[id] = null;
        handle.Invalidate();
      }
    }

  }
}
