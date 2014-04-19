using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using OkuBase.Graphics;
using OkuBase.Settings;

namespace OkuBase.Driver
{
  public class NullGraphicsDriver : IGraphicsDriver
  {
    public string DriverName
    {
      get { return "null"; }
    }

    public Control Display
    {
      get { return null; }
    }

    public void SetBackgroundColor(Color color)
    {
    }

    public void Initialize(GraphicsSettings settings)
    {
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
    }

    public void InitImage(Image image)
    {
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
    }

    public void ReleaseImage(Image image)
    {
    }

    public void InitRenderTarget(RenderTarget target)
    {
    }

    public void SetRenderTarget(RenderTarget target)
    {
    }

    public void ReleaseRenderTarget(RenderTarget target)
    {
    }

    public void Begin()
    {
    }

    public void End()
    {
    }

    public void Clear()
    {
    }

    public void DrawImage(ImageBase image, float x, float y, float rotation, float sx, float sy, Color tint)
    {
    }

    public void DrawScreenAlignedQuad(ImageBase image, Color tint)
    {
    }

    public void DrawLine(float x1, float y1, float x2, float y2, float width, Color color)
    {
    }

    public void DrawLines(OkuBase.Geometry.Vector2f[] vertices, Color[] colors, int count, float width, LineMode interpretation)
    {
    }

    public void DrawPoint(float x, float y, float size, Color color)
    {
    }

    public void DrawPoints(OkuBase.Geometry.Vector2f[] points, Color[] colors, int count, float size)
    {
    }

    public void DrawMesh(OkuBase.Geometry.Vector2f[] points, OkuBase.Geometry.Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, ImageBase texture)
    {
    }

    public void SetViewport(float left, float right, float bottom, float top)
    {
    }

    public void BeginScreenSpace()
    {
    }

    public void EndScreenSpace()
    {
    }

    public void SetScissorRectangle(int left, int right, int width, int height)
    {
    }

    public void ClearScissorRectangle()
    {
    }

    public void ApplyAndPushTransform(OkuBase.Geometry.Vector2f translation, OkuBase.Geometry.Vector2f scale, float angle)
    {
    }

    public void PopTransform()
    {
    }

    public bool InitShaderProgram(ShaderProgram program)
    {
      return true;
    }

    public void UseShaderProgram(ShaderProgram program)
    {
    }

    public void SetShaderFloat(ShaderProgram program, string name, params float[] values)
    {
    }

    public void SetShaderTexture(ShaderProgram program, string name, ImageBase image)
    {
    }

    public void ReleaseShaderProgram(ShaderProgram program)
    {
    }

    public void InitVertexBuffer(Geometry.VertexBuffer vbuffer)
    {
    }

    public void UpdateVertexBuffer(Geometry.VertexBuffer vbuffer)
    {
    }

    public void ReleaseVertexBuffer(Geometry.VertexBuffer vbuffer)
    {
    }

    public void DrawVertexBuffer(Geometry.VertexBuffer vbuffer, PrimitiveType ptype, ImageBase texture)
    {
    }
  }
}
