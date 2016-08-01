using System;
using System.Windows.Forms;
using OkuBase.Input;
using OkuEngine.Input;

namespace OkuEngine
{
  /// <summary>
  /// Provides name and description for events related to levels,
  /// like adding or removing entities or event handlers.
  /// </summary>
  public static class EventNames
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
    /// Gets the event name for a generic overlap event that is queued
    /// when two entities with physics components overlap.
    /// </summary>
    /// <param name="entity1">The first entity.</param>
    /// <param name="entity2">The second entity.</param>
    /// <returns>The name of event the engine queues when two entities overlap.</returns>
    public static string GetGenericOverlapEventName(Entity entity1, Entity entity2)
    {
      //Use max and min so order of ids does not matter
      return "overlap_entities_" + Math.Min(entity1.ID, entity2.ID) + "_" + Math.Max(entity1.ID, entity2.ID);
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

    /// <summary>
    /// Is queued after a component was added to an entity.
    /// Parameters are the entity and the new component.
    /// </summary>
    public const string EntityComponentAdded = "entity_component_added";

    /// <summary>
    /// Is queued after a component was removed from an entity.
    /// Parameters are the entity and the removed component.
    /// </summary>
    public const string EntityComponentRemoved = "entity_component_removed";

    /// <summary>
    /// Is queued after all components were removed from an entity.
    /// Parameter is the entity.
    /// </summary>
    public const string EntityComponentsCleared = "entity_components_cleared";

    /// <summary>
    /// Queued when the position of an entity changed.
    /// Parameter is the moved entity.
    /// </summary>
    public const string EntityMoved = "entity_moved";
  }
}
