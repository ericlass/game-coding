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
    
    /// <summary>
    /// Gets the widget at the given point. The point has to be given in container space!
    /// Sub-containers are searched recursivly.
    /// </summary>
    /// <param name="p">The point to check.</param>
    /// <returns>The widget at the given point (might be this container!) or null if the point is outside of the containers area.</returns>
    public Widget GetWidgetAt(Vector2f p)
    {
      //Check if point is actually inside container
      if (p.X < 0 || p.X > Width || p.Y < 0 || p.Y > Height)
        return null;
        
      //Check children
      foreach (var item in _children)
      {
        Rectangle2f area = item.Value.GetArea();
        if (area.IsInside(p))
        {
          if (item.Value is Container)
          {
            Vector2f pWidget = p - new Vector2f(item.Value.Left, item.Value.Bottom);
            Container cont = item.Value as Container;
            Widget result = cont.GetWidgetAt(pWidget);
            if (result != null) //Actually, result should never be null as I check that the point is inside of the container above
              return result;
          }
          else
            return item.Value;
        }
      }
      
      //If no children as at this point, then the container itself is there
      return this;
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
