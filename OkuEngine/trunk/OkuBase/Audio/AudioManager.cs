using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Driver.Audio;
using OkuBase.Settings;

namespace OkuBase.Audio
{
  public class AudioManager : Manager
  {
    IAudioDriver _driver = null;

    public IAudioDriver Driver
    {
      get { return _driver; }
    }

    public override void Initialize(OkuSettings settings)
    {
      _driver = Oku.Instance.Drivers.AudioDriver;
    }

    public override void Finish()
    {
    }

    public override void Update(float dt)
    {
    }

  }
}
