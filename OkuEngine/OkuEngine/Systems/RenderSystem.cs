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
        graphics.VertexPositions = currentLevel.RenderQueue[0].Mesh.Vertices.Positions;
        graphics.VertexTexCoords = currentLevel.RenderQueue[0].Mesh.Vertices.TexCoords;
        graphics.PrimitiveType = PrimitiveType.TriangleStrip;

        //Iterate render queue and execute render tasks
        foreach (var task in currentLevel.RenderQueue)
        {
          graphics.ScreenSpace = task.ScreenSpace;
          graphics.VertexColors = task.Mesh.Vertices.Colors;

          graphics.PushTransform();

          graphics.Translation = task.Translation;
          graphics.Scale = task.Scale;
          graphics.Angle = task.Angle;

          graphics.Draw(0, task.Mesh.Vertices.Positions.Length);

          graphics.PopTransform();
        }
      }
      finally
      {
        currentLevel.RenderQueue.Clear();
      }
    }

  }
}
