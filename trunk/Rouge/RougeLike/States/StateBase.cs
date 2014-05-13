using System;
using System.Collections.Generic;
using OkuBase;

namespace RougeLike.States
{
  /// <summary>
  /// Defines the base for all states for the StateMachine.
  /// </summary>
  public abstract class StateBase
  {
    /// <summary>
    /// Gets the unique id of the state.
    /// </summary>
    public abstract string Id { get; }

    /// <summary>
    /// Is called one time when the scene is initiated. Should be used to load content.
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// Is called when the state is entered.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public abstract void Enter(EntityObject entity);

    /// <summary>
    /// Is called every frame as long as the state if currently active.
    /// </summary>
    /// <param name="dt">The number if fractional seconds passed since the last frame.</param>
    /// <param name="entity">The entity the state belongs to.</param>
    /// <returns>The id of the next state or null if the current state shall not be changed.</returns>
    public abstract string Update(float dt, EntityObject entity);

    /// <summary>
    /// Is called every frame as long as the state is currently active.
    /// Is supposed to render the game object.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public abstract void Render(EntityObject entity);

    /// <summary>
    /// Is called when the state is left.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public abstract void Leave(EntityObject entity);

    /// <summary>
    /// Is called when the scene is finalized. Should free all content.
    /// </summary>
    public abstract void Finish();

    /// <summary>
    /// Gets the OkuManager. A shortcut for OkuBase.OkuManager.Instance.
    /// </summary>
    protected OkuManager Oku
    {
      get { return OkuManager.Instance; }
    }

  }
}
