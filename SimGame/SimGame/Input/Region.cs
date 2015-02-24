using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;
using OkuBase.Input;

namespace SimGame.Input
{
  public delegate void MouseHandler(string id, MouseEvent mevent, MouseButton button);
  public delegate void KeyboardHandler(string id, KeyboardEvent kevent, Keys key);

  /// <summary>
  /// Internal class for regions data.
  /// </summary>
  public class Region
  {
    private string _id = null;
    private Rectangle2f _area = new Rectangle2f();
    private int _zIndex = 0;
    private MouseHandler _mouseHandler = null;
    private KeyboardHandler _keyboardHandler = null;

    public Region(string id)
    {
      _id = id;
    }

    public Region(string id, Rectangle2f area, int zIndex, MouseHandler mouseHandler, KeyboardHandler keyboardHandler) : this(id)
    {
      _area = area;
      _zIndex = zIndex;
      _mouseHandler = mouseHandler;
      _keyboardHandler = keyboardHandler;
    }

    public string Id
    {
      get { return _id; }
    }

    public Rectangle2f Area
    {
      get { return _area; }
      set { _area = value; }
    }

    public int ZIndex
    {
      get { return _zIndex; }
      set { _zIndex = value; }
    }

    public MouseHandler MouseHandler
    {
      get { return _mouseHandler; }
      set { _mouseHandler = value; }
    }

    public KeyboardHandler KeyboardHandler
    {
      get { return _keyboardHandler; }
      set { _keyboardHandler = value; }
    }

  }
}
