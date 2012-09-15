using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace OkuEngine.Input
{
  public class InputManager : IStoreable
  {
    private Dictionary<KeyAction, Dictionary<Keys, int>> _keyBindings = new Dictionary<KeyAction, Dictionary<Keys, int>>();

    public InputManager()
    {
      _keyBindings.Add(KeyAction.Down, new Dictionary<Keys, int>());
      _keyBindings.Add(KeyAction.Up, new Dictionary<Keys, int>());
    }

    public bool FireKeyAction(Keys key, KeyAction action)
    {
      if (_keyBindings[action].ContainsKey(key))
      {
        OkuManagers.EventManager.QueueEvent(_keyBindings[action][key], null); //TODO: Maybe pass modifier keys as parameter?
        return true;
      }
      return false;
    }

    public bool AddBinding(Keys key, KeyAction action, int eventId)
    {
      if (!_keyBindings[action].ContainsKey(key))
      {
        _keyBindings[action].Add(key, eventId);
        return true;
      }
      return false;
    }

    public bool RemoveBinding(Keys key, KeyAction action)
    {
      return _keyBindings[action].Remove(key);
    }

    private bool LoadBinding(XmlNode node, out Keys key, out KeyAction action, out int eventId)
    {
      key = default(Keys);
      action = default(KeyAction);
      eventId = 0;

      string value = node.GetTagValue("key");
      if (value != null)
      {
        if (!Converter.TryParseEnum<Keys>(value, out key))
          return false;
      }

      value = node.GetTagValue("action");
      if (value != null)
      {
        if (!Converter.TryParseEnum<KeyAction>(value, out action))
          return false;
      }

      value = node.GetTagValue("event");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          eventId = test;
        else
          return false;
      }

      return true;
    }

    public bool Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "binding")
        {
          Keys key;
          KeyAction action;
          int eventId = 0;

          if (LoadBinding(child, out key, out action, out eventId))
          {
            if (!AddBinding(key, action, eventId))
              OkuManagers.Logger.LogError("Trying to bind key " + key.ToString() + " twice!");
          }
        }

        child = child.NextSibling;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("keybindings");
      foreach (KeyValuePair<KeyAction, Dictionary<Keys, int>> action in _keyBindings)
      {
        foreach (KeyValuePair<Keys, int> binding in action.Value)
        {
          writer.WriteValueTag("key", binding.Key.ToString());
          writer.WriteValueTag("action", action.Key.ToString());
          writer.WriteValueTag("event", binding.Value.ToString());
        }
      }
      writer.WriteEndElement();

      return true;
    }

  }
}
