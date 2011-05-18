using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class SoundInstance : ContentInstance
  {
    private SoundContent _content = null;
    private float _volume = 1.0f;
    private float _pitch = 1.0f;
    private float _pan = 0.0f;
    private bool _loop = false;

    public SoundInstance(SoundContent content)
    {
      _content = content;
    }

    public void Play()
    {
      OkuDrivers.SoundEngine.Play(this);
    }

    public void Pause()
    {
      OkuDrivers.SoundEngine.Pause(this);
    }

    public void Stop()
    {
      OkuDrivers.SoundEngine.Stop(this);
    }

    public SoundContent Content
    {
      get { return _content; }
      set { _content = value; }
    }

    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

    public float Pitch
    {
      get { return _pitch; }
      set { _pitch = value; }
    }

    public float Pan
    {
      get { return _pan; }
      set { _pan = value; }
    }

    public bool Loop
    {
      get { return _loop; }
      set { _loop = value; }
    }

  }
}
