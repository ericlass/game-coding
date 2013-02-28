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
        _handlers.Add(eventId, new List<ScriptInstance>());

      _handlers[eventId].Add(script);
      OkuManagers.Instance.EventManager.AddListener(eventId, new EventListenerDelegate(EventReceived));
    }

    public bool LoadHandlers(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "handler")
        {
          int eventId = 0;
          ScriptInstance script = null;

          string value = child.GetTagValue("event");
          if (value != null)
          {
            if (int.TryParse(value, out eventId))
            {
              value = child.GetTagValue("script");
              if (value != null)
              {
                script = OkuManagers.Instance.ScriptManager.CompileScript(value);
                if (script != null)
                {
                  AddHandler(eventId, script);                
                }
              }
            }
          }

          if (eventId == 0 || script == null)
          {
            OkuManagers.Instance.Logger.LogError("Behavior " + Name + " has an invalid handler!");
            return false;
          }
        }

        child = child.NextSibling;
      }

      return true;
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
      }
      return true;
    }

  }
}
