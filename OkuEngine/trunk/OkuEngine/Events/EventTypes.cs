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

    /// <summary>
    /// An actor was destroyed. Event data is the actor id.
    /// </summary>
    public const int ActorDestroyed = 10000;

    /// <summary>
    /// The beginning of user defined events. All user defined events must be greater than this.
    /// </summary>
    public const int UserEventBase = 100000;
  }
}
