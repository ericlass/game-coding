using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

    
    void DrawImage(ImageContent content, Vector position);
    void DrawImage(ImageContent content, Vector position, float rotation);
    void DrawImage(ImageContent content, Vector position, Vector scale);
    void DrawImage(ImageContent content, Vector position, float rotation, Vector scale);

    void DrawImage(ImageContent content, Vector position, Color tint);
    void DrawImage(ImageContent content, Vector position, float rotation, Color tint);
    void DrawImage(ImageContent content, Vector position, Vector scale, Color tint);
    void DrawImage(ImageContent content, Vector position, float rotation, Vector scale, Color tint);

    void DrawImage(ImageContent content, Matrix3 transform);
    void DrawImage(ImageContent content, Matrix3 transform, Color tint);

    //Line drawing
    void DrawLine(Vector start, Vector end, float width, Color color);
    void DrawLines(VectorList vertices, float width, Color color, VertexInterpretation interpretation);

    void DrawLine(Vector start, Vector end, Matrix3 transform, float width, Color color);
    void DrawLines(VectorList vertices, Matrix3 transform, float width, Color color, VertexInterpretation interpretation);

    //Point drawing
    void DrawPoint(Vector p, float size, Color color);
    void DrawPoints(VectorList points, float size, Color color);

    void DrawPoint(Vector p, Matrix3 transform, float size, Color color);
    void DrawPoints(VectorList points, Matrix3 transform, float size, Color color);

    //Content handling
    void InitContentFile(ImageContent content, Stream data);
    void InitContentRaw(ImageContent content, byte[] data, int width, int height);
    void ReleaseContent(ImageContent content);
  }
}
