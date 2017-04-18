using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class PhysicsSystem : GameSystem
  {

    public override void Execute(Level currentLevel)
    {
      //First, move all entities
      foreach (var entity in currentLevel.Entities)
      {
        var physicsComp = entity.GetComponent<PhysicsComponent>();
        if (physicsComp == null)
          continue;

        var posComp = entity.GetComponent<PositionComponent>();
        if (posComp == null)
          continue;

        Vector2f pos = posComp.Position;
        float dt = currentLevel.Engine.DeltaTime;

        //Time corrected verlet integration: xi+1 = xi + (xi - xi-1) * (dti / dti-1) + a * dti * dti
        Vector2f newPos = pos + (pos - pos - 1) * (dt / currentLevel.Engine.PreviousDeltaTime) + currentLevel.Engine.Gravity * dt * dt;

        posComp.Position = pos;
      }

      //Second, check all object for collision
      foreach (var entity in currentLevel.Entities)
      {
        var shapeComp = entity.GetComponent<ShapeComponent>();
        if (shapeComp == null)
          continue;

        var shapes = shapeComp.GetShapes(currentLevel);
        foreach (var shape in shapes)
        {
          var nearShapes = currentLevel.SpatialShapeMap.GetItemsNear(entity.ID, shape);
          foreach (var nearShape in nearShapes)
          {
            var shape1 = currentLevel.ShapeCache[shape];
            var shape2 = currentLevel.ShapeCache[nearShape];

            if (shape1 == null)
              throw new Exception("Could not find shape with ID " + shape);

            if (shape2 == null)
              throw new Exception("Could not find shape with ID " + nearShape);

            var transformMatrix = currentLevel.Engine.GetEntityTransformMatrix(entity);
            var shape1World = currentLevel.Engine.TransformPoly(shape1, transformMatrix);
            var shape2World = currentLevel.Engine.TransformPoly(shape1, transformMatrix);

            Vector2f mtd;
            if (Overlaps.PolygonPolygon(shape1World, shape2World, out mtd))
            {
              //TODO: Fix spatial map to support this. We need to know the ID of the other entity!
              //TODO: Apply MTD
              //TODO: Queue overlap event: currentLevel.Engine.QueueEvent(EventNames.GetGenericOverlapEventName(entity, TODO), null);
            }
          }
        }
      }
    }

  }
}
