using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Events
{
  internal static class EventTypes
  {
    public const int Invalid = 0;

    /// <summary>
    /// The viewport of the currently active scene has changed. Event data is the viewport object itself.
    /// </summary>
    public const int ViewPortChanged = 100;

    public const int ActorDestroyed = 10000;
  }
}
