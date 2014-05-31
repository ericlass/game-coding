using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Tiles
{
  public enum TileType
  {
    Empty,
    Filled,
    SouthEast,
    SouthWest,
    NorthEast,
    NorthWest
  }

  public class Tile
  {
    public int ImageIndex { get; set; }
    public TileType TileType { get; set; }
  }
}
