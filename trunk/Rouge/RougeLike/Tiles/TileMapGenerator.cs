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
      PerlinNoise noise = new PerlinNoise(parameters.Seed);
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

      CreateBuilding(tiles, parameters.Seed);
      //CreateSlopTiles(tiles);
      PostProcess(tiles);      

      return tiles;
    }

    private static void CreateBuilding(Tile[,] tiles, int seed)
    {
      Random rand = new Random(seed);
      int type = (rand.Next(1000) % 3) + 1;
      BuildingType buildingType = (BuildingType)type;
      //buildingType = BuildingType.Hall;

      OkuBase.OkuManager.Instance.Graphics.Title = buildingType.ToString();

      int baseWidth = 0;
      switch (buildingType)
      {
        case BuildingType.Tower:
          baseWidth = 100;
          break;

        case BuildingType.Bunker:
          baseWidth = 150;
          break;

        case BuildingType.Hall:
          baseWidth = 300;
          break;

        default:
          throw new Exception("Unknown building type: " + buildingType.ToString());
      }

      // Calculate left and right bounds of the base
      int center = tiles.GetLength(0) / 2;
      int halfWidth = baseWidth / 2;
      int left = center - halfWidth;
      int right = center + halfWidth;

      // Calculate average height in the base area
      int averageHeight = 0;
      for (int x = left; x <= right; x++)
      {
        for (int y = 0; y < tiles.GetLength(1); y++)
        {
          if (tiles[x, y].TileType == TileType.Empty)
          {
            averageHeight += y;
            break;
          }
        }
      }
      averageHeight = averageHeight / (right - left + 1);

      // Build base plate
      for (int x = left; x <= right; x++)
      {
        for (int y = 0; y < tiles.GetLength(1); y++)
        {
          Tile tile = tiles[x, y];
          if (y <= averageHeight)
            tile.TileType = TileType.Filled;
          else
            tile.TileType = TileType.Empty;

          tile.ImageIndex = 0;
        }
      }

      #region Smooth base plate sides
      // Smooth left side of base plate
      int height = 0;
      for (int y = 0; y < tiles.GetLength(1); y++)
      {
        if (tiles[left - 1, y].TileType == TileType.Empty)
        {
          height = y;
          break;
        }
      }

      if (Math.Abs(averageHeight - height) > 2)
      {
        int increment = 0;
        Func<TileType, bool> checkFunc = null;

        if (height < averageHeight)
        {
          increment = -1;
          checkFunc = (ttype) => ttype == TileType.Empty;
        }
        else
        {
          increment = 1;
          checkFunc = (ttype) => ttype != TileType.Empty;
        }

        int colHeight = averageHeight;
        for (int x = left - 1; x > 0; x--)
        {
          Tile tile = tiles[x, colHeight];

          if (checkFunc(tile.TileType))
          {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
              tile = tiles[x, y];
              if (y <= colHeight)
                tile.TileType = TileType.Filled;
              else
                tile.TileType = TileType.Empty;
              tile.ImageIndex = 0;
            }
          }
          else
            break;

          colHeight += increment;
        }
      }

      // Smooth right side of base plate
      height = 0;
      for (int y = 0; y < tiles.GetLength(1); y++)
      {
        if (tiles[right + 1, y].TileType == TileType.Empty)
        {
          height = y;
          break;
        }
      }

      if (Math.Abs(averageHeight - height) > 2)
      {
        int increment = 0;
        Func<TileType, bool> checkFunc = null;

        if (height < averageHeight)
        {
          increment = -1;
          checkFunc = (ttype) => ttype == TileType.Empty;
        }
        else
        {
          increment = 1;
          checkFunc = (ttype) => ttype != TileType.Empty;
        }

        int colHeight = averageHeight;
        for (int x = right + 1; x < tiles.GetLength(0); x++)
        {
          Tile tile = tiles[x, colHeight];

          if (checkFunc(tile.TileType))
          {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
              tile = tiles[x, y];
              if (y <= colHeight)
                tile.TileType = TileType.Filled;
              else
                tile.TileType = TileType.Empty;
              tile.ImageIndex = 0;
            }
          }
          else
            break;

          colHeight += increment;
        }
      }
      #endregion

      if (buildingType == BuildingType.Tower)
      {
        int firstFloorHeight = 20;
        DrawRectangle(tiles, left, right, averageHeight , averageHeight + firstFloorHeight, TileType.Filled, 0);

        int neckWidth = (baseWidth / 4) * 2;
        int neckHeight = 100;
        DrawRectangle(tiles, center - (neckWidth / 2), center + (neckWidth / 2), averageHeight + firstFloorHeight, averageHeight + firstFloorHeight + neckHeight, TileType.Filled, 0);
      }
    }

    public static void DrawRectangle(Tile[,] tiles, int left, int right, int bottom, int top, TileType type, int image)
    {
      for (int x = left; x <= right; x++)
      {
        Tile tile = tiles[x, bottom];
        tile.TileType = type;
        tile.ImageIndex = image;

        tile = tiles[x, top];
        tile.TileType = type;
        tile.ImageIndex = image;
      }

      for (int y = bottom; y <= top; y++)
      {
        Tile tile = tiles[left, y];
        tile.TileType = type;
        tile.ImageIndex = image;

        tile = tiles[right, y];
        tile.TileType = type;
        tile.ImageIndex = image;
      }
    }

    /// <summary>
    /// Does some final post processing on the tile map.
    /// </summary>
    /// <param name="tiles">The tiles to be processed.</param>
    private static void PostProcess(Tile[,] tiles)
    {
      for (int y = 1; y < tiles.GetLength(1) - 1; y++)
      {
        for (int x = 1; x < tiles.GetLength(0) - 1; x++)
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
    }

    /// <summary>
    /// Creates slop tiles on the given tile map where they should be.
    /// </summary>
    /// <param name="tiles">The tiles to process.</param>
    private static void CreateSlopTiles(Tile[,] tiles)
    {
      for (int y = 1; y < tiles.GetLength(1) - 1; y++)
      {
        for (int x = 1; x < tiles.GetLength(0) - 1; x++)
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
      }
    }

  }
}
