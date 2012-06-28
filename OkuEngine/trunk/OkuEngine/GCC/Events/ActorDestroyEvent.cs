using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine.GCC.Events
{
  public class ActorDestroyEvent : BaseEvent
  {
    private int _actorId = 0;

    public ActorDestroyEvent(int actorId, float timestamp)
    {
      _actorId = actorId;
      _timeStamp = timestamp;
    }

    public override int EventType
    {
      get { return EventTypes.ActorDestroyed; }
    }

    public override string Name
    {
      get { return "ActorDestroyed"; }
    }

    public override void Serialize(Stream stream)
    {
      StreamWriter writer = new StreamWriter(stream);
      writer.Write(_actorId);
    }

    public override BaseEvent Copy()
    {
      return new ActorDestroyEvent(_actorId, _timeStamp);
    }

    public int ActorId
    {
      get { return _actorId; }
    }

  }
}
