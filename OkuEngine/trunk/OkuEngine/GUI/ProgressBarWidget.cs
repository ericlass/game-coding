using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  /// <summary>
  /// Defines a widget that displays a progress as a bar graph.
  /// </summary>
  public class ProgressBarWidget : Widget
  {
    private float _min = 0;
    private float _max = 100;
    private float _position = 0;

    private Vector2f[] _vertices = new Vector2f[4];
    private Vector2f[] _progressRect = new Vector2f[4];
    private Color[] _colors = new Color[4];

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    public float Min
    {
      get { return _min; }
      set { _min = value; }
    }    

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    public float Max
    {
      get { return _max; }
      set { _max = value; }
    }
    
    /// <summary>
    /// Gets or sets the current position. Min &lt;= Position &lt;= Max.
    /// </summary>
    public float Position
    {
      get { return _position; }
      set { _position = value; }
    }

    protected override void AreaChange()
    {
      //If area is changed, recalculate vertices
      _vertices[0] = Vector2f.Zero;
      _vertices[1] = new Vector2f(0, Area.Height);
      _vertices[2] = new Vector2f(Area.Width, Area.Height);
      _vertices[3] = new Vector2f(Area.Width, 0);
    }

    /// <summary>
    /// Renders the progress bar.
    /// </summary>
    public override void Render(Canvas canvas)
    {
      _colors[0] = Container.ColorMap.WidgetLight;
      _colors[1] = Container.ColorMap.WidgetDark;
      _colors[2] = Container.ColorMap.WidgetDark;
      _colors[3] = Container.ColorMap.WidgetLight;

      canvas.DrawMesh(_vertices, null, _colors, _vertices.Length, MeshMode.Quads, null);

      if (_position > _min)
      {
        float ratio = _position / _max;
        float right = Area.Width * ratio;

        _progressRect[0] = _vertices[0];
        _progressRect[1] = _vertices[1];
        _progressRect[2] = new Vector2f(right, Area.Height);
        _progressRect[3] = new Vector2f(right, 0);

        _colors[0] = Container.ColorMap.ActiveDark;
        _colors[1] = Container.ColorMap.ActiveLight;
        _colors[2] = Container.ColorMap.ActiveLight;
        _colors[3] = Container.ColorMap.ActiveDark;

        canvas.DrawMesh(_progressRect, null, _colors, _progressRect.Length, MeshMode.Quads, null);
      }

      canvas.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);
    }

  }
}
