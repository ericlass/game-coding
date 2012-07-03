using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  /// <summary>
  /// Defines a widget in the form of a button that can be clicked.
  /// </summary>
  public class ButtonWidget : Widget
  {
    private Color _currentColorDark = Color.Black;
    private Color _currentColorLight = Color.Silver;
    private bool _focused = false;
    private bool _active = false;
    private bool _clicked = false;

    private ImageContent _glyph = null;
    private Vector _glyphPos = Vector.Zero;

    private String _text = null;
    private bool _refreshNeeded = true;
    private MeshInstance _textMesh = null;
    private Vector[] _vertices = new Vector[4];
    private Vector[] _focusRect = new Vector[4];
    private Color[] _colors = new Color[4];

    /// <summary>
    /// The text to display on the button.
    /// </summary>
    public String Text
    {
      get { return _text; }
      set 
      { 
        _text = value;
        _refreshNeeded = true;
      }
    }

    /// <summary>
    /// Gets or sets an icon image that is displayed on the button left to the text.
    /// </summary>
    public ImageContent Glyph
    {
      get { return _glyph; }
      set 
      {
        _glyph = value;
        _refreshNeeded = true;
      }
    }

    protected override void AreaChange()
    {
      //If area is changed, recalculate vertices
      _vertices[0] = Vector.Zero;
      _vertices[1] = new Vector(0, Area.Height);
      _vertices[2] = new Vector(Area.Width, Area.Height);
      _vertices[3] = new Vector(Area.Width, 0);

      float inset = 3;
      _focusRect[0] = new Vector(_vertices[0].X + inset, _vertices[0].Y + inset);
      _focusRect[1] = new Vector(_vertices[1].X + inset, _vertices[1].Y - inset);
      _focusRect[2] = new Vector(_vertices[2].X - inset, _vertices[2].Y - inset);
      _focusRect[3] = new Vector(_vertices[3].X - inset, _vertices[3].Y + inset);

      _refreshNeeded = true;
    }

    /// <summary>
    /// Gets if the button was clicked.
    /// </summary>
    public bool Clicked
    {
      get { return _clicked; }
    }

    /// <summary>
    /// Initializes the button after it has been added to a container.
    /// </summary>
    public override void Init()
    {
      _currentColorLight = Container.ColorMap.WidgetLight;
      _currentColorDark = Container.ColorMap.WidgetDark;
    }

    /// <summary>
    /// Updates the buttons state.
    /// </summary>
    /// <param name="dt">The time passed since the last frame.</param>
    public override void Update(float dt)
    {
      _clicked = false;
    }

    /// <summary>
    /// Refreshes text and recalculates glyph and text positions if needed.
    /// </summary>
    private void Refresh()
    {
      if (_refreshNeeded)
      {
        _textMesh = null;

        bool hasText = _text != null && _text.Length > 0;
        bool hasGlyph = _glyph != null && _glyph.Width > 0 && _glyph.Height > 0;

        float textWidth = 0;
        float glyphWidth = 0;
        float totalWidth = 0;
        if (hasText)
        {
          _textMesh = Container.Font.GetStringMesh(_text, 0, 0, Container.ColorMap.FontLight);
          textWidth = _textMesh.Vertices.Positions[_textMesh.Vertices.Positions.Length - 2].X - _textMesh.Vertices.Positions[0].X;
          totalWidth += textWidth;
        }

        if (hasGlyph)
        {
          glyphWidth = _glyph.Width;
          totalWidth += glyphWidth;
        }

        if (hasText && hasGlyph)
          totalWidth += 5;

        Vector center = new Vector((Area.Width / 2.0f) - 1.0f, Area.Height / 2.0f);

        if (hasText)
          OkuMath.CenterAt(_textMesh.Vertices.Positions, new Vector(center.X + (totalWidth / 2.0f) - (textWidth / 2.0f), center.Y));

        if (hasGlyph)
        {
          _glyphPos.X = center.X - (totalWidth / 2.0f) + (glyphWidth / 2.0f);
          _glyphPos.Y = center.Y;
        }

        _refreshNeeded = false;
      }
    }

    /// <summary>
    /// Renders the button depending on its state.
    /// </summary>
    public override void Render(Canvas canvas)
    {
      Refresh();

      _colors[0] = _currentColorDark;
      _colors[1] = _currentColorLight;
      _colors[2] = _currentColorLight;
      _colors[3] = _currentColorDark;

      canvas.DrawMesh(_vertices, null, _colors, _vertices.Length, MeshMode.Quads, null);
      canvas.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);

      if (_textMesh != null)
        canvas.DrawMesh(_textMesh);

      if (_glyph != null)
        canvas.DrawImage(_glyph, _glyphPos);

      if (_focused)
        canvas.DrawLines(_focusRect, Container.ColorMap.FontDark, _focusRect.Length, 0.5f, VertexInterpretation.PolygonClosed);
    }

    public override void MouseEnter()
    {
      if (!_active)
      {
        _currentColorLight = Container.ColorMap.HotLight;
        _currentColorDark = Container.ColorMap.HotDark;
      }
    }

    public override void MouseLeave()
    {
      if (!_active)
      {
        _currentColorLight = Container.ColorMap.WidgetLight;
        _currentColorDark = Container.ColorMap.WidgetDark;
      }
    }

    public override void MouseDown(MouseButton button)
    {
      _currentColorLight = Container.ColorMap.ActiveLight;
      _currentColorDark = Container.ColorMap.ActiveDark;
    }

    public override void MouseUp(MouseButton button)
    {
      _currentColorLight = Container.ColorMap.HotLight;
      _currentColorDark = Container.ColorMap.HotDark;
      _clicked = _active;
    }

    public override void Activate()
    {
      _active = true;
    }

    public override void Deactivate()
    {
      _active = false;
      _currentColorLight = Container.ColorMap.WidgetLight;
      _currentColorDark = Container.ColorMap.WidgetDark;
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
