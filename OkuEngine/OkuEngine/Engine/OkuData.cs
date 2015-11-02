using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuEngine.Input;
using OkuEngine.Events;

namespace OkuEngine
{
  /// <summary>
  /// Contains the data of the game.
  /// </summary>
  public class OkuData
  {
    private static OkuData _instance = null;

    public static OkuData Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuData();
        return _instance;
      }
      set { _instance = value; }
    }

    private OkuData()
    {
    }

    private GraphicsSettings _renderSettings = new GraphicsSettings();
    private AudioSettings _audioSettings = new AudioSettings();

    private List<KeyBinding> _keyBindings = new List<KeyBinding>();
    private List<ImageBase> _images = new List<ImageBase>();

    public bool AfterLoad()
    {
      foreach (KeyBinding binding in _keyBindings)
        if (!binding.AfterLoad())
          return false;

      return true;
    }

    public List<ImageBase> Images
    {
      get { return _images; }
      set { _images = value; }
    }

    public GraphicsSettings RenderSettings
    {
      get { return _renderSettings; }
      set { _renderSettings = value; }
    }

    public AudioSettings AudioSettings
    {
      get { return _audioSettings; }
      set { _audioSettings = value; }
    }

    /// <summary>
    /// Gets the list of key bindings.
    /// </summary>
    public List<KeyBinding> KeyBindings
    {
      get { return _keyBindings; }
      set { _keyBindings = value; }
    }

  }
}
