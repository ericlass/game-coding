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
      OpenGLWindow window = OpenGLWindow.Build();
      window.Run();
    }
  }
}
