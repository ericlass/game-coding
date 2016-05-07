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
          graphics.VertexPositions = task.Mesh.Vertices.Positions;
          graphics.VertexTexCoords = task.Mesh.Vertices.TexCoords;
          graphics.VertexColors = task.Mesh.Vertices.Colors;
          graphics.PrimitiveType = task.Mesh.PrimitiveType;

          graphics.ScreenSpace = task.ScreenSpace;
          
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
