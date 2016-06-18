using System;
using System.Collections.Generic;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class PhysicsSystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      var collisionEntites = new List<Entity>();

      foreach (var entity in currentLevel.Entities)
      {
        if (entity.ContainsComponent<CollisionComponent>())
          collisionEntites.Add(entity);
      }

      foreach (var entity in collisionEntites)
      {
        var collision = entity.GetComponent<CollisionComponent>();
        
      }

    }
  }
}
