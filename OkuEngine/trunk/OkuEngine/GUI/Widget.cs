using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Base class for all widgets.
  /// </summary>
  public class Widget
  {
    private int _id = KeySequence.NextValue;
    private Quad _area = new Quad();
    private string _hintText = null;
    private bool _visible = true;

    private WidgetContainer _container = null;

    /// <summary>
    /// Gets os sets the widget container this widget belongs to.
    /// </summary>
    public WidgetContainer Container
    {
      get { return _container; }
      set { _container = value; }
    }

    /// <summary>
    /// Gets or sets the area of the widget.
    /// </summary>
    public Quad Area
    {
      get { return _area; }
      set
      {
        _area = value;
        AreaChange();
      }
    }

    /// <summary>
    /// Gets or sets the text that is displayed in the hint.
    /// Null means: display no hint.
    /// </summary>
    public string HintText
    {
      get { return _hintText; }
      set { _hintText = value; }
    }

    /// <summary>
    /// Gets or sets if the widget is visible or not.
    /// </summary>
    public bool Visible
    {
      get { return _visible; }
      set { _visible = value; }
    }

    /// <summary>
    /// Is called when the area of the widget changes.
    /// </summary>
    protected virtual void AreaChange()
    {
    }

    /// <summary>
    /// Gets a unique artificial ID for this widget.
    /// </summary>
    public int ID
    {
      get { return _id; }
    }

    /// <summary>
    /// Is called every frame to enable widgets to do animations.
    /// </summary>
    /// <param name="dt">The time passed since the last frame in seconds.</param>
    public virtual void Update(float dt)
    {
    }

    /// <summary>
    /// Is called when the widget has to render itself.
    /// </summary>
    public virtual void Render()
    {
    }

    /// <summary>
    /// Is called when the mouse cursor enters the area of the widget.
    /// </summary>
    public virtual void MouseEnter()
    {
    }

    /// <summary>
    /// Is called when the mouse cursor leaves the area of the widget.
    /// </summary>
    public virtual void MouseLeave()
    {
    }

    /// <summary>
    /// Is called when the mouse cursor is in the widgets area and 
    /// a mouse button is pressed down.
    /// </summary>
    /// <param name="button">The mouse button that was pressed.</param>
    public virtual void MouseDown(MouseButton button)
    {
    }

    /// <summary>
    /// Is called when the mouse cursor is in the widgets area and 
    /// a mouse button is raised up.
    /// </summary>
    /// <param name="button">The mouse button that was raised.</param>
    public virtual void MouseUp(MouseButton button)
    {
    }

    /// <summary>
    /// Is called when the mouse wheel was scrolled up or down.
    /// </summary>
    /// <param name="delta">Determines how far the wheel has been scrolled in which direction. Positive means forward, Negative means backwards scrolling.</param>
    public virtual void MouseWheel(float delta)
    {
    }

    /// <summary>
    /// Is called when the widget is focused and a keyboard key is pressed.
    /// </summary>
    /// <param name="key">The key that was pressed.</param>
    public virtual void KeyDown(Keys key)
    {
    }

    /// <summary>
    /// Is called when the widget is focused and a keyboard key is raised up.
    /// </summary>
    /// <param name="key">The key that was raised.</param>
    public virtual void KeyUp(Keys key)
    {
    }

    /// <summary>
    /// Is called when the widget is activated.
    /// </summary>
    public virtual void Activate()
    {
    }

    /// <summary>
    /// Is called when the widget is deactivated.
    /// </summary>
    public virtual void Deactivate()
    {
    }

    /// <summary>
    /// Is called when the widget is focused.
    /// </summary>
    public virtual void Focus()
    {
    }

    /// <summary>
    /// Is called when the widget is unfocused.
    /// </summary>
    public virtual void Unfocus()
    {
    }

    /// <summary>
    /// Is called once when the widget is added to the container.
    /// The container property is set when this method is called.
    /// </summary>
    public virtual void Init()
    {
    }

  }
}
