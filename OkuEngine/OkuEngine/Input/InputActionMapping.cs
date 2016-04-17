using System;
using System.Collections.Generic;

namespace OkuEngine.Input
{
  /// <summary>
  /// Defines a mapping from 1-n input actions to a single event.
  /// If any of the input actions occur, the event is queued.
  /// </summary>
  public class InputActionMapping
  {
    private string _eventName = null;
    private List<InputKeyAction> _actions = new List<InputKeyAction>();

    /// <summary>
    /// Create a new action mapping that queues the given event.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    public InputActionMapping(string eventName)
    {
      _eventName = eventName;
    }

    /// <summary>
    /// Gets the name of the event that is queued if any of the actions occurr.
    /// </summary>
    public string EventName
    {
      get { return _eventName; }
    }

    /// <summary>
    /// Gets the list of actions.
    /// </summary>
    public List<InputKeyAction> Actions
    {
      get { return _actions; }
    }

  }
}
