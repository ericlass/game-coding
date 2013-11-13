using System;
using System.Collections.Generic;
using OkuBase.Geometry;

namespace RougeLike
{
  /// <summary>
  /// Defines the base for a controller process.
  /// A controller process is a process that controlls
  /// the movement and other actions of characters in the game.
  /// </summary>
  public abstract class ControllerProcess : ProcessBase
  {
    protected List<Entity> _entities = new List<Entity>();

    public List<Entity> Entities
    {
      get { return _entities; }
    }

    public override void Initialize()
    {      
    }

    public abstract bool IsMoving(Entity entity, ref Vector2f movement);
    public abstract bool IsAttacking(Entity entity);

    public override bool Update(float dt)
    {
      foreach (Entity entity in Entities)
	    {
        //Move
        Vector2f movement = Vector2f.Zero;
        if (IsMoving(entity, ref movement))
        {
          TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
          if (trans == null)
            throw new InvalidOperationException("Entity " + entity.Id + " has no transform component! It must have one for the controller to be able to handle it!");

          trans.Translation += movement;

          //TODO: Set orientation regarding the movement vector
        }

        if (IsAttacking(entity))
        {

        }
      }

      //Attack
      //Other Actions
      return false;
    }

    public override void Destroy()
    {
    }
  }
}
