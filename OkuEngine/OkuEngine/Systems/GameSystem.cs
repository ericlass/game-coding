using System;
using System.Collections.Generic;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public abstract class GameSystem
  {
    public virtual void Init()
    {
    }

    public virtual void LevelChanged(Level previous, Level next)
    {
    }

    public abstract void Execute(Level currentLevel);

    public virtual void Finish()
    {
    }
  }
}