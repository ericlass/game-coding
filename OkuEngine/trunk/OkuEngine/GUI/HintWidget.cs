using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  /// <summary>
  /// Defines a widget that shows a hint.
  /// </summary>
  public class HintWidget : LabelWidget
  {
    private Vector2f[] _vertices = new Vector2f[4];
    private Color[] _colors = new Color[4];

    /// <summary>
    /// Gets the color of the font.
    /// </summary>
    /// <returns>The color of the font.</returns>
    protected override Color GetFontColor()
    {
      return Container.ColorMap.FontDark;
    }

    protected override void AreaChange()
    {
      base.AreaChange();

      Vector2f min, max;
      OkuMath.BoundingBox(GetTextMesh().Vertices.Positions, out min, out max);
      const float border = 4;
      min.X -= border;
      min.Y -= border;
      max.X += border;
      max.Y += border;

      _vertices[0] = min;
      _vertices[1].X = min.X;
      _vertices[1].Y = max.Y;
      _vertices[2] = max;
      _vertices[3].X = max.X;
      _vertices[3].Y = min.Y;
    }

    public override void Render(Canvas canvas)
    {
      _colors[0] = Container.ColorMap.WindowLight;
      _colors[1] = Container.ColorMap.WindowLight;
      _colors[2] = Container.ColorMap.WindowLight;
      _colors[3] = Container.ColorMap.WindowLight;

      canvas.DrawMesh(_vertices, null, _colors, _vertices.Length, MeshMode.Quads, null);
      canvas.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);

      base.Render(canvas);
    }
  }
}
