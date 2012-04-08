using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  public class GuiTestGame : OkuGame
  {
    private ImmediateModeGui _gui = null;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }

    public override void Initialize()
    {
      _gui = new ImmediateModeGui();

      ButtonWidget button = new ButtonWidget();
      button.Area = new Quad(-50, 50, 20, -20);

      _gui.AddWidget(button);

      button = new OkuEngine.ButtonWidget();
      button.Area = new Quad(-50, 50, -120, -160);
            
      _gui.AddWidget(button);
    }

    public override void Update(float dt)
    {
      _gui.Update(dt);
    }

    public override void Render(int pass)
    {
      _gui.Render();
      Vector mousePos = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
      OkuDrivers.Renderer.DrawPoint(mousePos, 4.0f, Color.Red);
    }

  }
}
