using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using System.Windows.Forms;

namespace RougeLike
{
  public class EnemyController : ControllerProcess
  {
    private const float _speed = 75.0f;

    private class EnemyProperties
    {
      public Orientation Orientation { get; set; }
      public Vector2f Direction { get; set; }
      public float Distance { get; set; }

      public EnemyProperties()
      {
        Orientation = Orientation.Down;
      }
    }

    private Dictionary<string, EnemyProperties> _properties = new Dictionary<string, EnemyProperties>();

    public override void Initialize()
    {
      foreach (Entity entity in Entities)
        _properties.Add(entity.Id, new EnemyProperties());
    }

    private Vector2f GetPlayerVector(Entity entity)
    {
      TransformComponent playerTrans = GameManager.Instance.ActiveScene.Entities["player"].GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (playerTrans == null)
        throw new InvalidOperationException("Player has to transform component!");

      TransformComponent entTrans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (entTrans == null)
        throw new InvalidOperationException("Enemy has to transform component!");

      return playerTrans.Translation - entTrans.Translation;
    }

    private float DistanceToPlayer(Entity entity)
    {
      Vector2f playerVector = GetPlayerVector(entity);

      return playerVector.Magnitude;
    }

    private Orientation VectorToOrientation(Vector2f vec)
    {
      Vector2f refX = new Vector2f(1, 1);
      Vector2f refY = new Vector2f(1, -1);
      Vector2f vecN = Vector2f.Normalize(vec);

      float dotX = refX.DotProduct(vec);
      float dotY = refY.DotProduct(vec);

      Orientation result;
      if (dotY >= 0)
      {
        if (dotX >= 0)
          result = Orientation.Right;
        else
          result = Orientation.Down;
      }
      else
      {
        if (dotX >= 0)
          result = Orientation.Up;
        else
          result = Orientation.Left;
      }

      return result;
    }

    public override bool Update(float dt)
    {
      foreach (Entity entity in Entities)
      {
        if (!_properties.ContainsKey(entity.Id))
          _properties.Add(entity.Id, new EnemyProperties());

        EnemyProperties props = _properties[entity.Id];
        props.Direction = Vector2f.Normalize(GetPlayerVector(entity));
        props.Orientation = VectorToOrientation(props.Direction);
        props.Distance = DistanceToPlayer(entity);

        TransformComponent trans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
        if (trans == null)
          throw new InvalidOperationException("Enemy has to transform component!");

        //Movement
        if (props.Distance > 10)
        {
          trans.Translation += props.Direction * (_speed * dt);
          entity.StateMachine.CurrentStateId = "idle";
        }

        //Attack
        if (props.Distance <= 10)
        {
          entity.StateMachine.CurrentStateId = props.Orientation.ToString().ToLower() + "_attack";
        }
      }

      return false;
    }

    public override void Destroy()
    {
      throw new NotImplementedException();
    }
  }
}
