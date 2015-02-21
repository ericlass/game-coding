using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace SimGame.Gui
{
  public abstract class Container : Widget, IEnumerable<Widget>
  {
    private List<Widget> _children = new List<Widget>();

    public Container()
    {
    }

    public Color BackgroundColor { get; set; }

    public void Add(Widget widget)
    {
      if (widget.Parent != null)
        throw new ArgumentException("The given widget already has a parent!");

      _children.Add(widget);
      widget.Parent = this;
    }

    public void Remove(Widget widget)
    {
      if (widget.Parent != this)
        throw new ArgumentException("Given widget is not a child of this container!");

      _children.Remove(widget);
      widget.Parent = null;
    }

    public IEnumerator<Widget> GetEnumerator()
    {
      return _children.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _children.GetEnumerator();
    }
  }
}
