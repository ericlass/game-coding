using System;
using System.Collections.Generic;
using OkuMath;
using OkuBase.Graphics;

namespace OkuEngine.Systems
{
  /// <summary>
  /// Defines a single render task with all required data to render something.
  /// </summary>
  public class RenderTask
  {
    private Vector2f _scale = Vector2f.One;

    public Vector2f Translation { get; set; }

    public Vector2f Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public float Angle { get; set; }

    public Vector2f[] VertexPositions { get; set; }
    public Vector2f[] TextureCoordinates { get; set; }
    public Color[] VertexColors { get; set; }

    public ImageBase Texture { get; set; }
    public ShaderProgram Shader { get; set; }
    
    public int Layer { get; set; }
    public bool ScreenSpace { get; set; }

  }
}
