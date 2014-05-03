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
    /// <param name="gameObject">The owning game object.</param>
    /// </summary>
    public abstract void Enter(GameObjectBase gameObject);

    /// <summary>
    /// Is called every frame as long as the state if currently active.
    /// </summary>
    /// <param name="dt">The number if fractional seconds passed since the last frame.</param>
    /// <param name="gameObject">The game object the state belongs to.</param>
    public abstract void Update(float dt, GameObjectBase gameObject);

    /// <summary>
    /// Is called every frame as long as the state is currently active.
    /// Is supposed to render the game object.
    /// <param name="gameObject">The owning game object.</param>
    /// </summary>
    public abstract void Render(GameObjectBase gameObject);

    /// <summary>
    /// Is called when the state is left.
    /// <param name="gameObject">The owning game object.</param>
    /// </summary>
    public abstract void Leave(GameObjectBase gameObject);

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
