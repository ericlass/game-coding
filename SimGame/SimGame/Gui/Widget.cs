using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public abstract void Render();

    public virtual void OnResize()
    {
    }
  }
}
