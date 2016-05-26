using System;
using System.Collections.Generic;
using OkuEngine.Levels;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  /// <summary>
  /// Abstract base class for mesh components.
  /// </summary>
  public abstract class MeshComponent : IComponent
  {
    public bool IsMultiAssignable
    {
      get { return true; }
    }

    public abstract string Name { get; }
    public abstract IComponent Copy();
    internal abstract List<AssetHandle> GetMeshes(Level currentLevel);
  }
}
