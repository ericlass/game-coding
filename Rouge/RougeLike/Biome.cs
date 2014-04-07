using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class Biome
  {
    public string Id { get; set; }
    public string Tileset { get; set; }
    public TileGeneratorParameters GeneratorParameters { get; set; }
  }
}
