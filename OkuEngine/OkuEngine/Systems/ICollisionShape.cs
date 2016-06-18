using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine.Systems
{
  public interface ICollisionShape
  {
    List<Vector2f[]> GetShapes();
    bool NeedsUpdate { get; }
  }
}
