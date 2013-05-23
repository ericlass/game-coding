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

    public void Initialize(GraphicsSettings settings)
    {
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
    }

    public void LoadImage(Image image)
    {
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
    }

    public void ReleaseImage(Image image)
    {
    }

    public void Begin()
    {
    }

    public void End()
    {
    }

    public void DrawImage(Image image, float x, float y, float rotation, float sx, float sy, Color tint)
    {
    }

    public void DrawScreenAlignedQuad(Image image, Color tint)
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

    public void DrawMesh(OkuBase.Geometry.Vector2f[] points, OkuBase.Geometry.Vector2f[] texCoords, Color[] colors, int count, PrimitiveType type, Image texture)
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

  }
}
