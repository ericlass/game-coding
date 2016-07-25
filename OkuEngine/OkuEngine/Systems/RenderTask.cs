using System;
using System.Collections.Generic;
using OkuMath;
using OkuEngine.Assets;

namespace OkuEngine.Systems
{
  /// <summary>
  /// Defines a single render task with all required data to render something.
  /// </summary>
  public class RenderTask
  {
    public RenderTask()
    {
      Scale = Vector2f.One;
    }

    public int Mesh { get; set; }
    public int Material { get; set; }

    public Vector2f Translation { get; set; }
    public Vector2f Scale { get; set; }
    public float Angle { get; set; }

    public int Layer { get; set; }
    public bool ScreenSpace { get; set; }
  }
}
