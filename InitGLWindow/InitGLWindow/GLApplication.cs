using System;
using System.Collections.Generic;
using OpenGL;

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
      window.OnRender += Window_OnRender;
      window.Run();
    }

    private void Window_OnRender()
    {
      //This is legacy GL and should not be used
      /*Gl.MatrixMode(MatrixMode.Projection);
      Gl.LoadIdentity();
      Gl.Ortho(-1, 1, -1, 1, -1, 1);
      
      Gl.MatrixMode(MatrixMode.Modelview);
      Gl.LoadIdentity();*/

      Gl.ClearColor(0, 0, 0, 1);
      Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

      Gl.Flush();
    }
  }
}
