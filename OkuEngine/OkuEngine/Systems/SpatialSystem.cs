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
    private Dictionary<int, SortedSet<int>> _entityShapeMap = new Dictionary<int, SortedSet<int>>();
    private Dictionary<int, SortedSet<int>> _entityMeshMap = new Dictionary<int, SortedSet<int>>();

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

        next.Engine.AddEventListener(new EventListener(EventNames.EntityMeshExchanged, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityShapeExchanged, OnEvent));

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
          if (entity.ContainsComponent<ShapeComponent>() || entity.ContainsComponent<MeshComponent>())
            _addedEntities.Add(entity);
          break;

        case EventNames.LevelEntityRemoved:
          entity = ev.Data[0] as Entity;
          if (entity.ContainsComponent<ShapeComponent>() || entity.ContainsComponent<MeshComponent>())
            _removedEntities.Add(entity);
          break;

        case EventNames.EntityComponentAdded:
          var component = ev.Data[1] as Component;
          if (component is ShapeComponent)
          {
            var comp = component as ShapeComponent;
            _updatedShapes.AddRange(comp.GetShapes(_currentLevel));
          }
          else if (component is MeshComponent)
          {
            var comp = component as MeshComponent;
            _updatedMeshes.AddRange(comp.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityComponentRemoved:
          component = ev.Data[1] as Component;
          if (component is ShapeComponent)
          {
            var comp = component as ShapeComponent;
            _removedShapes.AddRange(comp.GetShapes(_currentLevel));
          }
          else if (component is MeshComponent)
          {
            var comp = component as MeshComponent;
            _removedMeshes.AddRange(comp.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityComponentsCleared:
          entity = ev.Data[0] as Entity;
          foreach (var comp in entity.GetComponents<ShapeComponent>())
          {
            var compo = comp as ShapeComponent;
            _removedShapes.AddRange(compo.GetShapes(_currentLevel));
          }

          foreach (var comp in entity.GetComponents<MeshComponent>())
          {
            var compo = comp as MeshComponent;
            _removedMeshes.AddRange(compo.GetMeshes(_currentLevel));
          }
          break;

        case EventNames.EntityMeshExchanged:
          {
            _removedMeshes.AddRange(ev.Data[2] as int[]);
            _updatedMeshes.AddRange(ev.Data[3] as int[]);
          }
          break;

        case EventNames.EntityShapeExchanged:
          {
            _removedShapes.AddRange(ev.Data[2] as int[]);
            _updatedShapes.AddRange(ev.Data[3] as int[]);
          }
          break;

        default:
          throw new Exception("Received event not registered for: " + ev.Name);
      }
    }

    public override void Execute(Level currentLevel)
    {
      //Removed entities
      foreach (var entity in _removedEntities)
      {
        foreach (var shapeComp in entity.GetComponents<ShapeComponent>())
        {
          foreach (var shapeId in (shapeComp as ShapeComponent).GetShapes(currentLevel))
          {
            currentLevel.SpatialShapeMap.Remove(entity.ID, shapeId);
            if (_entityShapeMap.ContainsKey(shapeId))
            {
              var entityList = _entityShapeMap[shapeId];
              entityList.Remove(entity.ID);
              if (entityList.Count <= 0)
                _entityShapeMap.Remove(shapeId);
            }
          }
        }

        foreach (var meshComp in entity.GetComponents<MeshComponent>())
        {
          foreach (var meshId in (meshComp as MeshComponent).GetMeshes(currentLevel))
          {
            currentLevel.SpatialMeshMap.Remove(entity.ID, meshId);
            if (_entityMeshMap.ContainsKey(meshId))
            {
              var meshList = _entityMeshMap[meshId];
              meshList.Remove(entity.ID);
              if (meshList.Count <= 0)
                _entityMeshMap.Remove(meshId);
            }
          }
        }
      }
      _removedEntities.Clear();


      // Added entities
      foreach (var entity in _addedEntities)
      {
        var transformMatrix = currentLevel.Engine.GetEntityTransformMatrix(entity);

        //Shapes
        foreach (var shapeComp in entity.GetComponents<ShapeComponent>())
        {
          foreach (var shapeId in (shapeComp as ShapeComponent).GetShapes(currentLevel))
          {
            var shapeWorldSpace = currentLevel.Engine.TransformPoly(currentLevel.ShapeCache[shapeId], transformMatrix);
            currentLevel.SpatialShapeMap.AddOrUpdate(entity.ID, shapeId, shapeWorldSpace);

            if (_entityShapeMap.ContainsKey(shapeId))
              _entityShapeMap[shapeId].Add(entity.ID);
            else
              _entityShapeMap.Add(shapeId, new SortedSet<int>() { entity.ID });
          }
        }

        //Meshes
        foreach (var meshComp in entity.GetComponents<MeshComponent>())
        {
          foreach (var meshId in (meshComp as MeshComponent).GetMeshes(currentLevel))
          {
            var meshWorldSpace = currentLevel.Engine.TransformPoly(currentLevel.MeshCache[meshId].Positions, transformMatrix);
            currentLevel.SpatialMeshMap.AddOrUpdate(entity.ID, meshId, meshWorldSpace);

            if (_entityMeshMap.ContainsKey(meshId))
              _entityMeshMap[meshId].Add(entity.ID);
            else
              _entityMeshMap.Add(meshId, new SortedSet<int>() { entity.ID });
          }
        }
      }
      _addedEntities.Clear();


      //Removed meshes
      foreach (var mesh in _removedMeshes)
      {
        currentLevel.SpatialMeshMap.RemoveAll(mesh);
      }
      _removedMeshes.Clear();


      //Updated meshes
      foreach (var meshId in _updatedMeshes)
      {
        foreach (var entityId in _entityMeshMap[meshId])
        {
          var transform = currentLevel.Engine.GetEntityTransformMatrix(currentLevel.Entities[entityId]);
          var transformedMesh = currentLevel.Engine.TransformPoly(currentLevel.MeshCache[meshId].Positions, transform);
          currentLevel.SpatialMeshMap.AddOrUpdate(entityId, meshId, transformedMesh);
        }
      }
      _updatedMeshes.Clear();


      //Removed shapes
      foreach (var shape in _removedShapes)
      {
        currentLevel.SpatialShapeMap.RemoveAll(shape);
      }
      _removedShapes.Clear();


      //Updates shapes
      foreach (var shapeId in _updatedShapes)
      {
        foreach (var entityId in _entityShapeMap[shapeId])
        {
          var transform = currentLevel.Engine.GetEntityTransformMatrix(currentLevel.Entities[entityId]);
          var transformedShape = currentLevel.Engine.TransformPoly(currentLevel.ShapeCache[shapeId], transform);
          currentLevel.SpatialShapeMap.AddOrUpdate(entityId, shapeId, transformedShape);
        }
      }
      _updatedShapes.Clear();


      //Transformed entities
      foreach (var entity in _transformedEntities)
      {
        var transform = currentLevel.Engine.GetEntityTransformMatrix(entity);

        foreach (var shapeComp in entity.GetComponents<ShapeComponent>())
        {
          foreach (var shapeId in (shapeComp as ShapeComponent).GetShapes(currentLevel))
          {
            var tranformedShape = currentLevel.Engine.TransformPoly(currentLevel.ShapeCache[shapeId], transform);
            currentLevel.SpatialShapeMap.AddOrUpdate(entity.ID, shapeId, tranformedShape);
          }

          foreach (var meshComp in entity.GetComponents<MeshComponent>())
          {
            foreach (var meshId in (meshComp as MeshComponent).GetMeshes(currentLevel))
            {
              var transformedMesh = currentLevel.Engine.TransformPoly(currentLevel.MeshCache[meshId].Positions, transform);
              currentLevel.SpatialMeshMap.AddOrUpdate(entity.ID, meshId, transformedMesh);
            }            
          }
        }
      }
      _transformedEntities.Clear();

    }

  }
}
