using System;
using System.Collections.Generic;

namespace OkuBase.Settings
{
  public class AudioSettings
  {
    private string _driverName = "openal";

    public string DriverName
    {
      get { return _driverName; }
      set { _driverName = value; }
    }

  }
}
