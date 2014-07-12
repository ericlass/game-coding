using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Tiles
{
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

    public Tile[,] GenerateTiles(TileGeneratorParameters parameters, int width, int height)
    {
      if (width % 16 != 0 || height % 16 != 0)
        throw new OkuBase.OkuException("Tilemap width and height must be a multiple of 16!");

      Tile[,] tiles = new Tile[width, height];
      PerlinNoise noise = new PerlinNoise(parameters.Seed);

      //Fill tile map with empty tiles first
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          Tile tile = new Tile();
          tile.TileType = TileType.Empty;
          tile.ImageIndex = 0;
          tiles[x, y] = tile;
        }
      }

      // Generate terrain from noise as described in GPU Gems 3
      /*for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          float density = -(y - (height / 2.0f));

          //density += noise.Noise(x, y, parameters.DetailLevel, parameters.DetailSize) * parameters.Amplitude;

          density += noise.Noise(x * 1.96f, y * 1.96f, parameters.DetailLevel, parameters.DetailSize) * parameters.Amplitude * 0.51f;
          density += noise.Noise(x * 1.01f, y * 1.01f, parameters.DetailLevel, parameters.DetailSize) * parameters.Amplitude;

          Tile tile = tiles[x, y]
          tile.ImageIndex = 0;

          if (density > 0.0f)
            tile.TileType = TileType.Filled;
        }
      }*/


      Random rand = new Random(parameters.Seed);
      int pos = 0;
      float lastHeight = 0;
      while (pos < width - 1)
      {
        float platformWidth = Math.Max(10.0f, (float)rand.NextDouble() * (parameters.DetailSize / 5));
        //float platformHeight = (float)rand.NextDouble() * (parameters.Amplitude / 3);
        float platformHeight = GameUtil.Clamp(noise.Noise(pos * (platformWidth / 2), 0, parameters.DetailLevel, parameters.DetailSize) * (parameters.Amplitude), lastHeight - 10, lastHeight + 10);

        int left = pos;
        int right = Math.Min(width - 1, pos + (int)platformWidth);
        int top = (height / 2) + (int)platformHeight;
        int bottom = 0;

        for (int ty = bottom; ty < top; ty++)
        {
          for (int tx = left; tx < right; tx++)
          {
            tiles[tx, ty].TileType = TileType.Filled;
          }
        }

        pos = right;
        lastHeight = platformHeight;
      }

      // Create slope tiles
      /*for (int y = 1; y < height - 1; y++)
      {
        for (int x = 1; x < width - 1; x++)
        {
          Tile tile = tiles[x, y];
          if (tile.TileType == TileType.Empty)
          {
            bool upFilled = tiles[x, y + 1].TileType == TileType.Filled;
            bool downFilled = tiles[x, y - 1].TileType == TileType.Filled;
            bool leftFilled = tiles[x - 1, y].TileType == TileType.Filled;
            bool rightFilled = tiles[x + 1, y].TileType == TileType.Filled;


            if (rightFilled && downFilled && !leftFilled && !upFilled)
            {
              tile.TileType = TileType.SouthEast;
              tile.ImageIndex = 1;
            }
            else if (!rightFilled && downFilled && leftFilled && !upFilled)
            {
              tile.TileType = TileType.SouthWest;
              tile.ImageIndex = 2;
            }
            else if (rightFilled && !downFilled && !leftFilled && upFilled)
            {
              tile.TileType = TileType.NorthEast;
              tile.ImageIndex = 3;
            }
            else if (!rightFilled && !downFilled && leftFilled && upFilled)
            {
              tile.TileType = TileType.NorthWest;
              tile.ImageIndex = 4;
            }
            else if (leftFilled && rightFilled && !upFilled && downFilled) // Fills single tile holes
            {
              tile.TileType = TileType.Filled;
            }

          }
        }
      }*/

      return tiles;
    }

  }
}
