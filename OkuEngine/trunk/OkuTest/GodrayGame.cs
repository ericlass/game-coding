﻿using System;
using System.Collections.Generic;
using System.Drawing;
using OkuEngine;

namespace OkuTest
{
  public class GodrayGame : OkuGame
  {
    private ImageContent _mask = null;
    private Vector _mousePos = Vector.Zero;
    private Vector _lightPos = Vector.Zero;
    private OkuEngine.Color _lightColor = new OkuEngine.Color(247, 235, 202);
    private PixelShaderContent _rayShader = null;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = OkuEngine.Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Height = 768;
      renderParams.Width = 1024;
      renderParams.Passes = 2;
    }

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
      Point m = OkuDrivers.Renderer.MainForm.PointToClient(new Point(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y));

      //Calculate mouse coordinates in world space
      _mousePos.X = OkuDrivers.Renderer.ViewPort.Left + m.X;
      _mousePos.Y = OkuDrivers.Renderer.ViewPort.Top - m.Y;

      //Get width and height of view
      float viewWidth = OkuDrivers.Renderer.ViewPort.Width;
      float viewHeight = OkuDrivers.Renderer.ViewPort.Height;

      //Get mouse (light) position in view space
      float lightX = _mousePos.X - OkuDrivers.Renderer.ViewPort.Left;
      float lightY = _mousePos.Y - OkuDrivers.Renderer.ViewPort.Bottom;

      //Convert view space light coordinates to texture space
      _lightPos.X = lightX / viewWidth;
      _lightPos.Y = lightY / viewHeight;
    }

    public override void Render(int pass)
    {
      switch (pass)
      {
        case 0:
          OkuDrivers.Renderer.DrawPoint(_mousePos, 50, _lightColor);
          OkuDrivers.Renderer.DrawScreenAlignedQuad(_mask);
          break;

        case 1:
          OkuDrivers.Renderer.UseShader(_rayShader);
          OkuDrivers.Renderer.SetShaderFloat(_rayShader, "lightPos", new float[] { _lightPos.X, _lightPos.Y });
          OkuDrivers.Renderer.SetShaderTexture(_rayShader, "tex", OkuDrivers.Renderer.GetPassResult(0, 0));

          OkuDrivers.Renderer.DrawScreenAlignedQuad(OkuDrivers.Renderer.GetPassResult(0, 0));

          OkuDrivers.Renderer.UseShader(null);
          break;

        default:
          break;
      }
      
    }

  }
}