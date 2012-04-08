using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OkuEngine
{
  public class ImmediateModeGui
  {
    private List<Widget> _widgets = new List<Widget>();
    private Widget _hotWidget = null; //The widget that the mouse hovers over.
    private Widget _activeWidget = null; //The widget the left mouse button was pressed down on
    private Widget _focusedWidget = null; //The widget the left mouse button was pressed down AND raised up on

    public void AddWidget(Widget widget)
    {
      _widgets.Add(widget);
    }

    public void Update(float dt)
    {
      Vector mousePos = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);

      Widget lastHot = _hotWidget;
      Widget lastActive = _activeWidget;
      Widget lastFocused = _focusedWidget;

      /*_hotWidget = null;
      _activeWidget = null;
      _focusedWidget = null;*/

      //Check mouse events for every widget
      foreach (Widget widget in _widgets)
      {
        widget.Update(dt);

        if (Intersections.PointInAABB(mousePos, widget.Area.Min, widget.Area.Max))
        {
          //Check for hot widget
          if (lastHot == null)
          {
            _hotWidget = widget;
            _hotWidget.MouseEnter();
          }
          else
          {
            if (lastHot != widget)
            {
              lastHot.MouseLeave();

              _hotWidget = widget;
              _hotWidget.MouseEnter();
            }
          }

          //Handle down and up of other mouse buttons
          List<MouseButton> pressedButtons = OkuDrivers.Input.Mouse.GetPressedButtons();
          foreach (MouseButton btn in pressedButtons)
            widget.MouseDown(btn);

          List<MouseButton> raisedButtons = OkuDrivers.Input.Mouse.GetRaisedButtons();
          foreach (MouseButton btn in raisedButtons)
            widget.MouseUp(btn);

          //Check for active widget
          if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Left))
          {
            if (lastActive == null)
            {
              _activeWidget = widget;
              _activeWidget.Activate();
            }
            else
            {
              if (lastActive != widget)
              {
                lastActive.Deactivate();

                _activeWidget = widget;
                _activeWidget.Activate();
              }
            }
          }

          //Check for focused widget
          if (OkuDrivers.Input.Mouse.ButtonRaised(MouseButton.Left))
          {
            if (lastActive != null && lastActive == widget)
            {
              if (lastFocused == null)
              {
                _focusedWidget = widget;
                _focusedWidget.Focus();
              }
              else
              {
                if (lastFocused != widget)
                {
                  lastFocused.Unfocus();

                  _focusedWidget = widget;
                  _focusedWidget.Focus();
                }
              }
            }
          }
        }
      }

      /*if (_hotWidget == null && lastHot != null)
        _hotWidget = lastHot;

      if (_activeWidget == null && lastActive != null)
        _activeWidget = lastActive;
      
      if (_focusedWidget == null && lastFocused != null)
        _focusedWidget = lastFocused;*/

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
