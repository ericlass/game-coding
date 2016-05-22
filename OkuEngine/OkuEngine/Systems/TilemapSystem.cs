using System;
using System.Collections.Generic;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine.Assets;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class TilemapSystem : GameSystem
  {
    public override void Execute(Level currentLevel)
    {
      foreach (var entity in currentLevel.Entities)
      {
        var tilemap = entity.GetComponent<TilemapComponent>();
        if (tilemap != null)
        {
          if (tilemap.TileTexCoords == null)
          {
            ImageBase image = currentLevel.Assets.GetAsset<ImageBase>(tilemap.Tileset);
            int tilesH = image.Width / tilemap.TileWidth;
            int tilesV = image.Height / tilemap.TileHeight;
            int numTiles = tilesH * tilesV;

            List<Vector2f[]> texCoords = new List<Vector2f[]>(numTiles);
            texCoords.Add(null); //Index 0 means "no tile"!

            float tileWidthTexSpace = 1.0f / tilesH;
            float tileHeightTexSpace = 1.0f / tilesV;
            for (int i = 0; i < numTiles; i++)
            {
              int x = i % tilesH;
              int y = i / tilesH;

              float left = x * tileWidthTexSpace;
              float right = left + tileWidthTexSpace;
              float top = 1.0f - (y * tileHeightTexSpace);
              float bottom = top - tileHeightTexSpace;

              texCoords[i] = new Vector2f[]
              {
                new Vector2f(left, bottom),
                new Vector2f(left, top),
                new Vector2f(right, bottom),
                new Vector2f(right, top)
              };
            }

            tilemap.TileTexCoords = texCoords;
          }

          const int chunkSize = 16;
          if (tilemap.ChunkMeshes == null)
          {
            int chunksH = (int)Math.Ceiling(tilemap.Width / (float)chunkSize);
            int chunksV = (int)Math.Ceiling(tilemap.Height / (float)chunkSize);
            int numChunks = chunksV * chunksH;

            List<AssetHandle[]> chunks = new List<AssetHandle[]>(numChunks);


            for (int i = 0; i < numChunks; i++)
            {
              //chunks x and y coordinates
              int chunkX = i % chunksH;
              int chunkY = i / chunksH;

              //tiles in this chunk
              int tleft = chunkX * chunkSize;
              int tright = Math.Min(tleft + chunkSize, tilemap.Width - 1);

              int ttop = chunkY * chunkSize;
              int tbottom = Math.Min(ttop + chunkSize, tilemap.Height - 1);

              int numTiles = ((tright - tleft) + 1) * ((tbottom - ttop) + 1);

              for (int y = ttop; y <= tbottom; y++)
              {
                float top = y * tilemap.TileHeight;
                float bottom = top + tilemap.TileHeight;
                for (int x = tleft; x <= tright; x++)
                {
                  float left = x * tilemap.TileWidth;
                  float right = left + tilemap.TileWidth;

                  for (int layer = 0; layer < tilemap.LayerCount; layer++)
                  {
                    ushort tile = tilemap.GetTile(layer, x, y);
                    //TODO: Create mesh for tile and set it in the chunk mesh cache
                  }
                }
              }
            }
            

            tilemap.ChunkMeshes = chunks;
          }
        }
      }

    }

  }
}
