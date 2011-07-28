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
    Form MainForm { get; }

    /// <summary>
    /// Is called once at the start of the application. It should do all necessary initialization
    /// that is needed by the renderer. It has to create the form that is used to display the game.
    /// </summary>
    void Initialize();

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
    void Begin();

    /// <summary>
    /// Is called once each frame to finish the rendering process. It should finalize the rendering process.
    /// For example it could swap the offscreen rendering surface to the screen.
    /// </summary>
    void End();


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
    /// Draws the given image transforming it by the given tranformation matrix.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="transform">The transformation matrix.</param>
    void DrawImage(ImageContent content, Matrix3 transform);

    /// <summary>
    /// Draws the given image transforming it by the given tranformation matrix.
    /// The image is tinted with given tint color.
    /// </summary>
    /// <param name="content">The content to be drawn.</param>
    /// <param name="transform">The transformation matrix.</param>
    void DrawImage(ImageContent content, Matrix3 transform, Color tint);

    /// <summary>
    /// Draws a line from (x1,y1) to (x2,y2) with the given width and color.
    /// </summary>
    /// <param name="x1">The x component of the start point.</param>
    /// <param name="y1">The y component of the start point.</param>
    /// <param name="x2">The x component of the end point.</param>
    /// <param name="y2">The y component of the end point.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    void DrawLine(float x1, float y1, float x2, float y2, float width, Color color);

    /// <summary>
    /// Draws a line from start to end with the given width and color.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    void DrawLine(Vector start, Vector end, float width, Color color);

    /// <summary>
    /// Draws a line from start to end with the given width. The color of the line 
    /// is determined by the color of the vertices.
    /// </summary>
    /// <param name="start">The start vertex.</param>
    /// <param name="end">The end vertex.</param>
    /// <param name="width">The width of the line in pixels.</param>
    void DrawLine(Vertex start, Vertex end, float width);

    /// <summary>
    /// Draws a series of lines using the given vertices with the given width and color.
    /// How the vertices are interpreted is specified by interpretation.
    /// </summary>
    /// <param name="vertices">The vertices to draw lines with.</param>
    /// <param name="width">The width of the lines in pixel.</param>
    /// <param name="color">The color of the lines.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(VectorList vertices, float width, Color color, VertexInterpretation interpretation);

    /// <summary>
    /// Draws lines using the given vertices with the given width. The color of the lines 
    /// is determined by the color of their vertices.
    /// </summary>
    /// <param name="vertices">The vertices to use.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(VertexList vertices, float width, VertexInterpretation interpretation);

    /// <summary>
    /// Draws a line from start to end with the given width and color. The vertices (start and end) are
    /// tranformed by the transformation matrix before drawing.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    void DrawLine(Vector start, Vector end, Matrix3 transform, float width, Color color);

    /// <summary>
    /// Draws a line from start to end with the given width. The vertices (start and end) are
    /// tranformed by the transformation matrix before drawing. The color of the line 
    /// is determined by the color of the vertices.
    /// </summary>
    /// <param name="start">The start vertex.</param>
    /// <param name="end">The end vertex.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    void DrawLine(Vertex start, Vertex end, Matrix3 transform, float width);

    /// <summary>
    /// Draws lines using the given vertices with the given width and color. The vertices are
    /// tranformed by the transformation matrix before drawing.
    /// </summary>
    /// <param name="vertices">The vertices to use.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(VectorList vertices, Matrix3 transform, float width, Color color, VertexInterpretation interpretation);

    /// <summary>
    /// Draws lines using the given vertices with the given width. The vertices are
    /// tranformed by the transformation matrix before drawing. The color of the lines 
    /// is determined by the color of their vertices.
    /// </summary>
    /// <param name="vertices">The vertices to use.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="width">The width of the line in pixels.</param>
    /// <param name="interpretation">Specifies how to interpret the vertices.</param>
    void DrawLines(VertexList vertices, Matrix3 transform, float width, VertexInterpretation interpretation);

    /// <summary>
    /// Draws a white point at the given coordinates with the given size.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="size">The size in pixels.</param>
    void DrawPoint(float x, float y, float size);

    /// <summary>
    /// Draws a point at the given coordinates with the given size and color.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="color">The color of the point.</param>
    void DrawPoint(float x, float y, float size, Color color);

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    void DrawPoint(Vector p, float size, Color color);

    /// <summary>
    /// Draws a point at the given vertex with the given size.
    /// The color of the point is taken from the vertex color.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="size">The size of the point in pixels.</param>
    void DrawPoint(Vertex p, float size);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// </summary>
    /// <param name="points">The center of the points in screen space pixels.</param>
    /// <param name="size">The size of the points in pixels.</param>
    /// <param name="color">The color of the points.</param>
    void DrawPoints(VectorList points, float size, Color color);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size.
    /// The color of the points is taken from the vertex colors.
    /// </summary>
    /// <param name="points">The vertices of the points.</param>
    /// <param name="size">The size of the points in pixels.</param>
    void DrawPoints(VertexList points, float size);

    /// <summary>
    /// Draws a point at the given point p with the given size and color.
    /// The point is transformed by the given transformation matrix before drawing.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the point in pixels.</param>
    /// <param name="color">The color of the point.</param>
    void DrawPoint(Vector p, Matrix3 transform, float size, Color color);

    /// <summary>
    /// Draws a point at the given vertex with the given size.
    /// The point is transformed by the given transformation matrix before drawing.
    /// The color of the point is taken from the vertex color.
    /// </summary>
    /// <param name="p">The center of the point in screen space pixels.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the point in pixels.</param>
    void DrawPoint(Vertex p, Matrix3 transform, float size);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size and color.
    /// The points are transformed by the given transformation matrix before drawing.
    /// </summary>
    /// <param name="points">The center of the points in screen space pixels.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the points in pixels.</param>
    /// <param name="color">The color of the points.</param>
    void DrawPoints(VectorList points, Matrix3 transform, float size, Color color);

    /// <summary>
    /// Draws a series of points at the given vertices with the given size.
    /// The points are transformed by the given transformation matrix before drawing.
    /// The color of the points is taken from the vertex colors.
    /// </summary>
    /// <param name="points">The vertices of the points.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="size">The size of the points in pixels.</param>
    void DrawPoints(VertexList points, Matrix3 transform, float size);

    /// <summary>
    /// Draws a mesh using the given vertices and mesh mode. The vertices are
    /// interpreted as screen space coordinates. The vertex colors will color
    /// the rendered mesh.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="mode">The mesh drwing mode.</param>
    void DrawMesh(VertexList vertices, MeshMode mode);

    /// <summary>
    /// Draws a mesh using the given vertices and mesh mode. The vertices are
    /// interpreted as screen space coordinates. The mesh is textured with the 
    /// given texture using the texture coordinates of the vertices. Vertex colors 
    /// tint the texture.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="mode">The mesh drwing mode.</param>
    /// <param name="texture">The texture to use. Can be null to specify no texture.</param>
    void DrawMesh(VertexList vertices, MeshMode mode, ImageContent texture);

    /// <summary>
    /// Draws a mesh using the given vertices and mesh mode. The vertices are
    /// interpreted as screen space coordinates. The vertex colors will color
    /// the rendered mesh. Before drawing the vertices are transformed by the 
    /// given transformation matrix.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="mode">The mesh drwing mode.</param>    
    void DrawMesh(VertexList vertices, MeshMode mode, Matrix3 transform);

    /// <summary>
    /// Draws a mesh using the given vertices and mesh mode. The vertices are
    /// interpreted as screen space coordinates. The mesh is textured with the 
    /// given texture using the texture coordinates of the vertices. Vertex colors 
    /// tint the texture. Before drawing the vertices are transformed by the 
    /// given transformation matrix.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh.</param>
    /// <param name="mode">The mesh drwing mode.</param>
    /// <param name="transform">The transformation matrix.</param>
    /// <param name="texture">The texture to use. Can be null to specify no texture.</param>
    void DrawMesh(VertexList vertices, MeshMode mode, Matrix3 transform, ImageContent texture);

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
  }
}
