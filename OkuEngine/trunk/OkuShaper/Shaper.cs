using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
    private ButtonWidget _saveAsButton = null;
    private ButtonWidget _imageButton = null;
    private PolyEditorWidget _editor = null;

    private ImageContent _image = null;
    private MemoryStream _imageStream = null;

    private string _filename = null;
    private bool _modified = false;

    private const string ImageFileFilter = "All Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tiff;*.tif|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|TIFF (*.tif, *.tiff)|*.tif;*.tiff|All Files (*.*)|*.*";
    private const string ShapeFileFilter = "Oku Shapes (*.oks)|*.oks|All Files (*.*)|*.*";

    /*public void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = ColorMap.Flash.BackGround;
      renderParams.Width = 1280;
      renderParams.Height = 800;
    }*/

    public override void Initialize()
    {
      _gui = new WidgetContainer(new SpriteFont("Calibri", 10.0f, System.Drawing.FontStyle.Bold, true));

      Form form = (Form)OkuManagers.Renderer.Display;
      form.FormClosing += new FormClosingEventHandler(form_FormClosing);

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

      _saveAsButton = new ButtonWidget();
      _saveAsButton.Area = new AABB(245, 774, 75, 21);
      _saveAsButton.Text = "Save As";
      _saveAsButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconSaveAs);
      _gui.AddWidget(_saveAsButton);

      _imageButton = new ButtonWidget();
      _imageButton.Area = new AABB(325, 774, 75, 21);
      _imageButton.Text = "Image";
      _imageButton.Glyph = new ImageContent(OkuShaper.Properties.Resources.IconImage);
      _gui.AddWidget(_imageButton);

      _editor = new PolyEditorWidget();
      _editor.Area = new AABB(5, 5, 1270, 764);
      _editor.Change += new EditorChangeDelegate(_editor_Change);
      _gui.AddWidget(_editor);

      UpdateWindowTitle();
    }

    private void _editor_Change()
    {
      _modified = true;
      UpdateWindowTitle();
    }

    private DialogResult ShowUnsavedDialog()
    {
      return MessageBox.Show("There are unsaved changes. Do you want to save now?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
    }

    private void form_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (_modified)
      {
        DialogResult result = ShowUnsavedDialog();
        if (result == DialogResult.Yes)
          Save(false);
        else if (result == DialogResult.Cancel)
          e.Cancel = true;
      }
    }

    public override void Update(float dt)
    {
      _gui.Update(dt);

      if (OkuManagers.Renderer.Display.Focused)
      {
        Vector mouseScreen = OkuManagers.Renderer.ScreenToDisplay(OkuManagers.Input.Mouse.X, OkuManagers.Input.Mouse.Y);
        Vector mouseWorld = OkuManagers.Renderer.ScreenToWorld(OkuManagers.Input.Mouse.X, OkuManagers.Input.Mouse.Y);

        //Load background image
        if (_imageButton.Clicked)
        {
          LoadBackgroundImage();
          UpdateWindowTitle();
        }
        //Clear scene when new button is clicked
        else if (_newButton.Clicked)
        {
          if (_modified)
          {
            DialogResult result = ShowUnsavedDialog();
            if (result == DialogResult.Yes)
              Save(false);
            else if (result == DialogResult.Cancel)
              return;
          }

          _editor.Points.Clear();
          _editor.ResetView();

          if (_imageStream != null)
            _imageStream.Close();

          _imageStream = null;

          if (_image != null)
            OkuManagers.Renderer.ReleaseContent(_image);

          _image = null;

          _filename = null;
          _modified = false;

          UpdateWindowTitle();
        }
        else if (_saveButton.Clicked)
        {
          Save(false);
        }
        else if (_saveAsButton.Clicked)
        {
          Save(true);
        }
        else if (_loadButton.Clicked)
        {
          if (_modified)
          {
            DialogResult result = ShowUnsavedDialog();
            if (result == DialogResult.Yes)
              Save(false);
            else if (result == DialogResult.Cancel)
              return;
          }
            
          OpenFileDialog openDialog = new OpenFileDialog();
          openDialog.Filter = ShapeFileFilter;
          openDialog.Multiselect = false;
          openDialog.Title = "Open Shape";
          if (openDialog.ShowDialog() == DialogResult.OK)
            LoadFile(openDialog.FileName);          
        }
      }
    }

    private void LoadBackgroundImage()
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = ImageFileFilter;
      openDialog.Multiselect = false;
      openDialog.Title = "Open Image";
      if (openDialog.ShowDialog() == DialogResult.OK)
      {
        if (_imageStream != null)
          _imageStream.Close();

        FileStream file = new FileStream(openDialog.FileName, FileMode.Open);
        try
        {
          MemoryStream memStream = new MemoryStream();
          memStream.SetLength(file.Length);
          file.Read(memStream.GetBuffer(), 0, (int)file.Length);
          _imageStream = memStream;
        }
        finally
        {
          file.Close();
        }

        if (_image != null)
          OkuManagers.Renderer.ReleaseContent(_image);

        _image = new ImageContent(_imageStream);
        _editor.BackgroundImage = _image;
        _modified = true;
        UpdateWindowTitle();
      }
    }

    private void Save(bool saveAs)
    {
      string filename = _filename;
      if (saveAs || filename == null || !File.Exists(filename))
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = ShapeFileFilter;
        dialog.Title = "Save Shape";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          filename = dialog.FileName;
        }
      }

      SaveFile(filename);
    }

    private void SaveFile(string filename)
    {
      Shape.Save(filename, _editor.Points.GetCollapsedArray(), _imageStream);
      _modified = false;
      _filename = filename;
      UpdateWindowTitle();
    }

    private void LoadFile(string filename)
    {
      Vector[] points;

      if (_imageStream != null)
        _imageStream.Close();

      Shape.Load(filename, out points, out _imageStream);

      if (_image != null)
        OkuManagers.Renderer.ReleaseContent(_image);

      if (_imageStream != null)
        _image = new ImageContent(_imageStream);
      else
        _image = null;

      _editor.BackgroundImage = _image;

      if (points != null)
      {
        _editor.Points = new DynamicArray<Vector>(points);
      }

      _modified = false;
      _filename = filename;

      UpdateWindowTitle();
    }

    private void UpdateWindowTitle()
    {
      string title = "Oku Shaper 1.0 - ";
      if (_filename != null)
        title += Path.GetFileName(_filename);
      else
        title += "Untitled";

      if (_modified)
        title += "*";

      OkuManagers.Renderer.Display.Text = title;
    }

    public override void Render(int pass)
    {
      _gui.Render();
    }

  }
}
