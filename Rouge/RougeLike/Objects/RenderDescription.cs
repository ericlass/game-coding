using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace RougeLike.Objects
{
  public class RenderDescription
  {
    private Color _tint = Color.White;

    public Color Tint
    {
      get { return _tint; }
      set { _tint = value; }
    }

    public ImageBase Image { get; set; }

    public VertexBuffer VertexBuffer { get; set; }
    public PrimitiveType PrimitiveType { get; set; }
  }
}
