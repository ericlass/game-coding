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
    private PolyEditorWidget _editor = null;

    private ImageContent _image = null;
    private string _imageFile = null;

    private string _filename = null;
    private bool _modified = false;

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
      _newButton.Area = new AABB(5, 774, 75, 21);
      _newButton.Text = "New";
      _newButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconNew);
      _gui.AddWidget(_newButton);

      _loadButton = new ButtonWidget();
      _loadButton.Area = new AABB(85, 774, 75, 21);
      _loadButton.Text = "Open";
      _loadButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconOpen);
      _gui.AddWidget(_loadButton);

      _saveButton = new ButtonWidget();
      _saveButton.Area = new AABB(165, 774, 75, 21);
      _saveButton.Text = "Save";
      _saveButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconSave);
      _gui.AddWidget(_saveButton);

      _imageButton = new ButtonWidget();
      _imageButton.Area = new AABB(245, 774, 75, 21);
      _imageButton.Text = "Image";
      _imageButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconImage);
      _gui.AddWidget(_imageButton);

      _editor = new PolyEditorWidget();
      _editor.Area = new AABB(5, 5, 1270, 764);
      _gui.AddWidget(_editor);
    }

    public override void Update(float dt)
    {
      _gui.Update(dt);

      if (OkuDrivers.Renderer.Display.Focused)
      {
        Vector mouseScreen = OkuDrivers.Renderer.ScreenToDisplay(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);
        Vector mouseWorld = OkuDrivers.Renderer.ScreenToWorld(OkuDrivers.Input.Mouse.X, OkuDrivers.Input.Mouse.Y);

        //Load background image
        if (_imageButton.Clicked)
        {
          LoadBackgroundImage();
        }
        //Clear scene when new button is clicked
        else if (_newButton.Clicked)
        {
          _editor.Points.Clear();
          _imageFile = null;
          if (_image != null)
            OkuDrivers.Renderer.ReleaseContent(_image);
          _image = null;
          _filename = null;
          _modified = false;
        }
      }
    }

    private void LoadBackgroundImage()
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
        _editor.BackgroundImage = _image;
      }

      openDialog.Dispose();
      Application.DoEvents();
    }

    public override void Render(int pass)
    {
      _gui.Render();
    }

  }
}
