using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class RenderSystem : GameSystem
  {
    public override void Init()
    {
      //TODO: Init required?
    }

    public override void Execute(Level currentLevel)
    {
      GraphicsManager graphics = OkuManager.Instance.Graphics;

      foreach (var entity in currentLevel.Entities)
      {
        var transform = entity.GetComponent<TransformComponent>();
        if (transform != null)
          graphics.ApplyAndPushTransform(transform.Translation, transform.Scale, transform.Rotation);

        Color tint = Color.White;

        var vcolor = entity.GetComponent<VertexColorComponent>();
        if (vcolor != null)
          tint = vcolor.Color;

        var image = entity.GetComponent<ImageComponent>();
        if (image != null)
          graphics.DrawImage(image.Image, 0, 0, tint);

        if (transform != null)
          graphics.PopTransform();
      }
    }

    public override void Finish()
    {
      //TODO: Finish required?
    }

  }
}
