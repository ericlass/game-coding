using System;
using System.Collections.Generic;
using System.Drawing;
using OkuEngine;

namespace OkuTest
{
  public class GodrayGame : OkuGame
  {
    private ImageContent _mask = null;
    private Vector2f _mousePos = Vector2f.Zero;
    private Vector2f _lightPos = Vector2f.Zero;
    private OkuEngine.Color _lightColor = new OkuEngine.Color(247, 235, 202);
    private PixelShaderContent _rayShader = null;

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = OkuEngine.Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Height = 768;
      renderParams.Width = 1024;
      renderParams.Passes = 2;
    }*/

    public override void Initialize()
    {
      _mask = new ImageContent(".\\content\\mask.png");

      _rayShader = new PixelShaderContent(
        "uniform sampler2D tex;\n" +
        "uniform vec2 lightPos;\n" +
        "\n" +
        "const int numSamples = 96;\n" +
        "const float decay = 0.985;\n" +
        "\n" +
        "varying vec2 Texcoord;\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "  vec2 texCoords = Texcoord;\n" +
        "  vec4 color = texture2D(tex, texCoords);\n" +
        "  vec2 lightDir = lightPos - texCoords;\n" +
        "  lightDir = lightDir / numSamples;\n" +
        "  float currentDecay = 1.0;\n" +
        "  for (int i = 0; i < numSamples; i++)\n" +
        "  {\n" +
        "    texCoords += lightDir;\n" +
        "    color = color + texture2D(tex, texCoords) * currentDecay;\n" +
        "    currentDecay *= decay;\n" +
        "  }\n" +
        "  gl_FragColor = color / 20.0;\n" +
        "}");
    }

    public override void Update(float dt)
    {
      //Get mouse position in window client coordinates
      Point m = OkuManagers.Renderer.Display.PointToClient(new Point(OkuManagers.Input.Mouse.X, OkuManagers.Input.Mouse.Y));

      //Calculate mouse coordinates in world space
      _mousePos.X = OkuData.Instance.SceneManager.ActiveScene.Viewport.Left + m.X;
      _mousePos.Y = OkuData.Instance.SceneManager.ActiveScene.Viewport.Top - m.Y;

      //Get width and height of view
      float viewWidth = OkuData.Instance.SceneManager.ActiveScene.Viewport.Width;
      float viewHeight = OkuData.Instance.SceneManager.ActiveScene.Viewport.Height;

      //Get mouse (light) position in view space
      float lightX = _mousePos.X - OkuData.Instance.SceneManager.ActiveScene.Viewport.Left;
      float lightY = _mousePos.Y - OkuData.Instance.SceneManager.ActiveScene.Viewport.Bottom;

      //Convert view space light coordinates to texture space
      _lightPos.X = lightX / viewWidth;
      _lightPos.Y = lightY / viewHeight;
    }

    public override void Render(int pass)
    {
      switch (pass)
      {
        case 0:
          OkuManagers.Renderer.DrawPoint(_mousePos, 50, _lightColor);
          OkuManagers.Renderer.DrawScreenAlignedQuad(_mask);
          break;

        case 1:
          OkuManagers.Renderer.UseShader(_rayShader);
          OkuManagers.Renderer.SetShaderFloat(_rayShader, "lightPos", new float[] { _lightPos.X, _lightPos.Y });
          OkuManagers.Renderer.SetShaderTexture(_rayShader, "tex", OkuManagers.Renderer.GetPassResult(0, 0));

          OkuManagers.Renderer.DrawScreenAlignedQuad(OkuManagers.Renderer.GetPassResult(0, 0));

          OkuManagers.Renderer.UseShader(null);
          break;

        default:
          break;
      }
      
    }

  }
}
