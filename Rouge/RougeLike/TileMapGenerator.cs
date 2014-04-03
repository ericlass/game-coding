using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public class TileGeneratorParameters
  {
    public int Amplitude { get; set; }
    public int DetailLevel { get; set; }
    public int Seed { get; set; }
  }

  public class TileMapGenerator
  {
    private static TileMapGenerator _instance = null;

    public static TileMapGenerator Instance
    {
      get
      {
        if (_instance == null)
          _instance = new TileMapGenerator();

        return _instance;
      }
    }

    private TileMapGenerator()
    {
    }

    public Tile[,] GenerateTile(TileGeneratorParameters parameters, int width, int height)
    {
      Tile[,] tiles = new Tile[width, height];
      PerlinNoise noise = new PerlinNoise(parameters.Seed);

      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          float density = -(y - (height / 2.0f));

          density += noise.Noise(x, y, parameters.DetailLevel, 200) * parameters.Amplitude;

          Tile tile = new Tile();
          tiles[x, y] = tile;
          if (density > 0.0f)
          {
            tile.ImageIndex = 1;
            tile.TileType = TileType.Filled;
          }
          else
          {
            tile.ImageIndex = 0;
            tile.TileType = TileType.Empty;
          }
        }
      }

      return tiles;
    }

  }
}
