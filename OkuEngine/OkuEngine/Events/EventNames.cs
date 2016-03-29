using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Events
{
  public static class EventNames
  {
    /// <summary>
    /// Is queued after the level has changed. Has no parameters.
    /// When this event is triggered, the new level is already the current level.
    /// </summary>
    public const string LevelChanged = "level_changed";

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
    /// Only parameters is the entity.
    /// </summary>
    public const string EntityComponentsCleared = "entity_components_cleared";

    /// <summary>
    /// Is queued after a new event listener was added to a level.
    /// Single parameter is the new event Listener.
    /// </summary>
    public const string LevelEventListenerAdded = "level_event_Listener_added";

    /// <summary>
    /// Is queued after an event listener was removed from a level.
    /// Single parameter is the removed event Listener.
    /// </summary>
    public const string LevelEventListenerRemoved = "level_event_Listener_removed";

    /// <summary>
    /// Is queued after all event listeners were removed from a level.
    /// No parameters.
    /// </summary>
    public const string LevelEventListenersCleared = "level_event_Listeners_cleared";

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
    public const string EngineTick = "engine_tick";
  }
}
