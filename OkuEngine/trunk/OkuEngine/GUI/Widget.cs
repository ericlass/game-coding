using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OkuEngine
{
  public abstract class Widget
  {
    private int _id = KeySequence.NextValue;
    private Quad _area = new Quad();

    private WidgetContainer _container = null;

    public WidgetContainer Container
    {
      get { return _container; }
      set { _container = value; }
    }

    public virtual Quad Area
    {
      get { return _area; }
      set { _area = value; }
    }

    public int ID
    {
      get { return _id; }
    }

    public abstract void Update(float dt);
    public abstract void Render();

    public abstract void MouseEnter();
    public abstract void MouseLeave();
    public abstract void MouseDown(MouseButton button);
    public abstract void MouseUp(MouseButton button);

    public abstract void KeyDown(Keys key);
    public abstract void KeyUp(Keys key);

    public abstract void Activate();
    public abstract void Deactivate();
    public abstract void Focus();
    public abstract void Unfocus();

  }
}
