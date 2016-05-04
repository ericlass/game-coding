using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using OkuBase.Graphics;
using OkuBase.Settings;
using OkuMath;
using OkuBase.Geometry;

namespace OkuBase.Driver
{
  public class NullGraphicsDriver : IGraphicsDriver
  {
    public float Angle
    {
      set { }
    }

    public Color BackgroundColor
    {
      set { }
    }

    public Control Display
    {
      get { return null; }
    }

    public string DriverName
    {
      get { return "null"; }
    }

    public PrimitiveType PrimitiveType
    {
      set { }
    }

    public RenderTarget RenderTarget
    {
      set { }
    }

    public Vector2f Scale
    {
      set { }
    }

    public ScissorRect ScissorRectangle
    {
      set { }
    }

    public bool ScreenSpace
    {
      set { }
    }

    public ShaderProgram Shader
    {
      set { }
    }

    public ImageBase Texture
    {
      set { }
    }

    public Vector2f Translation
    {
      set { }
    }

    public Vector2f[] VertexColors
    {
      set { }
    }

    public Vector2f[] VertexPositions
    {
      set { }
    }

    public Vector2f[] VertexTexCoords
    {
      set { }
    }

    public void Begin()
    {
    }

    public void Clear()
    {
    }

    public void Draw()
    {
    }

    public void Draw(int first, int last)
    {
    }

    public void DrawInstanced(int count)
    {
    }

    public void DrawInstanced(int count, int first, int last)
    {
    }

    public void End()
    {
    }

    public void Finish()
    {
    }

    public void Initialize(GraphicsSettings settings)
    {
    }

    public void InitImage(Image image)
    {
    }

    public void InitRenderTarget(RenderTarget target)
    {
    }

    public bool InitShaderProgram(ShaderProgram program)
    {
      return true;
    }

    public void PopTransform()
    {
    }

    public void PushTransform()
    {
    }

    public void ReleaseImage(Image image)
    {
    }

    public void ReleaseRenderTarget(RenderTarget target)
    {
    }

    public void ReleaseShaderProgram(ShaderProgram program)
    {
    }

    public void SetShaderValue(string name, ImageBase image)
    {
    }

    public void SetShaderValue(string name, params float[] values)
    {
    }

    public void SetViewport(float left, float right, float bottom, float top)
    {
    }

    public void Update(float dt)
    {
    }

  }
}
