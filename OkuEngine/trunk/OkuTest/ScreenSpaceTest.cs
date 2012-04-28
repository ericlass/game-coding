using System;
using System.Collections.Generic;
using System.Text;
using OkuEngine;

namespace OkuTest
{
  public class ScreenSpaceTest : OkuGame
  {
    ImageContent _earth = null;
    ImageContent _yin = null;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 786;
    }

    public override void Initialize()
    {
      _earth = new ImageContent(".\\content\\earth.png");
      _yin = new ImageContent(".\\content\\yinyang.png");
    }

    public override void Update(float dt)
    {
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Left))
        OkuDrivers.Renderer.ViewPort.Left += 100 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Right))
        OkuDrivers.Renderer.ViewPort.Left -= 100 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Up))
        OkuDrivers.Renderer.ViewPort.Top -= 100 * dt;
      if (OkuDrivers.Input.Keyboard.KeyIsDown(System.Windows.Forms.Keys.Down))
        OkuDrivers.Renderer.ViewPort.Top += 100 * dt;
    }

    public override void Render(int pass)
    {
      OkuDrivers.Renderer.DrawImage(_yin, Vector.Zero);

      OkuDrivers.Renderer.BeginScreenSpace();
      OkuDrivers.Renderer.DrawImage(_earth, new Vector(50, 50));
      OkuDrivers.Renderer.EndScreenSpace();
    }

  }
}
