using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Audio;
using OkuBase.Settings;

namespace OkuBase.Driver
{
  public class NullAudioDriver : IAudioDriver
  {
    public string DriverName
    {
      get { return null; }
    }

    public float Volume
    {
      get { return 1.0f; }
      set { }
    }

    public bool Initialize(AudioSettings settings)
    {
      return true;
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
    }

    public void Play(Source source)
    {
    }

    public void Pause(Source source)
    {
    }

    public void Stop(Source source)
    {
    }

    public void LoadSource(Source source)
    {
    }

    public void UpdateSource(Source source)
    {
    }

    public void ReleaseSource(Source source)
    {
    }

  }
}
