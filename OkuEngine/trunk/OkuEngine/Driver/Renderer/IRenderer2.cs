using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OkuEngine.Driver.Renderer
{
  /// <summary>
  /// A try to streamline the rendering interface. NOT USED!
  /// </summary>
  public interface IRenderer2
  {
    Color Background { get; set; }
    Color Foreground { get; set; }
    ImageContent Texture { get; set; }
    Vector[] Vertices { get; set; }
    Vector[] TextureCoordinates { get; set; }
    Color[] Colors { get; set; }
    PixelShaderContent PixelShader { get; set; }
    Vector Translation { get; set; }

    bool Initialize();
    void Update(float dt);
    void Begin(int pass);
    void Draw(DrawMode mode);
    void End(int pass);

    void BeginScreenSpace();
    void EndScreenSpace();

    void SetScissorRectangle(int left, int right, int width, int height);
    void ClearScissorRectangle();

    int LoadTexture(Bitmap texture);
  }
}
