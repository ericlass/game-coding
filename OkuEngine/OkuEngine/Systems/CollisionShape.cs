using System;
using System.Collections.Generic;
using OkuMath;

namespace OkuEngine.Systems
{
  public abstract class CollisionShape
  {
    public abstract List<Vector2f[]> GetShapes();
    internal abstract bool Dirty { get; }
  }
}
