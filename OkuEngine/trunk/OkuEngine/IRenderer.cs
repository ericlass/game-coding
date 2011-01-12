﻿using System;
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
    int ScreenWidth { get; set; }
    int ScreenHeight { get; set; }
    bool Fullscreen { get; set; }
    Color ClearColor { get; set; }
    Form MainForm { get; }

    void Initialize();
    void Finish();

    void Begin();
    void End();

    //void Draw(SceneNode node);
    void DrawTree(SceneNode startNode);
    void Draw(Content content, Vector v1, Vector v2, Vector v3, Vector v4);

    void InitContent(Content content, Stream data);
    void ReleaseContent(Content content);
  }
}
