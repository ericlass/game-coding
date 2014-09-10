using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public TileGeneratorResult GenerateTiles(TileGeneratorParameters parameters, int width, int height)
    {
      if (width % 16 != 0 || height % 16 != 0)
        throw new OkuBase.OkuException("Tilemap width and height must be a multiple of 16!");

      Tile[,] tiles = new Tile[width, height];

      TileGeneratorResult result = new TileGeneratorResult();
      result.Tiles = tiles;
      result.Doors = new List<Vector2i>();

      //Fill tile map with empty tiles first
      Parallel.For(0, height, delegate(int y) 
      {
        for (int x = 0; x < width; x++)
        {
          Tile tile = new Tile();
          tile.TileType = TileType.Empty;
          tile.ImageIndex = -1;
          tiles[x, y] = tile;
        }
      });

      // Generate terrain from noise as described in GPU Gems 3
      PerlinNoise noise = new PerlinNoise(parameters.Seed);

      Parallel.For(0, height, delegate(int y)
      {
        for (int x = 0; x < width; x++)
        {
          //Default noise, similar to GPU Gems
          float density = -(y - (height / 4.0f));

          float noiseValue = noise.Noise(x * 1.96f, y * 1.96f, parameters.DetailLevel, parameters.DetailSize);
          if (parameters.Absolute)
            noiseValue = -Math.Abs(noiseValue) * 2;
          density += noiseValue * parameters.Amplitude * 0.51f;

          noiseValue = noise.Noise(x * 1.01f, y * 1.01f, parameters.DetailLevel, parameters.DetailSize);
          if (parameters.Absolute)
            noiseValue = -Math.Abs(noiseValue) * 2;
          density += noiseValue * parameters.Amplitude;

          //Caves
          if (parameters.Caves && x > 5 && x < width - 5 && y > 5)
          {
            if (Math.Abs(noise.Noise(x, y, 3, 80)) <= 0.08)
              density = 0;
          }

          Tile tile = tiles[x, y];
          if (density > 0.0f)
          {
            tile.TileType = TileType.Filled;
            tile.ImageIndex = 0;
          }
        }
      });

      CreateBuilding(result, parameters.Seed);
      //CreateSlopTiles(tiles);
      PostProcess(tiles);      

      return result;
    }

    private static void CreateBuilding(TileGeneratorResult results, int seed)
    {
      Tile[,] tiles = results.Tiles;

      Random rand = new Random(seed);
      int type = (rand.Next(1000) % 3) + 1;
      BuildingType buildingType = (BuildingType)type;
      //buildingType = BuildingType.Hall;

      OkuBase.OkuManager.Instance.Graphics.Title = buildingType.ToString();

      int baseWidth = 0;
      switch (buildingType)
      {
        case BuildingType.Tower:
          baseWidth = 150;
          break;

        case BuildingType.Bunker:
          baseWidth = 200;
          break;

        case BuildingType.Hall:
          baseWidth = 350;
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
      //TODO: Check height from above now there are caves!
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
          {
            tile.TileType = TileType.Filled;
            tile.ImageIndex = 0;
          }
          else
          {
            tile.TileType = TileType.Empty;
            tile.ImageIndex = -1;
          }          
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
              {
                tile.TileType = TileType.Filled;
                tile.ImageIndex = 0;
              }
              else
              {
                tile.TileType = TileType.Empty;
                tile.ImageIndex = -1;
              }
              
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
              {
                tile.TileType = TileType.Filled;
                tile.ImageIndex = 0;
              }
              else
              {
                tile.TileType = TileType.Empty;
                tile.ImageIndex = -1;
              }
              
            }
          }
          else
            break;

          colHeight += increment;
        }
      }
      #endregion

      baseWidth = baseWidth - 16;
      left += 8;
      right -= 8;

      int doorHeight = 3;
      int wallImage = 6;
      int bgWallImage = 7;
      if (buildingType == BuildingType.Tower)
      {
        // Base room
        int firstFloorHeight = 25;
        FillRectangle(tiles, left, right, averageHeight, averageHeight + firstFloorHeight, TileType.Empty, bgWallImage);
        DrawRectangle(tiles, left, right, averageHeight, averageHeight + firstFloorHeight, TileType.Filled, wallImage);        
        // Doors
        DrawLine(left, averageHeight + 1, left, averageHeight + doorHeight, tiles, TileType.Filled, bgWallImage);
        DrawLine(right, averageHeight + 1, right, averageHeight + doorHeight, tiles, TileType.Filled, bgWallImage);
        results.Doors.Add(new Vector2i(left, averageHeight + 1));
        results.Doors.Add(new Vector2i(right, averageHeight + 1));

        // Neck
        int neckWidth = (baseWidth / 6) * 2;
        int neckHeight = 150;
        int neckLeft = center - (neckWidth / 2);
        int neckRight = center + (neckWidth / 2);
        int neckBottom = averageHeight + 1;
        int neckTop = neckBottom + neckHeight;

        // Body
        FillRectangle(tiles, neckLeft, neckRight, neckBottom, neckTop, TileType.Empty, bgWallImage);
        DrawLine(neckLeft, neckTop, neckLeft, neckBottom + doorHeight, tiles, TileType.Filled, wallImage);
        DrawLine(neckRight, neckTop, neckRight, neckBottom + doorHeight, tiles, TileType.Filled, wallImage);
        DrawLine(neckLeft + 1, averageHeight + firstFloorHeight, neckRight - 1, averageHeight + firstFloorHeight, tiles, TileType.Empty, bgWallImage);
        //Doors
        DrawLine(neckLeft, averageHeight + 1, neckLeft, averageHeight + doorHeight, tiles, TileType.Filled, bgWallImage);
        DrawLine(neckRight, averageHeight + 1, neckRight, averageHeight + doorHeight, tiles, TileType.Filled, bgWallImage);
        results.Doors.Add(new Vector2i(neckLeft, averageHeight + 1));
        results.Doors.Add(new Vector2i(neckRight, averageHeight + 1));

        // "Stairs"
        int stairHeight = 8;
        int stairWidth = (neckWidth / 3);
        int numStairs = neckHeight / stairHeight;
        int sy = neckBottom + doorHeight + 1;
        for (int i = 0; i < numStairs; i++)
        {
          int sl, sr;

          if (i % 2 == 0)
          {
            sl = neckRight - stairWidth;
            sr = neckRight - 1;
          }
          else
          {
            sl = neckLeft + 1;
            sr = neckLeft + stairWidth;
          }

          DrawLine(sl, sy, sr, sy, tiles, TileType.Filled, wallImage);
          sy += stairHeight;
        }

        // Top
        int topWidth = (baseWidth / 4) * 3;
        int topHeight = firstFloorHeight * 2;

        int topLeft = center - (topWidth / 2);
        int topRight = topLeft + topWidth;
        int topTop = neckTop + topHeight;

        int notchWidth = neckWidth / 3;
        FillRectangle(tiles, topLeft, topRight, neckTop, topTop, TileType.Empty, bgWallImage);
        DrawRectangle(tiles, topLeft, topRight, neckTop, topTop, TileType.Filled, wallImage);
        DrawLine(neckLeft + notchWidth, neckTop, neckRight - notchWidth, neckTop, tiles, TileType.Empty, bgWallImage);
      }
    }

    private static void DrawRectangle(Tile[,] tiles, int left, int right, int bottom, int top, TileType type, int image)
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

    private static void FillRectangle(Tile[,] tiles, int left, int right, int bottom, int top, TileType type, int image)
    {
      for (int y = bottom; y <= top; y++)
      {
        for (int x = left; x < right; x++)
        {
          Tile tile = tiles[x, y];
          tile.TileType = type;
          tile.ImageIndex = image;
        }
      }
    }

    private static void DrawLine(int x0, int y0, int x1, int y1, Tile[,] tiles, TileType type, int image)
    {
      int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
      int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
      int err = dx + dy, e2;

      while (true)
      {
        Tile tile = tiles[x0, y0];
        tile.TileType = type;
        tile.ImageIndex = image;

        if (x0 == x1 && y0 == y1)
          break;

        e2 = 2 * err;
        if (e2 > dy)
        {
          err += dy;
          x0 += sx; 
        }

        if (e2 < dx)
        {
          err += dx;
          y0 += sy;
        }
      }
    }

    /// <summary>
    /// Does some final post processing on the tile map.
    /// </summary>
    /// <param name="tiles">The tiles to be processed.</param>
    private static void PostProcess(Tile[,] tiles)
    {
      //for (int y = 1; y < tiles.GetLength(1) - 1; y++)
      Parallel.For(1, tiles.GetLength(1) - 1, delegate(int y)
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
            {
              tile.TileType = TileType.Filled;
              tile.ImageIndex = 0;
            }
          }

          // Remove single tile pins
          if (tile.TileType == TileType.Filled)
          {
            if (!leftFilled && !rightFilled && !upFilled && downFilled)
            {
              tile.TileType = TileType.Empty;
              tile.ImageIndex = -1;
            }
          }

        }
      });

      //for (int y = 1; y < tiles.GetLength(1) - 1; y++)
      Parallel.For(1, tiles.GetLength(1) - 1, delegate(int y)
      {
        for (int x = 1; x < tiles.GetLength(0) - 1; x++)
        {
          Tile tile = tiles[x, y];

          // Set floor tiles
          if (tile.TileType == TileType.Filled)
          {
            bool upFilled = tiles[x, y + 1].TileType == TileType.Filled;
            bool downFilled = tiles[x, y - 1].TileType == TileType.Filled;
            bool leftFilled = tiles[x - 1, y].TileType == TileType.Filled;
            bool rightFilled = tiles[x + 1, y].TileType == TileType.Filled;

            if (!upFilled && tile.ImageIndex == 0)
              tile.ImageIndex = 1;
          }
        }
      });

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
