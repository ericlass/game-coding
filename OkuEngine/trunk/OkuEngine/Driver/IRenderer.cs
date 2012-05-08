using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace OkuEngine
{
  /// <summary>
  /// Interface with methods for rendering the game. A rendering driver has to implement all methods according to the specifications.
  /// </summary>
  public interface IRenderer
  {
    /// <summary>
    /// Gets or sets if the game is run in fullscreen mode or not.
    /// </summary>
    bool Fullscreen { get; set; }

    /// <summary>
    /// Gets or sets the color that is used to clear the screen each frame when rendering starts.
    /// </summary>
    Color ClearColor { get; set; }

    /// <summary>
    /// Gets the form that is used to render the game to.
    /// </summary>
    Control Display { get; }

    /// <summary>
    /// Gets or sets the current viewport that is rendered to the screen.
    /// </summary>
    ViewPort ViewPort { get; set; }

    /// <summary>
    /// Gets or sets the texture filter used for interpolating textures when they
    /// are minimized or maximized.
    /// </summary>
    TextureFilter TextureFilter { get; set; }

    /// <summary>
    /// Gets the number of render passes that are performed.
    /// </summary>
    int RenderPasses { get; }

    /// <summary>
    /// Gets the number of render targets for the given pass.
    /// </summary>
    /// <param name="pass">The index of the render pass.</param>
    /// <returns>The number of render targets the given pass has.</returns>
    int GetNumPassTargets(int pass);

    /// <summary>
    /// Gets the rendered image of the given pass for the given target.
    /// </summary>
    /// <param name="pass">The index of the render pass.</param>
    /// <param name="target">The index of the render target.</param>
    /// <returns>The rendered image of the given pass for the given target.</returns>
    ImageContent GetPassResult(int pass, int target);

    /// <summary>
    /// Is called once at the start of the application. It should do all necessary initialization
    /// that is needed by the renderer. It has to create the form that is used to display the game.
    /// </summary>
    void Initialize(RendererParams parameters);

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
    /// Is called once each frame right after the updating process. It should do all things that are necessary
    /// for the renderer to be able to render things.
    /// </summary>
    void Begin(int pass);

    /// <summary>
    /// Is called once each frame to finish the rendering process. It should finalize the rendering process.
    /// For example it could swap the offscreen rendering surface to the screen.
    /// </summary>
    void End(int pass);


    /// <summary>
    /// Draws the given image content at the given position.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    void DrawImage(ImageContent content, Vector position);

    /// <summary>
    /// Draws the given image content at the given position, rotating it by the given angle.
    /// The image rotated around it's center.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    void DrawImage(ImageContent content, Vector position, float rotation);

    /// <summary>
    /// Draws the given image content at the given position, scaling it by the given factors.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="scale">The scale factors.</param>
    void DrawImage(ImageContent content, Vector position, Vector scale);

    /// <summary>
    /// Draws the given image content at the given position, rotating and scaling it 
    /// by the given values.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="scale">The scale factors.</param>
    void DrawImage(ImageContent content, Vector position, float rotation, Vector scale);

    /// <summary>
    /// Draws the given image content at the given position. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    void DrawImage(ImageContent content, Vector position, Color tint);

    /// <summary>
    /// Draws the given image content at the given position, rotating it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    void DrawImage(ImageContent content, Vector position, float rotation, Color tint);

    /// <summary>
    /// Draws the given image content at the given position, scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    void DrawImage(ImageContent content, Vector position, Vector scale, Color tint);

    /// <summary>
    /// Draws the given image content at the given position, rotating and scaling it by the given 
    /// values. The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="position">The position to draw the image to in screen space pixels.</param>
    /// <param name="rotation">The rotation angle in degrees.</param>
    /// <param name="scale">The scale factors.</param>
    /// <param name="tint">A color that is used to tint the image with.</param>
    void DrawImage(ImageContent content, Vector position, float rotation, Vector scale, Color tint);

    /// <summary>
    /// Draws the given image content on a screen aligned quad so it fills the whole screen.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    void DrawScreenAlignedQuad(ImageContent content);

    /// <summary>
    /// Draws the given image content on a screen aligned quad so it fills the whole 
    /// screen using the given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="tint">The color tint the image with.</param>
    void DrawScreenAlignedQuad(ImageContent content, Color tint);

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    void DrawLine(Vector start, Vector end, float width, Color color);

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw lines with.</param>
    /// <param name="color">The color of the lines.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixel.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(Vector[] vertices, Color color, int count, float width, VertexInterpretation interpretation);

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and colors.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw the lines with.</param>
    /// <param name="colors">The colors belonging to the vertices. Has to be same lentgh as vertices.</param>
    /// <param name="count">The number of lines to draw from the given array.</param>
    /// <param name="width">The width of the lines in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(Vector[] vertices, Color[] colors, int count, float width, VertexInterpretation interpretation);

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="p">The center of the point in world space pixels.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    void DrawPoint(Vector p, float size, Color color);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in world space pixels.</param>
    /// <param name="color">The color of the points.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="size">The size of the points in pixels.</param>
    void DrawPoints(Vector[] points, Color color, int count, float size);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in world space pixels.</param>
    /// <param name="colors">The color values belonging to the points. Must be same length as points.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="size">The size of the points in pixels.</param>
    void DrawPoints(Vector[] points, Color[] colors, int count, float size);

    /// <summary>
    /// Draws a generic mesh using the given parameters.
    /// </summary>
    /// <param name="points">The coordinates of the vertices of the mesh in world space. Must not be null.</param>
    /// <param name="texCoords">The normalized texture coordinates of the vertices. Must be same length as points. If null, no texture is applied.</param>
    /// <param name="colors">The colors of the vertices. Must be same length as points. If null, white is used as default color.</param>
    /// <param name="count">The number of points to draw from the given array.</param>
    /// <param name="mode">The mode used to create polygons from the given vertices.</param>
    /// <param name="texture">The texture to be applied. If not null, texCoords must also be given.</param>
    void DrawMesh(Vector[] points, Vector[] texCoords, Color[] colors, int count, MeshMode mode, ImageContent texture);

    /// <summary>
    /// Initializes image content which means that textures are created for them.
    /// This method also sets the Width and Height properties of the content.
    /// If the given content has already been initialized, the current texture
    /// is dropped and a new one is created. This can be used to update the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The content data. This must be a stream that contains a complete image file like PNG, BMP or JPG.</param>
    void InitContentFile(ImageContent content, Stream data);

    /// <summary>
    /// Initializes image content from raw data which is represented by a byte array.
    /// The data is expected to only contain pixel data.
    /// This method also sets the Width and Height properties of the content.
    /// If the given content has already been initialized, the current texture
    /// is dropped and a new one is created. This can be used to update the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The pixel data.</param>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    void InitContentRaw(ImageContent content, byte[] data, int width, int height);

    /// <summary>
    /// Initializes image content which means that textures are created for them.
    /// This method also sets the Width and Height properties of the content.
    /// If the given content has already been initialized, the current texture
    /// is dropped and a new one is created. This can be used to update the content.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">A bitmap containing the image data. Must be pixel format Format32bppArgb.</param>
    void InitContentBitmap(ImageContent content, Bitmap image);

    /// <summary>
    /// Updates a region of the given image content with new image data.
    /// </summary>
    /// <param name="content">The content to be updated.</param>
    /// <param name="x">The left bound of the region.</param>
    /// <param name="y">The top bound of the region.</param>
    /// <param name="width">The width of the region.</param>
    /// <param name="height">The height of the region.</param>
    /// <param name="rawData">The data to put into the region.</param>
    void UpdateContent(ImageContent content, int x, int y, int width, int height, byte[] rawData);

    /// <summary>
    /// Updates a region of the given image content with new image data.
    /// </summary>
    /// <param name="content">The content to be updated.</param>
    /// <param name="x">The left bound of the region.</param>
    /// <param name="y">The top bound of the region.</param>
    /// <param name="width">The width of the region.</param>
    /// <param name="height">The height of the region.</param>
    /// <param name="image">The image data to put into the region.</param>
    void UpdateContent(ImageContent content, int x, int y, int width, int height, Bitmap image);

    /// <summary>
    /// Releases content that was previously initialized by the renderer. 
    /// This frees all resource that are connected to the given content.
    /// </summary>
    /// <param name="content">The content to release.</param>
    void ReleaseContent(ImageContent content);

    /// <summary>
    /// Intializes the given pixel shader by compiling and linking it.
    /// The source must already be attached to the given content.
    /// </summary>
    /// <param name="content">The pixel shader content to be initialized.</param>
    void InitShaderContent(PixelShaderContent content);

    /// <summary>
    /// Enables the given pixel shader. If null is passed shaders are disabled.
    /// </summary>
    /// <param name="content">The shader content to use.</param>
    void UseShader(PixelShaderContent content);

    /// <summary>
    /// Sets the given texture to the variable of the given shader.
    /// </summary>
    /// <param name="shader">The shader.</param>
    /// <param name="name">The name of the variable.</param>
    /// <param name="texture">The texture to set.</param>
    void SetShaderTexture(PixelShaderContent shader, string name, ImageContent texture);

    /// <summary>
    /// Sets the float values to a uniform variable in the given shader.
    /// The length of the given array determines the type of the shader
    /// variable (vec1, vec2, vec3, vec4).
    /// </summary>
    /// <param name="shader">The shader to set the variable at.</param>
    /// <param name="name">The name of the variable.</param>
    /// <param name="values">The float values to set.</param>
    void SetShaderFloat(PixelShaderContent shader, string name, float[] values);

    /// <summary>
    /// Converts the given screen pixel coordinates to display client coordinates.
    /// The origin for these coordinates is in the lower left corner.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The client space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    Vector ScreenToDisplay(int x, int y);

    /// <summary>
    /// Converts the given screen pixel coordinates to world coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The world space coordinates of the given pixel. Note that this can be outside of the window in windowed mode.</returns>
    Vector ScreenToWorld(int x, int y);

    /// <summary>
    /// Set the renderer to screen space mode. In this mode
    /// all draw calls are done in screen space.
    /// </summary>
    void BeginScreenSpace();

    /// <summary>
    /// Ends the screen space mode.
    /// </summary>
    void EndScreenSpace();
  }
}
