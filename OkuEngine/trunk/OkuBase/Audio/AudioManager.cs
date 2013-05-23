using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OkuBase.Driver;
using OkuBase.Settings;

namespace OkuBase.Audio
{
  public class AudioManager : Manager
  {
    IAudioDriver _driver = null;

    internal IAudioDriver Driver
    {
      get { return _driver; }
    }

    public Source NewSource(Sound sound)
    {
      Source result = new Source();
      result.Sound = sound;
      _driver.LoadSource(result);
      return result;
    }

    public void ReleaseSound(Source source)
    {
      _driver.ReleaseSource(source);
    }

    public void Play(Source source)
    {
      _driver.Play(source);
    }

    public void Pause(Source source)
    {
      _driver.Pause(source);
    }

    public void Stop(Source source)
    {
      _driver.Stop(source);
    }

    public override void Initialize(OkuSettings settings)
    {
      _driver = Oku.Instance.Drivers.AudioDriver;
      _driver.Initialize(settings.Audio);
    }

    public override void Finish()
    {
      _driver.Finish();
    }

    public override void Update(float dt)
    {
      _driver.Update(dt);
    }

  }
}
