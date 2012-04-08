using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ButtonWidget : Widget
  {
    private const float _blendTime = 0.2f;
    private float _currentTime = 0.0f;
    private Color _startColor = Color.Black;
    private Color _endColor = Color.Blue;
    private Color _currentColor = Color.Blue;
    private bool _focused = false;

    private Color _color = Color.Blue;
    private Color _hotColor = Color.Cyan;
    private Color _activeColor = Color.Red;

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

    public override void Render()
    {
      Vector[] vertices = new Vector[] { Area.Min, new Vector(Area.Min.X, Area.Max.Y), Area.Max, new Vector(Area.Max.X, Area.Min.Y) };
      Color[] colors = new Color[] { _currentColor, _currentColor, _currentColor, _currentColor };
      OkuDrivers.Renderer.DrawMesh(vertices, null, colors, vertices.Length, MeshMode.Quads, null);

      if (_focused)
        OkuDrivers.Renderer.DrawLines(vertices, Color.Magenta, vertices.Length, 2.0f, VertexInterpretation.PolygonClosed);
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
      
    }

    public override void MouseUp(MouseButton button)
    {
      
    }

    public override void KeyDown(System.Windows.Forms.Keys key)
    {
      throw new NotImplementedException();
    }

    public override void KeyUp(System.Windows.Forms.Keys key)
    {
      throw new NotImplementedException();
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
