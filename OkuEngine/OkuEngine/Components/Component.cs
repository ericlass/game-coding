using System;

namespace OkuEngine.Components
{
  /// <summary>
  /// Interface for components.
  /// </summary>
  public abstract class Component
  {
    /// <summary>
    /// Components must define a unique name.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Components must define if they can be assigned multiple times to an entity or not.
    /// </summary>
    public abstract bool IsMultiAssignable { get; }

    /// <summary>
    /// Is called when a component is added to an entity.
    /// Allows to do initialzation specfic to an entity, like registering to the entities event queue.
    /// </summary>
    public virtual void OnAdd(Entity owner)
    {
    }

    /// <summary>
    /// Called every frame for logic processing.
    /// </summary>
    /// <param name="dt">Time passed since last frame in seconds.</param>
    public virtual void Update(Entity owner, float dt)
    {
    }

    /// <summary>
    /// Is called when a component is removed from an entity.
    /// Allows to do cleanup specfic to an entity, like unregistering from the entities event queue.
    /// </summary>
    public virtual void OnRemove(Entity owner)
    {
    }

    /// <summary>
    /// Does a full, deep, independent copy of the component.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public abstract Component Copy();
  }
}
