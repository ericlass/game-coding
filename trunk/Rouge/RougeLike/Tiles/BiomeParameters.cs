using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Tiles
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
      Biome MountainBiome = new Biome()
      {
        Id = "mountain",
        Tileset = "mountain_tile.png",
        GeneratorParameters = new TileGeneratorParameters()
        {
          Amplitude = 40,
          DetailLevel = 4,
          DetailSize = 200,
          Seed = 622745886
        }
      };
      _biomes.Add(MountainBiome.Id, MountainBiome);

      Biome GrassLandBiome = new Biome()
      {
        Id = "grassland",
        Tileset = "grass_tile.png",
        GeneratorParameters = new TileGeneratorParameters()
        {
          Amplitude = 15,
          DetailLevel = 3,
          DetailSize = 200,
          Seed = 6846532
        }
      };
      _biomes.Add(GrassLandBiome.Id, GrassLandBiome);

      Biome DesertBiome = new Biome()
      {
        Id = "desert",
        Tileset = "desert_tile.png",
        GeneratorParameters = new TileGeneratorParameters()
        {
          Amplitude = 20,
          DetailLevel = 2,
          DetailSize = 250,
          Seed = 265549
        }
      };
      _biomes.Add(DesertBiome.Id, DesertBiome);
    }

    public Biome this[string id]
    {
      get { return _biomes[id]; }
    }

  }
}
