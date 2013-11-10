using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Settings
{
  public class OkuSettings
  {
    private GraphicsSettings _graphics = new GraphicsSettings();
    private AudioSettings _audio = new AudioSettings();

    public GraphicsSettings Graphics
    {
      get { return _graphics; }
    }

    public AudioSettings Audio
    {
      get { return _audio; }
    }

  }
}
