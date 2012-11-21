using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace OkuEngine.Input
{
  /// <summary>
  /// Defines a manager that handles input processing and key bindings.
  /// </summary>
  public class InputManager : IStoreable
  {
    private Dictionary<KeyAction, Dictionary<Keys, int>> _stateBindings = new Dictionary<KeyAction, Dictionary<Keys, int>>();
    private Dictionary<KeyAction, Dictionary<Keys, int>> _stateChangeBindings = new Dictionary<KeyAction, Dictionary<Keys, int>>();
    private Dictionary<Keys, KeyAction> _keyStates = new Dictionary<Keys, KeyAction>();
    private Dictionary<Keys, int> _stateEvents = new Dictionary<Keys, int>();

    /// <summary>
    /// Creates a new input mananger.
    /// </summary>
    public InputManager()
    {
      _stateChangeBindings.Add(KeyAction.Down, new Dictionary<Keys, int>());
      _stateChangeBindings.Add(KeyAction.Up, new Dictionary<Keys, int>());

      _stateBindings.Add(KeyAction.Down, new Dictionary<Keys, int>());
      _stateBindings.Add(KeyAction.Up, new Dictionary<Keys, int>());
    }

    /// <summary>
    /// Is called when any key action happens. Enqueues the corresponding events.
    /// </summary>
    /// <param name="key">The key that was pressed.</param>
    /// <param name="action">The action that was performed on the key.</param>
    /// <returns>True if the key was handled, else false.</returns>
    public bool OnKeyAction(Keys key, KeyAction action)
    {
      bool handled = false;

      if (!_keyStates.ContainsKey(key) || _keyStates[key] != action)
      {
        if (_stateChangeBindings[action].ContainsKey(key))
        {
          OkuManagers.EventManager.QueueEvent(_stateChangeBindings[action][key]); //TODO: Maybe pass modifier keys as parameter?
          handled = true;
        }

        _stateEvents.Remove(key);

        if (_stateBindings[action].ContainsKey(key))
        {
          _stateEvents.Add(key, _stateBindings[action][key]);
        }

        if (!_keyStates.ContainsKey(key))
          _keyStates.Add(key, action);
        else
          _keyStates[key] = action;
      }      

      return handled;
    }

    /// <summary>
    /// Adds a new key binding to the manager.
    /// </summary>
    /// <param name="key">The key to handle.</param>
    /// <param name="action">The action to look for.</param>
    /// <param name="eventId">The event to enqueue when the key action happens.</param>
    /// <param name="state">True if the event should be enqueued as long as the key is in the state, false if the event should be enqueued when the state changes.</param>
    /// <returns>True if the binding was added, false if there already is a binding for the same event for that key action.</returns>
    public bool AddBinding(Keys key, KeyAction action, int eventId, bool state)
    {
      Dictionary<KeyAction, Dictionary<Keys, int>> bindings = state ? _stateBindings : _stateChangeBindings;

      if (!bindings[action].ContainsKey(key))
      {
        bindings[action].Add(key, eventId);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes the binding for the given key action.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The key action.</param>
    /// <returns>True if the binding was removed, false if there was no binding for the given key action.</returns>
    public bool RemoveBinding(Keys key, KeyAction action)
    {
      return _stateChangeBindings[action].Remove(key);
    }

    /// <summary>
    /// Enqueues any currently active state events,
    /// </summary>
    public void Update()
    {
      foreach (int eventId in _stateEvents.Values)
      {
        OkuManagers.EventManager.QueueEvent(eventId);
      }
    }

    private bool LoadBinding(XmlNode node, out Keys key, out KeyAction action, out int eventId, out bool state)
    {
      key = default(Keys);
      action = default(KeyAction);
      eventId = 0;
      state = false;

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

      value = node.GetTagValue("state");
      if (value != null)
      {
        state = Converter.StrToBool(value, false);
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
          bool state = false;

          if (LoadBinding(child, out key, out action, out eventId, out state))
          {
            if (!AddBinding(key, action, eventId, state))
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
      foreach (KeyValuePair<KeyAction, Dictionary<Keys, int>> action in _stateChangeBindings)
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
