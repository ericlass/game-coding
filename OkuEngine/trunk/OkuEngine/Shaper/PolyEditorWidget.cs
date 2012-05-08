using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Shaper
{
  public class PolyEditorWidget : Widget
  {
    private DynamicArray<Vector> _points = new DynamicArray<Vector>();
    private bool _showPoints = true;
    private Color _pointColor = Color.Red;
    private Color _lineColor = Color.Blue;

    private Vector _viewOffset = Vector.Zero;
    private float _viewScale = 1.0f;

    private Vector _mousePos = Vector.Zero;

    private bool _panning = false;
    private Vector _dragStart = Vector.Zero;
    private Vector _dragOrigin = Vector.Zero;

    private bool _hot = false;
    

    private Vector[] _vertices = new Vector[4];

    public DynamicArray<Vector> Points
    {
      get { return _points; }
      set { _points = value; }
    }
    
    public Color LineColor
    {
      get { return _lineColor; }
      set { _lineColor = value; }
    }
    
    public Color PointColor
    {
      get { return _pointColor; }
      set { _pointColor = value; }
    }
    
    public bool ShowPoints
    {
      get { return _showPoints; }
      set { _showPoints = value; }
    }

    protected override void AreaChange()
    {
      _vertices[0] = new Vector(Area.Min.X, Area.Max.Y);
      _vertices[1] = Area.Max;
      _vertices[2] = new Vector(Area.Max.X, Area.Min.Y);
      _vertices[3] = Area.Min;
    }

    private Vector ClientToPoly(Vector point)
    {
      return (point - _viewOffset) / _viewScale;
    }

    private Vector PolyToClient(Vector point)
    {
      return (point * _viewScale) + _viewOffset;
    }

    private Vector DisplayToPoly(Vector point)
    {
      return ClientToPoly(point - Area.Min);
    }

    private Vector PolyToDisplay(Vector point)
    {
      return PolyToClient(point) + Area.Min;
    }

    public override void Update(float dt)
    {
      Vector mouse = OkuDrivers.Renderer.ScreenToDisplay(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
      _mousePos = DisplayToPoly(mouse);

      if (_panning)
      {
        _viewOffset = _dragOrigin + (mouse - _dragStart);
      }
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);
      if (_hot)
        OkuDrivers.Renderer.DrawPoint(PolyToDisplay(_mousePos), 4.0f, Color.Red);

      OkuDrivers.Renderer.DrawLine(PolyToDisplay(Vector.Zero), PolyToDisplay(new Vector(25, 0)), 1.0f, Color.Red);
      OkuDrivers.Renderer.DrawLine(PolyToDisplay(Vector.Zero), PolyToDisplay(new Vector(0, 25)), 1.0f, Color.Green);
    }

    public override void MouseEnter()
    {
      _hot = true;
    }

    public override void MouseLeave()
    {
      _hot = false;
    }

    public override void MouseDown(MouseButton button)
    {
      if (!_panning && button == MouseButton.Middle)
      {
        _panning = true;
        _dragStart = OkuDrivers.Renderer.ScreenToDisplay(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
        _dragOrigin = _viewOffset;
      }
    }

    public override void MouseUp(MouseButton button)
    {
      if (_panning && button == MouseButton.Middle)
      {
        _panning = false;
      }
    }

    public override void MouseWheel(float delta)
    {
      _viewScale *= 1.0f + (delta / 10.0f);
    }

  }
}
