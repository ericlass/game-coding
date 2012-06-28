using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Events
{
  public interface IEventManager
  {
    bool AddListener(int eventType, EventListenerDelegate eventDelegate);
    bool RemoveListener(int eventType, EventListenerDelegate eventDelegate);
    bool TriggerEvent(BaseEvent eventData);
    bool QueueEvent(BaseEvent eventData);
    bool AbortEvent(int eventType, bool allOfType);
    bool Update(float maxTime);
  }
}
