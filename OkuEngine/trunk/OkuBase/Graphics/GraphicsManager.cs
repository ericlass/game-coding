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

    internal IGraphicsDriver Driver
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

    public Image NewImage(ImageData data)
    {
      Image result = new Image(data);
      _driver.LoadImage(result);
      return result;
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, System.Drawing.Bitmap bitmap)
    {
    }

    public void ReleaseImage(Image image)
    {
    }

    #endregion

    #region Rendering

    internal void Begin()
    {
    }

    internal void End()
    {
    }

    #endregion

  }
}
