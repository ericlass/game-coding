using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.GCC.Events
{
  /// <summary>
  /// Base class for all events.
  /// Event time stamp must be set in constructor!
  /// </summary>
  public abstract class BaseEvent
  {
    protected float _timeStamp = 0.0f;

    public float Timestamp
    {
      get { return _timeStamp; }
    }

    public abstract int EventType { get; }  //<0 = system messages (undefined behavior), 0 = Invalid, 1-10000 = System reserved, 10000-MaxInt = Free for custom use
    public abstract string Name { get; }
    public abstract void Serialize(Stream stream);
    public abstract BaseEvent Copy();

  }
}
