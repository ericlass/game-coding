using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Input;
using SimGame.Objects;
using SimGame.Mouse;

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
    private bool updateRequired = false;

    private Vector2f _dragStartPos = Vector2f.Zero;
    private bool dragging = false;

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
        updateRequired = true;
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
        updateRequired = true;
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
        switch (mevent)
        {
          case MouseEvent.ButtonDown:
            if (button == MouseButton.Left)
            {
              dragging = true;
              _dragStartPos = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
            }
            break;

          case MouseEvent.ButtonUp:
            if (button == MouseButton.Left)
              dragging = false;
            break;

          case MouseEvent.Move:
            if (dragging)
            {
              Vector2f currentPos = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
              _parentObject.Transform.Translation += currentPos - _dragStartPos;
              UpdateMouseRegions(_parentObject);
            }
            break;

          default:
            break;
        }
      }
    }

    private void UpdateMouseRegions(GameObject obj)
    {
      //TODO: Remove current widget regions

      _input.Mouse.RemoveRegion(HeaderRegionName);
      Rectangle2f headerRegion = new Rectangle2f(obj.Transform.Translation.X, obj.Transform.Translation.Y + BorderBottom + _content.Height, Width, BorderTop);
      _input.Mouse.AddRegion(HeaderRegionName, headerRegion, obj.ZIndex, OnMouseEvent);

      //TODO: Create mouse regions for each widget
      updateRequired = false;
    }

    private Vector2f MouseInClientSpace(GameObject obj, string widgetId)
    {
      Widget widget = Content.GetWidget(widgetId);
      if (widget == null)
        return Vector2f.Zero;

      Vector2f widgetPosWorld = new Vector2f(
        obj.Transform.Translation.X + BorderLeft,
        obj.Transform.Translation.Y + BorderBottom
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

    public override void Initialize(SimGame.Objects.GameObject obj)
    {
      _parentObject = obj;
      UpdateMouseRegions(obj);
    }

    public override void Update(GameObject obj, float dt)
    {
      if (updateRequired)
        UpdateMouseRegions(obj);
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
