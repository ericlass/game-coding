using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace RougeLike.Objects
{
  public class RenderDescription
  {
    public ImageBase Image { get; set; }

    public VertexBuffer VertexBuffer { get; set; }
    public PrimitiveType PrimitiveType { get; set; }
  }
}
