using System;
using System.Collections.Generic;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public abstract class EngineSystem
  {
    public abstract string Name { get; }
    public abstract void Init();
    public abstract void Execute();
    public abstract void Finish();
  }
}