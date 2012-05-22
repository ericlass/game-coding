using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Shaper
{
  public class PolyEditorWidget : Widget
  {
    private DynamicArray<Vector> _points = new DynamicArray<Vector>();
    private DynamicArray<Vector> _pointsForDrawing = new DynamicArray<Vector>();
    private bool _showPoints = true;
    private Color _pointColor = Color.Red;
    private Color _lineColor = Color.Blue;
    private int _hotPoint = -1;

    private Vector _cutPoint = Vector.Zero;
    private Vector _cutNormal = Vector.Zero;
    private int _cutIndex = -1;

    private ImageContent _backgroundImage = null;

    private bool _offsetUserChanges = false;
    private Vector _viewOffset = Vector.Zero;
    private float _viewScale = 1.0f;

    private Vector _mousePos = Vector.Zero;

    private bool _dragging = false;
    private bool _panning = false;
    private Vector _dragStart = Vector.Zero;
    private Vector _dragOrigin = Vector.Zero;

    private bool _selecting = false;
    private Vector _selectionStart = Vector.Zero;
    private Vector _selectionEnd = Vector.Zero;
    private List<int> _selectedPoints = new List<int>();

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

    public ImageContent BackgroundImage
    {
      get { return _backgroundImage; }
      set { _backgroundImage = value; }
    }

    protected override void AreaChange()
    {
      _vertices[0] = Vector.Zero;
      _vertices[1] = new Vector(0, Area.Height);
      _vertices[2] = new Vector(Area.Width, Area.Height);
      _vertices[3] = new Vector(Area.Width, 0);

      if (!_offsetUserChanges)
      {
        _viewOffset.X = Area.Width / 2.0f;
        _viewOffset.Y = Area.Height / 2.0f;
      }
    }

    private Vector ClientToPoly(Vector point)
    {
      return (point - _viewOffset) / _viewScale;
    }

    private Vector PolyToClient(Vector point)
    {
      return (point * _viewScale) + _viewOffset;
    }

    public override void Update(float dt)
    {
      _mousePos = MousePosition;
      Vector mousePoly = ClientToPoly(_mousePos);

      if (_panning)
      {
        _viewOffset = _dragOrigin + (_mousePos - _dragStart);
        _offsetUserChanges = true;
      }

      if (_dragging)
      {
        _points[_hotPoint] = mousePoly;
      }
      else
      {
        float dist = 0;
        int p = _points.InternalArray.ClosestPoint(mousePoly, out dist);
        if (p >= 0 && (dist * _viewScale) < 5.0f)
          _hotPoint = p;
        else
          _hotPoint = -1;
      }

      _cutPoint = Vector.Zero;
      _cutIndex = -1;
      if (_hotPoint < 0)
      {
        float dist = float.MaxValue;
        for (int i = 0; i < _points.Count; i++)
        {
          int j = (i + 1) % _points.Count;
          Vector line = _points[j] - _points[i];
          Vector mp = mousePoly - _points[i];
          float projection = line.ProjectScalar(mp);
          if (projection >= 0.0f && projection <= 1.0f)
          {
            Vector projected = line * projection;
            float d = (mp - projected).Magnitude;
            if (d < 4.0f && d < dist)
            {
              dist = d;
              _cutIndex = i;
              _cutPoint = projected + _points[i];
              _cutNormal = line.GetNormal();
            }
          }
        }
      }

      if (_selecting)
      {
        _selectionEnd = MousePosition;
      }
    }

    public override void Render(Canvas canvas)
    {
      canvas.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);

      if (_backgroundImage != null)
      {
        canvas.DrawImage(_backgroundImage, PolyToClient(Vector.Zero), new Vector(_viewScale, _viewScale));
      }

      if (_hot)
        canvas.DrawPoint(_mousePos, 4.0f, Color.Red);

      canvas.DrawLine(PolyToClient(Vector.Zero), PolyToClient(new Vector(25, 0)), 1.0f, Color.Red);
      canvas.DrawLine(PolyToClient(Vector.Zero), PolyToClient(new Vector(0, 25)), 1.0f, Color.Green);

      //Translate points to client space
      _pointsForDrawing.Clear();
      for (int i = 0; i < _points.Count; i++)
        _pointsForDrawing.Add(PolyToClient(_points[i]));

      canvas.DrawLines(_pointsForDrawing.InternalArray, _lineColor, _pointsForDrawing.Count, 1.0f, VertexInterpretation.PolygonClosed);
      canvas.DrawPoints(_pointsForDrawing.InternalArray, _pointColor, _pointsForDrawing.Count, 4.0f);

      if (_hotPoint >= 0)
        canvas.DrawPoint(_pointsForDrawing[_hotPoint], 4.0f, Color.Yellow);

      if (_cutIndex >= 0)
      {
        Vector cutP = PolyToClient(_cutPoint);
        canvas.DrawPoint(cutP, 3.0f, Color.Yellow);
        canvas.DrawLine(cutP + (_cutNormal * 5), cutP - (_cutNormal * 5), 1.0f, Color.Yellow);
      }

      if (_selecting)
      {
        canvas.FillRect(_selectionStart, _selectionEnd, new Color(255, 255, 0, 64));
      }

      foreach (int sel in _selectedPoints)
      {
        canvas.DrawPoint(PolyToClient(_points[sel]), 4.0f, Color.Green);
      }
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
        _dragStart = MousePosition;
        _dragOrigin = _viewOffset;
      }
      else if (button == MouseButton.Left)
      {
        if (_hotPoint >= 0 && !_dragging)
        {
          _dragging = true;
        }
        else if (_cutIndex >= 0)
        {
          _points.Insert(_cutPoint, _cutIndex + 1);
          _dragging = true;
          _hotPoint = _cutIndex + 1;
        }
        else
        {
          _points.Add(ClientToPoly(MousePosition));
          _dragging = true;
          _hotPoint = _points.Count - 1;
        }
      }
      else if (button == MouseButton.Right)
      {
        bool ctrl = OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.ControlKey);
        if (!ctrl)
          _selectedPoints.Clear();

        if (_hotPoint >= 0)
        {
          _selectedPoints.Add(_hotPoint);
        }
        else if (_cutIndex >= 0)
        {
          _selectedPoints.Add(_cutIndex);
          _selectedPoints.Add((_cutIndex + 1) % _points.Count);
        }
        _selecting = true;
        _selectionStart = MousePosition;
        _selectionEnd = MousePosition;
      }
    }

    public override void MouseUp(MouseButton button)
    {
      if (_panning && button == MouseButton.Middle)
      {
        _panning = false;
      }
      else if (_dragging && button == MouseButton.Left)
      {
        _dragging = false;
      }
      else if (_selecting && button == MouseButton.Right)
      {
        _selecting = false;
        Vector minPoly = new Vector(Math.Min(_selectionStart.X, _selectionEnd.X), Math.Min(_selectionStart.Y, _selectionEnd.Y));
        Vector maxPoly = new Vector(Math.Max(_selectionStart.X, _selectionEnd.X), Math.Max(_selectionStart.Y, _selectionEnd.Y));
        minPoly = ClientToPoly(minPoly);
        maxPoly = ClientToPoly(maxPoly);
        for (int i = 0; i < _points.Count; i++)
        {
          if (Intersections.PointInAABB(_points[i], minPoly, maxPoly))
            _selectedPoints.Add(i);
        }
      }
    }

    public override void MouseWheel(float delta)
    {
      //Zoom in/out to the point where the mouse is
      Vector posBefore = ClientToPoly(MousePosition);
      _viewScale *= 1.0f + (delta / 10.0f);
      Vector posAfter = ClientToPoly(MousePosition);
      _viewOffset += (posAfter - posBefore) * _viewScale;
    }

    public override void KeyDown(System.Windows.Forms.Keys key)
    {
      bool ctrl = OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.ControlKey);

      if (key == System.Windows.Forms.Keys.Delete)
      {
        _selectedPoints.Sort();
        for (int i = _selectedPoints.Count - 1; i >= 0; i--)
        {
          _points.Delete(_selectedPoints[i]);
        }
        _selectedPoints.Clear();
      }
      else if (key == System.Windows.Forms.Keys.A)
      {
        if (ctrl)
        {
          _selectedPoints.Clear();
          for (int i = 0; i < _points.Count; i++)
          {
            _selectedPoints.Add(i);
          }
        }
      }
    }

  }
}
