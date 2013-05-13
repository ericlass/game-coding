using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OkuBase.Driver.Graphics
{
  public interface IGraphicsDriver
  {
    /// <summary>
    /// Gets the name of the driver.
    /// </summary>
    string DriverName { get; }

    /// <summary>
    /// Gets the control that is used to render.
    /// This may be a window or some other control in a window.
    /// </summary>
    Control Display { get; }

    /// <summary>
    /// Begin drawing a new frame.
    /// </summary>
    void Begin();

    /// <summary>
    /// Drawing the frame is finished and the frame can be presented.
    /// </summary>
    void End();

  }
}
