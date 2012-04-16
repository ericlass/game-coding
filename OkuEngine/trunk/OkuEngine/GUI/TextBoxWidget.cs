using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class TextBoxWidget : Widget
  {
    private bool _textMeshValid = false;
    private MeshInstance _textMesh = null;
    private String _text = "";
    private bool _focused = false;

    public String Text
    {
      get { return _text; }
      set
      {
        _text = value;
        _textMeshValid = false;
      }
    }

    public override void Update(float dt)
    {
    }

    public override void Render()
    {
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
