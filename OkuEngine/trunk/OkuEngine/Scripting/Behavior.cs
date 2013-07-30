using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Events;
using Newtonsoft.Json;

namespace OkuEngine.Scripting
{
  public class Behavior : StoreableEntity
  {
    private Dictionary<int, List<ScriptInstance>> _handlers = new Dictionary<int, List<ScriptInstance>>();

    public Behavior()
    {
    }

    public void EventReceived(int eventId, params object[] data)
    {
      if (_handlers.ContainsKey(eventId))
      {
        foreach (ScriptInstance script in _handlers[eventId])
        {
          script.Run(data);
        }
      }
    }

    [JsonPropertyAttribute]
    public Dictionary<int, List<ScriptInstance>> Handlers
    {
      get { return _handlers; }
      set { _handlers = value; }
    }

    private void AddHandler(int eventId, ScriptInstance script)
    {
      if (!_handlers.ContainsKey(eventId))
      {
        _handlers.Add(eventId, new List<ScriptInstance>());
        OkuManagers.Instance.EventManager.AddListener(eventId, new EventListenerDelegate(EventReceived));
      }

      _handlers[eventId].Add(script);
      
    }

    public override bool AfterLoad()
    {
      //TODO: Bad hack that should be replaced asap
      foreach (KeyValuePair<int, List<ScriptInstance>> handler in _handlers)
      {
        foreach (ScriptInstance script in handler.Value)
        {
          if (!OkuManagers.Instance.ScriptManager.Recompile(script))
            return false;
        }
        OkuManagers.Instance.EventManager.AddListener(handler.Key, new EventListenerDelegate(EventReceived));
      }
      return true;
    }

  }
}
