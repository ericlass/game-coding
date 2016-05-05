using System;
using System.Windows.Forms;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuBase.Geometry;
using OkuMath;

namespace OkuBase.Driver
{
  /// <summary>
  /// Defines the interface for a graphics driver.
  /// </summary>
  public interface IGraphicsDriver
  {
    string DriverName { get; }
    Control Display { get; }

    void Initialize(GraphicsSettings settings);
    void Update(float dt);
    void Finish();

    void Begin();
    void End();
    void Clear();

    void InitImage(Image image);
    void ReleaseImage(Image image);

    void InitRenderTarget(RenderTarget target);
    void ReleaseRenderTarget(RenderTarget target);

    bool InitShaderProgram(ShaderProgram program);
    void ReleaseShaderProgram(ShaderProgram program);

    void SetShaderValue(string name, params float[] values);
    void SetShaderValue(string name, ImageBase image);

    void SetViewport(float left, float right, float bottom, float top);

    void PushTransform();
    void PopTransform();

    void Draw(int first, int count);
    void DrawInstanced(int first, int count, int primcount);

    Vector2f[] VertexPositions { set; }
    Vector2f[] VertexTexCoords { set; }
    Color[] VertexColors { set; }

    PrimitiveType PrimitiveType { set; }

    ImageBase Texture { set; }

    Color BackgroundColor { set; }
    RenderTarget RenderTarget { set; }
    ScissorRect ScissorRectangle { set; }

    Vector2f Translation { set; }
    Vector2f Scale { set; }
    float Angle { set; }
    bool ScreenSpace { set; }

    ShaderProgram Shader { set; }

    float LineWidth { set; }
    float PointSize { set; }

  }
}
