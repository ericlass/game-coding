using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class PhysicsSystem : GameSystem
  {
    private const float GridCellSize = 32.0f;

    //Maps grid cells to entites and their shapes. Dictionary<GRIDCELL, Dictionary<ENTITYID, SHAPES>>
    private Dictionary<int, Dictionary<int, List<Vector2f[]>>> spatialHashMap = new Dictionary<int, Dictionary<int, List<Vector2f[]>>>();

    //Maps entities and their shapes to grid cells. Dictionary<ENTITYID, Dictionary<GRIDCELL, SHAPES>> 
    private Dictionary<int, Dictionary<int, List<Vector2f[]>>> entityHashMap = new Dictionary<int, Dictionary<int, List<Vector2f[]>>>();

    public override void Execute(Level currentLevel)
    {
      List<Entity> collisionEntities = new List<Entity>();

      foreach (var entity in currentLevel.Entities)
      {
        if (entity.ContainsComponent<CollisionComponent>())
          collisionEntities.Add(entity);
      }

      //Filter entites for collision component and do spatial hashing if required
      foreach (var entity in collisionEntities)
        UpdateSpatialHashing(currentLevel, entity);

      //TODO: Check for collisions
      foreach (var entity in collisionEntities)
        HandleCollisions(currentLevel, entity);
    }

    private void HandleCollisions(Level currentLevel, Entity entity)
    {
      if (!entityHashMap.ContainsKey(entity.ID))
        throw new ArgumentException("Given entity with ID '" + entity.ID + "' is not in " + nameof(entityHashMap));

      foreach (var myEntry in entityHashMap[entity.ID])
      {
        int cellHash = myEntry.Key;
        var myShapes = myEntry.Value;
        var others = spatialHashMap[cellHash];
        foreach (var otherEntry in others)
        {
          if (otherEntry.Key != entity.ID)
          {
            foreach (var myShape in myShapes)
            {
              foreach (var otherShape in otherEntry.Value)
              {
                Vector2f mtd;
                if (Overlaps.PolygonPolygon(myShape, otherShape, out mtd))
                {
                  //TODO: Queue event if specified
                  //TODO: If both entities are solid, use mtd to move them apart. Setting the position will cause recalc of shape in next frame.
                }
              }
            }
          }
        }
      }

    }

    private void UpdateSpatialHashing(Level currentLevel, Entity entity)
    {
      float dt = currentLevel.Variables.GetFloat(VariableNames.DeltaTime);
      var colComp = entity.GetComponent<CollisionComponent>();

      bool wasMoved = true;

      var position = Vector2f.Zero;
      var posComp = entity.GetComponent<PositionComponent>();
      if (posComp != null)
      {
        position = posComp.Position;
        wasMoved = posComp.Dirty;
        posComp.Dirty = false;
      }

      var angle = 0.0f;
      var rotComp = entity.GetComponent<AngleComponent>();
      if (rotComp != null)
      {
        angle = rotComp.Angle;
        wasMoved = wasMoved || rotComp.Dirty;
        rotComp.Dirty = false;
      }

      var scale = Vector2f.One;
      var scaleComp = entity.GetComponent<ScaleComponent>();
      if (scaleComp != null)
      {
        scale = scaleComp.Scale;
        wasMoved = wasMoved || scaleComp.Dirty;
        scaleComp.Dirty = false;
      }

      var velocity = Vector2f.Zero;
      var velComp = entity.GetComponent<VelocityComponent>();
      if (velComp != null)
      {
        velocity = velComp.Velocity;
        if (!wasMoved)
          wasMoved = velocity != Vector2f.Zero;
      }

      if (wasMoved || colComp.Shape.Dirty)
      {
        foreach (var item in spatialHashMap.Values)
          item.Remove(entity.ID);

        var newPos = position + (velocity * dt);
        if (posComp != null)
          posComp.Position = newPos;

        Matrix3x3f transformMatrix = Matrix3x3f.Translate(newPos.X, newPos.Y) * Matrix3x3f.Rotation(angle) * Matrix3x3f.Scale(scale.X, scale.Y);

        foreach (var shape in colComp.Shape.GetShapes(currentLevel))
        {
          //Transform object space shape to world space using matrix
          Vector2f[] transformedShape = new Vector2f[shape.Length];
          for (int j = 0; j < shape.Length; j++)
            transformedShape[j] = transformMatrix * shape[j];

          //Get cells the AABB of the shape touches
          var aabb = AABBMath.FromPoints(transformedShape);
          var cells = GridMath.CellsOfAABB(aabb.Item1, aabb.Item2, GridCellSize);

          //Store transformed shape in spatial hash map
          foreach (var cell in cells)
          {
            int cellHash = 7;
            cellHash = (cellHash * 31) + cell.X;
            cellHash = (cellHash * 31) + cell.Y;

            //Add entity to map from cell hash to entity
            Dictionary<int, List<Vector2f[]>> cellShapes = null;
            if (spatialHashMap.ContainsKey(cellHash))
              cellShapes = spatialHashMap[cellHash];
            else
            {
              cellShapes = new Dictionary<int, List<Vector2f[]>>();
              spatialHashMap.Add(cellHash, cellShapes);
            }

            List<Vector2f[]> shapes = null;
            if (cellShapes.ContainsKey(entity.ID))
              shapes = cellShapes[entity.ID];
            else
            {
              shapes = new List<Vector2f[]>();
              cellShapes.Add(entity.ID, shapes);
            }

            shapes.Add(transformedShape);

            //Add entity to map from entity to cells
            Dictionary<int, List<Vector2f[]>> entityCells = null;
            if (entityHashMap.ContainsKey(entity.ID))
              entityCells = entityHashMap[entity.ID];
            else
            {
              entityCells = new Dictionary<int, List<Vector2f[]>>();
              entityHashMap.Add(entity.ID, entityCells);
            }

            shapes = null;
            if (entityCells.ContainsKey(cellHash))
              shapes = entityCells[cellHash];
            else
            {
              shapes = new List<Vector2f[]>();
              entityCells.Add(cellHash, shapes);
            }

            shapes.Add(transformedShape);
          }
        }

        colComp.Shape.Dirty = false;
      }
    }
  }
}
