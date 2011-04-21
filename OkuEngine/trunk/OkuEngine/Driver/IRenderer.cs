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
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public interface IRenderer
  {
    bool Fullscreen { get; set; }
    Color ClearColor { get; set; }
    Form MainForm { get; }

    void Initialize();
    void Finish();

    void Begin();
    void End();

    void Draw(SceneNode node);

    void DrawLine(Vector start, Vector end);
    void DrawPoint(Vector p);

    void InitContentFile(ImageContent content, Stream data);
    void InitContentRaw(ImageContent content, byte[] data, int width, int height);
    void ReleaseContent(ImageContent content);
  }
}
