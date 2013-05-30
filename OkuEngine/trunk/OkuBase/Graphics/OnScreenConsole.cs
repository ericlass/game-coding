using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace OkuBase.Graphics
{
  public class OnScreenConsole
  {
    private SpriteFont _font = null;
    private List<string> _entries = new List<string>();
    private float _height = 200.0f;
    private Color _bgColor = new Color(0, 0, 0, 128);
    private TextProcessor _input = new TextProcessor();

    public OnScreenConsole()
    {
      _font = new SpriteFont("Courier New", 10.0f, FontStyle.Regular, false);
      OkuManager.Instance.Input.OnKeyPressed += new OkuBase.Input.KeyEventDelegate(Input_OnKeyPressed);
    }

    public OnScreenConsole(SpriteFont font)
    {
      _font = font;
      OkuManager.Instance.Input.OnKeyPressed += new OkuBase.Input.KeyEventDelegate(Input_OnKeyPressed);
    }

    private void Input_OnKeyPressed(Keys key)
    {
      if (key != Keys.Enter)
        _input.ProcessKey(key);
      else
      {
        AddEntry(_input.Text);
        _input.Text = "";
      }
    }

    public float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    public SpriteFont Font
    {
      get { return _font; }
      set { _font = value; }
    }

    public void AddEntry(string entry)
    {
      _entries.Add(_entries.Count + ": " + entry);
    }

    public void Draw()
    {
      OkuManager.Instance.Graphics.BeginScreenSpace();

      float bottom = OkuManager.Instance.Graphics.DisplayHeight - _height;

      OkuManager.Instance.Graphics.DrawRectangle(
        0, 
        OkuManager.Instance.Graphics.DisplayWidth, 
        bottom, 
        OkuManager.Instance.Graphics.DisplayHeight,
        _bgColor);

      float maxY = OkuManager.Instance.Graphics.DisplayHeight + _font.Height;
      for (int i = _entries.Count - 1; i >= 0; i--)
      {
        string current = _entries[i];
        float y = bottom + (((_entries.Count - 1 - i) + 1) * _font.Height) + _font.Height;
        if (y > maxY)
          break;
        Mesh mesh = _font.GetStringMesh(current, 5, y, Color.White);
        OkuManager.Instance.Graphics.DrawMesh(mesh);
      }

      float splitY = bottom + _font.Height;
      OkuManager.Instance.Graphics.DrawLine(0, splitY, OkuManager.Instance.Graphics.DisplayWidth, splitY, 1.0f, Color.Silver);

      Mesh inputMesh = _font.GetStringMesh(_input.Text, 0, splitY, Color.White);
      OkuManager.Instance.Graphics.DrawMesh(inputMesh);

      OkuManager.Instance.Graphics.EndScreenSpace();
    }

  }
}
