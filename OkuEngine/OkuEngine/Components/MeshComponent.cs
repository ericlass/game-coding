using System;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class MeshComponent : IComponent
  {
    private AssetHandle _mesh = null;

    public MeshComponent(AssetHandle mesh)
    {
      if (!mesh.IsValid)
        throw new ArgumentException("Given mesh asset handle is not valid anymore!");

      if (mesh.AssetType != AssetType.StaticMesh && mesh.AssetType != AssetType.DynamicMesh)
        throw new ArgumentException("Trying to create a mesh component with an asset of type: " + mesh.AssetType + "! Only mesh assets are allowed.");

      _mesh = mesh;
    }

    public AssetHandle Mesh
    {
      get { return _mesh; }
      set { _mesh = value; }
    }

    public bool IsMultiAssignable
    {
      get { return true; }
    }

    public string Name
    {
      get{ return "mesh"; }
    }

    public IComponent Copy()
    {
      return new MeshComponent(_mesh);
    }

  }
}
