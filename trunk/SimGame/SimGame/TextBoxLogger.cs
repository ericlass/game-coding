using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimGame
{
  class TextBoxLogger : ILogger
  {
    private TextBox _textBox = null;

    public TextBoxLogger(TextBox textBox)
    {
      _textBox = textBox;
    }

    public void Log(string text)
    {
      _textBox.Text += DateTime.Now.ToString() + " - " + text + Environment.NewLine;
    }
  }
}
