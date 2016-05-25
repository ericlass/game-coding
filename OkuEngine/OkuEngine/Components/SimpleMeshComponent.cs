using System;
using System.Collections.Generic;
using OkuEngine.Assets;
using OkuEngine.Levels;

namespace OkuEngine.Components
{
  public class SimpleMeshComponent : MeshComponent
  {
    private AssetHandle _mesh = null;
    private List<AssetHandle> _list = null;

    public SimpleMeshComponent(AssetHandle mesh)
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
      set
      {
        _mesh = value;
        _list = null;
      }
    }

    public override string Name
    {
      get { return "simplemesh"; }
    }

    public override IComponent Copy()
    {
      return new SimpleMeshComponent(_mesh);
    }

    internal override List<AssetHandle> GetMeshes(Level currentLevel)
    {
      if (_list == null)
        _list = new List<AssetHandle>() { _mesh };

      return _list;
    }

  }
}
