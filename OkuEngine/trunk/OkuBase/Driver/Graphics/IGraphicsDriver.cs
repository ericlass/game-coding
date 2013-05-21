using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase.Geometry;
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
    /// Initializes an image which means that textures are created for them.
    /// </summary>
    /// <param name="image">The image to be initialized.</param>
    void LoadImage(Image image);

    /// <summary>
    /// Updates a region of the given image content with new image data.
    /// </summary>
    /// <param name="image">The image to be updated.</param>
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
    /// <param name="image">The image to release.</param>
    void ReleaseImage(Image image);

    /// <summary>
    /// Begin drawing a new frame.
    /// </summary>
    void Begin();

    /// <summary>
    /// Drawing the frame is finished and the frame can be presented.
    /// </summary>
    void End();

    /// <summary>
    /// Draws the given image at the given position, rotating and scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="sx">The scale factor on the x axis.</param>
    /// <param name="sy">The scale factor on the y axis.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    void DrawImage(Image image, float x, float y, float rotation, float sx, float sy, Color tint);

    /// <summary>
    /// Draws the given image on a screen aligned quad so it fills the whole 
    /// screen using the given tint color.
    /// </summary>
    /// <param name="image">The image to be drawn.</param>
    /// <param name="tint">The color tint the image with.</param>
    void DrawScreenAlignedQuad(Image image, Color tint);

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="x1">The x coordinate of the start point.</param>
    /// <param name="y1">The y coordinate of the start point.</param>
    /// <param name="x2">The x coordinate of the end point.</param>
    /// <param name="y2">The y coordinate of the end point.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    void DrawLine(float x1, float y1, float x2, float y2, float width, Color color);

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and colors.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw the lines with.</param>
    /// <param name="colors">The colors belonging to the vertices. Has to be same length as vertices.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(Vector2f[] vertices, Color[] colors, int count, float width, LineMode interpretation);

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="x">The x coordinate of the point.</param>
    /// <param name="y">The y coordinate of the point.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    void DrawPoint(float x, float y, float size, Color color);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in world space pixels.</param>
    /// <param name="colors">The color values belonging to the points. Must be same length as points.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="size">The size of the points in pixels.</param>
    void DrawPoints(Vector2f[] points, Color[] colors, int count, float size);


    /// <summary>
    /// Draws a generic mesh using the given parameters.
    /// </summary>
    /// <param name="points">The coordinates of the vertices of the mesh in world space. Must not be null.</param>
    /// <param name="texCoords">The normalized texture coordinates of the vertices. Must be same length as points. If null, no texture is applied.</param>
    /// <param name="colors">The colors of the vertices. Must be same length as points. If null, white is used as default color.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="type">The type of primitive used to draw the given vertices.</param>
    /// <param name="texture">The texture to be applied. If not null, texCoords must also be given.</param>
    void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, Image texture);


    /// <summary>
    /// Set the current part of the world that is shown in the display.
    /// </summary>
    /// <param name="left">The left bound of the viewport.</param>
    /// <param name="right">The right bound of the viewport.</param>
    /// <param name="bottom">The bottom bound of the viewport.</param>
    /// <param name="top">The top bound of the viewport.</param>
    void SetViewport(float left, float right, float bottom, float top);

    /// <summary>
    /// Set the renderer to screen space mode. In this mode
    /// all draw calls are done in screen space.
    /// </summary>
    void BeginScreenSpace();

    /// <summary>
    /// Ends the screen space mode.
    /// </summary>
    void EndScreenSpace();

    /// <summary>
    /// Sets a rectangular area of the screen where drawing will happen. 
    /// Everything outside of the specified area will not be drawn and
    /// kept form the previous frame.
    /// The area is specified in display space pixel coordinates and are inclusive.
    /// </summary>
    /// <param name="left">The left border of the scissor rectangle.</param>
    /// <param name="right">The right border of the scissor rectangle.</param>
    /// <param name="width">The width of the scissor rectangle.</param>
    /// <param name="height">The height of the scissor rectangle.</param>
    void SetScissorRectangle(int left, int right, int width, int height);

    /// <summary>
    /// Clear the scissor rectangle so that thw whole screen is redrawn again.
    /// </summary>
    void ClearScissorRectangle();

    /// <summary>
    /// Pushes the current transformation onto the stack and applies the given transformation.
    /// </summary>
    /// <param name="translation">The amount to translate.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="angle">The angle to rotate.</param>
    void ApplyAndPushTransform(Vector2f translation, Vector2f scale, float angle);

    /// <summary>
    /// Pops the current transformation from the stack.
    /// </summary>
    void PopTransform();

  }
}
