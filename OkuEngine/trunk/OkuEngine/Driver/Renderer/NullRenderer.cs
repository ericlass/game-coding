using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OkuEngine.Driver.Renderer
{
  /// <summary>
  /// Defines a renderer that does not render anything.
  /// </summary>
  public class NullRenderer : IRenderer
  {
    public const string RendererName = "null";

    public bool Fullscreen
    {
      get { return false; }
      set { }
    }

    public Color ClearColor
    {
      get { return Color.Black; }
      set { }
    }

    public Control Display
    {
      get { return null; }
    }

    public TextureFilter TextureFilter
    {
      get { return TextureFilter.Linear; }
      set { }
    }

    public int RenderPasses
    {
      get { return 0; }
    }

    public int GetNumPassTargets(int pass)
    {
      return 0;
    }

    public ImageContent GetPassResult(int pass, int target)
    {
      return null;
    }

    public void Initialize(System.Xml.XmlNode node)
    {
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
    }

    public void Begin(int pass)
    {
    }

    public void End(int pass)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, float rotation)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, Vector2f scale)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, float rotation, Vector2f scale)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, Color tint)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, float rotation, Color tint)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, Vector2f scale, Color tint)
    {
    }

    public void DrawImage(ImageContent content, Vector2f position, float rotation, Vector2f scale, Color tint)
    {
    }

    public void DrawScreenAlignedQuad(ImageContent content)
    {
    }

    public void DrawScreenAlignedQuad(ImageContent content, Color tint)
    {
    }

    public void DrawLine(Vector2f start, Vector2f end, float width, Color color)
    {
    }

    public void DrawLines(Vector2f[] vertices, Color color, int count, float width, VertexInterpretation interpretation)
    {
    }

    public void DrawLines(Vector2f[] vertices, Color[] colors, int count, float width, VertexInterpretation interpretation)
    {
    }

    public void DrawPoint(Vector2f p, float size, Color color)
    {
    }

    public void DrawPoints(Vector2f[] points, Color color, int count, float size)
    {
    }

    public void DrawPoints(Vector2f[] points, Color[] colors, int count, float size)
    {
    }

    public void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, MeshMode mode, ImageContent texture)
    {
    }

    public void InitImageContent(ImageContent content, System.Drawing.Bitmap image)
    {
    }

    public void UpdateContent(ImageContent content, int x, int y, int width, int height, System.Drawing.Bitmap image)
    {
    }

    public void ReleaseContent(ImageContent content)
    {
    }

    public void InitShaderContent(PixelShaderContent content)
    {
    }

    public void UseShader(PixelShaderContent content)
    {
    }

    public void SetShaderTexture(PixelShaderContent shader, string name, ImageContent texture)
    {
    }

    public void SetShaderFloat(PixelShaderContent shader, string name, float[] values)
    {
    }

    public Vector2f ScreenToDisplay(int x, int y)
    {
      return Vector2f.Zero;
    }

    public Vector2f ScreenToWorld(int x, int y)
    {
      return Vector2f.Zero;
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

    public void SetTransform(Matrix3 transform)
    {
    }

    public void SetViewTransform(Matrix3 transform)
    {
    }


    public void ApplyAndPushTransform(Transformation transform)
    {
    }

    public void PopTransform()
    {
    }

    public void OnViewportEvent(int eventType, params object[] eventData)
    {
    }

    public void DrawMesh(Vector2f[] points, Vector2f[] texCoords, Color[] colors, int count, DrawMode mode, ImageContent texture)
    {
    }

    public void SetLineWidth(float width)
    {
    }

    public void SetPointSize(float size)
    {
    }

  }
}
