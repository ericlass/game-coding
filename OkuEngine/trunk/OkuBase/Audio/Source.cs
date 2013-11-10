using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuBase.Audio
{
  public class Source
  {
    private int _id = 0;
    private Sound _sound = null;
    private float _volume = 1.0f;
    private float _pitch = 1.0f;
    private float _pan = 0.0f;
    private bool _loop = false;

    internal Source()
    {
      _id = KeySequence.NextValue(KeySequence.SourceSequence);
    }

    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    public Sound Sound
    {
      get { return _sound; }
      set { _sound = value; }
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
