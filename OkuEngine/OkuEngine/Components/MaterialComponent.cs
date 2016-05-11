using System;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class MaterialComponent : IComponent
  {
    private AssetHandle _material = null;

    public MaterialComponent(AssetHandle material)
    {
      if (!material.IsValid)
        throw new ArgumentException("Given material asset handle is not valid anymore!");

      if (material.AssetType != AssetType.Material)
        throw new ArgumentException("Trying to create a material component with an asset of type: " + material.AssetType + "! Only material assets are allowed.");

      _material = material;
    }

    public AssetHandle Material
    {
      get { return _material; }
      set { _material = value; }
    }

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return "material"; }
    }

    public IComponent Copy()
    {
      return new MaterialComponent(_material);
    }

  }
}
