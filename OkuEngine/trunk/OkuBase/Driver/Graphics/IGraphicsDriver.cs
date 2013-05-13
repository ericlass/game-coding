using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Driver.Graphics
{
  public interface IGraphicsDriver
  {
    /// <summary>
    /// Gets the name of the driver.
    /// </summary>
    string DriverName { get; }

    /// <summary>
    /// Gets the handle of the window that is used to render.
    /// </summary>
    IntPtr DisplayHandle { get; }

  }
}
