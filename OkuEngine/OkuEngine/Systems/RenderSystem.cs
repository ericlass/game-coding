using System;
using System.Collections.Generic;
using OkuMath;
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
        var positionComp = entity.GetComponent<PositionComponent>();
        var angleComp = entity.GetComponent<AngleComponent>();
        var scaleComp = entity.GetComponent<ScaleComponent>();

        bool hasTransform = positionComp != null || angleComp != null || scaleComp != null;
        bool isScreenSpace = positionComp != null && positionComp.ScreenSpace;

        if (hasTransform)
        {
          Vector2f pos = positionComp == null ? Vector2f.Zero : positionComp.Position;
          float angle = angleComp == null ? 0.0f : angleComp.Angle;
          Vector2f scale = scaleComp == null ? Vector2f.One : scaleComp.Scale;

          if (isScreenSpace)
            graphics.BeginScreenSpace();

          graphics.ApplyAndPushTransform(pos, scale, angle);
        }

        Color tint = Color.White;

        var vcolor = entity.GetComponent<ColorComponent>();
        if (vcolor != null)
          tint = vcolor.Color;

        var image = entity.GetComponent<ImageComponent>();
        if (image != null)
          graphics.DrawImage(image.Image, 0, 0, tint);

        if (hasTransform)
          graphics.PopTransform();

        if (isScreenSpace)
          graphics.EndScreenSpace();
      }
    }

    public override void Finish()
    {
      //TODO: Finish required?
    }

  }
}
