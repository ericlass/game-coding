using System;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class EntitySystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      //Submit render tasks to render queue
      foreach (var entity in currentLevel.Entities)
      {
        var imageComp = entity.GetComponent<ImageComponent>();

        if (imageComp != null && imageComp.Image != null)
        {

          var positionComp = entity.GetComponent<PositionComponent>();
          var angleComp = entity.GetComponent<AngleComponent>();
          var scaleComp = entity.GetComponent<ScaleComponent>();

          RenderTask task = new RenderTask();
          task.Translation = positionComp != null ? positionComp.Position : Vector2f.Zero;
          task.Scale = scaleComp != null ? scaleComp.Scale : Vector2f.One;
          task.Angle = angleComp != null ? angleComp.Angle : 0.0f;

          task.ScreenSpace = positionComp != null ? positionComp.ScreenSpace : false;

          task.Texture = imageComp.Image;

          float halfWidth = imageComp.Image.Width / 2.0f;
          float halfHeight = imageComp.Image.Height / 2.0f;

          Vector2f[] pos = new Vector2f[4];
          Vector2f[] tex = new Vector2f[4];

          tex[0] = new Vector2f(0, 1);
          tex[1] = new Vector2f(1, 1);
          tex[2] = new Vector2f(1, 0);
          tex[3] = new Vector2f(0, 0);
          task.TextureCoordinates = tex;

          pos[0] = new Vector2f(-halfWidth, halfHeight);
          pos[1] = new Vector2f(halfWidth, halfHeight);
          pos[2] = new Vector2f(halfWidth, -halfHeight);
          pos[3] = new Vector2f(-halfWidth, -halfHeight);
          task.VertexPositions = pos;

          var colorComp = entity.GetComponent<ColorComponent>();
          if (colorComp != null)
          {
            Color[] colors = new Color[4];
            colors[0] = colorComp.Color;
            colors[1] = colorComp.Color;
            colors[2] = colorComp.Color;
            colors[3] = colorComp.Color;
            task.VertexColors = colors;
          }

          //TODO: Set Layer
          //TODO: Set Shader

          currentLevel.RenderQueue.Add(task);
        }        
      }
    }
    
  }
}
