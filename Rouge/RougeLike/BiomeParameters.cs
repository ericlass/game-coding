using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class BiomeParameters
  {
    private static BiomeParameters _instance = null;

    public static BiomeParameters Instance
    {
      get
      {
        if (_instance == null)
          _instance = new BiomeParameters();

        return _instance;
      }
    }

    private Dictionary<string, Biome> _biomes = new Dictionary<string, Biome>();

    private BiomeParameters()
    {
      Biome RockBiome = new Biome()
      {
        Id = "rock",
        Tileset = "simple_tiles.png",
        GeneratorParameters = new TileGeneratorParameters()
        {
          Amplitude = 30,
          DetailLevel = 6,
          DetailSize = 200,
          Seed = 912745896
        }
      };
      _biomes.Add("rock", RockBiome);
    }

    public Biome this[string id]
    {
      get { return _biomes[id]; }
    }

  }
}
