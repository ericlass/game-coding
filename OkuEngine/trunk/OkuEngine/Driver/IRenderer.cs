using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Interface with methods for rendering the game.
  /// </summary>
  public interface IRenderer
  {
    bool Fullscreen { get; set; }
    Color ClearColor { get; set; }
    Form MainForm { get; }

    //Initialization / Finalization
    void Initialize();
    void Update(float dt);
    void Finish();

    //Rendering
    void Begin();
    void End();

    //Image drawing
    void DrawImage(ImageContent content, Vector position);
    void DrawImage(ImageContent content, Vector position, float rotation);
    void DrawImage(ImageContent content, Vector position, Vector scale);
    void DrawImage(ImageContent content, Vector position, float rotation, Vector scale);    
    void DrawImage(ImageContent content, Vector position, Color tint);
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
