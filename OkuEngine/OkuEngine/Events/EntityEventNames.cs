using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Events
{
  /// <summary>
  /// Provides name and description for events related to entities,
  /// like adding or removing components.
  /// </summary>
  public static class EntityEventNames
  {
    /// <summary>
    /// Is queued after a component was added to an entity.
    /// Parameter is the new component.
    /// </summary>
    public const string EntityComponentAdded = "entity_component_added";

    /// <summary>
    /// Is queued after a component was removed from an entity.
    /// Parameter is the removed component.
    /// </summary>
    public const string EntityComponentRemoved = "entity_component_removed";

    /// <summary>
    /// Is queued after all components were removed from an entity.
    /// No parameters.
    /// </summary>
    public const string EntityComponentsCleared = "entity_components_cleared";
  }
}
