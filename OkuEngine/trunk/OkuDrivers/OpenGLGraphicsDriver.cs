using System;
using System.Collections.Generic;
using OkuBase.Driver.Graphics;
using System.Windows.Forms;
using OkuBase.Graphics;
using OkuBase.Settings;

namespace OkuDrivers
{
  public class OpenGLGraphicsDriver : IGraphicsDriver
  {
    public string DriverName
    {
      get { return "opengl"; }
    }

    #region IGraphicsDriver Member


    public Control Display
    {
      get { throw new NotImplementedException(); }
    }

    public void Initialize(GraphicsSettings settings)
    {
      throw new NotImplementedException();
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Finish()
    {
      throw new NotImplementedException();
    }

    public void LoadImage(Image image)
    {
      throw new NotImplementedException();
    }

    public void UpdateImage(Image image, int x, int y, int width, int height, ImageData data)
    {
      throw new NotImplementedException();
    }

    public void ReleaseImage(Image image)
    {
      throw new NotImplementedException();
    }

    public void Begin()
    {
      throw new NotImplementedException();
    }

    public void End()
    {
      throw new NotImplementedException();
    }

    public void DrawImage(Image image, float x, float y, float rotation, float sx, float sy, Color tint)
    {
      throw new NotImplementedException();
    }

    public void DrawScreenAlignedQuad(Image image, Color tint)
    {
      throw new NotImplementedException();
    }

    public void DrawLine(float x1, float y1, float x2, float y2, float width, Color color)
    {
      throw new NotImplementedException();
    }

    public void DrawLines(OkuBase.Geometry.Vector2f[] vertices, Color[] colors, int count, float width, VertexInterpretation interpretation)
    {
      throw new NotImplementedException();
    }

    public void DrawPoint(float x, float y, float size, Color color)
    {
      throw new NotImplementedException();
    }

    public void DrawPoints(OkuBase.Geometry.Vector2f[] points, Color[] colors, int count, float size)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
