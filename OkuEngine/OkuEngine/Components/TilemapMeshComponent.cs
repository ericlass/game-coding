using System;
using System.Collections.Generic;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine.Levels;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  /// <summary>
  /// Component that renders a tile map.
  /// Maps can be loaded from different file formats, like Tiled XML format (TMX).
  /// The tile map has one collision layer and 1-n graphical layers.
  /// </summary>
  public class TilemapMeshComponent : MeshComponent
  {
    //Width and height of chunks in number of tiles.
    private const int ChunkSize = 16;

    private int _tileSetImage = 0;
    private Tilemap _tileMap = null;

    private List<int> _meshRenderList = new List<int>();
    private SortedSet<int> _changedChunks = new SortedSet<int>();

    /// <summary>
    /// List of texture coordinates for the tiles from the tile sets.
    /// The index in the list is the tile index from the tile set.
    /// Index 0 is always null as 0 measn no tile.
    /// </summary>
    private List<Vector2f[]> _tileTexCoords { get; set; }

    /// <summary>
    /// List of mesh assest for the chunks of the tile map.
    /// Each item in the list is an array of the chunks for a single tile layer.
    /// </summary>
    private List<int[]> _chunkMeshes { get; set; }

    public TilemapMeshComponent(Tilemap tilemap, int tileImage)
    {
      _tileMap = tilemap;
      _tileSetImage = tileImage;

      _tileMap.OnChangeTile += TileMap_OnChangeTile;
    }

    private void TileMap_OnChangeTile(Vector2i obj)
    {
      int chunkIndex = obj.X / ChunkSize * obj.Y / ChunkSize;
      _changedChunks.Add(chunkIndex);
      //Change is communicated later when the meshes are updated in the mesh cache
    }

    /// <summary>
    /// Gets or set the tile set image containing the tile images for the graphical layers.
    /// </summary>
    public int Tileset
    {
      get { return _tileSetImage; }
    }

    /// <summary>
    /// Gets or sets the tile map asset.
    /// </summary>
    public Tilemap Tilemap
    {
      get { return _tileMap; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get { return "tilemap"; }
    }

    /// <summary>
    /// Creates a deep copy of the component and all its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
    public override Component Copy()
    {
      return new TilemapMeshComponent(_tileMap, _tileSetImage);
    }

    /// <summary>
    /// Gets the meshes to be rendered for the current frame.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    /// <returns>The meshes to be rendered.</returns>
    internal override List<int> GetMeshes(Level currentLevel)
    {
      if (_tileTexCoords == null)
        GenerateTexCoords(currentLevel);

      if (_chunkMeshes == null || _changedChunks.Count > 0)
        GenerateChunkMeshes(currentLevel);

      //TODO: Render only visible chunks
      _meshRenderList.Clear();
      foreach (var chunk in _chunkMeshes)
        _meshRenderList.AddRange(chunk);

      return _meshRenderList;
    }

    /// <summary>
    /// Generates the meshes for the chunks of the tile map.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    private void GenerateChunkMeshes(Level currentLevel)
    {
      //How many chunks does the tilemap have?
      int chunksH = (int)Math.Ceiling(_tileMap.Width / (float)ChunkSize);
      int chunksV = (int)Math.Ceiling(_tileMap.Height / (float)ChunkSize);
      int numChunks = chunksV * chunksH;

      //Prepare mesh cache for all layers
      List<int[]> chunks = new List<int[]>(_tileMap.LayerCount);
      for (int i = 0; i < _tileMap.LayerCount; i++)
        chunks.Add(new int[numChunks]);

      int pixelHeight = _tileMap.Height * _tileMap.TileHeight;
      for (int chunkIndex = 0; chunkIndex < numChunks; chunkIndex++)
      {
        //chunks x and y coordinates
        int chunkX = chunkIndex % chunksH;
        int chunkY = chunkIndex / chunksH;

        //Which tiles are inside this chunk
        int tleft = chunkX * ChunkSize;
        int tright = Math.Min(tleft + ChunkSize, _tileMap.Width - 1);

        int tbottom = chunkY * ChunkSize;
        int ttop = Math.Min(tbottom + ChunkSize, _tileMap.Height - 1);

        //How many tile in this chunk
        int numTiles = (tright - tleft) * (ttop - tbottom);

        //Create vertices lists
        List<List<Vector2f>> positions = new List<List<Vector2f>>(_tileMap.LayerCount);
        List<List<Vector2f>> texCoords = new List<List<Vector2f>>(_tileMap.LayerCount);
        List<List<Color>> colors = new List<List<Color>>(_tileMap.LayerCount);

        //Create vertices list for each layer
        int numVertices = numTiles * 4;
        for (int i = 0; i < _tileMap.LayerCount; i++)
        {
          positions.Add(new List<Vector2f>(numVertices));
          texCoords.Add(new List<Vector2f>(numVertices));
          colors.Add(new List<Color>(numVertices));
        }

        //Generate vertices for tile
        for (int tileY = tbottom; tileY <= ttop; tileY++)
        {
          float bottom = tileY * _tileMap.TileHeight;
          float top = bottom + _tileMap.TileHeight;

          for (int tileX = tleft; tileX <= tright; tileX++)
          {
            float left = tileX * _tileMap.TileWidth;
            float right = left + _tileMap.TileWidth;

            //Iterating layers here saves calcualting tile coordinate again for each layer
            for (int layer = 0; layer < _tileMap.LayerCount; layer++)
            {
              ushort tile = _tileMap.GetTile(layer, tileX, tileY);
              if (tile > 0)
              {
                List<Vector2f> vecs = positions[layer];
                vecs.Add(new Vector2f(left, bottom));
                vecs.Add(new Vector2f(left, top));
                vecs.Add(new Vector2f(right, top));
                vecs.Add(new Vector2f(right, bottom));                

                texCoords[layer].AddRange(_tileTexCoords[tile]);

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

          int meshEntry = currentLevel.MeshCache.CreateEntry();
          currentLevel.MeshCache.BufferData(meshEntry, new Mesh(pos, tex, cols, PrimitiveType.Quads));

          chunks[layer][chunkIndex] = meshEntry;
        }
      }

      _chunkMeshes = chunks;
    }

    /// <summary>
    /// Generate texture coordinates for the single tiles in the tile set.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    private void GenerateTexCoords(Level currentLevel)
    {
      ImageAsset image = currentLevel.Assets.GetAsset<ImageAsset>(_tileSetImage);

      //How many tiles in this image
      int tilesH = image.Image.Width / _tileMap.TileWidth;
      int tilesV = image.Image.Height / _tileMap.TileHeight;
      int numTiles = tilesH * tilesV;

      //Prepare tex coord list. Contains texture coordinates for each tile.
      List<Vector2f[]> texCoords = new List<Vector2f[]>(numTiles + 1);
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

        texCoords.Add(
          new Vector2f[]
          {
            new Vector2f(left, bottom),
            new Vector2f(left, top),
            new Vector2f(right, top),
            new Vector2f(right, bottom)                  
          }
        );
      }

      _tileTexCoords = texCoords;
    }

  }
}
