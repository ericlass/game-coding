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
    /// <summary>
    /// Gets or sets the index of the image to be used for this tile.
    /// </summary>
    public int ImageIndex { get; set; }

    /// <summary>
    /// Gets or sets the type of this tile.
    /// </summary>
    public TileType TileType { get; set; }

    /// <summary>
    /// Gets or sets a custom tag that can be used for whatever you want.
    /// </summary>
    public int Tag { get; set; }
  }
}
