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

    private Orientation VectorToOrientation(Vector2f vec)
    {
      const double quartertPi = Math.PI * 0.25;
      const double threeQurterPi = Math.PI * 0.75;

      //Vector2f other = Vector2f.Normalize(vec);
      double angle = Math.Atan2(vec.Y, vec.X);
      double angleAbs = Math.Abs(angle);

      if (angleAbs >= 0.0 && angleAbs <= quartertPi)
      {
        return Orientation.Right;
      }
      else if (angleAbs >= threeQurterPi && angleAbs <= Math.PI)
      {
        return Orientation.Left;
      }
      else
      {
        if (angle > 0)
          return Orientation.Up;
        else
          return Orientation.Down;
      }
    }

    public abstract bool IsMoving(Entity entity, ref Vector2f movement);
    public abstract bool IsAttacking(Entity entity);

    public override bool Update(float dt)
    {
      foreach (Entity entity in Entities)
	    {
        if (entity.StateMachine.CurrentStateId.EndsWith("idle"))
        {
          Vector2f movement = Vector2f.Zero;
          if (IsMoving(entity, ref movement))
          {
            Orientation direction = VectorToOrientation(movement);
            entity.StateMachine.CurrentStateId = direction.ToString().ToLower() + "_move";
          }
        }
        else if (entity.StateMachine.CurrentStateId.EndsWith("move"))
        {
          Vector2f movement = Vector2f.Zero;
          if (IsMoving(entity, ref movement))
          {
            Orientation direction = VectorToOrientation(movement);
            entity.StateMachine.CurrentStateId = direction.ToString().ToLower() + "_move";

            TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
            if (trans == null)
              throw new InvalidOperationException("Entity " + entity.Id + " has no transform component!");

            trans.Translation += movement * dt;
          }
          else
          {
            string[] parts = entity.StateMachine.CurrentStateId.Split('_');
            entity.StateMachine.CurrentStateId = parts[0] + "_idle";
          }
        }
        else if (entity.StateMachine.CurrentStateId.EndsWith("attack"))
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
