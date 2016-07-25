using System;
using System.Collections.Generic;
using OkuEngine.Levels;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  /// <summary>
  /// Abstract base class for mesh components.
  /// </summary>
  public abstract class MeshComponent : Component
  {
    public override bool IsMultiAssignable
    {
      get { return true; }
    }

    internal abstract List<int> GetMeshes(Level currentLevel);
  }
}
