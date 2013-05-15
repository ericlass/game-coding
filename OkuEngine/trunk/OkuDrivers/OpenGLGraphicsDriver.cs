using System;
using System.Collections.Generic;
using OkuBase.Driver.Graphics;
using System.Windows.Forms;
using OkuBase.Graphics;
using OkuBase.Settings;

namespace OkuDrivers
{
  public class OpenGLGraphicsDriver : IGraphicsDriver
  {
    public string DriverName
    {
      get { return "opengl"; }
    }

    #region IGraphicsDriver Member


    public Control Display
    {
      get { throw new NotImplementedException(); }
    }

    public void Initialize(GraphicsSettings settings)
    {
      throw new NotImplementedException();
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Finish()
    {
      throw new NotImplementedException();
    }

    public void LoadImage(Image image)
    {
      throw new NotImplementedException();
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
      throw new NotImplementedException();
    }

    public void ReleaseImage(Image image)
    {
      throw new NotImplementedException();
    }

    public void Begin()
    {
      throw new NotImplementedException();
    }

    public void End()
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
