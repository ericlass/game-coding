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

    private ImageContent _image = null;
    private string _imageFile = null;
    private Vector[] _imageBox = null;

    private string _filename = null;
    private bool _modified = false;

    private DynamicArray<Vector> _points = new DynamicArray<Vector>();
    private int _hotPoint = -1;

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

      if (OkuDrivers.Renderer.Display.Focused)
      {
        Vector mouseScreen = OkuDrivers.Renderer.ScreenToClient(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
        Vector mouseWorld = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);

        //Load background image
        if (_imageButton.Clicked)
        {
          loadBackgroundImage();
        }
        //Clear scene when new button is clicked
        else if (_newButton.Clicked)
        {
          _points.Clear();
          _imageFile = null;
          if (_image != null)
            OkuDrivers.Renderer.ReleaseContent(_image);
          _image = null;
          _filename = null;
          _modified = false;
        }
        else
        {
          //Dragging with middle mouse button
          if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Middle))
          {
            _dragging = true;
            _dragStart = mouseScreen;
            _oldCenter = OkuDrivers.Renderer.ViewPort.Center;
          }

          if (_dragging)
          {
            Vector mousePos = mouseScreen;
            Vector offset = (_dragStart - mousePos) * OkuDrivers.Renderer.ViewPort.Scale;
            OkuDrivers.Renderer.ViewPort.Center = _oldCenter + offset;
          }

          if (OkuDrivers.Input.Mouse.ButtonRaised(MouseButton.Middle))
            _dragging = false;

          //Get point closest to the mouse cursor
          float distance = 0.0f;
          int closestPoint = _points.InternalArray.ClosestPoint(mouseWorld, out distance);
          if (distance < 3.0f)
          {
            _hotPoint = closestPoint;
          }
          else
          {
            _hotPoint = -1;
          }

          //Mouse wheel zoom
          if (OkuDrivers.Input.Mouse.WheelSpinned)
            OkuDrivers.Renderer.ViewPort.Scale *= 1.0f + (-OkuDrivers.Input.Mouse.WheelDelta / 10.0f);

          //Reset zoom
          if (OkuDrivers.Input.Keyboard.KeyPressed(Keys.NumPad0))
            OkuDrivers.Renderer.ViewPort.Scale = Vector.One;

          if (OkuDrivers.Input.Mouse.ButtonPressed(MouseButton.Left) && _hotPoint < 0)
          {
            _points.Add(mouseWorld);
          }
        }
      }
    }

    private void loadBackgroundImage()
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = "All Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tiff;*.tif|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|TIFF (*.tif, *.tiff)|*.tif;*.tiff|All Files (*.*)|*.*";
      openDialog.Multiselect = false;
      openDialog.Title = "Open Image";
      if (openDialog.ShowDialog() == DialogResult.OK)
      {
        _imageFile = openDialog.FileName;

        if (_image != null)
          OkuDrivers.Renderer.ReleaseContent(_image);

        _image = new ImageContent(openDialog.FileName);

        float halfWidth = _image.Width / 2.0f;
        float halfHeight = _image.Height / 2.0f;
        _imageBox = PolygonFactory.Box(-halfWidth, halfWidth, halfHeight, -halfHeight);
      }
    }

    public override void Render(int pass)
    {
      if (_image != null)
      {
        OkuDrivers.Renderer.DrawImage(_image, Vector.Zero);
        OkuDrivers.Renderer.DrawLines(_imageBox, Color.Silver, _imageBox.Length, 2.0f, VertexInterpretation.PolygonClosed);
      }

      OkuDrivers.Renderer.DrawLines(_points.InternalArray, Color.Blue, _points.Count, 2.0f, VertexInterpretation.PolygonClosed);
      OkuDrivers.Renderer.DrawPoints(_points.InternalArray, Color.Red, _points.Count, 4.0f);

      if (_hotPoint >= 0)
      {
        OkuDrivers.Renderer.DrawPoint(_points[_hotPoint], 4.0f, Color.Green);
      }

      OkuDrivers.Renderer.DrawLine(Vector.Zero, new Vector(25, 0), 1.0f, Color.Red);
      OkuDrivers.Renderer.DrawLine(Vector.Zero, new Vector(0, 25), 1.0f, Color.Green);

      _gui.Render();
    }

  }
}
