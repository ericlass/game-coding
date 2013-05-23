using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Driver
{
  public interface IAudioDriver
  {
    string DriverName { get; }

    void Update(float dt);
  }
}
