using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class EntitySystem : GameSystem
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
        var renderComps = entity.GetComponents<IRenderComponent>();

        if (renderComps.Count > 0)
        {
          var positionComp = entity.GetComponent<PositionComponent>();
          var angleComp = entity.GetComponent<AngleComponent>();
          var scaleComp = entity.GetComponent<ScaleComponent>();

          foreach (var comp in renderComps)
          {
            IRenderComponent renderComp = comp as IRenderComponent;

            RenderTask task;
            if (_taskCacheBG.Count > 0)
              task = _taskCacheBG.Dequeue();
            else
              task = new RenderTask();

            _taskCacheFG.Enqueue(task);

            task.Translation = positionComp != null ? positionComp.Position : Vector2f.Zero;
            task.ScreenSpace = positionComp != null ? positionComp.ScreenSpace : false;
            task.Scale = scaleComp != null ? scaleComp.Scale : Vector2f.One;
            task.Angle = angleComp != null ? angleComp.Angle : 0.0f;

            task.Mesh = renderComp.GetMesh();

            //TODO: Set Layer
            task.Layer = 0;

            //TODO: Set Shader
            task.Shader = null;

            currentLevel.RenderQueue.Add(task);
          }                    
        }        
      }
    }
    
  }
}
