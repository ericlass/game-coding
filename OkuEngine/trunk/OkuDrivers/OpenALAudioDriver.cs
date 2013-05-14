using System;
using System.Collections.Generic;
using OkuBase.Driver.Audio;

namespace OkuDrivers
{
  public class OpenALAudioDriver : IAudioDriver
  {
    public string DriverName
    {
      get { return "openal"; }
    }

  }
}
