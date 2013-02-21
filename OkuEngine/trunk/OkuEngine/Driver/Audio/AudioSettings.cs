using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Driver.Audio
{
  public class AudioSettings
  {
    private string _type = "openal";
    private float _volume = 1.0f;

    public string Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

  }
}
