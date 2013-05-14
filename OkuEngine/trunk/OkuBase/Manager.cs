using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Settings;

namespace OkuBase
{
  public abstract class Manager
  {
    public abstract void Initialize(OkuSettings settings);
    public abstract void Update(float dt);
    public abstract void Finish();
  }
}
