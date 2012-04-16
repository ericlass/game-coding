using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a widget that simpy displays a text.
  /// </summary>
  public class LabelWidget : Widget
  {
    private String _text = null;
    private bool _textValid = false;
    private MeshInstance _textMesh = null;

    /// <summary>
    /// The text to display. Can be multiline.
    /// </summary>
    public String Text
    {
      get { return _text; }
      set 
      { 
        _text = value;
        _textValid = false;
      }
    }

    protected override void AreaChange()
    {
      _textValid = false;
    }

    /// <summary>
    /// Lazyly gets the mesh for the text.
    /// </summary>
    /// <returns>The mesh for the text.</returns>
    private MeshInstance GetTextMesh()
    {
      if (!_textValid || _textMesh == null)
      {
        _textMesh = Container.Font.GetStringMesh(_text, Area.Min.X, Area.Min.Y, Container.ColorMap.FontLight);
        _textValid = true;
      }
      return _textMesh;
    }

    /// <summary>
    /// Updates the label.
    /// </summary>
    /// <param name="dt">The time passed since the last frame.</param>
    public override void Update(float dt)
    {
    }

    /// <summary>
    /// Renders the label.
    /// </summary>
    public override void Render()
    {
      GetTextMesh().Draw();
    }

    public override void MouseEnter()
    {
    }

    public override void MouseLeave()
    {
    }

    public override void MouseDown(MouseButton button)
    {
    }

    public override void MouseUp(MouseButton button)
    {
    }

    public override void KeyDown(System.Windows.Forms.Keys key)
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
    }

    public override void Unfocus()
    {
    }
  }
}
