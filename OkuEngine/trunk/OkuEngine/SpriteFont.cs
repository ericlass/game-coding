﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace OkuEngine
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
    private Graphics _graphics = null;
    private ImageContent _fontSheetContent = null;
    private int _nextPos = 0;

    private Dictionary<char, CharDimensions> _chars = new Dictionary<char, CharDimensions>();

    private FontFamily _fontFamily = null;
    private Font _font = null;
    private FontStyle _fontStyle = FontStyle.Regular;

    private bool _antiAlias = false;

    public SpriteFont(string fontname, float size, FontStyle style, bool antiAlias)
    {
      _fontFamily = new FontFamily(fontname);
      _fontStyle = style;
      _font = new Font(_fontFamily, size, _fontStyle);
      _antiAlias = antiAlias;

      _fontSheet = new Bitmap(1, 1); //Create dummy bitmap to get graphics context
      _graphics = Graphics.FromImage(_fontSheet);
      SizeF charSize = _graphics.MeasureString("M", _font);
      _fontSheet.Dispose();

      _texWidth = NextPowerOfTwo((int)(charSize.Width * 100));
      _texHeight = NextPowerOfTwo(_font.Height);
      _fontSheet = new Bitmap(_texWidth, _texHeight, PixelFormat.Format32bppArgb);
      _graphics = Graphics.FromImage(_fontSheet);
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
        if (_fontSheetContent == null)
          _fontSheetContent = new ImageContent(_fontSheet);
        else
          _fontSheetContent.UpdateData(_fontSheet);
      }
    }

    public MeshInstance GetStringMesh(string text, float offsetX, float offsetY, Color color)
    {
      PrepareChars(text);

      VertexList vertices = new VertexList();
      float left = offsetX;
      float bottom = _font.Height + offsetY;

      float textureSize = _texWidth;

      float texBottom = _font.Height / (float)_texHeight;
      
      foreach (char current in text)
      {
        CharDimensions dims = _chars[current];
        float texLeft = dims.Left / textureSize;
        float texRight = texLeft + dims.Width / textureSize;

        float right = left + dims.Width;

        Vertex vert = new Vertex();
        vert.Position.X = left;
        vert.Position.Y = offsetY;
        vert.TextureCoordinates.X = texLeft;
        vert.TextureCoordinates.Y = 0;
        vert.Color = color;
        vertices.Add(vert);

        vert = new Vertex();
        vert.Position.X = right;
        vert.Position.Y = offsetY;
        vert.TextureCoordinates.X = texRight;
        vert.TextureCoordinates.Y = 0;
        vert.Color = color;
        vertices.Add(vert);

        vert = new Vertex();
        vert.Position.X = right;
        vert.Position.Y = bottom;
        vert.TextureCoordinates.X = texRight;
        vert.TextureCoordinates.Y = texBottom;
        vert.Color = color;
        vertices.Add(vert);

        vert = new Vertex();
        vert.Position.X = left;
        vert.Position.Y = bottom;
        vert.TextureCoordinates.X = texLeft;
        vert.TextureCoordinates.Y = texBottom;
        vert.Color = color;
        vertices.Add(vert);

        left += dims.Width;
      }

      VertexContent content = new VertexContent(vertices);
      return  new MeshInstance(content, _fontSheetContent, MeshMode.Quads);
    }

  }
}
