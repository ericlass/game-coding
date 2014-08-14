using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase.Utils;

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
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          //Default noise, similar to GPU Gems
          float density = -(y - (height / 2.0f));
          density += noise.Noise(x * 1.96f, y * 1.96f, parameters.DetailLevel, parameters.DetailSize) * parameters.Amplitude * 0.51f;
          density += noise.Noise(x * 1.01f, y * 1.01f, parameters.DetailLevel, parameters.DetailSize) * parameters.Amplitude;

          Tile tile = tiles[x, y];
          tile.ImageIndex = 0;

          if (density > 0.0f)
            tile.TileType = TileType.Filled;
        }
      }

      // Post processing
      for (int y = 1; y < height - 1; y++)
      {
        for (int x = 1; x < width - 1; x++)
        {
          Tile tile = tiles[x, y];

          bool upFilled = tiles[x, y + 1].TileType == TileType.Filled;
          bool downFilled = tiles[x, y - 1].TileType == TileType.Filled;
          bool leftFilled = tiles[x - 1, y].TileType == TileType.Filled;
          bool rightFilled = tiles[x + 1, y].TileType == TileType.Filled;

          // Fill single tile holes
          if (tile.TileType == TileType.Empty)
          {
            if (leftFilled && rightFilled && !upFilled && downFilled)
              tile.TileType = TileType.Filled;
          }

          // Remove single tile pins
          if (tile.TileType == TileType.Filled)
          {
            if (!leftFilled && !rightFilled && !upFilled && downFilled)
              tile.TileType = TileType.Empty;
          }

          // Set floor tiles
          if (tile.TileType == TileType.Filled)
          {
            if (!upFilled)
              tile.ImageIndex = 1;
          }

        }
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
              tile.ImageIndex = 2;
            }
            else if (!rightFilled && downFilled && leftFilled && !upFilled)
            {
              tile.TileType = TileType.SouthWest;
              tile.ImageIndex = 3;
            }
            else if (rightFilled && !downFilled && !leftFilled && upFilled)
            {
              tile.TileType = TileType.NorthEast;
              tile.ImageIndex = 4;
            }
            else if (!rightFilled && !downFilled && leftFilled && upFilled)
            {
              tile.TileType = TileType.NorthWest;
              tile.ImageIndex = 5;
            }

          }
        }
      }*/

      return tiles;
    }

  }
}
