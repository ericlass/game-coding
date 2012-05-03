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
    private ButtonWidget _button = null;
    private ProgressBarWidget _progress = null;

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
      button.Area = new Quad(5, 5, 100, 30);
      button.Text = "Button 1";
      _button = button;

      _gui.AddWidget(button);

      ImageContent glyph = new ImageContent(".\\content\\orange_tile.png");

      button = new OkuEngine.ButtonWidget();
      button.Area = new Quad(5, 40, 100, 30);
      button.Text = "Button 2";
      button.Glyph = glyph;
            
      _gui.AddWidget(button);

      LabelWidget label = new LabelWidget();
      label.Area = new Quad(5, 90, 100, 0);
      label.Text = "Label 1";

      _gui.AddWidget(label);

      _progress = new ProgressBarWidget();
      _progress.Area = new Quad(5, 95, 200, 20);

      _progress.Position = 40;

      _gui.AddWidget(_progress);

      TextBoxWidget text = new TextBoxWidget();
      text.Area = new Quad(5, 120, 200, 20);

      _gui.AddWidget(text);
    }

    public override void Update(float dt)
    {
      _gui.Update(dt);

      if (_button.Clicked)
      {
        OkuDrivers.Renderer.ViewPort.Scale *= -1;
      }

      String hotText = _gui.HotWidget != null ? _gui.HotWidget.ID.ToString() : "None";
      String activeText = _gui.ActiveWidget != null ? _gui.ActiveWidget.ID.ToString() : "None";
      String focusedText = _gui.FocusedWidget != null ? _gui.FocusedWidget.ID.ToString() : "None";

      OkuDrivers.Renderer.Display.Text = "H: " + hotText + "; A: " + activeText + "; F: " + focusedText;

      if (OkuDrivers.Input.Keyboard.KeyPressed(Keys.Add))
        _progress.Position = Math.Min(_progress.Position + 5, _progress.Max);

      if (OkuDrivers.Input.Keyboard.KeyPressed(Keys.Subtract))
        _progress.Position = Math.Max(_progress.Position - 5, _progress.Min);
    }

    public override void Render(int pass)
    {
      _gui.Render();
      Vector mousePos = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
      OkuDrivers.Renderer.DrawPoint(mousePos, 4.0f, Color.Red);
    }

  }
}
