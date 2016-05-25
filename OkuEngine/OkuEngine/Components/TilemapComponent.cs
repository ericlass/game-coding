using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine.Levels;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class TilemapComponent : MeshComponent
  {
    public const byte CollisionNone = 0;
    public const byte CollisionFull = 1;
    public const byte CollisionNorthWest = 2;
    public const byte CollisionNorthEast = 3;
    public const byte CollisionSouthWest = 4;
    public const byte CollisionSouthEast = 5;

    private const int ChunkSize = 16;

    private AssetHandle _tileSetImage = null;
    private int _width = 4;
    private int _height = 4;
    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private byte[] _collision = null;
    private List<ushort[]> _layers = new List<ushort[]>();

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

    public TilemapComponent(int width, int height, int layers)
    {
      _width = width;
      _height = height;

      int numTiles = width * height;
      _collision = new byte[numTiles];

      for (int i = 0; i < layers; i++)
        _layers.Add(new ushort[numTiles]);
    }

    private TilemapComponent(AssetHandle tileset, int width, int height, int tileWidth, int tileHeight, byte[] collision, List<ushort[]> layers)
    {
      _tileSetImage = tileset;
      _width = width;
      _height = height;
      _collision = collision;
      _layers = layers;
    }

    public AssetHandle Tileset
    {
      get { return _tileSetImage; }
      set { _tileSetImage = value; }
    }

    public int Width
    {
      get { return _width; }
    }

    public int Height
    {
      get { return _height; }
    }

    public int TileWidth
    {
      get { return _tileWidth; }
    }

    public int TileHeight
    {
      get { return _tileHeight; }
    }

    public int LayerCount
    {
      get { return _layers.Count; }
    }

    public override string Name
    {
      get { return "tilemap"; }
    }

    public byte GetCollision(int x, int y)
    {
      return _collision[x + (y * _width)];
    }

    public void SetCollision(int x, int y, byte collision)
    {
      _collision[x + (y * _width)] = collision;
    }

    public ushort GetTile(int layer, int x, int y)
    {
      return _layers[layer][x + (y * _width)];
    }

    public void SetTile(int layer, int x, int y, ushort tile)
    {
      _layers[layer][x + (y * _width)] = tile;
    }

    public static TilemapComponent LoadFromTiledXml(Stream stream, Func<string, AssetHandle> imageLoader)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(stream);

      //Map properties
      XmlElement map = doc.DocumentElement;
      string version = map.Attributes["version"].InnerText;
      if (version != "1.0")
        throw new FormatException("Unsupported Tiled map version: " + version + "! Only version 1.0 is supported.");

      string orient = map.Attributes["orientation"].InnerText;
      if (orient != "orthogonal")
        throw new FormatException("Unsupported Tiled map orientation: " + orient + "! Only orthogonal is supported.");

      string str = map.Attributes["width"].InnerText;
      int width = int.Parse(str);

      str = map.Attributes["height"].InnerText;
      int height = int.Parse(str);

      str = map.Attributes["tilewidth"].InnerText;
      int tileWidth = int.Parse(str);

      str = map.Attributes["tileheight"].InnerText;
      int tileHeight = int.Parse(str);

      //Tileset properties
      XmlElement tileset = map["tileset"];
      XmlElement image = tileset["image"];
      string src = image.Attributes["source"].InnerText;
      AssetHandle tileSetImage = imageLoader(src);

      //Layers
      XmlNodeList layers = map.SelectNodes("//layer");

      byte[] collisionData = null;
      List<ushort[]> layersData = null;

      int numTiles = width * height;
      bool first = true;
      foreach (XmlNode layer in layers)
      {
        XmlElement data = layer["data"];
        string encoding = data.Attributes["encoding"].InnerText;

        if (encoding != "csv")
          throw new FormatException("Only CSV encoding is currently supported for Tiled maps!");

        string csv = data.InnerText.Trim().Replace("\r", "").Replace("\n", "");
        string[] parts = csv.Split(',');

        if (parts.Length != numTiles)
          throw new FormatException("Tile map specifies " + numTiles + " tiles, but data is " + parts.Length + " tiles!");

        if (first)
        {
          first = false;
          collisionData = new byte[numTiles];
          for (int i = 0; i < parts.Length; i++)
            collisionData[i] = byte.Parse(parts[i]);
        }
        else
        {
          if (layersData == null)
            layersData = new List<ushort[]>();

          ushort[] ld = new ushort[parts.Length];
          for (int i = 0; i < parts.Length; i++)
            ld[i] = ushort.Parse(parts[i]);

          layersData.Add(ld);
        }
      }

      return new TilemapComponent(tileSetImage, width, height, tileWidth, tileHeight, collisionData, layersData);
    }

    public void SaveToOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

    public void LoadFromOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

    public override IComponent Copy()
    {
      byte[] cols = new byte[_collision.Length];
      Array.Copy(_collision, cols, _collision.Length);

      List<ushort[]> layers = new List<ushort[]>();
      foreach (var layer in _layers)
      {
        ushort[] lay = new ushort[layer.Length];
        Array.Copy(layer, lay, layer.Length);
        layers.Add(lay);
      }

      return new TilemapComponent(_tileSetImage, _width, _height, _tileWidth, _tileHeight, cols, layers);
    }

    internal override List<AssetHandle> GetMeshes(Level currentLevel)
    {
      if (_tileTexCoords == null)
        GenerateTexCoords(currentLevel);

      if (_chunkMeshes == null)
        GenerateChunkMeshes(currentLevel);

      //TODO: Render all layers
      //TODO: Render only visible chunks
      return new List<AssetHandle>(_chunkMeshes[0]);
    }

    private void GenerateChunkMeshes(Level currentLevel)
    {
      //How many chunks does the tilemap have?
      int chunksH = (int)Math.Ceiling(_width / (float)ChunkSize);
      int chunksV = (int)Math.Ceiling(_height / (float)ChunkSize);
      int numChunks = chunksV * chunksH;

      //Prepare mesh cache for all layers
      List<AssetHandle[]> chunks = new List<AssetHandle[]>(LayerCount);
      for (int i = 0; i < LayerCount; i++)
        chunks.Add(new AssetHandle[numChunks]);

      int pixelHeight = _height * _tileHeight;
      for (int chunkIndex = 0; chunkIndex < numChunks; chunkIndex++)
      {
        //chunks x and y coordinates
        int chunkX = chunkIndex % chunksH;
        int chunkY = chunkIndex / chunksH;

        //Which tiles are inside this chunk
        int tleft = chunkX * ChunkSize;
        int tright = Math.Min(tleft + ChunkSize, _width - 1);

        int ttop = chunkY * ChunkSize;
        int tbottom = Math.Min(ttop + ChunkSize, _height - 1);

        //How many tile in this chunk
        int numTiles = (tright - tleft) * (tbottom - ttop);

        //Create vertices lists
        List<List<Vector2f>> positions = new List<List<Vector2f>>(LayerCount);
        List<List<Vector2f>> texCoords = new List<List<Vector2f>>(LayerCount);
        List<List<Color>> colors = new List<List<Color>>(LayerCount);

        //Create vertices list for each layer
        int numVertices = numTiles * 4;
        for (int i = 0; i < LayerCount; i++)
        {
          positions.Add(new List<Vector2f>(numVertices));
          texCoords.Add(new List<Vector2f>(numVertices));
          colors.Add(new List<Color>(numVertices));
        }

        //Generate vertices for tile
        for (int tileY = ttop; tileY <= tbottom; tileY++)
        {
          float top = pixelHeight - tileY * _tileHeight;
          float bottom = top - _tileHeight;
          for (int tileX = tleft; tileX <= tright; tileX++)
          {
            float left = tileX * _tileWidth;
            float right = left + _tileWidth;

            //Iterating layers here saves calcualting tile coordinate again for each layer
            for (int layer = 0; layer < LayerCount; layer++)
            {
              ushort tile = GetTile(layer, tileX, tileY);
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

    private void GenerateTexCoords(Level currentLevel)
    {
      ImageBase image = currentLevel.Assets.GetAsset<ImageBase>(_tileSetImage);

      //How many tiles in this image
      int tilesH = image.Width / _tileWidth;
      int tilesV = image.Height / _tileHeight;
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
