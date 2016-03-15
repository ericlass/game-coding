using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Graphics;
using OkuBase.Audio;
using OkuBase.Input;
using OkuBase.Driver;
using OkuBase.Settings;

namespace OkuBase
{
  public class OkuManager
  {
    private static OkuManager _instance = null;

    public static OkuManager Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuManager();
        return _instance;
      }
    }

    private List<Manager> _managers = new List<Manager>();

    private DriverManager _drivers = new DriverManager();
    private GraphicsManager _graphics = new GraphicsManager();
    private AudioManager _audio = new AudioManager();
    private InputManager _input = new InputManager();

    private OkuManager()
    {
      //CAUTION: The order is important!!!
      _managers.Add(_drivers);
      _managers.Add(_graphics);
      _managers.Add(_audio);
      _managers.Add(_input);
    }

    public void Initialize(OkuSettings settings)
    {
      //Make sure to initialize in correct order
      for (int i = 0; i < _managers.Count; i++)
        _managers[i].Initialize(settings);
    }

    public void Update(float dt)
    {
      for (int i = 0; i < _managers.Count; i++)
        _managers[i].Update(dt);
    }

    public void Finish()
    {
      //Finish in oposite order
      for (int i = _managers.Count - 1; i >= 0; i--)
        _managers[i].Finish();
    }

    internal DriverManager Drivers
    {
      get { return _drivers; }
    }

    public GraphicsManager Graphics
    {
      get { return _graphics; }
    }

    public AudioManager Audio
    {
      get { return _audio; }
    }

    public InputManager Input
    {
      get { return _input; }
    }

  }
}
