using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class PhysicsSystem : GameSystem
  {
    //Dictionary<GRIDCELL, Dictionary<ENTITYINDEX, SHAPES>>
    private Dictionary<int, Dictionary<int, List<Vector2f[]>>> spatialHashMap = new Dictionary<int, Dictionary<int, List<Vector2f[]>>>();

    public override void Execute(Level currentLevel)
    {
      float dt = currentLevel.Variables.GetFloat(VariableNames.DeltaTime);
      float gridCellSize = 32.0f;

      //Filter entites for collision component and do spatial hashing if required
      for (int i = 0; i < currentLevel.Entities.Count; i++)
      {
        var entity = currentLevel.Entities[i];
        var colComp = entity.GetComponent<CollisionComponent>();
        if (colComp != null)
        {
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

            foreach (var shape in colComp.Shape.GetShapes())
            {
              //Transform object space shape to world space using matrix
              Vector2f[] transformedShape = new Vector2f[shape.Length];
              for (int j = 0; j < shape.Length; j++)
                transformedShape[j] = transformMatrix * shape[j];

              //Get cells the AABB of the shape touches
              var aabb = AABBMath.FromPoints(transformedShape);
              var cells = GridMath.CellsOfAABB(aabb.Item1, aabb.Item2, gridCellSize);

              //Store transformed shape in spatial hash map
              foreach (var cell in cells)
              {
                int cellHash = 7;
                cellHash = (cellHash * 31) + cell.X;
                cellHash = (cellHash * 31) + cell.Y;

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
              }
              
            }
          }

        }
      }

    }
  }
}
