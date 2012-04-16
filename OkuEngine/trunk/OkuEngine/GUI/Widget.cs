using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Base class for all widgets.
  /// </summary>
  public abstract class Widget
  {
    private int _id = KeySequence.NextValue;
    private Quad _area = new Quad();

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
    public abstract void Update(float dt);

    /// <summary>
    /// Is called when the widget has to render itself.
    /// </summary>
    public abstract void Render();

    /// <summary>
    /// Is called when the mouse cursor enters the area of the widget.
    /// </summary>
    public abstract void MouseEnter();

    /// <summary>
    /// Is called when the mouse cursor leaves the area of the widget.
    /// </summary>
    public abstract void MouseLeave();

    /// <summary>
    /// Is called when the mouse cursor is in the widgets area and 
    /// a mouse button is pressed down.
    /// </summary>
    /// <param name="button">The mouse button that was pressed.</param>
    public abstract void MouseDown(MouseButton button);

    /// <summary>
    /// Is called when the mouse cursor is in the widgets area and 
    /// a mouse button is raised up.
    /// </summary>
    /// <param name="button">The mouse button that was raised.</param>
    public abstract void MouseUp(MouseButton button);

    /// <summary>
    /// Is called when the widget is focused and a keyboard key is pressed.
    /// </summary>
    /// <param name="key">The key that was pressed.</param>
    public abstract void KeyDown(Keys key);

    /// <summary>
    /// Is called when the widget is focused and a keyboard key is raised up.
    /// </summary>
    /// <param name="key">The key that was raised.</param>
    public abstract void KeyUp(Keys key);

    /// <summary>
    /// Is called when the widget is activated.
    /// </summary>
    public abstract void Activate();

    /// <summary>
    /// Is called when the widget is deactivated.
    /// </summary>
    public abstract void Deactivate();

    /// <summary>
    /// Is called when the widget is focused.
    /// </summary>
    public abstract void Focus();

    /// <summary>
    /// Is called when the widget is unfocused.
    /// </summary>
    public abstract void Unfocus();

    /// <summary>
    /// Is called once when the widget is added to the container.
    /// The container property is set when this method is called.
    /// </summary>
    public virtual void Init()
    {
    }

  }
}
