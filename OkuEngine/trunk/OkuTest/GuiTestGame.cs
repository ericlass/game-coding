using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  public class GuiTestGame : OkuGame
  {
    private WidgetContainer _gui = null;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = new Color(51, 51, 51);
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }

    public override void Initialize()
    {
      _gui = new WidgetContainer( new SpriteFont("Arial", 10, System.Drawing.FontStyle.Regular, true));

      ButtonWidget button = new ButtonWidget();
      button.Area = new Quad(-50, 50, 15, -15);
      button.Text = "Button 1";

      _gui.AddWidget(button);

      button = new OkuEngine.ButtonWidget();
      button.Area = new Quad(-50, 50, -30, -60);
      button.Text = "Button 2";
            
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
