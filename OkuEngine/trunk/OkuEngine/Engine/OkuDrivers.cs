using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Driver.Audio;
using OkuEngine.Driver.Renderer;
using OkuEngine.Events;

namespace OkuEngine
{
  public class OkuDrivers
  {
    private static OkuDrivers _instance = null;

    public static OkuDrivers Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuDrivers();
        return _instance;
      }
    }

    private IRenderer _renderer = null;
    private ISoundEngine _soundEngine = null;

    private OkuDrivers()
    {
    }

    public bool Initialize()
    {
      _renderer = RendererFactory.Instance.CreateRenderer(OkuData.Instance.RenderSettings);
      if (_renderer != null)
        OkuManagers.Instance.EventManager.AddListener(EventTypes.ViewPortChanged, new EventListenerDelegate(_renderer.OnViewportEvent));
      else
        throw new OkuException("Could not create renderer!");

      _soundEngine = SoundEngineFactory.Instance.CreateSoundEngine(OkuData.Instance.AudioSettings);
      if (_soundEngine == null)
        throw new OkuException("Could not create sound engine!");

      return true;
    }

    public IRenderer Renderer
    {
      get { return _renderer; }
    }

    public ISoundEngine SoundEngine
    {
      get { return _soundEngine; }
    }

  }
}
