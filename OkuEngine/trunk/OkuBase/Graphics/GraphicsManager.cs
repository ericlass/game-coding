using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OkuBase.Driver.Graphics;
using OkuBase.Settings;

namespace OkuBase.Graphics
{
  public class GraphicsManager : Manager
  {
    private IGraphicsDriver _driver = null;

    public IGraphicsDriver Driver
    {
      get { return _driver; }
    }

    public override void Initialize(OkuSettings settings)
    {
      _driver = Oku.Instance.Drivers.GraphicsDriver;
      _driver.Initialize(settings.Graphics);
    }

    public override void Update(float dt)
    {
    }

    public override void Finish()
    {
    }

    #region Images

    public Image NewImage(ImageData data, bool compressed)
    {
      Image result = new Image(data, compressed);
      _driver.LoadImage(result);
      return result;
    }

    public Image NewImage(ImageData data)
    {
      return NewImage(data, false);
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
      _driver.UpdateImage(image, x, y, width, height, data);
    }

    public void ReleaseImage(Image image)
    {
      _driver.ReleaseImage(image);
    }

    #endregion

    #region Rendering

    internal void Begin()
    {
      _driver.Begin();
    }

    internal void End()
    {
      _driver.End();
    }

    #endregion

  }
}
