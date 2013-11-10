using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;
using OkuBase.Input;
using OkuBase.Logging;

namespace OkuBase.Graphics
{
  public delegate void ConsoleCommandEnteredDelegate(string command);

  /// <summary>
  /// Defines an on-screen console that is drawn as an overlay over the game.
  /// The console needs to receive keyboard input to work. Therefore it must be
  /// set as the current input handler.
  /// </summary>
  public class OnScreenConsole : ILogWriter
  {
    private SpriteFont _font = null;
    private List<string> _entries = new List<string>();
    private float _height = 200.0f;
    private Color _bgColor = new Color(0, 0, 0, 128);
    private TextProcessor _input = new TextProcessor();
    private int _historyIndex = -1;
    private bool _active = false;

    /// <summary>
    /// Creates a new console with a default font.
    /// </summary>
    public OnScreenConsole()
    {
      _font = new SpriteFont("Courier New", 10.0f, FontStyle.Regular, false);
      Init();
    }

    /// <summary>
    /// Creates a new console with the given font.
    /// </summary>
    /// <param name="font">The font to use to display text.</param>
    public OnScreenConsole(SpriteFont font)
    {
      _font = font;
      Init();
    }

    private void Init()
    {
      OkuManager.Instance.Input.OnKeyPressed += new KeyEventDelegate(KeyPressed);
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
    /// Gets or sets if the console is currently active. An active console
    /// processes keyboard events, an inactive one does not.
    /// </summary>
    public bool Active
    {
      get { return _active; }
      set { _active = value; }
    }

    /// <summary>
    /// Is triggered when the user enters a command and hits the enter key.
    /// </summary>
    public event ConsoleCommandEnteredDelegate OnCommandEntered;

    /// <summary>
    /// Adds the given new line to the console.
    /// </summary>
    /// <param name="line">The new line.</param>
    public void AddLine(string line)
    {
      _entries.Add(line);
      while (_entries.Count > 100)
        _entries.RemoveAt(0);
    }

    public void Clear()
    {
      _entries.Clear();
      _historyIndex = -1;
    }

    /// <summary>
    /// Draws the console on the screen. This should be called in the Render method
    /// after everything else has been drawn.
    /// </summary>
    public void Draw()
    {
      OkuManager.Instance.Graphics.BeginScreenSpace();

      float bottom = OkuManager.Instance.Graphics.DisplayHeight - _height;

      //Draw transparent background
      OkuManager.Instance.Graphics.DrawRectangle(
        0, 
        OkuManager.Instance.Graphics.DisplayWidth, 
        bottom, 
        OkuManager.Instance.Graphics.DisplayHeight,
        _bgColor);

      //Draw entries
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

      //Draw splitting line
      float splitY = bottom + _font.Height;
      OkuManager.Instance.Graphics.DrawLine(0, splitY, OkuManager.Instance.Graphics.DisplayWidth, splitY, 1.0f, Color.Silver);

      //Draw input line
      Mesh inputMesh = _font.GetStringMesh(_input.Text, 5, splitY, Color.White);
      OkuManager.Instance.Graphics.DrawMesh(inputMesh);

      //Draw cursor
      float cursorPos = _font.GetTextWidth(_input.Text, _input.CursorPosition) + 5;
      OkuManager.Instance.Graphics.DrawLine(cursorPos, splitY - 2, cursorPos, splitY - (_font.Height - 2), 1.0f, Color.White);

      OkuManager.Instance.Graphics.EndScreenSpace();
    }

    public void KeyPressed(Keys key)
    {
      if (!_active)
        return;

      switch (key)
      {
        case Keys.Enter:
          string text = _input.Text;
          AddLine(text);
          if (OnCommandEntered != null)
            OnCommandEntered(text);
          _input.Text = "";
          _historyIndex = -1;
          break;

        case Keys.Up:
          if (_entries.Count <= 0)
            break;
          if (_historyIndex < 0)
            _historyIndex = _entries.Count;
          _historyIndex--;
          if (_historyIndex < 0)
            _historyIndex = 0;
          _input.Text = _entries[_historyIndex];
          break;

        case Keys.Down:
          if (_entries.Count <= 0)
            break;
          if (_historyIndex >= 0)
          {
            _historyIndex++;
            if (_historyIndex >= _entries.Count)
              _historyIndex = _entries.Count - 1;
            _input.Text = _entries[_historyIndex];
          }
          break;

        // A little hack to get rid of the ^
        case Keys.Oem5:
          break;

        default:
          _input.ProcessKey(key);
          break;
      }
    }

    public void WriteLine(LogEntry entry)
    {
      AddLine(entry.ToString());
    }

  }
}
