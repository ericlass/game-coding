using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;
using OkuBase.Geometry;
using SimGame.Gui;
using SimGame.Input;

namespace SimGame.Objects
{
  public class GuiObject : GameObjectBase
  {
    private Container _content = null;
    private InputContext _input = null;

    private GameObject _parentObject = null;
    private Widget _focusedWidget = null;

    public GuiObject(Container content, InputContext input)
    {
      if (content == null)
        throw new ArgumentException("Dialog content cannot be null!");

      if (input == null)
        throw new ArgumentException("Input context cannot be null!");

      _content = content;
      _input = input;
    }

    public Container Content
    {
      get { return _content; }
    }

    public InputContext Input
    {
      get { return _input; }
    }

    private void OnMouseEvent(string region, MouseEvent mevent, MouseButton button)
    {
      if (region != _content.Id)
        throw new ArgumentException("Region of received mouse event differs from content!");

      Vector2f mouse = new Vector2f(_input.MouseX - _parentObject.Transform.Translation.X, _input.MouseY - _parentObject.Transform.Translation.Y);
      int x = (int)mouse.X;
      int y = (int)mouse.Y;
      
      Widget widget = _content.GetWidgetAt(mouse);
      
      if (widget != null)
      {
        switch (mevent)
        {
          case MouseEvent.Enter:
            widget.OnMouseEnter(x, y);
            break;
            
          case MouseEvent.Leave:
            widget.OnMouseLeave(x, y);
            break;
            
          case MouseEvent.ButtonDown:
            widget.OnMouseDown(x, y, button);
            if (button == MouseButton.Left)
              _focusedWidget = widget;
            break;
            
          case MouseEvent.ButtonUp:
            widget.OnMouseUp(x, y, button);
            break;
            
          case MouseEvent.Move:
            widget.OnMouseMove(x, y);
            break;
            
          default:
            throw new ArgumentException("Unknown mouse event: " + mevent.ToString());
        }
      }
    }

    private void OnKeyboardEvent(string id, KeyboardEvent kevent, Keys key)
    {
      if (id != _content.Id)
        throw new ArgumentException("Region of received keyboard event differs from content!");

      if (_focusedWidget == null)
        return;
      
      switch (kevent)
      {
        case KeyboardEvent.KeyPressed:
          _focusedWidget.OnKeyDown(key);
          break;

        case KeyboardEvent.KeyRaised:
          _focusedWidget.OnKeyUp(key);
          break;

        default:
          break;
      }
    }

    private void UpdateRegion()
    {
      Rectangle2f contentArea = new Rectangle2f(_parentObject.Transform.Translation.X, _parentObject.Transform.Translation.Y, _content.Width, _content.Height);
      Region contentRegion = _input.Processor[_content.Id];
      if (contentRegion == null)
      {
        contentRegion = new Region(_content.Id, contentArea, _parentObject.ZIndex, OnMouseEvent, OnKeyboardEvent);
        _input.Processor.AddRegion(contentRegion);
      }
      else
        contentRegion.Area = contentArea;
    }

    public override void Initialize(GameObject obj)
    {
      _parentObject = obj;
      UpdateRegion();
    }

    public override void Update(GameObject obj, float dt)
    {
      if (_updateRequired)
        UpdateRegion();
    }

    public override void Render(GameObject obj)
    {
      _content.Render();
    }

  }
}
