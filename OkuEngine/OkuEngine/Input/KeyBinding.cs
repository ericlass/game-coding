using System;
using System.Windows.Forms;
using OkuBase.Input;

namespace OkuEngine.Input
{
  /// <summary>
  /// Defines the binding of a single key to an event.
  /// </summary>
  public class KeyBinding
  {
    private Keys _key = default(Keys);
    private KeyAction _action = default(KeyAction);
    private bool _state = false;
    private int _event = 0;

    public Keys Key
    {
      get { return _key; }
      set { _key = value; }
    }

    public KeyAction Action
    {
      get { return _action; }
      set { _action = value; }
    }

    public bool State
    {
      get { return _state; }
      set { _state = value; }
    }

    public int Event
    {
      get { return _event; }
      set { _event = value; }
    }

    public bool AfterLoad()
    {
      return true;
    }

  }
}
