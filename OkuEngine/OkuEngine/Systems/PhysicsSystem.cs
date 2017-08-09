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

        var veloComp = entity.GetComponent<VelocityComponent>();

        Vector2f pos = posComp.Position;
//        Vector2f prevPos = posComp.PreviousPosition;
        float dt = currentLevel.Engine.DeltaTime;
//        float prevDt = currentLevel.Engine.PreviousDeltaTime;
        var a = currentLevel.Engine.Gravity * physicsComp.GravityMultiplier;

        //Time corrected verlet integration: xi+1 = xi + (xi - xi-1) * (dti / dti-1) + a * dti * dti
        
        var v = Vector2f.Zero;
        if (veloComp != null)
        {
          v = veloComp.Velocity;
        }
        v = v + a * dt;

        posComp.PreviousPosition = pos;
        posComp.Position += v * dt;

        if (veloComp != null)
        {
          veloComp.Velocity = v;
        }
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
          var shape1 = currentLevel.ShapeCache[shape];
          if (shape1 == null)
            throw new Exception("Could not find shape with ID " + shape);

          var nearEntities = currentLevel.SpatialShapeMap.GetItemsNear(entity);
          foreach (var nearEntity in nearEntities)
          {
            //if (nearEntity == entity)
            //  continue;

            var shapeComponents = nearEntity.GetComponents<ShapeComponent>();
            foreach (var nearShapeComp in shapeComponents)
            {
              foreach (var nearShape in (nearShapeComp as ShapeComponent).GetShapes(currentLevel))
              {
                var shape2 = currentLevel.ShapeCache[nearShape];
                if (shape2 == null)
                  throw new Exception("Could not find shape with ID " + nearEntity);

                var transformMatrix1 = currentLevel.Engine.GetEntityTransformMatrix(entity);
                var shape1World = currentLevel.Engine.TransformPoly(shape1, transformMatrix1);
                var transformMatrix2 = currentLevel.Engine.GetEntityTransformMatrix(nearEntity);
                var shape2World = currentLevel.Engine.TransformPoly(shape2, transformMatrix2);

                Vector2f mtd;
                if (Overlaps.PolygonPolygon(shape1World, shape2World, out mtd))
                {
                  //TODO: Apply MTD
                  var posComp = entity.GetComponent<PositionComponent>();
                  if (posComp != null)
                  {
                    posComp.Position += mtd;
                  }

                  var veloComp = entity.GetComponent<VelocityComponent>();
                  if (veloComp != null)
                  {
                    veloComp.Velocity = Vector2f.Zero;
                  }

                  currentLevel.Engine.QueueEvent(EventNames.GetGenericOverlapEventName(entity, nearEntity), new object[] { entity, nearEntity });
                }

              }
            }
          }
        }
      }
    }

  }
}
