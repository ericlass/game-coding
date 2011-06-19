using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace OkuEngine
{
  public class SpriteFont
  {
    private const int _texWidth = 512;

    private Bitmap _fontSheet = null;
    private Graphics _graphics = null;
    private ImageContent _fontSheetContent = null;
    private Point _nextPos = Point.Empty;

    private Dictionary<char, VertexList> _chars = new Dictionary<char, VertexList>();

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

    private void ResizeFontSheet(int width, int height)
    {
      //Remember old font sheet
      Bitmap oldSheet = _fontSheet;
      //Create new sheet with new dimensions
      _fontSheet = new Bitmap(width, NextPowerOfTwo(height), PixelFormat.Format32bppArgb);
      //Create graphics object
      _graphics = Graphics.FromImage(_fontSheet);
      //Enable or Disable anti aliasing
      if (_antiAlias)
        _graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      else
        _graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      //Clear whole bitmap with transparent color
      _graphics.Clear(System.Drawing.Color.FromArgb(0, 0, 0, 0));
      //Copy old sheet to new
      if (oldSheet != null)
        _graphics.DrawImageUnscaled(oldSheet, 0, 0);
    }

    public void PrepareChars(string chars)
    {
      int height = _font.Height;
      
      if (_fontSheet == null)
        ResizeFontSheet(_texWidth, NextPowerOfTwo(height));

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
          if ((_nextPos.X + width) >= _texWidth)
          {
            _nextPos.X = 0;
            _nextPos.Y += height;
            if (_nextPos.Y + height >= _fontSheet.Height)
            {
              ResizeFontSheet(_texWidth, NextPowerOfTwo(_nextPos.Y + height));              
            }
          }

          _graphics.DrawString(charStr, _font, Brushes.White, _nextPos.X, _nextPos.Y, StringFormat.GenericTypographic);

          float texLeft = _nextPos.X / (float)_texWidth;
          float texRight = (_nextPos.X + width) / (float)_texWidth;

          float texTop = _nextPos.Y / (float)(_fontSheet.Height);
          float texBottom = (_nextPos.Y + height) / (float)(_fontSheet.Height);

          VertexList vertices = new VertexList();

          Vertex vert = new Vertex();
          vert.Position.X = 0;
          vert.Position.Y = 0;
          vert.TextureCoordinates.X = texLeft;
          vert.TextureCoordinates.Y = texTop;
          vertices.Add(vert);

          vert = new Vertex();
          vert.Position.X = width;
          vert.Position.Y = 0;
          vert.TextureCoordinates.X = texRight;
          vert.TextureCoordinates.Y = texTop;
          vertices.Add(vert);

          vert = new Vertex();
          vert.Position.X = width;
          vert.Position.Y = height;
          vert.TextureCoordinates.X = texRight;
          vert.TextureCoordinates.Y = texBottom;
          vertices.Add(vert);

          vert = new Vertex();
          vert.Position.X = 0;
          vert.Position.Y = height;
          vert.TextureCoordinates.X = texLeft;
          vert.TextureCoordinates.Y = texBottom;
          vertices.Add(vert);          

          _chars.Add(current, vertices);

          _nextPos.X += width + 1;

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

    public void DrawString(string text, Vector origin)
    {
      DrawString(text, origin.X, origin.Y);
    }

    public void DrawString(string text, float x, float y)
    {
      PrepareChars(text);

      VertexList vertices = new VertexList();
      Vector offset = new Vector();
      offset.X = x;
      offset.Y = y;
      foreach (char c in text)
      {
        if (c == '\n')
        {
          offset.Y += (_fontFamily.GetEmHeight(_fontStyle) / _font.GetHeight()) * _fontFamily.GetLineSpacing(_fontStyle);
          offset.X = y;
        }
        else
        {
          VertexList charVerts = _chars[c];
          foreach (Vertex vert in charVerts)
          {
            Vertex clone = vert.Clone();
            clone.Position.Add(offset);
            vertices.Add(clone);
          }
            
          offset.X += charVerts[1].Position.X;
        }
      }

      OkuDrivers.Renderer.DrawMesh(vertices, MeshMode.Quads, _fontSheetContent);
    }

  }
}
