using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace OkuEngine
{
  public class ButtonWidget : Widget
  {
    private Color _currentColorLow = Color.Black;
    private Color _currentColorHigh = Color.Silver;
    private bool _focused = false;
    private bool _active = false;
    private bool _clicked = false;

    private String _text = null;
    private bool _textValid = false;
    private MeshInstance _textMesh = null;
    private Vector[] _vertices = new Vector[4];
    private Vector[] _focusRect = new Vector[4];
    private Color[] _colors = new Color[4];

    public String Text
    {
      get { return _text; }
      set 
      { 
        _text = value;
        _textValid = false;
      }
    }

    public override Quad Area
    {
      set
      {
        base.Area = value;
        //If area is changed, recalculate vertices
        _vertices[0] = Area.Min;
        _vertices[1] = new Vector(Area.Min.X, Area.Max.Y);
        _vertices[2] = Area.Max;
        _vertices[3] = new Vector(Area.Max.X, Area.Min.Y);

        float inset = 3;
        _focusRect[0] = new Vector(Area.Min.X + inset, Area.Min.Y + inset);
        _focusRect[1] = new Vector(Area.Min.X + inset, Area.Max.Y - inset);
        _focusRect[2] = new Vector(Area.Max.X - inset, Area.Max.Y - inset);
        _focusRect[3] = new Vector(Area.Max.X - inset, Area.Min.Y + inset);
      }
    }

    public bool Clicked
    {
      get { return _clicked; }
      set { _clicked = value; }
    }

    public override void Init()
    {
      _currentColorHigh = Container.ColorMap.WidgetHigh;
      _currentColorLow = Container.ColorMap.WidgetLow;
    }

    public override void Update(float dt)
    {
      _clicked = false;
    }

    private MeshInstance GetTextMesh()
    {
      if (!_textValid || _textMesh == null)
      {
        _textMesh = Container.Font.GetStringMesh(_text, 0, 0, Container.ColorMap.FontHigh);
        OkuMath.CenterAt(_textMesh.Vertices.Positions, Area.GetCenter());
        _textValid = true;
      }
      return _textMesh;
    }

    public override void Render()
    {
      _colors[0] = _currentColorLow;
      _colors[1] = _currentColorHigh;
      _colors[2] = _currentColorHigh;
      _colors[3] = _currentColorLow;

      OkuDrivers.Renderer.DrawMesh(_vertices, null, _colors, _vertices.Length, MeshMode.Quads, null);
      OkuDrivers.Renderer.DrawLines(_vertices, Container.ColorMap.BorderHigh, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);
      
      GetTextMesh().Draw();

      if (_focused)
        OkuDrivers.Renderer.DrawLines(_focusRect, Container.ColorMap.FontLow, _focusRect.Length, 0.5f, VertexInterpretation.PolygonClosed);
    }

    public override void MouseEnter()
    {
      if (!_active)
      {
        _currentColorHigh = Container.ColorMap.HotHigh;
        _currentColorLow = Container.ColorMap.HotLow;
      }
    }

    public override void MouseLeave()
    {
      if (!_active)
      {
        _currentColorHigh = Container.ColorMap.WidgetHigh;
        _currentColorLow = Container.ColorMap.WidgetLow;
      }
    }

    public override void MouseDown(MouseButton button)
    {
      _currentColorHigh = Container.ColorMap.ActiveHigh;
      _currentColorLow = Container.ColorMap.ActiveLow;
    }

    public override void MouseUp(MouseButton button)
    {
      _currentColorHigh = Container.ColorMap.HotHigh;
      _currentColorLow = Container.ColorMap.HotLow;
      _clicked = _active;
    }

    public override void KeyDown(Keys key)
    {
    }

    public override void KeyUp(System.Windows.Forms.Keys key)
    {
    }

    public override void Activate()
    {
      _active = true;
    }

    public override void Deactivate()
    {
      _active = false;
      _currentColorHigh = Container.ColorMap.WidgetHigh;
      _currentColorLow = Container.ColorMap.WidgetLow;
    }

    public override void Focus()
    {
      _focused = true;
    }

    public override void Unfocus()
    {
      _focused = false;
    }
  }
}
