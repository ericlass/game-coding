using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using System.Windows.Forms;

namespace RougeLike
{
  public class SimpleEnemyController : ControllerProcess
  {
    private class EnemyProperties
    {
      public Orientation Direction { get; set; }

      public EnemyProperties()
      {
        Direction = Orientation.Down;
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
        return Vector2f.Zero;

      TransformComponent entTrans = entity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (entTrans == null)
        return Vector2f.Zero;

      return playerTrans.Translation - entTrans.Translation;
    }

    private float DistanceToPlayer(Entity entity)
    {
      Vector2f playerVector = GetPlayerVector(entity);

      if (playerVector == Vector2f.Zero)
        return float.MaxValue;

      return playerVector.Magnitude;
    }

    public override bool Update(float dt)
    {
      foreach (Entity entity in Entities)
      {
        if (!_properties.ContainsKey(entity.Id))
          _properties.Add(entity.Id, new EnemyProperties());

        EnemyProperties props = _properties[entity.Id];
      }

      return false;
    }

    public override void Destroy()
    {
      throw new NotImplementedException();
    }
  }
}
