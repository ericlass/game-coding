using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Graphics;
using OkuBase.Audio;
using OkuBase.Input;

namespace OkuBase
{
  public class Oku
  {
    private static Oku _instance = null;

    public static Oku Instance
    {
      get
      {
        if (_instance == null)
          _instance = new Oku();
        return _instance;
      }
    }

    private List<Manager> _managers = new List<Manager>();

    private GraphicsManager _graphics = new GraphicsManager();
    private AudioManager _audio = new AudioManager();
    private InputManager _input = new InputManager();

    private Oku()
    {
      _managers.Add(_graphics);
      _managers.Add(_audio);
      _managers.Add(_input);
    }

    public void Initialize(OkuSettings settings)
    {
      foreach (Manager man in _managers)
        man.Initialize(settings);
    }

    public void Update(float dt)
    {
      foreach (Manager man in _managers)
        man.Update(dt);
    }

    public void Finish()
    {
      foreach (Manager man in _managers)
        man.Finish();
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
