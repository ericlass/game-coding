using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OkuBase.Graphics;
using OkuBase.Geometry;
using OkuBase.Input;
using OkuMath;

namespace OkuBase.GUI
{
  /// <summary>
  /// Container for GUI widgets that manages updating an rendering widget.
  /// Every widget has to added to a container to work.
  /// </summary>
  public class WidgetContainer
  {
    private List<Widget> _widgets = new List<Widget>();
    private Widget _hotWidget = null; //The widget that the mouse hovers over.
    private Widget _activeWidget = null; //The widget the left mouse button was pressed down on
    private Widget _focusedWidget = null; //The widget the left mouse button was pressed down AND raised up on
    private HintWidget _hint = null; 
    private SpriteFont _font = null;
    private ColorMap _colorMap = ColorMap.Flash;
    private float _cursorBlinkTime = 0.5f;
    private float _hoverTime = 0.0f;
    private Vector2f _hintPos = Vector2f.Zero;
    private Canvas _canvas = new Canvas(new Rectangle2f());

    /// <summary>
    /// Creates a new widget container with the system default font.
    /// </summary>
    public WidgetContainer()
    {
      _font = new SpriteFont(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size, OkuBase.Graphics.FontStyle.Regular, true);
    }

    /// <summary>
    /// Creates a new widget container with the given font.
    /// </summary>
    /// <param name="font">The font to use.</param>
    public WidgetContainer(SpriteFont font)
    {
      _font = font;
    }

    /// <summary>
    /// Gets or sets the time that passes between cursor
    /// states (Visible/Not Visible).
    /// </summary>
    public float CursorBlinkTime
    {
      get { return _cursorBlinkTime; }
      set { _cursorBlinkTime = value; }
    }

    /// <summary>
    /// Gets the font that is used by all widgets
    /// that are managed by thios container.
    /// </summary>
    public SpriteFont Font
    {
      get { return _font; }
    }

    /// <summary>
    /// Gets the widget that is currently "hot".
    /// Hot means that the mouse cursor is currently hovering over it.
    /// </summary>
    public Widget HotWidget
    {
      get { return _hotWidget; }
    }

    /// <summary>
    /// Gets or sets the widget that is currently active.
    /// A widget is active if the left mouse button was pressed
    /// down while the widget was hot. The widget stays active
    /// until the left mouse button is raised.
    /// </summary>
    public Widget ActiveWidget
    {
      get { return _activeWidget; }
      set { _activeWidget = value; }
    }

    /// <summary>
    /// Gets or sets the widget that is currently focused.
    /// A widget is focused if the left mouse button was pressed 
    /// down and raised while the widget was hot.
    /// The focused widget also gets keyboard input forwarded.
    /// </summary>
    public Widget FocusedWidget
    {
      get { return _focusedWidget; }
      set { _focusedWidget = value; }
    }

    /// <summary>
    /// Gets or sets the current color map.
    /// The color map defines the colors that are used to draw
    /// all widgets that are in this container.
    /// </summary>
    public ColorMap ColorMap
    {
      get { return _colorMap; }
      set { _colorMap = value; }
    }

    /// <summary>
    /// Gets the hint widget.
    /// </summary>
    private HintWidget Hint
    {
      get
      {
        if (_hint == null)
        {
          _hint = new HintWidget();
          _hint.Visible = false;
          AddWidget(_hint);
        }
        return _hint;
      }
    }

    /// <summary>
    /// Adds the given widget to this container.
    /// </summary>
    /// <param name="widget">The widget to add.</param>
    public void AddWidget(Widget widget)
    {
      _widgets.Add(widget);
      widget.Container = this;
      widget.Init();
    }

    /// <summary>
    /// Removes the given widget from this container.
    /// </summary>
    /// <param name="widget">The widget to be removed.</param>
    public void Remove(Widget widget)
    {
      _widgets.Remove(widget);
    }

    /// <summary>
    /// Updates the widgets and their states.
    /// Has to be passed every frame passing the time
    /// passed since the last frame.
    /// </summary>
    /// <param name="dt">The time passed since the last frame.</param>
    public void Update(float dt)
    {
      //Get mouse position in screen space
      Vector2f mousePos = OkuManager.Instance.Graphics.ScreenToDisplay(OkuManager.Instance.Input.Mouse.X, OkuManager.Instance.Input.Mouse.Y);

      //Update hint position
      if (!Hint.Visible)
      {
        _hintPos = mousePos;
        _hintPos.Y -= 20;
      }

      //Find new hot widget
      Widget newHot = null;
      foreach (Widget widget in _widgets)
      {
        if (widget != Hint)
        {
          widget.Update(dt);
          
          if (newHot == null && Overlaps.PointAABB(mousePos, widget.Area.Min, widget.Area.Max))
          {
            newHot = widget;
          }
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
        List<MouseButton> pressedButtons = OkuManager.Instance.Input.Mouse.GetPressedButtons();
        foreach (MouseButton btn in pressedButtons)
          _hotWidget.MouseDown(btn);

        List<MouseButton> raisedButtons = OkuManager.Instance.Input.Mouse.GetRaisedButtons();
        foreach (MouseButton btn in raisedButtons)
          _hotWidget.MouseUp(btn);

        Widget lastActive = _activeWidget;
        //Check for active widget
        if (OkuManager.Instance.Input.Mouse.ButtonPressed(MouseButton.Left))
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
        if (OkuManager.Instance.Input.Mouse.ButtonRaised(MouseButton.Left))
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

        //Forward mouse wheel scrolling
        if (OkuManager.Instance.Input.Mouse.WheelSpinned)
        {
          newHot.MouseWheel(OkuManager.Instance.Input.Mouse.WheelDelta);
        }
      }

      _hotWidget = newHot;

      //Forward keyboard events to focused widget
      if (_focusedWidget != null)
      {
        List<Keys> pressedKeys = OkuManager.Instance.Input.Keyboard.GetPressedButtons();
        foreach (Keys key in pressedKeys)
          _focusedWidget.KeyDown(key);

        List<Keys> raisedKeys = OkuManager.Instance.Input.Keyboard.GetRaisedButtons();
        foreach (Keys key in raisedKeys)
          _focusedWidget.KeyUp(key);
      }

      //Deactivate active widget if mouse button is raised
      if (_activeWidget != null && OkuManager.Instance.Input.Mouse.ButtonRaised(MouseButton.Left))
      {
        _activeWidget.Deactivate();
        _activeWidget = null;
      }

      //Handle display and update of hint
      if (newHot != null && newHot == _hotWidget)
      {
        _hoverTime -= dt;
        if (!Hint.Visible && newHot != null && _hoverTime <= 0.0f && newHot.HintText != null && newHot.HintText.Length > 0)
        {
          Hint.Text = newHot.HintText;
          Hint.Area = new Rectangle2f(_hintPos, Vector2f.Zero);
          Hint.Visible = true;
        }
      }
      else
      {
        _hoverTime = 0.5f;
        Hint.Visible = false;
      }
    }

    /// <summary>
    /// Renders all widget that are in this container.
    /// The widgets are always rendered in screen space.
    /// </summary>
    public void Render()
    {
      OkuManager.Instance.Graphics.BeginScreenSpace();
      foreach (Widget widget in _widgets)
      {
        if (widget.Visible)
        {
          _canvas.Area = widget.Area;
          OkuManager.Instance.Graphics.SetScissorRectangle((int)widget.Area.Min.X, (int)widget.Area.Min.Y, (int)widget.Area.Width, (int)widget.Area.Height);
          widget.Render(_canvas);
        }
      }

      OkuManager.Instance.Graphics.ClearScissorRectangle();
      OkuManager.Instance.Graphics.EndScreenSpace();
    }

  }
}
