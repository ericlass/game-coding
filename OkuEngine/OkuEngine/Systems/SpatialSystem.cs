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
    private const int MeshGroup = 1;
    private const int ShapeGroup = 2;

    private List<int> _updatedMeshes = new List<int>();
    private List<int> _removedMeshes = new List<int>();
    private List<int> _updatedShapes = new List<int>();
    private List<int> _removedShapes = new List<int>();
    private List<Entity> _transformedEntities = new List<Entity>();
    private List<Entity> _addedEntities = new List<Entity>();
    private List<Entity> _removedEntities = new List<Entity>();

    private Level _currentLevel = null;

    public override void LevelChanged(Level previous, Level next)
    {
      if (previous != null)
      {
        previous.EventQueue.RemoveListener(OnEvent);
      }

      if (next != null)
      {
        //Entity based events
        next.Engine.AddEventListener(new EventListener(EventNames.LevelEntityAdded, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.LevelEntityRemoved, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentAdded, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentRemoved, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentsCleared, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityMeshChanged, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.EntityMoved, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityRotated, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityScaled, OnEvent));

        //Cache events
        next.Engine.AddEventListener(new EventListener(EventNames.MeshCacheDataBuffered, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.MeshCacheEntryRemoved, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.ShapeCacheDataBuffered, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.ShapeCacheEntryRemoved, OnEvent));
      }

      _currentLevel = next;
    }

    private void OnEvent(Event ev)
    {
      //TODO: Extract cases to methods
      switch (ev.Name)
      {
        case EventNames.MeshCacheDataBuffered:
          _updatedMeshes.Add((int)ev.Data[0]);
          break;

        case EventNames.MeshCacheEntryRemoved:
          _removedMeshes.Add((int)ev.Data[0]);
          break;

        case EventNames.ShapeCacheDataBuffered:
          _updatedShapes.Add((int)ev.Data[0]);
          break;

        case EventNames.ShapeCacheEntryRemoved:
          _removedShapes.Add((int)ev.Data[0]);
          break;

        case EventNames.EntityMoved:
        case EventNames.EntityRotated:
        case EventNames.EntityScaled:
          _transformedEntities.Add((Entity)ev.Data[0]);
          break;

        case EventNames.LevelEntityAdded:
          var entity = ev.Data[0] as Entity;
          if (entity.ContainsComponent<CollisionComponent>() || entity.ContainsComponent<MeshComponent>())
            _addedEntities.Add(entity);
          break;

        case EventNames.LevelEntityRemoved:
          entity = ev.Data[0] as Entity;
          if (entity.ContainsComponent<CollisionComponent>() || entity.ContainsComponent<MeshComponent>())
            _removedEntities.Add(entity);
          break;

        case EventNames.EntityComponentAdded:
          var component = ev.Data[1] as Component;
          if (component is CollisionComponent)
          {
            var comp = component as CollisionComponent;
            _updatedShapes.Add(comp.Shape);
          }
          else if (component is MeshComponent)
          {
            var comp = component as MeshComponent;
            _updatedMeshes.AddRange(comp.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityComponentRemoved:
          component = ev.Data[1] as Component;
          if (component is CollisionComponent)
          {
            var comp = component as CollisionComponent;
            _removedShapes.Add(comp.Shape);
          }
          else if (component is MeshComponent)
          {
            var comp = component as MeshComponent;
            _removedMeshes.AddRange(comp.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityComponentsCleared:
          entity = ev.Data[0] as Entity;
          foreach (var comp in entity.GetComponents<CollisionComponent>())
          {
            var compo = comp as CollisionComponent;
            _removedShapes.Add(compo.Shape);
          }

          foreach (var comp in entity.GetComponents<MeshComponent>())
          {
            var compo = comp as MeshComponent;
            _removedMeshes.AddRange(compo.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityMeshChanged:
          {
            MeshComponent comp = ev.Data[1] as MeshComponent;
            _updatedMeshes.AddRange(comp.GetMeshes(_currentLevel));
          }
          break;

        default:
          throw new Exception("Received event not registered for: " + ev.Name);
      }
    }

    /// <summary>
    /// Creates a transformation matrix for the given entity from its position, angle and scale components, if they exist.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The transformation matrix for this entity.</returns>
    private Matrix3x3f GetEntityTransformMatrix(Entity entity)
    {
      PositionComponent posComp = entity.GetComponent<PositionComponent>();
      AngleComponent angleComp = entity.GetComponent<AngleComponent>();
      ScaleComponent scaleComp = entity.GetComponent<ScaleComponent>();

      return
        (posComp == null ? Matrix3x3f.Identity : Matrix3x3f.Translate(posComp.Position.X, posComp.Position.Y)) *
        (angleComp == null ? Matrix3x3f.Identity : Matrix3x3f.Rotation(angleComp.Angle)) *
        (scaleComp == null ? Matrix3x3f.Identity : Matrix3x3f.Scale(scaleComp.Scale.X, scaleComp.Scale.Y));
    }

    /// <summary>
    /// Transforms a polygon using the given transformation matrix.
    /// </summary>
    /// <param name="poly">The poly to be transformed.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <returns>A copy of the poly transformed using the given matrix.</returns>
    private Vector2f[] TranformPoly(Vector2f[] poly, Matrix3x3f transform)
    {
      Vector2f[] result = new Vector2f[poly.Length];

      for (int i = 0; i < poly.Length; i++)
      {
        result[i] = transform * poly[i];
      }

      return result;
    }

    public override void Execute(Level currentLevel)
    {
      foreach (var entity in _addedEntities)
      {
        var transformMatrix = GetEntityTransformMatrix(entity);

        //TODO: Make this work. Shapes have to work just like meshes.
        var colComp = entity.GetComponent<CollisionComponent>();
        if (colComp != null)
        {
          //TODO: Transform each shape to world space
          //TODO: Add transformed shape to spatial map
          //currentLevel.SpatialShapeMap.AddOrUpdate(entity.ID, colComp.Shape, currentLevel.ShapeCache[colComp.Shape].GetShapes());
        }

        //Meshes
        var meshComps = entity.GetComponents<MeshComponent>();
        foreach (var meshComp in meshComps)
        {
          var mesh = meshComp as MeshComponent;
          foreach (var meshId in mesh.GetMeshes(currentLevel))
          {
            var meshWorldSpace = TranformPoly(currentLevel.MeshCache[meshId].Positions, transformMatrix);
            currentLevel.SpatialMeshMap.AddOrUpdate(entity.ID, meshId, meshWorldSpace);
          }
        }
      }
      _addedEntities.Clear();

      foreach (var entity in _removedEntities)
      {
        //TODO: Handle shapes

        var meshComps = entity.GetComponents<MeshComponent>();
        foreach (var meshComp in meshComps)
        {
          var mesh = meshComp as MeshComponent;
          foreach (var meshId in mesh.GetMeshes(currentLevel))
          {
            currentLevel.SpatialMeshMap.Remove(entity.ID, meshId);
          }
        }
      }
      _removedEntities.Clear();


      foreach (var mesh in _updatedMeshes)
      {
        //TODO: Transform mesh to world space, but for this I need the entity!!!
        currentLevel.SpatialMeshMap.UpdateAll(mesh, currentLevel.MeshCache[mesh].Positions);
      }
      _updatedMeshes.Clear();

      foreach (var mesh in _removedMeshes)
      {
        currentLevel.SpatialMeshMap.RemoveAll(mesh);
      }
      _removedMeshes.Clear();

      foreach (var shape in _updatedShapes)
      {
        currentLevel.SpatialShapeMap.UpdateAll(shape, currentLevel.ShapeCache[shape].GetShapes());
      }
      _updatedShapes.Clear();

      foreach (var shape in _removedShapes)
      {
        currentLevel.SpatialShapeMap.RemoveAll(shape);
      }
      _removedShapes.Clear();

      foreach (var entity in _transformedEntities)
      {
        //TODO: Implement
      }
      _transformedEntities.Clear();

      

      

    }

  }
}
