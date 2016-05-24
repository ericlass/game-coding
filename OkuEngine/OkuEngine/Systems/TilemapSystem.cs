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
    private const int ChunkSize = 16;

    public override void Execute(Level currentLevel)
    {
      foreach (var entity in currentLevel.Entities)
      {
        var tilemap = entity.GetComponent<TilemapComponent>();
        if (tilemap != null)
        {
          if (tilemap.TileTexCoords == null)
            GenerateTexCoords(currentLevel, tilemap);
          
          if (tilemap.ChunkMeshes == null)
            GenerateChunkMeshes(currentLevel, tilemap);

          //TODO: Queue render tasks for visible chunks
        }
      }

    }

    private void GenerateChunkMeshes(Level currentLevel, TilemapComponent tilemap)
    {
      //How many chunks does the tilemap have?
      int chunksH = (int)Math.Ceiling(tilemap.Width / (float)ChunkSize);
      int chunksV = (int)Math.Ceiling(tilemap.Height / (float)ChunkSize);
      int numChunks = chunksV * chunksH;

      //Prepare mesh cache for all layers
      List<AssetHandle[]> chunks = new List<AssetHandle[]>(tilemap.LayerCount);
      for (int i = 0; i < tilemap.LayerCount; i++)
        chunks.Add(new AssetHandle[numChunks]);

      for (int chunkIndex = 0; chunkIndex < numChunks; chunkIndex++)
      {
        //chunks x and y coordinates
        int chunkX = chunkIndex % chunksH;
        int chunkY = chunkIndex / chunksH;

        //Which tiles are inside this chunk
        int tleft = chunkX * ChunkSize;
        int tright = Math.Min(tleft + ChunkSize, tilemap.Width - 1);

        int ttop = chunkY * ChunkSize;
        int tbottom = Math.Min(ttop + ChunkSize, tilemap.Height - 1);

        //How many tile in this chunk
        int numTiles = ((tright - tleft) + 1) * ((tbottom - ttop) + 1);

        //Create vertices lists
        List<List<Vector2f>> positions = new List<List<Vector2f>>(tilemap.LayerCount);
        List<List<Vector2f>> texCoords = new List<List<Vector2f>>(tilemap.LayerCount);
        List<List<Color>> colors = new List<List<Color>>(tilemap.LayerCount);

        //Create vertices list for each layer
        int numVertices = numTiles * 4;
        for (int i = 0; i < tilemap.LayerCount; i++)
        {
          positions.Add(new List<Vector2f>(numTiles * numVertices));
          texCoords.Add(new List<Vector2f>(numTiles * numVertices));
          colors.Add(new List<Color>(numTiles * numVertices));
        }

        //Generate vertices for tile
        for (int tileY = ttop; tileY <= tbottom; tileY++)
        {
          float top = tileY * tilemap.TileHeight;
          float bottom = top + tilemap.TileHeight;
          for (int tileX = tleft; tileX <= tright; tileX++)
          {
            float left = tileX * tilemap.TileWidth;
            float right = left + tilemap.TileWidth;

            //Iterating layers here saves calcualting tile coordinate again for each layer
            for (int layer = 0; layer < tilemap.LayerCount; layer++)
            {
              ushort tile = tilemap.GetTile(layer, tileX, tileY);
              if (tile > 0)
              {
                List<Vector2f> vecs = positions[layer];
                vecs.Add(new Vector2f(left, bottom));
                vecs.Add(new Vector2f(left, top));
                vecs.Add(new Vector2f(right, bottom));
                vecs.Add(new Vector2f(right, top));

                texCoords[layer].AddRange(tilemap.TileTexCoords[tile]);

                List<Color> cols = colors[layer];
                cols.Add(Color.White);
                cols.Add(Color.White);
                cols.Add(Color.White);
                cols.Add(Color.White);
              }
            }
          }
        }

        //Create mesh for this chunk in every layer
        for (int layer = 0; layer < positions.Count; layer++)
        {
          Vector2f[] pos = positions[layer].ToArray();
          Vector2f[] tex = texCoords[layer].ToArray();
          Color[] cols = colors[layer].ToArray();

          StaticMeshAsset mesh = new StaticMeshAsset(pos, tex, cols, PrimitiveType.TriangleStrip);
          chunks[layer][chunkIndex] = currentLevel.Assets.AddMesh(mesh);
        }
      }

      tilemap.ChunkMeshes = chunks;
    }

    private void GenerateTexCoords(Level currentLevel, TilemapComponent tilemap)
    {
      ImageBase image = currentLevel.Assets.GetAsset<ImageBase>(tilemap.Tileset);

      //How many tiles in this image
      int tilesH = image.Width / tilemap.TileWidth;
      int tilesV = image.Height / tilemap.TileHeight;
      int numTiles = tilesH * tilesV;

      //Prepare tex coord list. Contains texture coordinates for each tile.
      List<Vector2f[]> texCoords = new List<Vector2f[]>(numTiles);
      texCoords.Add(null); //Index 0 means "no tile"!

      //Width and height of one tile in texture space
      float tileWidthTexSpace = 1.0f / tilesH;
      float tileHeightTexSpace = 1.0f / tilesV;

      //Generate tex coords
      for (int i = 0; i < numTiles; i++)
      {
        int x = i % tilesH;
        int y = i / tilesH;

        float left = x * tileWidthTexSpace;
        float right = left + tileWidthTexSpace;
        float top = 1.0f - (y * tileHeightTexSpace);
        float bottom = top - tileHeightTexSpace;

        texCoords[i + 1] = new Vector2f[]
        {
                new Vector2f(left, bottom),
                new Vector2f(left, top),
                new Vector2f(right, bottom),
                new Vector2f(right, top)
        };
      }

      tilemap.TileTexCoords = texCoords;
    }

  }
}
