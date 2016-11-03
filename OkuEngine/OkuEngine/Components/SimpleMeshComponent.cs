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
    private int _mesh = 0;
    private List<int> _list = null;

    /// <summary>
    /// Creates a new mesh component with the given mesh.
    /// </summary>
    /// <param name="mesh"></param>
    public SimpleMeshComponent(int mesh)
    {
      _mesh = mesh;
    }

    /// <summary>
    /// Gets or sets the mesh of this component.
    /// </summary>
    public int Mesh
    {
      get { return _mesh; }
      set
      {
        var oldMesh = _mesh;
        _mesh = value;
        _list = null;
        QueueEvent(EventNames.EntityMeshExchanged, new int[] { oldMesh }, new int[] { _mesh });
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
    public override Component Copy()
    {
      return new SimpleMeshComponent(_mesh);
    }

    /// <summary>
    /// Gets the meshes to be rendered.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    /// <returns>The meshes to be rendered.</returns>
    internal override List<int> GetMeshes(Level currentLevel)
    {
      if (_list == null)
        _list = new List<int>() { _mesh };

      return _list;
    }

  }
}
