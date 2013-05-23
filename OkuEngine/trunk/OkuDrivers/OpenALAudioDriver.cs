using System;
using System.Collections.Generic;
using OkuBase.Driver;

namespace OkuDrivers
{
  public class OpenALAudioDriver : IAudioDriver
  {
    public string DriverName
    {
      get { return "openal"; }
    }

    public void Update(float dt)
    {
    }

  }
}
