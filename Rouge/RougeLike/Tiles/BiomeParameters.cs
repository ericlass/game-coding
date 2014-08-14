using System;
using System.Collections.Generic;
using System.IO;
using JSONator;

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
        {
          _instance = new BiomeParameters();
          _instance.Init();
        }

        return _instance;
      }
    }

    private Dictionary<string, Biome> _biomes = new Dictionary<string, Biome>();

    private BiomeParameters()
    {      
    }

    private void Init()
    {
      string[] files = Directory.GetFiles(".\\Content\\Biomes", "*.json");
      foreach (string fileName in files)
      {
        JSONObjectValue json = GameUtil.ParseJsonFile(fileName);
        Biome biome = new Biome();
        biome.Id = json.GetString("id").Value;
        biome.Tileset = json.GetString("tileset").Value;
        biome.GeneratorParameters = new TileGeneratorParameters();
        biome.GeneratorParameters.Amplitude = (int)json.GetNumber("amplitude").Value;
        biome.GeneratorParameters.DetailLevel = (int)json.GetNumber("detaillevel").Value;
        biome.GeneratorParameters.DetailSize = (int)json.GetNumber("detailsize").Value;

        _biomes.Add(biome.Id, biome);
      }
    }

    public Biome this[string id]
    {
      get { return _biomes[id]; }
    }

  }
}
