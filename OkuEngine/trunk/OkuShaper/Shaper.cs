using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuEngine;
using OkuEngine.Shaper;

namespace OkuShaper
{
  public class Shaper : OkuGame
  {
    private WidgetContainer _gui = null;
    private ButtonWidget _newButton = null;
    private ButtonWidget _loadButton = null;
    private ButtonWidget _saveButton = null;
    private ButtonWidget _imageButton = null;

    private Shape _shape = new Shape();
    private ImageContent _image = null;
    private Vector[] _imageBox = null;

    private string _filename = null;
    private bool _modified = false;

    private bool _dragging = false;
    private Vector _dragStart = Vector.Zero;
    private Vector _oldCenter = Vector.Zero;

    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = ColorMap.Flash.BackGround;
      renderParams.Width = 1280;
      renderParams.Height = 800;
    }

    public override void Initialize()
    {
      _gui = new WidgetContainer(new SpriteFont("Calibri", 10.0f, System.Drawing.FontStyle.Bold, true));

      _newButton = new ButtonWidget();
      _newButton.Area = new Quad(5, 774, 75, 21);
      _newButton.Text = "New";
      _gui.AddWidget(_newButton);

      _loadButton = new ButtonWidget();
      _loadButton.Area = new Quad(85, 774, 75, 21);
      _loadButton.Text = "Open";
      _gui.AddWidget(_loadButton);

      _saveButton = new ButtonWidget();
      _saveButton.Area = new Quad(165, 774, 75, 21);
      _saveButton.Text = "Save";
      _gui.AddWidget(_saveButton);

      _imageButton = new ButtonWidget();
      _imageButton.Area = new Quad(245, 774, 75, 21);
      _imageButton.Text = "Image";
      _gui.AddWidget(_imageButton);
    }

    public override void Update(float dt)
    {
      _gui.Update(dt);

      if (_dragging)
      {
        Vector mousePos = OkuDrivers.Renderer.ScreenToClient(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
        Vector offset = _dragStart - mousePos;
        OkuDrivers.Renderer.ViewPort.Center = _oldCenter + offset;
      }

      if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Middle))
      {
        _dragging = true;
        _dragStart = OkuDrivers.Renderer.ScreenToClient(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
        _oldCenter = OkuDrivers.Renderer.ViewPort.Center;
      }

      if (OkuDrivers.Input.Mouse.ButtonRaised(MouseButton.Middle))
      {
        _dragging = false;
      }

      if (_imageButton.Clicked)
      {
        OpenFileDialog openDialog = new OpenFileDialog();
        openDialog.Filter = "PNG (*.png)|*.png";
        openDialog.Multiselect = false;
        openDialog.Title = "Open Image";
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
          _shape.Image = openDialog.FileName;

          if (_image != null)
            OkuDrivers.Renderer.ReleaseContent(_image);

          _image = new ImageContent(openDialog.FileName);

          float halfWidth = _image.Width / 2.0f;
          float halfHeight = _image.Height / 2.0f;
          _imageBox = PolygonFactory.Box(-halfWidth, halfWidth, halfHeight, -halfHeight);
        }
      }
    }

    public override void Render(int pass)
    {
      if (_image != null)
      {
        OkuDrivers.Renderer.DrawImage(_image, Vector.Zero);
        OkuDrivers.Renderer.DrawLines(_imageBox, Color.Silver, _imageBox.Length, 2.0f, VertexInterpretation.PolygonClosed);
      }

      OkuDrivers.Renderer.DrawLine(Vector.Zero, new Vector(25, 0), 1.0f, Color.Red);
      OkuDrivers.Renderer.DrawLine(Vector.Zero, new Vector(0, 25), 1.0f, Color.Green);

      if (OkuDrivers.Input.Mouse.WheelDelta != 0)
        OkuDrivers.Renderer.Display.Text = OkuDrivers.Input.Mouse.WheelDelta.ToString();

      _gui.Render();
    }

  }
}
