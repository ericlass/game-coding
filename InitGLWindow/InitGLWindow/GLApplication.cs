using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitGLWindow
{
  public class GLApplication
  {
    public GLApplication()
    {
    }

    public void Run()
    {
      OpenGLWindow window = OpenGLWindow.Build(MyWndProc);
      window.Run();
    }

    public IntPtr MyWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
      return OpenGLWindow.DefaultWndProc(hWnd, msg, wParam, lParam);
    }
  }
}
