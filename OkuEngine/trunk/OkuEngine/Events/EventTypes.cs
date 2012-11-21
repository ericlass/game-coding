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

    /// <summary>
    /// The state of an actor was changed. Event data is the actor id, the previous state name and the new state name.
    /// </summary>
    public const int ActorStateChanged = 1000;

    #endregion

    /// <summary>
    /// The beginning of user defined events. All user defined events must be greater than this.
    /// </summary>
    public const int UserEventBase = 1000000;
  }
}
