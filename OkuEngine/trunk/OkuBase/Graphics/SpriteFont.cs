using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using OkuBase.Geometry;

namespace OkuBase.Graphics
{
  public class SpriteFont
  {
    /// <summary>
    /// Used internally to store character dimensions. The values are represented in texture pixel space.
    /// </summary>
    private struct CharDimensions
    {
      public int Left;
      public int Width;

      public CharDimensions(int left, int width)
      {
        Left = left;
        Width = width;
      }

      public int Right
      {
        get { return Left + Width; }
      }
    }

    private int _texWidth = 0;
    private int _texHeight = 0;

    private Bitmap _fontSheet = null;
    private System.Drawing.Graphics _graphics = null;
    private Image _fontSheetImage = null;
    private int _nextPos = 0;

    private Dictionary<char, CharDimensions> _chars = new Dictionary<char, CharDimensions>();

    private FontFamily _fontFamily = null;
    private System.Drawing.Font _font = null;
    private FontStyle _fontStyle = FontStyle.Regular;

    private bool _antiAlias = false;

    public SpriteFont(string fontname, float size, FontStyle style, bool antiAlias)
    {
      _fontFamily = new FontFamily(fontname);
      _fontStyle = style;
      _font = new System.Drawing.Font(_fontFamily, size, (System.Drawing.FontStyle)_fontStyle);
      _antiAlias = antiAlias;

      _fontSheet = new Bitmap(1, 1); //Create dummy bitmap to get graphics context
      _graphics = System.Drawing.Graphics.FromImage(_fontSheet);
      SizeF charSize = _graphics.MeasureString("M", _font);
      _fontSheet.Dispose();

      _texWidth = NextPowerOfTwo((int)(charSize.Width * 100));
      _texHeight = NextPowerOfTwo(_font.Height);
      _fontSheet = new Bitmap(_texWidth, _texHeight, PixelFormat.Format32bppArgb);
      _graphics = System.Drawing.Graphics.FromImage(_fontSheet);
      _graphics.Clear(System.Drawing.Color.FromArgb(0, 128, 128, 128));
      if (antiAlias)
        _graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
      else
        _graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
    }

    public bool AntiAlias
    {
      get { return _antiAlias; }
    }

    public int Height
    {
      get { return _font.Height; }
    }

    private int NextPowerOfTwo(int number)
    {
      int num = number;
      num--;
      num = (num >> 1) | num;
      num = (num >> 2) | num;
      num = (num >> 4) | num;
      num = (num >> 8) | num;
      num = (num >> 16) | num;
      return num + 1;
    }

    public void PrepareChars(string chars)
    {
      int height = _font.Height;

      bool updated = false;
      foreach (char current in chars)
      {
        if (!_chars.ContainsKey(current))
        {
          string charStr = "" + current;

          SizeF size = _graphics.MeasureString(charStr, _font, PointF.Empty, StringFormat.GenericTypographic);
          int width = (int)size.Width;
          //Special handling for spaces. They get measured with width 0.
          if (width == 0 && current == ' ')
          {
            size = _graphics.MeasureString("_", _font, PointF.Empty, StringFormat.GenericTypographic);
            width = (int)size.Width;
          }

          if (width > _texWidth)
            throw new InvalidOperationException("The font is too big! The character " + current + " is wider than the texture it will be drawn too!");

          //Make sure that character fits into texture
          if ((_nextPos + width) >= _texWidth)
            throw new InvalidOperationException("Oops! You are using a lot of characters. I didn't expect that. Unfortunately you cannot have any more characters.");

          _graphics.DrawString(charStr, _font, Brushes.White, _nextPos, 0, StringFormat.GenericTypographic);

          _chars.Add(current, new CharDimensions(_nextPos, width));

          _nextPos += width + 1;

          updated = true;
        }
      }

      if (updated)
      {
        if (_fontSheetImage == null)
          _fontSheetImage = OkuManager.Instance.Graphics.NewImage(ImageData.FromBitmap(_fontSheet), true);
        else
          OkuManager.Instance.Graphics.UpdateImage(_fontSheetImage, 0, 0, _fontSheetImage.Width, _fontSheetImage.Height, ImageData.FromBitmap(_fontSheet));
      }
    }

    public Mesh GetStringMesh(string text, float offsetX, float offsetY, Color color)
    {
      PrepareChars(text);

      List<Vector2f> positions = new List<Vector2f>();
      List<Vector2f> texCoords = new List<Vector2f>();
      List<Color> colors = new List<Color>();

      float left = offsetX;
      float top = offsetY;
      float bottom = top - _font.Height;      

      float textureSize = _texWidth;

      float texTop = 1f;
      float texBottom = texTop - (_font.Height / (float)_texHeight);

      foreach (char current in text)
      {
        if (current == '\n')
        {
          left = offsetX;
          top -= _font.Height;          
          bottom = top - _font.Height;
        }
        else if (current >= ' ')
        {
          CharDimensions dims = _chars[current];
          float texLeft = dims.Left / textureSize;
          float texRight = texLeft + dims.Width / textureSize;

          float right = left + dims.Width;

          positions.Add(new Vector2f(left, top));
          texCoords.Add(new Vector2f(texLeft, texTop));
          colors.Add(color);

          positions.Add(new Vector2f(right, top));
          texCoords.Add(new Vector2f(texRight, texTop));
          colors.Add(color);

          positions.Add(new Vector2f(right, bottom));
          texCoords.Add(new Vector2f(texRight, texBottom));
          colors.Add(color);

          positions.Add(new Vector2f(left, bottom));
          texCoords.Add(new Vector2f(texLeft, texBottom));
          colors.Add(color);

          left += dims.Width;
        }
      }

      Vertices content = new Vertices(positions.ToArray(), texCoords.ToArray(), colors.ToArray());
      return new Mesh(content, _fontSheetImage, PrimitiveType.Quads);
    }

    /// <summary>
    /// Gets the width of the given text in world units.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The width of the text.</returns>
    public float GetTextWidth(string text)
    {
      PrepareChars(text);

      //TODO: Handle line breaks
      float result = 0.0f;
      foreach (char c in text)
      {
        CharDimensions dims = _chars[c];
        result += dims.Width;
      }
      return result;
    }

    /// <summary>
    /// Gets the width of the first count character of text
    /// in world units.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="count">The number of characters.</param>
    /// <returns>The width of the first count charaters.</returns>
    public float GetTextWidth(string text, int count)
    {
      PrepareChars(text);

      //TODO: Handle line breaks
      float result = 0.0f;
      for (int i = 0; i < count; i++)
      {
        CharDimensions dims = _chars[text[i]];
        result += dims.Width;
      }
      return result;
    }

  }
}
