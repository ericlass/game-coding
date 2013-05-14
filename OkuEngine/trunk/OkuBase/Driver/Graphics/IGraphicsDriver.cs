using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase.Graphics;
using OkuBase.Settings;

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
    /// Is called once at the start of the application. It should do all necessary initialization
    /// that is needed by the renderer. It has to create the form that is used to display the game.
    /// </summary>
    /// <param name="settings">The settings for rendering.</param>
    void Initialize(GraphicsSettings settings);

    /// <summary>
    /// Is called each frame during the update process. This must not do any rendering. It should
    /// only be used for updating internal stuff.
    /// </summary>
    /// <param name="dt">The time since the last frame in seconds.</param>
    void Update(float dt);

    /// <summary>
    /// Is called when the application ends. All resources allocated by the renderer have to be freed
    /// by this method.
    /// </summary>
    void Finish();

    /// <summary>
    /// Initializes image content which means that textures are created for them.
    /// This method also sets the Width and Height properties of the content.
    /// If the given content has already been initialized, the current texture
    /// is dropped and a new one is created. This can be used to update the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The pixel data of the image.</param>
    void LoadImage(Image image, ImageData data);

    /// <summary>
    /// Updates a region of the given image content with new image data.
    /// </summary>
    /// <param name="content">The content to be updated.</param>
    /// <param name="x">The left bound of the region.</param>
    /// <param name="y">The top bound of the region.</param>
    /// <param name="width">The width of the region.</param>
    /// <param name="height">The height of the region.</param>
    /// <param name="image">The image data to put into the region.</param>
    void UpdateImage(Image image, int x, int y, int width, int height, ImageData data);

    /// <summary>
    /// Releases content that was previously initialized by the renderer. 
    /// This frees all resource that are connected to the given content.
    /// </summary>
    /// <param name="content">The content to release.</param>
    void ReleaseImage(Image image);

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
