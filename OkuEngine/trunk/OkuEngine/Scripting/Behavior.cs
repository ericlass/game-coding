using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Events;

namespace OkuEngine.Scripting
{
  public class Behavior : StoreableEntity
  {
    private Dictionary<int, List<ScriptInstance>> _handlers = new Dictionary<int, List<ScriptInstance>>();

    public Behavior()
    {
    }

    public void EventReceived(int eventId, object data)
    {
      if (_handlers.ContainsKey(eventId))
      {
        foreach (ScriptInstance script in _handlers[eventId])
        {
          long tick1, tick2, freq;
          Kernel32.QueryPerformanceFrequency(out freq);
          Kernel32.QueryPerformanceCounter(out tick1);
          script.Run();
          Kernel32.QueryPerformanceCounter(out tick2);
          float time = ((tick2 - tick1) / (float)freq) * 1000.0f;
          OkuManagers.Logger.LogInfo("Behavior Script took " + time.ToString() + "ms");
        }
      }
    }

    private void AddHandler(int eventId, ScriptInstance script)
    {
      if (!_handlers.ContainsKey(eventId))
        _handlers.Add(eventId, new List<ScriptInstance>());

      _handlers[eventId].Add(script);
      OkuManagers.EventManager.AddListener(eventId, new EventListenerDelegate(EventReceived));
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
                script = OkuManagers.ScriptManager.CompileScript(value);
                if (script != null)
                {
                  AddHandler(eventId, script);                
                }
              }
            }
          }

          if (eventId == 0 || script == null)
          {
            OkuManagers.Logger.LogError("Behavior " + Name + " has an invalid handler!");
            return false;
          }
        }

        child = child.NextSibling;
      }

      return true;
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode handlers = node["handlers"];
      if (handlers != null)
      {
        if (!LoadHandlers(handlers))
          return false;
      }
      else
      {
        OkuManagers.Logger.LogError("No handlers defined for behavior " + _name + "!");
        return false;
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("behavior");

      if (!base.Save(writer))
        return false;

      writer.WriteStartElement("handlers");
      foreach (KeyValuePair<int, List<ScriptInstance>> handler in _handlers)
      {
        foreach (ScriptInstance script in handler.Value)
        {
          writer.WriteStartElement("handler");
          
          writer.WriteValueTag("event", handler.Key.ToString());

          writer.WriteStartElement("script");
          writer.WriteCData(script.Source);
          writer.WriteEndElement();

          writer.WriteEndElement();
        }        
      }
      writer.WriteEndElement();

      writer.WriteEndElement();

      return true;
    }

  }
}
