using System;

namespace OkuEngine.Components
{
  /// <summary>
  /// Interface for components.
  /// </summary>
  public abstract class Component
  {
    private Entity _owner = null;

    public Entity Owner
    {
      get { return _owner; }
    }

    internal void SetOwner(Entity owner)
    {
      _owner = owner;
    }

    /// <summary>
    /// Convenience method for queueing component event. The entity and component are automatically attached.
    /// </summary>
    /// <param name="eventName">The name of the event to queue.</param>
    protected void QueueEvent(string eventName)
    {
      Owner.QueueComponentEvent(eventName, this);
    }

    /// <summary>
    /// Components must define a unique name.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Components must define if they can be assigned multiple times to an entity or not.
    /// </summary>
    public abstract bool IsMultiAssignable { get; }

    /// <summary>
    /// Called every frame during the update step.
    /// </summary>
    /// <param name="dt">The time passed since the last frame in seconds.</param>
    public virtual void Update(float dt)
    {
    }

    /// <summary>
    /// Does a full, deep, independent copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public abstract Component Copy();
  }
}
