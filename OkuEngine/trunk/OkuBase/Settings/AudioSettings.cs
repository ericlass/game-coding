using System;
using System.Collections.Generic;

namespace OkuBase.Settings
{
  public class AudioSettings
  {
    private string _driverName = "openal";
    private float _volume = 1.0f;

    public string DriverName
    {
      get { return _driverName; }
      set { _driverName = value; }
    }

    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

  }
}
