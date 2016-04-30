using System;
using OkuBase;
using OkuBase.Graphics;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class RenderSystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      GraphicsManager graphics = OkuManager.Instance.Graphics;

      try
      {
        //Iterate render queue and execute render tasks
        foreach (var task in currentLevel.RenderQueue)
        {
          if (task.ScreenSpace)
            graphics.BeginScreenSpace();

          graphics.ApplyAndPushTransform(task.Translation, task.Scale, task.Angle);

          graphics.DrawMesh(task.VertexPositions, task.TextureCoordinates, task.VertexColors, task.VertexPositions.Length, PrimitiveType.Quads, task.Texture);

          graphics.PopTransform();

          if (task.ScreenSpace)
            graphics.EndScreenSpace();
        }
      }
      finally
      {
        currentLevel.RenderQueue.Clear();
      }
    }

  }
}
