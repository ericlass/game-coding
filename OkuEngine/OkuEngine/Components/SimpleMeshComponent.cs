using System;
using System.Collections.Generic;
using OkuEngine.Assets;
using OkuEngine.Levels;

namespace OkuEngine.Components
{
  /// <summary>
  /// Componenet that stores a single mesh.
  /// </summary>
  public class SimpleMeshComponent : MeshComponent
  {
    private AssetHandle _mesh = null;
    private List<AssetHandle> _list = null;

    /// <summary>
    /// Creates a new mesh component with the given mesh.
    /// </summary>
    /// <param name="mesh"></param>
    public SimpleMeshComponent(AssetHandle mesh)
    {
      if (!mesh.IsValid)
        throw new ArgumentException("Given mesh asset handle is not valid anymore!");

      if (mesh.AssetType != AssetType.StaticMesh && mesh.AssetType != AssetType.DynamicMesh)
        throw new ArgumentException("Trying to create a mesh component with an asset of type: " + mesh.AssetType + "! Only mesh assets are allowed.");

      _mesh = mesh;
    }

    /// <summary>
    /// Gets or sets the mesh of this component.
    /// </summary>
    public AssetHandle Mesh
    {
      get { return _mesh; }
      set
      {
        _mesh = value;
        _list = null;
      }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get { return "simplemesh"; }
    }

    /// <summary>
    /// Creates a deep copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override IComponent Copy()
    {
      return new SimpleMeshComponent(_mesh);
    }

    /// <summary>
    /// Gets the meshes to be rendered.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    /// <returns>The meshes to be rendered.</returns>
    internal override List<AssetHandle> GetMeshes(Level currentLevel)
    {
      if (_list == null)
        _list = new List<AssetHandle>() { _mesh };

      return _list;
    }

  }
}
