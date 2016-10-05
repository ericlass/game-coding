using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public abstract class CollisionShape
  {
    public event Action OnChange;

    protected void FireChangeEvent()
    {
      OnChange?.Invoke();
    }

    public abstract List<int> GetShapes(Level currentLevel);
  }
}
