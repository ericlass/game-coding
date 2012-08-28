using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Events
{
  public interface IEventManager
  {
    /// <summary>
    /// Adds a new listener for the given event type.
    /// </summary>
    /// <param name="eventType">The type of the events the listeners wants to listen to.</param>
    /// <param name="eventDelegate">The delegate that is called when the event occurrs.</param>
    /// <returns>True if the listener was successfully registered, false if the listener was already registered.</returns>
    bool AddListener(int eventType, EventListenerDelegate eventDelegate);

    /// <summary>
    /// Removes the listener.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="eventDelegate">The delegate that has to be removed.</param>
    /// <returns>True if the listener was removed, false if the listener was not registered.</returns>
    bool RemoveListener(int eventType, EventListenerDelegate eventDelegate);

    /// <summary>
    /// Trigger the given event. The event is immediatelly alerted to the listeners no matter
    /// if there are other events in the queue.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="eventData">The data for the given event type.</param>
    /// <returns>True if the event was triggered, false if no listener is registered for the event.</returns>
    bool TriggerEvent(int eventType, object eventData);

    /// <summary>
    /// Adds the given event to the event queue.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="eventData">The data for the event.</param>
    /// <returns>True if the event was queued, else false.</returns>
    bool QueueEvent(int eventType, object eventData);

    /// <summary>
    /// Removes an event from the queue. Depending on the value of the
    /// allOfType parameter, all events if the given type or only the first
    /// one in the queue is removed.
    /// </summary>
    /// <param name="eventType">The type of event.</param>
    /// <param name="allOfType">Determines if only the first event in the queue or all events of the given type are removed.</param>
    /// <returns>True if the events are aborted, else false.</returns>
    bool AbortEvent(int eventType, bool allOfType);

    /// <summary>
    /// Triggers processing of all events in the queue. A maximum time for event processing
    /// can be specified. If the event processing takes longer than this time, the remaining
    /// events are posponed to the next update.
    /// </summary>
    /// <param name="maxTime">The maximum time to spend on event processing.</param>
    /// <returns>True if event processing finished successfully, else false.</returns>
    bool Update(float maxTime);
  }
}
