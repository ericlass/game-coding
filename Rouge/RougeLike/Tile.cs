using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public enum TileType
  {
    Empty,
    Filled
  }

  public class Tile
  {
    public int ImageIndex { get; set; }
    public TileType TileType { get; set; }
  }
}
