using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Components
{
  public abstract class ShapeComponent : Component
  {
    public override bool IsMultiAssignable
    {
      get
      {
        return true;
      }
    }

    internal abstract List<int> GetShapes(Level currentLevel);
  }
}
