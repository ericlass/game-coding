using System;
using System.Collections.Generic;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public abstract class GameSystem
  {
    public abstract void Init();
    public abstract void Execute(Level currentLevel);
    public abstract void Finish();
  }
}