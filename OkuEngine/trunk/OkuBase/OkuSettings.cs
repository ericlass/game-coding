using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase
{
  public class OkuSettings
  {
    private string _graphicsDriverName = "opengl";
    private string _audioDriverName = "openal";

    public string GraphicsDriverName
    {
      get { return _graphicsDriverName; }
      set { _graphicsDriverName = value; }
    }

    public string AudioDriverName
    {
      get { return _audioDriverName; }
      set { _audioDriverName = value; }
    }

  }
}
