using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OkuEngine
{
  public class WidgetContainer
  {
    private List<Widget> _widgets = new List<Widget>();
    private Widget _hotWidget = null; //The widget that the mouse hovers over.
    private Widget _activeWidget = null; //The widget the left mouse button was pressed down on
    private Widget _focusedWidget = null; //The widget the left mouse button was pressed down AND raised up on
    private SpriteFont _font = null;

    public WidgetContainer()
    {
      _font = new SpriteFont(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size, SystemFonts.DefaultFont.Style, true);
    }

    public WidgetContainer(SpriteFont font)
    {
      _font = font;
    }

    public SpriteFont Font
    {
      get { return _font; }
    }

    public void AddWidget(Widget widget)
    {
      _widgets.Add(widget);
      widget.Container = this;
    }

    public void Update(float dt)
    {
      Vector mousePos = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);

      //Find new hot widget
      Widget newHot = null;
      foreach (Widget widget in _widgets)
      {
        widget.Update(dt);
        if (newHot == null && Intersections.PointInAABB(mousePos, widget.Area.Min, widget.Area.Max))
        {
          newHot = widget;
        }
      }

      //If hot widget has changed, update
      if (newHot != _hotWidget)
      {
        if (_hotWidget != null)
          _hotWidget.MouseLeave();

        
        if (newHot != null)
          newHot.MouseEnter();
      }

      if (newHot != null)
      {
        //Handle down and up of other mouse buttons
        List<MouseButton> pressedButtons = OkuDrivers.Input.Mouse.GetPressedButtons();
        foreach (MouseButton btn in pressedButtons)
          _hotWidget.MouseDown(btn);

        List<MouseButton> raisedButtons = OkuDrivers.Input.Mouse.GetRaisedButtons();
        foreach (MouseButton btn in raisedButtons)
          _hotWidget.MouseUp(btn);

        Widget lastActive = _activeWidget;
        //Check for active widget
        if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Left))
        {
          if (_activeWidget == null)
          {
            _activeWidget = newHot;
            _activeWidget.Activate();
          }
          else
          {
            if (_activeWidget != newHot)
            {
              _activeWidget.Deactivate();

              _activeWidget = newHot;
              _activeWidget.Activate();
            }
          }
        }

        //Check for focused widget
        if (OkuDrivers.Input.Mouse.ButtonRaised(MouseButton.Left))
        {
          if (lastActive != null && lastActive == newHot)
          {
            if (_focusedWidget == null)
            {
              _focusedWidget = newHot;
              _focusedWidget.Focus();
            }
            else
            {
              if (_focusedWidget != newHot)
              {
                _focusedWidget.Unfocus();

                _focusedWidget = newHot;
                _focusedWidget.Focus();
              }
            }
          }
        }
      }

      _hotWidget = newHot;

      //Forward keyboard events to focused widget
      if (_focusedWidget != null)
      {
        List<Keys> pressedKeys = OkuDrivers.Input.Keyboard.GetPressedButtons();
        foreach (Keys key in pressedKeys)
          _focusedWidget.KeyDown(key);

        List<Keys> raisedKeys = OkuDrivers.Input.Keyboard.GetRaisedButtons();
        foreach (Keys key in raisedKeys)
          _focusedWidget.KeyUp(key);
      }
    }

    public void Render()
    {
      foreach (Widget widget in _widgets)
        widget.Render();
    }

  }
}
