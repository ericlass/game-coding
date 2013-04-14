using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OkuEngine.Input
{
  /// <summary>
  /// Defines the binding of a single key to an event.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public class KeyBinding : IStoreable
  {
    private Keys _key = default(Keys);
    private KeyAction _action = default(KeyAction);
    private bool _state = false;
    private int _event = 0;

    [JsonPropertyAttribute]
    public Keys Key
    {
      get { return _key; }
      set { _key = value; }
    }

    [JsonPropertyAttribute]
    public KeyAction Action
    {
      get { return _action; }
      set { _action = value; }
    }

    [JsonPropertyAttribute]
    public bool State
    {
      get { return _state; }
      set { _state = value; }
    }

    [JsonPropertyAttribute]
    public int Event
    {
      get { return _event; }
      set { _event = value; }
    }

    public bool AfterLoad()
    {
      throw new NotImplementedException();
    }

  }
}
