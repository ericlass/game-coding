using System;
using System.Text;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// A simple text processing engine. It is driven by passing
  /// the keys that are pressed on the keyboard to its ProcessKey
  /// method.
  /// </summary>
  public class TextProcessor
  {
    private String _text = "";
    private int _cursorPos = 0;
    private bool _multiline = false;

    /// <summary>
    /// Creates a new text processor.
    /// </summary>
    public TextProcessor()
    {
    }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    public string Text
    {
      get { return _text; }
      set
      {
        _text = value == null ? "" : value;
        _cursorPos = Math.Min(_text.Length, _cursorPos);
      }
    }

    /// <summary>
    /// Gets or set the current position of the cursor.
    /// This is the character index in the text string
    /// and does not handle line breaks.
    /// </summary>
    public int CursorPosition
    {
      get { return _cursorPos; }
      set { _cursorPos = Math.Min(_text.Length, Math.Max(0, value)); }
    }

    /// <summary>
    /// Gets or sets if multiple lines can be entered.
    /// </summary>
    public bool Multiline
    {
      get { return _multiline; }
      set { _multiline = value; }
    }

    /// <summary>
    /// Calculates the line and character position
    /// of the corsur in a multiline text processor.
    /// </summary>
    /// <param name="line">The line index is returned here.</param>
    /// <param name="character">The character index in the line is returned here.</param>
    public void GetCursorPosition(ref int line, ref int character)
    {
      line = 0;
      character = 0;
      for (int i = 0; i < _text.Length; i++)
      {
        character++;
        if (_text[i] == '\n')
        {
          character = 0;
          line++;
        }
      }
    }

    /// <summary>
    /// Processes a key stroke and updates the text and cursor position accordingly.
    /// </summary>
    /// <param name="key">The key that was pressed.</param>
    /// <returns>True if the text was changed by processing the key, else false.</returns>
    public bool ProcessKey(Keys key)
    {
      bool result = false;

      //TODO: Selection, Ctrl+V, Ctrl+C, Ctrl+A

      if (key == Keys.Left)
      {
        _cursorPos = Math.Max(0, _cursorPos - 1);
      }
      else if (key == Keys.Right)
      {
        _cursorPos = Math.Min(_text.Length, _cursorPos + 1);
      }
      else if (key == Keys.Home)
      {
        _cursorPos = 0;
      }
      else if (key == Keys.End)
      {
        _cursorPos = _text.Length;
      }
      else if (key == Keys.Delete)
      {
        if (_cursorPos < _text.Length)
        {
          _text = _text.Remove(_cursorPos, 1);
          result = true;
        }
      }
      else if (key == Keys.Back)
      {
        if (_cursorPos > 0)
        {
          _text = _text.Remove(_cursorPos - 1, 1);
          _cursorPos = Math.Max(0, _cursorPos - 1);
          result = true;
        }
      }
      else if (key == Keys.Enter && _multiline)
      {
        _text = _text.Insert(_cursorPos, Environment.NewLine);
        _cursorPos = Math.Min(_text.Length, _cursorPos + Environment.NewLine.Length);
        result = true;
      }
      else
      {
        char pressed = OkuManagers.Instance.Input.Keyboard.KeyToChar(key);
        if (pressed > 0)
        {
          _text = _text.Insert(_cursorPos, pressed.ToString());
          _cursorPos = Math.Min(_text.Length, _cursorPos + 1);
          result = true;
        }
      }

      return result;
    }

  }
}
