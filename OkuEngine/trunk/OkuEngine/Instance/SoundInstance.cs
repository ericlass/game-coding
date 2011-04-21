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
    private float _pitch = 0.0f;

    public SoundInstance(SoundContent content)
    {
      _content = content;
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

  }
}
