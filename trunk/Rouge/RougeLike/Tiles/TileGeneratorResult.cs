using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Tiles
{
  public class TileGeneratorResult
  {
    /// <summary>
    /// Gets or sets the actual tiles that have been generated.
    /// </summary>
    public Tile[,] Tiles { get; set; }

    /// <summary>
    /// Gets or set the lower left tile coordinate where doors should be placed.
    /// </summary>
    public List<Vector2i> Doors { get; set; }
  }
}
