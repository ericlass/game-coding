using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;

namespace SimGame.Gui
{
  public abstract class Widget
  {
    public string Id { get; set; }

    public int Left { get; set; }
    public int Bottom { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Container Parent { get; set; }

    public Rectangle2f GetArea()
    {
      return new Rectangle2f(Left, Bottom, Width, Height);
    }
    
    public abstract void Render();

    public virtual void OnResize() { }

    public virtual void OnMouseDown(int x, int y, MouseButton button) { }
    public virtual void OnMouseUp(int x, int y, MouseButton button) { }
    public virtual void OnMouseEnter(int x, int y) { }
    public virtual void OnMouseLeave(int x, int y) { }
    public virtual void OnMouseMove(int x, int y) { }

    public virtual void OnKeyDown(Keys key) { }
    public virtual void OnKeyUp(Keys key) { }
  }
}
