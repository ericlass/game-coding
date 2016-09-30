using System;
using System.Collections.Generic;
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
        next.Engine.AddEventListener(new EventListener(EventNames.MeshCacheDataBuffered, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.MeshCacheEntryRemoved, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.ShapeCacheDataBuffered, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.ShapeCacheEntryRemoved, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.LevelEntityAdded, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.LevelEntityRemoved, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentAdded, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentRemoved, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityComponentsCleared, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityMeshChanged, OnEvent));

        next.Engine.AddEventListener(new EventListener(EventNames.EntityMoved, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityRotated, OnEvent));
        next.Engine.AddEventListener(new EventListener(EventNames.EntityScaled, OnEvent));
      }

      _currentLevel = next;
    }

    private void OnEvent(Event ev)
    {
      //TODO: Extact cases to methods
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

    public override void Execute(Level currentLevel)
    {
      foreach (var mesh in _updatedMeshes)
      {
        currentLevel.SpatialMeshMap.AddOrUpdate(0, mesh, currentLevel.MeshCache[mesh].Positions);
      }
      _updatedMeshes.Clear();

      foreach (var mesh in _removedMeshes)
      {

      }
      _removedMeshes.Clear();

      foreach (var shape in _updatedShapes)
      {

      }
      _updatedShapes.Clear();

      foreach (var shape in _removedShapes)
      {

      }
      _removedShapes.Clear();

      foreach (var entity in _transformedEntities)
      {

      }
      _transformedEntities.Clear();

      foreach (var entity in _addedEntities)
      {

      }
      _addedEntities.Clear();

      foreach (var entity in _removedEntities)
      {

      }
      _removedEntities.Clear();

    }

  }
}
