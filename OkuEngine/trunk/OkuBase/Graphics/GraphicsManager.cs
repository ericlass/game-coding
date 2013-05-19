using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OkuBase.Driver.Graphics;
using OkuBase.Settings;
using OkuBase.Geometry;
using OkuBase.Utils;

namespace OkuBase.Graphics
{
  public class GraphicsManager : Manager
  {
    private IGraphicsDriver _driver = null;
    private ViewPort _viewport = null;

    void OnViewportChange(ViewPort sender)
    {
      _driver.SetViewport(sender.Left, sender.Right, sender.Bottom, sender.Top);
    }

    public IGraphicsDriver Driver
    {
      get { return _driver; }
    }

    public ViewPort Viewport
    {
      get { return _viewport; }
    }

    public override void Initialize(OkuSettings settings)
    {
      _driver = Oku.Instance.Drivers.GraphicsDriver;
      _driver.Initialize(settings.Graphics);

      _viewport = new ViewPort(settings.Graphics.Width, settings.Graphics.Height);
      _viewport.Change += new ViewPortChangeEventHandler(OnViewportChange);
    }

    public override void Update(float dt)
    {
    }

    public override void Finish()
    {
    }

    /// <summary>
    /// Converts the given screen pixel coordinates to display client coordinates.
    /// The origin for these coordinates is in the lower left corner.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The client space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    public Vector2f ScreenToDisplay(int x, int y)
    {
      Point p = _driver.Display.PointToClient(new Point((int)x, (int)y));
      return new Vector2f(p.X, (_driver.Display.ClientSize.Height - 1) - p.Y);
    }

    /// <summary>
    /// Converts the given screen pixel coordinates to world coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The world space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    public Vector2f ScreenToWorld(int x, int y)
    {
      Vector2f pDist = ScreenToDisplay(x, y);

      float wx = OkuMath.InterpolateLinear(_viewport.Left, _viewport.Right, pDist.X / _driver.Display.ClientSize.Width);
      float wy = OkuMath.InterpolateLinear(_viewport.Bottom, _viewport.Top, pDist.Y / _driver.Display.ClientSize.Height);

      return new Vector2f(wx, wy);
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
