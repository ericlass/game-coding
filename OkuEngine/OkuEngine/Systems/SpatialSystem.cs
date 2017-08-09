using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Events;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  /// <summary>
  /// System that takes care of updating the spatial hash map.
  /// Registers for all necessary events and forwards updates to
  /// the spatial hash map.
  /// </summary>
  public class SpatialSystem : GameSystem
  {
    //private Level _currentLevel = null;

    public override void Execute(Level currentLevel)
    {
      //TODO: Do not rebuild full spatial map each frame. This is slow.
      currentLevel.SpatialMeshMap.Clear();
      currentLevel.SpatialShapeMap.Clear();

      foreach (var entity in currentLevel.Entities)
      {
        if (entity.ContainsComponent<ShapeComponent>())
          currentLevel.SpatialShapeMap.AddOrUpdate(entity);

        //if (entity.ContainsComponent<MeshComponent>())
        //  currentLevel.SpatialMeshMap.AddOrUpdate(entity);
      }
    }

  }
}
