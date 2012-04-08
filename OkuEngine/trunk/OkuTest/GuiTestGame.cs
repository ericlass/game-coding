using System;
using System.Collections.Generic;
using OkuEngine;

namespace OkuTest
{
  public class GuiTestGame : OkuGame
  {
    private ImmediateModeGui _gui = null;
    private Button _button = null;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.Black;
      renderParams.Fullscreen = false;
      renderParams.Width = 1024;
      renderParams.Height = 768;
    }

    public override void Initialize()
    {
      _button = new Button();
      _button.Area = new Quad(-50, 50, 20, -20);

      Intersections.PointInAABB(Vector.Zero, _button.Area.Min, _button.Area.Max);

      _gui = new ImmediateModeGui();
      _gui.AddWidget(_button);
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
