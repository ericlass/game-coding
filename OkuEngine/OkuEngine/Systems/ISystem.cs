using System;
using System.Collections.Generic;

namespace OkuEngine.Systems
{
  public interface ISystem
  {
    string Name { get; }

    void Init();
    void Execute();
    void Finish();
  }
}