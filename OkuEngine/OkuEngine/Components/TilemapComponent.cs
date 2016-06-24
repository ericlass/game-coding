using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
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
  public class TilemapComponent : MeshComponent
  {
    //Width and height of chunks in number of tiles.
    private const int ChunkSize = 16;

    private AssetHandle _tileSetImage = null;
    private AssetHandle _tileMap = null;

    private List<AssetHandle> _meshRenderList = new List<AssetHandle>();

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
    private List<AssetHandle[]> _chunkMeshes { get; set; }

    public TilemapComponent(AssetHandle tilemap, AssetHandle tileImage)
    {
      if (!tilemap.IsValid)
        throw new ArgumentException("Given tilemap asset is not valid anymore!");

      if (!tileImage.IsValid)
        throw new ArgumentException("Given image asset is not valid anymore!");

      if (tilemap.AssetType != AssetType.Tilemap)
        throw new ArgumentException("Parameter 'tilemap' has to be asset type Tilemap!");

      if (tileImage.AssetType != AssetType.Image)
        throw new ArgumentException("Parameter 'image' has to be asset type Image!");

      _tileMap = tilemap;
      _tileSetImage = tileImage;
    }

    /// <summary>
    /// Gets or set the tile set image containing the tile images for the graphical layers.
    /// </summary>
    public AssetHandle Tileset
    {
      get { return _tileSetImage; }
      set { _tileSetImage = value; }
    }

    public AssetHandle Tilemap
    {
      get { return _tileMap; }
      set { _tileMap = value; }
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
    public override IComponent Copy()
    {
      return new TilemapComponent(_tileMap, _tileSetImage);
    }

    /// <summary>
    /// Gets the meshes to be rendered for the current frame.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
    /// <returns>The meshes to be rendered.</returns>
    internal override List<AssetHandle> GetMeshes(Level currentLevel)
    {
      if (_tileTexCoords == null)
        GenerateTexCoords(currentLevel);

      if (_chunkMeshes == null)
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
      TilemapAsset tilemap = currentLevel.Assets.GetAsset<TilemapAsset>(_tileMap);

      //How many chunks does the tilemap have?
      int chunksH = (int)Math.Ceiling(tilemap.Width / (float)ChunkSize);
      int chunksV = (int)Math.Ceiling(tilemap.Height / (float)ChunkSize);
      int numChunks = chunksV * chunksH;

      //Prepare mesh cache for all layers
      List<AssetHandle[]> chunks = new List<AssetHandle[]>(tilemap.LayerCount);
      for (int i = 0; i < tilemap.LayerCount; i++)
        chunks.Add(new AssetHandle[numChunks]);

      int pixelHeight = tilemap.Height * tilemap.TileHeight;
      for (int chunkIndex = 0; chunkIndex < numChunks; chunkIndex++)
      {
        //chunks x and y coordinates
        int chunkX = chunkIndex % chunksH;
        int chunkY = chunkIndex / chunksH;

        //Which tiles are inside this chunk
        int tleft = chunkX * ChunkSize;
        int tright = Math.Min(tleft + ChunkSize, tilemap.Width - 1);

        int tbottom = chunkY * ChunkSize;
        int ttop = Math.Min(tbottom + ChunkSize, tilemap.Height - 1);

        //How many tile in this chunk
        int numTiles = (tright - tleft) * (ttop - tbottom);

        //Create vertices lists
        List<List<Vector2f>> positions = new List<List<Vector2f>>(tilemap.LayerCount);
        List<List<Vector2f>> texCoords = new List<List<Vector2f>>(tilemap.LayerCount);
        List<List<Color>> colors = new List<List<Color>>(tilemap.LayerCount);

        //Create vertices list for each layer
        int numVertices = numTiles * 4;
        for (int i = 0; i < tilemap.LayerCount; i++)
        {
          positions.Add(new List<Vector2f>(numVertices));
          texCoords.Add(new List<Vector2f>(numVertices));
          colors.Add(new List<Color>(numVertices));
        }

        //Generate vertices for tile
        for (int tileY = tbottom; tileY <= ttop; tileY++)
        {
          float bottom = tileY * tilemap.TileHeight;
          float top = bottom + tilemap.TileHeight;

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

          StaticMeshAsset mesh = new StaticMeshAsset(pos, tex, cols, PrimitiveType.Quads);
          chunks[layer][chunkIndex] = currentLevel.Assets.AddMesh(mesh);
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
      TilemapAsset tilemap = currentLevel.Assets.GetAsset<TilemapAsset>(_tileMap);
      ImageBase image = currentLevel.Assets.GetAsset<ImageBase>(_tileSetImage);

      //How many tiles in this image
      int tilesH = image.Width / tilemap.TileWidth;
      int tilesV = image.Height / tilemap.TileHeight;
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
