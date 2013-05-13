using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase
{
  public abstract class Manager
  {
    public abstract void Initialize();
    public abstract void Update(float dt);
    public abstract void Finish();
  }
}
