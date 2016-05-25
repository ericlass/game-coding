using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Assets;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class EntityRenderSystem : GameSystem
  {
    private Queue<RenderTask> _taskCacheFG = new Queue<RenderTask>();
    private Queue<RenderTask> _taskCacheBG = new Queue<RenderTask>();

    public override void Execute(Level currentLevel)
    {
      var temp = _taskCacheBG;
      _taskCacheBG = _taskCacheFG;
      _taskCacheFG = temp;
      _taskCacheFG.Clear();

      //Submit render tasks to render queue
      foreach (var entity in currentLevel.Entities)
      {
        var meshComps = entity.GetComponents<MeshComponent>();

        if (meshComps.Count > 0)
        {
          var positionComp = entity.GetComponent<PositionComponent>();
          var angleComp = entity.GetComponent<AngleComponent>();
          var scaleComp = entity.GetComponent<ScaleComponent>();
          var materialComp = entity.GetComponent<MaterialComponent>();

          Vector2f translation = positionComp != null ? positionComp.Position : Vector2f.Zero;
          bool screenSpace = positionComp != null ? positionComp.ScreenSpace : false;
          Vector2f scale = scaleComp != null ? scaleComp.Scale : Vector2f.One;
          float angle = angleComp != null ? angleComp.Angle : 0.0f;

          AssetHandle material = materialComp != null ? materialComp.Material : null;

          foreach (var comp in meshComps)
          {
            MeshComponent meshComp = comp as MeshComponent;

            foreach (var mesh in meshComp.GetMeshes(currentLevel))
            {
              RenderTask task;
              if (_taskCacheBG.Count > 0)
                task = _taskCacheBG.Dequeue();
              else
                task = new RenderTask();

              _taskCacheFG.Enqueue(task);

              task.Translation = translation;
              task.Scale = scale;
              task.Angle = angle;
              task.ScreenSpace = screenSpace;

              task.Mesh = mesh;
              task.Material = material;

              //TODO: Set Layer
              task.Layer = 0;

              currentLevel.RenderQueue.Add(task);
            }
          }
        }
      }

    }
    
  }
}
