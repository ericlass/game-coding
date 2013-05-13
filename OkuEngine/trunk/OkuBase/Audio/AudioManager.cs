using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Driver.Audio;

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
      throw new NotImplementedException();
    }

    public override void Finish()
    {
      throw new NotImplementedException();
    }

    public override void Update(float dt)
    {
      throw new NotImplementedException();
    }

  }
}
