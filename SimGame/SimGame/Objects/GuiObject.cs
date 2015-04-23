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
      switch (mevent)
      {
        case MouseEvent.Enter:
          _content.OnMouseEnter(x, y);
          break;
        case MouseEvent.Leave:
          _content.OnMouseLeave(x, y);
          break;
        case MouseEvent.ButtonDown:
          _content.OnMouseDown(x, y, button);
          break;
        case MouseEvent.ButtonUp:
          _content.OnMouseUp(x, y, button);
          break;
        case MouseEvent.Move:
          _content.OnMouseMove(x, y);
          break;
        default:
          throw new ArgumentException("Unknown mouse event: " + mevent.ToString());
      }
    }

    private void OnKeyboardEvent(string id, KeyboardEvent kevent, Keys key)
    {
      if (id != _content.Id)
        throw new ArgumentException("Region of received keyboard event differs from content!");

      switch (kevent)
      {
        case KeyboardEvent.KeyPressed:
          _content.OnKeyDown(key);
          break;

        case KeyboardEvent.KeyRaised:
          _content.OnKeyUp(key);
          break;

        default:
          break;
      }
    }

    private void UpdateRegions()
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
      UpdateRegions();
    }

    public override void Update(GameObject obj, float dt)
    {
      if (_updateRequired)
        UpdateRegions();
    }

    public override void Render(GameObject obj)
    {
      _content.Render();
    }

  }
}
