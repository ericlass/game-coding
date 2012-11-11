using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OkuEngine.Driver.Renderer;

namespace OkuEngine
{
  /// <summary>
  /// Defines a widget that is a single line text box.
  /// </summary>
  public class TextBoxWidget : Widget
  {
    private bool _textMeshValid = false;
    private MeshInstance _textMesh = null;
    private Vector _textOffset = new Vector();

    private Vector[] _vertices = new Vector[4];
    private Color[] _colors = new Color[4];

    private bool _focused = false;
    private TextProcessor _processor = new TextProcessor();

    private float _currentTime = 0.0f;
    private bool _cursorVisible = true;

    /// <summary>
    /// Creates a new text box widget.
    /// </summary>
    public TextBoxWidget()
    {
      _processor.Multiline = true;
    }

    /// <summary>
    /// Gets or sets the text that is displayed on the button.
    /// </summary>
    public String Text
    {
      get { return _processor.Text; }
      set
      {
        _processor.Text = value;
        _textMeshValid = false;
      }
    }

    protected override void AreaChange()
    {
      //If area is changed, recalculate vertices
      _vertices[0] = Vector.Zero;
      _vertices[1] = new Vector(0, Area.Height);
      _vertices[2] = new Vector(Area.Width, Area.Height);
      _vertices[3] = new Vector(Area.Width, 0);
    }

    /// <summary>
    /// Gets the text mesh that can be used to render the text.
    /// </summary>
    /// <returns>The text mesh.</returns>
    private MeshInstance GetTextMesh()
    {
      if (!_textMeshValid || _textMesh == null)
      {
        _textOffset.X = 4;
        _textOffset.Y = Area.Height - (Area.Height - Container.Font.Height) / 2.0f;

        _textMesh = Container.Font.GetStringMesh(_processor.Text, _textOffset.X, _textOffset.Y, Container.ColorMap.GetContrastFontColor(Container.ColorMap.WindowLight));
        _textMeshValid = true;
      }
      return _textMesh;
    }

    public override void Update(float dt)
    {
      if (Container.CursorBlinkTime > 0.0f)
      {
        _currentTime += dt;
        while (_currentTime > Container.CursorBlinkTime)
        {
          _cursorVisible = !_cursorVisible;
          _currentTime -= Container.CursorBlinkTime;
        }
      }
    }

    public override void Render(Canvas canvas)
    {
      _colors[0] = Container.ColorMap.WindowLight;
      _colors[1] = Container.ColorMap.WindowDark;
      _colors[2] = Container.ColorMap.WindowDark;
      _colors[3] = Container.ColorMap.WindowLight;

      canvas.DrawMesh(_vertices, null, _colors, _vertices.Length, MeshMode.Quads, null);
      canvas.DrawLines(_vertices, Container.ColorMap.BorderLight, _vertices.Length, 1.0f, VertexInterpretation.PolygonClosed);

      canvas.DrawMesh(GetTextMesh());

      //Draw cursor only if widget is focused
      if (_focused && _cursorVisible)
      {
        float cursorX = 0.0f;
        if (_processor.CursorPosition > 0)
          cursorX = Container.Font.GetTextWidth(_processor.Text, _processor.CursorPosition);

        cursorX += _textOffset.X;

        canvas.DrawLine(new Vector(cursorX, _textOffset.Y), new Vector(cursorX, _textOffset.Y - Container.Font.Height), 1.0f, Color.Black);
      }
    }

    public override void KeyDown(Keys key)
    {
      _textMeshValid = !_processor.ProcessKey(key);
    }

    public override void Focus()
    {
      _focused = true;
      _cursorVisible = true;
      _currentTime = 0.0f;
    }

    public override void Unfocus()
    {
      _focused = false;
    }
  }
}
