using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Input;
using SimGame.Objects;
using SimGame.Input;

namespace SimGame.Gui
{
  public class Dialog : GameObjectBase
  {
    private const string HeaderRegionName = "dialogheader";

    private const int BorderLeft = 4;
    private const int BorderRight = 4;
    private const int BorderBottom = 4;
    private const int BorderTop = 20;

    private Container _content = null;
    private InputContext _input = null;

    private GameObject _parentObject = null;
    private bool _updateRequired = false;

    private Vector2f _dragStartPos = Vector2f.Zero;
    private bool _dragging = false;

    /// <summary>
    /// Creates a new dialog.
    /// </summary>
    /// <param name="content">The dialog content. Cannot be null.</param>
    /// <param name="input">The input context to use. Cannot be null.</param>
    public Dialog(Container content, InputContext input)
    {
      if (content == null)
        throw new ArgumentException("Dialog content cannot be null!");

      if (input == null)
        throw new ArgumentException("Input context cannot be null!");

      _content = content;
      _input = input;
    }

    /// <summary>
    /// Gets or set the width of the dialog. The content is automatically resized accordingly.
    /// </summary>
    public int Width
    {
      get { return _content.Width + BorderLeft + BorderRight; }
      set 
      {
        _content.Width = value - BorderLeft - BorderRight;
        _updateRequired = true;
      }
    }

    /// <summary>
    /// Gets or set the height of the dialog. The content is automatically resized accordingly.
    /// </summary>
    public int Height
    {
      get { return _content.Height + BorderBottom + BorderTop; }
      set
      {
        _content.Height = value - BorderBottom - BorderTop;
        _updateRequired = true;
      }
    }

    /// <summary>
    /// Gets or sets the content of the dialog. Can never be null.
    /// </summary>
    public Container Content
    {
      get { return _content; }
      set 
      { 
        if (value == null)
          throw new ArgumentException("Dialog content cannot be null!");

        _content = value;
      }
    }

    public bool DrawBorder { get; set; }
    public Color BorderColor { get; set; }

    private void OnMouseEvent(string region, MouseEvent mevent, MouseButton button)
    {
      if (region == HeaderRegionName)
      {
        //Handle dragging of dialog
        switch (mevent)
        {
          case MouseEvent.ButtonDown:
            if (button == MouseButton.Left)
            {
              _dragging = true;
              _dragStartPos = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
            }
            break;

          case MouseEvent.ButtonUp:
            if (button == MouseButton.Left)
              _dragging = false;
            break;

          case MouseEvent.Move:
            if (_dragging)
            {
              Vector2f currentPos = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
              Vector2f delta = currentPos - _dragStartPos;
              _parentObject.Transform.Translation += delta;
              _dragStartPos = currentPos;              

              UpdateRegions();
            }
            break;

          default:
            break;
        }
      }
      else
      {
        //Forward events to widgets
        Widget widget = _content.GetWidget(region);
        if (widget == null && _content.Id == region)
          widget = _content;

        if (widget != null)
        {
          Vector2f mouse = MouseInClientSpace(widget);
          int x = (int)mouse.X;
          int y = (int)mouse.Y;
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
    }

    private void OnKeyboardEvent(string id, KeyboardEvent kevent, Keys key)
    {
      Widget widget = _content.GetWidget(id);
      if (widget != null)
      {
        switch (kevent)
        {
          case KeyboardEvent.KeyPressed:
            widget.OnKeyDown(key);
            break;

          case KeyboardEvent.KeyRaised:
            widget.OnKeyUp(key);
            break;

          default:
            break;
        }
      }
    }

    private void UpdateRegions()
    {
      Rectangle2f headerArea = new Rectangle2f(_parentObject.Transform.Translation.X, _parentObject.Transform.Translation.Y + BorderBottom + _content.Height, Width, BorderTop);
      Region headerRegion = _input.Processor[HeaderRegionName];
      if (headerRegion == null)
      {
        headerRegion = new Region(HeaderRegionName, headerArea, _parentObject.ZIndex, OnMouseEvent, null);
        _input.Processor.AddRegion(headerRegion);
      }
      else     
        headerRegion.Area = headerArea;

      Vector2f pos = new Vector2f(_parentObject.Transform.Translation.X + BorderLeft, _parentObject.Transform.Translation.Y + BorderBottom);
      CreateOrUpdateWidgetRegion(_content, pos, _parentObject.ZIndex);
      UpdateWidgetRegions(_content, pos, _parentObject.ZIndex + 1);

      _updateRequired = false;
    }

    public void UpdateWidgetRegions(Container parent, Vector2f pos, int zIndex)
    {
      foreach (var widget in parent)
      {
        CreateOrUpdateWidgetRegion(widget, pos, zIndex);
        if (widget is Container)
          UpdateWidgetRegions(widget as Container, pos + new Vector2f(widget.Left, widget.Bottom), zIndex + 1);
      }
    }

    private void CreateOrUpdateWidgetRegion(Widget widget, Vector2f pos, int zIndex)
    {
      Rectangle2f area = new Rectangle2f(pos.X + widget.Left, pos.Y + widget.Bottom, widget.Width, widget.Height);
      Region region = _input.Processor[widget.Id];
      if (region == null)
      {
        region = new Region(widget.Id, area, zIndex, OnMouseEvent, OnKeyboardEvent);
        _input.Processor.AddRegion(region);
      }
      else
        region.Area = area;
    }

    private Vector2f MouseInClientSpace(Widget widget)
    {
      Vector2f widgetPosWorld = new Vector2f(
        _parentObject.Transform.Translation.X + BorderLeft,
        _parentObject.Transform.Translation.Y + BorderBottom
      );

      while (widget != null)
      {
        widgetPosWorld.X += widget.Left;
        widgetPosWorld.Y += widget.Bottom;
        widget = widget.Parent;
      }

      Vector2f mousePosWorld = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);

      return mousePosWorld - widgetPosWorld;
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
      if (DrawBorder)
      {
        Oku.Graphics.DrawRectangle(0, Width, 0, Height, BorderColor);
      }

      Oku.Graphics.ApplyAndPushTransform(new Vector2f(BorderLeft, BorderBottom), Vector2f.One, 0);
      try
      {
        //TODO: Set scissor rectangle
        Content.Render();
      }
      finally
      {
        Oku.Graphics.PopTransform();
      }
    }

  }
}
