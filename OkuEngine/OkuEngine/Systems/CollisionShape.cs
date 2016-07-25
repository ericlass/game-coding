using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public abstract class CollisionShape
  {
    public abstract List<Vector2f[]> GetShapes(Level currentLevel);
    internal abstract bool Dirty { get; }
  }
}
