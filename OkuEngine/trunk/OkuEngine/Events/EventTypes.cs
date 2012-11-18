using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Events
{
  internal static class EventTypes
  {
    public const int Invalid = 0;

    /// <summary>
    /// The viewport of the currently active scene has changed. Event data is the viewport object itself.
    /// </summary>
    public const int ViewPortChanged = 100;

    #region Actor Events

    // All actor events in this class define a base. When the event happens,
    // the id of the actor is added to this base so we get a unique event id
    // for the every actor. The base event should be 5000 apart so there can
    // be 5000 actors in total. This is hopefully enough.
    // This is needed because I think that you will be more interessted in
    // the change of one specific actor instead of all actors.

    /// <summary>
    /// The state of an actor was changed. Event data is the actor id.
    /// </summary>
    public const int ActorStateChanged = 5000;

    #endregion

    /// <summary>
    /// The beginning of user defined events. All user defined events must be greater than this.
    /// </summary>
    public const int UserEventBase = 1000000;
  }
}
