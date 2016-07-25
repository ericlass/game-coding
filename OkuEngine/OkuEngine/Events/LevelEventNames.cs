using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;
using OkuEngine.Input;

namespace OkuEngine.Events
{
  /// <summary>
  /// Provides name and description for events related to levels,
  /// like adding or removing entities or event handlers.
  /// </summary>
  public static class LevelEventNames
  {
    /// <summary>
    /// Gets the event name for a keyboard key up or down action.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action.</param>
    /// <returns>The name of the event the engine queues when the given key action occurrs.</returns>
    public static string GetGenericInputEventName(Keys key, InputAction action)
    {
      return "keyboard_" + key.ToString().ToLower() + "_" + action.ToString().ToLower();
    }

    /// <summary>
    /// Gets the event name for a mouse button up or down action.
    /// </summary>
    /// <param name="button">The mouse button.</param>
    /// <param name="action">The action.</param>
    /// <returns>The name of the event the engine queues when the given button action occurrs.</returns>
    public static string GetGenericInputEventName(MouseButton button, InputAction action)
    {
      return "mouse_" + button.ToString().ToLower() + "_" + action.ToString().ToLower();
    }

    /// <summary>
    /// Is queued after the level has changed. Has no parameters.
    /// When this event is triggered, the new level is already the current level.
    /// </summary>
    public const string LevelChanged = "level_changed";

    /// <summary>
    /// Is queued after a new event listener was added to a level.
    /// Single parameter is the new event Listener.
    /// </summary>
    public const string LevelEventListenerAdded = "level_event_listener_added";

    /// <summary>
    /// Is queued after an event listener was removed from a level.
    /// Single parameter is the removed event Listener.
    /// </summary>
    public const string LevelEventListenerRemoved = "level_event_listener_removed";

    /// <summary>
    /// Is queued after all event listeners were removed from a level.
    /// No parameters.
    /// </summary>
    public const string LevelEventListenersCleared = "level_event_listeners_cleared";

    /// <summary>
    /// Is queued after a new entity was added to the level.
    /// Single parameter is the new entity.
    /// </summary>
    public const string LevelEntityAdded = "level_entity_added";

    /// <summary>
    /// Is queued after an entity was removed from the level.
    /// Single parameter is the removed entity.
    /// </summary>
    public const string LevelEntityRemoved = "level_entity_removed";

    /// <summary>
    /// Is queued after all entities were removed from a level.
    /// No parameters.
    /// </summary>
    public const string LevelEntitiesCleared = "level_entities_cleared";

    /// <summary>
    /// Is queued once every frame.
    /// Single parameter is the delta time.
    /// </summary>
    public const string EveryFrame = "every_frame";
  }
}
