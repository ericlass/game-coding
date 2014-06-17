using System;
using System.Collections.Generic;
using OkuBase;
using RougeLike.Objects;
using RougeLike.Behaviors;
using RougeLike.Renderers;

namespace RougeLike.States
{
  public class State
  {
    private string _id = null;
    private IBehaviorPattern _behavior = null;
    private IEntityRenderer _renderer = null;
  
    public State(string id)
    {
      _id = id;
    }
  
    /// <summary>
    /// Gets the unique id of the state.
    /// </summary>
    public string Id 
    { 
      get { return _id; }
    }
    
    public IBehaviorPattern Behavior
    {
      get { return _behavior; }
      set { _behavior = value; }
    }
    
    public IEntityRenderer Renderer
    {
      get { return _renderer; }
      set { _renderer = value; }
    }

    /// <summary>
    /// Is called one time when the scene is initiated. Should be used to load content.
    /// </summary>
    public void Init()
    {
      if (_behavior != null)
        _behavior.Init();
      if (_renderer != null)
        _renderer.Init();
    }

    /// <summary>
    /// Is called when the state is entered.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public void Enter(EntityObject entity)
    {
      if (_behavior != null)
        _behavior.Begin(entity);
      if (_renderer != null)
        _renderer.Begin(entity);
    }

    /// <summary>
    /// Is called every frame as long as the state if currently active.
    /// </summary>
    /// <param name="dt">The number if fractional seconds passed since the last frame.</param>
    /// <param name="entity">The entity the state belongs to.</param>
    /// <returns>The id of the next state or null if the current state shall not be changed.</returns>
    public string Update(float dt, EntityObject entity)
    {
      if (_behavior != null)
        _behavior.Update(dt, entity, entity.Controller);
      if (_renderer != null)
        _renderer.Update(dt, entity);
    }

    /// <summary>
    /// Is called every frame as long as the state is currently active.
    /// Is supposed to render the game object.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public void Render(EntityObject entity)
    {
      if (_renderer != null)
        _renderer.Render(entity);
    }

    /// <summary>
    /// Is called when the state is left.
    /// <param name="entity">The owning entity.</param>
    /// </summary>
    public void Leave(EntityObject entity)
    {
      if (_behavior != null)
        _behavior.End(entity);
      if (_renderer != null)
        _renderer.End(entity);
    }

    /// <summary>
    /// Is called when the scene is finalized. Should free all content.
    /// </summary>
    public void Finish()
    {
      if (_behavior != null)
        _behavior.Finish();
      if (_renderer != null)
        _renderer.Finish();
    }
  }
}