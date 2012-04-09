using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace OkuEngine
{
  public class ButtonWidget : Widget
  {
    private const float _blendTime = 0.2f;
    private float _currentTime = 0.0f;
    private Color _startColor = Color.Black;
    private Color _endColor = new Color(71, 71, 71);
    private Color _currentColor = new Color(71, 71, 71);

    private bool _focused = false;

    private String _text = null;
    private bool _textValid = false;
    private MeshInstance _textMesh = null;

    private Color _color = new Color(71, 71, 71);
    private Color _hotColor = new Color(101, 101, 101);
    private Color _fontColor = Color.White;
    private Color _borderColor = new Color(31, 31, 31);
    private Color _activeColor = Color.Blend(new Color(101, 101, 101), Color.Blue, 0.5f);

    public Color ActiveColor
    {
      get { return _activeColor; }
      set { _activeColor = value; }
    }

    public Color BorderColor
    {
      get { return _borderColor; }
      set { _borderColor = value; }
    }

    public Color HotColor
    {
      get { return _hotColor; }
      set { _hotColor = value; }
    }    

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public float BlendTime
    {
      get { return _blendTime; }
    }

    public String Text
    {
      get { return _text; }
      set 
      { 
        _text = value;
        _textValid = false;
      }
    }

    public override void Update(float dt)
    {
      if (_currentTime > 0.0f)
      {
        _currentTime -= dt;
        float ratio = 1.0f - (_currentTime / _blendTime);
        _currentColor = Color.Blend(_startColor, _endColor, ratio);
      }
      else
      {
        _currentColor = _endColor;
      }
    }

    private MeshInstance GetTextMesh()
    {
      if (!_textValid || _textMesh == null)
      {
        _textMesh = Container.Font.GetStringMesh(_text, 0, 0, _fontColor);
        OkuMath.CenterAt(_textMesh.Vertices.Positions, Area.GetCenter());
        _textValid = true;
      }
      return _textMesh;
    }

    public override void Render()
    {
      Vector[] vertices = new Vector[] { Area.Min, new Vector(Area.Min.X, Area.Max.Y), Area.Max, new Vector(Area.Max.X, Area.Min.Y) };
      Color[] colors = new Color[] { _currentColor, _currentColor, _currentColor, _currentColor };
      OkuDrivers.Renderer.DrawMesh(vertices, null, colors, vertices.Length, MeshMode.Quads, null);
      OkuDrivers.Renderer.DrawLines(vertices, _borderColor, vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);

      GetTextMesh().Draw();
    }

    public override void MouseEnter()
    {
      _startColor = _currentColor;
      _endColor = _hotColor;
      _currentTime = _blendTime;
    }

    public override void MouseLeave()
    {
      _startColor = _currentColor;
      _endColor = _color;
      _currentTime = _blendTime;
    }

    public override void MouseDown(MouseButton button)
    {
      _startColor = _currentColor;
      _endColor = _activeColor;
      _currentTime = _blendTime;
    }

    public override void MouseUp(MouseButton button)
    {
      _startColor = _currentColor;
      _endColor = _hotColor;
      _currentTime = _blendTime;
    }

    public override void KeyDown(Keys key)
    {
    }

    public override void KeyUp(System.Windows.Forms.Keys key)
    {
    }

    public override void Activate()
    {
    }

    public override void Deactivate()
    {
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
