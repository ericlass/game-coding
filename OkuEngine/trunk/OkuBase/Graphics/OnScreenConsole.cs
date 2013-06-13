﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Input;

namespace OkuBase.Graphics
{
  public delegate void ConsoleCommandEnteredDelegate(string command);
  public delegate void ConsoleCloseDelegate();

  /// <summary>
  /// Defines an on-screen console that is drawn as an overlay over the game.
  /// The console needs to receive keyboard input to work. Therefore it must be
  /// set as the current input handler.
  /// </summary>
  public class OnScreenConsole : IInputHandler
  {
    private SpriteFont _font = null;
    private List<string> _entries = new List<string>();
    private float _height = 200.0f;
    private Color _bgColor = new Color(0, 0, 0, 128);
    private TextProcessor _input = new TextProcessor();
    private Keys _closeKey = Keys.Oem5;

    /// <summary>
    /// Creates a new console with a default font.
    /// </summary>
    public OnScreenConsole()
    {
      _font = new SpriteFont("Courier New", 10.0f, FontStyle.Regular, false);
    }

    /// <summary>
    /// Creates a new console with the given font.
    /// </summary>
    /// <param name="font">The font to use to display text.</param>
    public OnScreenConsole(SpriteFont font)
    {
      _font = font;
    }

    /// <summary>
    /// Gets or sets the height of the console in pixels.
    /// </summary>
    public float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Gets or set the font that is used to render text.
    /// </summary>
    public SpriteFont Font
    {
      get { return _font; }
      set { _font = value; }
    }

    /// <summary>
    /// Gets or sets the key that is used to close the console.
    /// </summary>
    public Keys CloseKey
    {
      get { return _closeKey; }
      set { _closeKey = value; }
    }

    /// <summary>
    /// Is triggered when the user enters a command and hits the enter key.
    /// </summary>
    public event ConsoleCommandEnteredDelegate OnCommandEntered;

    /// <summary>
    /// Is triggered when the close key is pressed.
    /// </summary>
    public event ConsoleCloseDelegate OnClose;

    /// <summary>
    /// Adds the given new line to the console.
    /// </summary>
    /// <param name="line">The new line.</param>
    public void AddLine(string line)
    {
      _entries.Add(line);
    }

    /// <summary>
    /// Draws the console on the screen. This should be called in the Render method
    /// after everything else has been drawn.
    /// </summary>
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

      Mesh inputMesh = _font.GetStringMesh(_input.Text, 5, splitY, Color.White);
      OkuManager.Instance.Graphics.DrawMesh(inputMesh);

      OkuManager.Instance.Graphics.EndScreenSpace();
    }

    #region IInputHandler Member

    public void KeyPressed(Keys key)
    {
      switch (key)
      {
        case Keys.Enter:
          string text = _input.Text;
          AddLine(text);
          if (OnCommandEntered != null)
            OnCommandEntered(text);
          _input.Text = "";
          break;

        default:
          if (key == _closeKey && OnClose != null)
            OnClose();
          else
            _input.ProcessKey(key);
          break;
      }
    }

    public void KeyReleased(Keys key) { }
    public void MousePressed(MouseButton button) { }
    public void MouseReleased(MouseButton button) { }
    public void MouseDblClick(MouseButton button) { }
    public void MouseWheel(int delta) { }

    #endregion

  }
}
