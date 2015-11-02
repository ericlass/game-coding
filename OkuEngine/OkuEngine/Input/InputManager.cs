using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;

namespace OkuEngine.Input
{
  /// <summary>
  /// Defines a manager that handles input processing and key bindings.
  /// </summary>
  public class InputManager
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
          OkuManagers.Instance.EventManager.QueueEvent(_stateChangeBindings[action][key]); //TODO: Maybe pass modifier keys as parameter?
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
        OkuManagers.Instance.EventManager.QueueEvent(eventId);
      }
    }

    public bool AfterLoad()
    {
      foreach (KeyBinding binding in OkuData.Instance.KeyBindings)
      {
        if (!AddBinding(binding.Key, binding.Action, binding.Event, binding.State))
          OkuBase.OkuManager.Instance.Logging.LogError("Trying to bind the same key to the same action twice!" + binding.Key + ", " + binding.Action);
      }
      return true;
    }

  }
}
