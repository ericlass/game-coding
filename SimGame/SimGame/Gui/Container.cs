using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace SimGame.Gui
{
  public abstract class Container : Widget, IEnumerable<Widget>
  {
    private Dictionary<string, Widget> _children = new Dictionary<string, Widget>();

    public Container()
    {
    }

    public Color BackgroundColor { get; set; }

    public void Add(Widget widget)
    {
      if (widget.Parent != null)
        throw new ArgumentException("The given widget already has a parent!");

      if (_children.ContainsKey(widget.Id))
        throw new ArgumentException("Widget is already a child of this container and cannot be added twice!");

      _children.Add(widget.Id, widget);
      widget.Parent = this;
    }

    public void Remove(Widget widget)
    {
      if (widget.Parent != this)
        throw new ArgumentException("Given widget is not a child of this container!");

      _children.Remove(widget.Id);
      widget.Parent = null;
    }

    /// <summary>
    /// Tries to find the widget with the given id in this container.
    /// Containers which are children of this container are searched recursivly.
    /// </summary>
    /// <param name="id">The id of the widget to find.</param>
    /// <returns>The widget with the given id or null if there is no widget with this id.</returns>
    public Widget GetWidget(string id)
    {
      //First, check this container
      if (_children.ContainsKey(id))
        return _children[id];

      // Check sub-containers recursivly.
      foreach (var item in _children)
      {
        if (item.Value is Container)
        {
          Container cont = item.Value as Container;
          return cont.GetWidget(id);
        }
      }

      return null;
    }

    public IEnumerator<Widget> GetEnumerator()
    {
      return _children.Values.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _children.Values.GetEnumerator();
    }
  }
}
