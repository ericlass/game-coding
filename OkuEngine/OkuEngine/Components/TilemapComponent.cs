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
    /// <summary>
    /// No collision at all.
    /// </summary>
    public const byte CollisionNone = 0;

    /// <summary>
    /// The full tile cannot be entered.
    /// </summary>
    public const byte CollisionFull = 1;

    /// <summary>
    /// The north west triangle of the tile cannot be entered.
    /// </summary>
    public const byte CollisionNorthWest = 2;

    /// <summary>
    /// The north east triangle of the tile cannot be entered.
    /// </summary>
    public const byte CollisionNorthEast = 3;

    /// <summary>
    /// The south west triangle of the tile cannot be entered.
    /// </summary>
    public const byte CollisionSouthWest = 4;

    /// <summary>
    /// The south east triangle of the tile cannot be entered.
    /// </summary>
    public const byte CollisionSouthEast = 5;

    //Width and height of chunks in number of tiles.
    private const int ChunkSize = 16;

    private AssetHandle _tileSetImage = null;
    private int _width = 4;
    private int _height = 4;
    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private byte[] _collision = null;
    private List<ushort[]> _layers = new List<ushort[]>();

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

    /// <summary>
    /// Creates a new tilemap component with the given width, height and number of layers.
    /// </summary>
    /// <param name="width">The width of the tile map (tiles).</param>
    /// <param name="height">The height of the tile map (tiles).</param>
    /// <param name="layers">The number of graphical layers.</param>
    public TilemapComponent(int width, int height, int layers)
    {
      _width = width;
      _height = height;

      int numTiles = width * height;
      _collision = new byte[numTiles];

      for (int i = 0; i < layers; i++)
        _layers.Add(new ushort[numTiles]);
    }

    /// <summary>
    /// Internal copy constructor.
    /// </summary>
    /// <param name="tileset">The tile set image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="tileWidth">The width of a single tile.</param>
    /// <param name="tileHeight">The height of a single tile.</param>
    /// <param name="collision">The collision layer.</param>
    /// <param name="layers">The graphical layer.</param>
    private TilemapComponent(AssetHandle tileset, int width, int height, int tileWidth, int tileHeight, byte[] collision, List<ushort[]> layers)
    {
      _tileSetImage = tileset;
      _width = width;
      _height = height;
      _collision = collision;
      _layers = layers;
    }

    /// <summary>
    /// Gets or set the tile set image containing the tile images for the graphical layers.
    /// </summary>
    public AssetHandle Tileset
    {
      get { return _tileSetImage; }
      set { _tileSetImage = value; }
    }

    /// <summary>
    /// Gets the width of the tile map in tiles.
    /// </summary>
    public int Width
    {
      get { return _width; }
    }

    /// <summary>
    /// Gets the height of the tile map in tiles.
    /// </summary>
    public int Height
    {
      get { return _height; }
    }

    /// <summary>
    /// Gets the width of a single tile in pixels.
    /// </summary>
    public int TileWidth
    {
      get { return _tileWidth; }
    }

    /// <summary>
    /// Gets the height of a single tile in pixels.
    /// </summary>
    public int TileHeight
    {
      get { return _tileHeight; }
    }

    /// <summary>
    /// Gets the number of graphical layers.
    /// </summary>
    public int LayerCount
    {
      get { return _layers.Count; }
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public override string Name
    {
      get { return "tilemap"; }
    }

    /// <summary>
    /// Gets the collision type at the given position.
    /// </summary>
    /// <param name="x">The X coordinate of the tile.</param>
    /// <param name="y">The Y coordinate of the tile.</param>
    /// <returns>The collision type for the tile.</returns>
    public byte GetCollision(int x, int y)
    {
      return _collision[x + (y * _width)];
    }

    /// <summary>
    /// Sets the collision type for the tile at the given position.
    /// </summary>
    /// <param name="x">The X coordinate of the tile.</param>
    /// <param name="y">The Y coordinate of the tile.</param>
    /// <param name="collision">The new collision type.</param>
    public void SetCollision(int x, int y, byte collision)
    {
      _collision[x + (y * _width)] = collision;
    }

    /// <summary>
    /// Gets the tile id of the tile on one of the graphical layers.
    /// </summary>
    /// <param name="layer">The layer index.</param>
    /// <param name="x">The X coordinate of the tile.</param>
    /// <param name="y">The Y coordinate of the tile.</param>
    /// <returns>The tile id of the tile.</returns>
    public ushort GetTile(int layer, int x, int y)
    {
      return _layers[layer][x + (y * _width)];
    }

    /// <summary>
    /// Sets the tile id of the tile on the specified tile and layer.
    /// </summary>
    /// <param name="layer">The layer index.</param>
    /// <param name="x">The X coordinate of the tile.</param>
    /// <param name="y">The Y coordinate of the tile.</param>
    /// <param name="tile">The id of tile.</param>
    public void SetTile(int layer, int x, int y, ushort tile)
    {
      _layers[layer][x + (y * _width)] = tile;
    }

    /// <summary>
    /// Loads a tile map from a Tiled TMX file. Supports loading of CSV encoded layers.
    /// The lowest layer is considered to be the collision layer. It should only contain tile ids from 0 - 5.
    /// </summary>
    /// <param name="stream">The stream containing the TMX file data.</param>
    /// <param name="imageLoader">A callback that can resolve the relative image paths in TMX files.</param>
    /// <returns>The loaded tile map.</returns>
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

        //Reverse tile lines. Tiled stores the the map in left-right, top-down order, but we need it in left-right, bottom-up order
        string csv = data.InnerText.Replace("\r", "");
        List<string> lines = new List<string>(csv.Trim().Split('\n'));
        lines[lines.Count - 1] += ","; //Add comma to last line
        lines[0] = lines[0].Substring(0, lines[0].Length - 1); //Remove comma from last line
        lines.Reverse();

        StringBuilder builder = new StringBuilder();
        foreach (var line in lines)
          builder.Append(line);

        //string csv = data.InnerText.Trim().Replace("\r", "").Replace("\n", "");
        csv = builder.ToString();
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

    /// <summary>
    /// Saves the tilemap to an OkuEngine-specific, binary tilemap format that is optimized for fast loading and streaming.
    /// </summary>
    /// <param name="stream">The stream to save the tile map to.</param>
    public static TilemapComponent SaveToOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Loads tile map data from an OkuEngine-soecific file format.
    /// </summary>
    /// <param name="stream">The stream to load the data from.</param>
    public static TilemapComponent LoadFromOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a deep copy of the component and all its data.
    /// </summary>
    /// <returns>A copy of the component.</returns>
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

        int tbottom = chunkY * ChunkSize;
        int ttop = Math.Min(tbottom + ChunkSize, _height - 1);

        //How many tile in this chunk
        int numTiles = (tright - tleft) * (ttop - tbottom);

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
        for (int tileY = tbottom; tileY <= ttop; tileY++)
        {
          float bottom = tileY * _tileHeight;
          float top = bottom + _tileHeight;

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

    /// <summary>
    /// Generate texture coordinates for the single tiles in the tile set.
    /// </summary>
    /// <param name="currentLevel">The current level.</param>
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

    public Vector2f GetMaxMovement(Vector2f min, Vector2f max, Vector2f mov)
    {
      Vector2f result = mov;

      Vector2f maxMov = max + mov;

      //Calculate tile area that sweeped box touches
      Vector2i tileLeftBottom = GridMath.CellOfPoint(min, _tileWidth);
      Vector2i tileRightTop = GridMath.CellOfPoint(maxMov, _tileWidth);

      //Calculate corner points of box
      Vector2f leftBottom = min;
      Vector2f leftTop = new Vector2f(min.X, max.Y);
      Vector2f rightTop = max;
      Vector2f rightBottom = new Vector2f(max.X, min.Y);

      //Calculate line segement of box
      var boxLines = new Tuple<Vector2f, Vector2f>[]
      {
        new Tuple<Vector2f, Vector2f>(leftBottom, leftTop),
        new Tuple<Vector2f, Vector2f>(leftTop, rightTop),
        new Tuple<Vector2f, Vector2f>(rightTop, rightBottom),
        new Tuple<Vector2f, Vector2f>(rightBottom, leftBottom)
      };

      //Calculate movement vectors of corner points
      var boxVectors = new Tuple<Vector2f, Vector2f>[]
      {
        new Tuple<Vector2f, Vector2f>(leftBottom, leftBottom + mov),
        new Tuple<Vector2f, Vector2f>(leftTop, leftTop + mov),
        new Tuple<Vector2f, Vector2f>(rightTop, rightTop + mov),
        new Tuple<Vector2f, Vector2f>(rightBottom, rightBottom + mov)
      };

      var tileLines = new List<Tuple<Vector2f, Vector2f>>(4);
      var tileVectors = new List<Tuple<Vector2f, Vector2f>>(4);

      System.Diagnostics.Debug.WriteLine("----------");

      System.Diagnostics.Debug.WriteLine(tileLeftBottom + " ; " + tileRightTop);

      for (int ty = tileLeftBottom.Y; ty <= tileRightTop.Y; ty++)
      {
        for (int tx = tileLeftBottom.X; tx <= tileRightTop.X; tx++)
        {
          byte col = GetCollision(tx, ty);
          System.Diagnostics.Debug.WriteLine(tx + ";" + ty + ":" + col);

          if (col > CollisionNone)
          {
            tileLines.Clear();
            tileVectors.Clear();

            float tileLeft = tx * _tileWidth;
            float tileRight = tileLeft + _tileWidth;
            float tileBottom = ty * _tileHeight;
            float tileTop = tileBottom + _tileHeight;

            Vector2f tLeftBottom = new Vector2f(tileLeft, tileBottom);
            Vector2f tLeftTop = new Vector2f(tileLeft, tileTop);
            Vector2f tRightTop = new Vector2f(tileRight, tileTop);
            Vector2f tRightBottom = new Vector2f(tileRight, tileBottom);

            switch (col)
            {
              case CollisionFull:
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tRightTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightBottom));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tLeftBottom));

                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftBottom - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tLeftTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tRightBottom - mov));
                break;

              case CollisionNorthEast:
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tRightTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightBottom));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tLeftTop));

                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tLeftTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tRightBottom - mov));
                break;

              case CollisionNorthWest:
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tRightTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tLeftBottom));

                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftBottom - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tLeftTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightTop - mov));
                break;

              case CollisionSouthEast:
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tRightTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightBottom));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tLeftBottom));

                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftBottom - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightTop, tRightTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tRightBottom - mov));
                break;

              case CollisionSouthWest:
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftTop));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tRightBottom));
                tileLines.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tLeftBottom));

                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftBottom, tLeftBottom - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tLeftTop, tLeftTop - mov));
                tileVectors.Add(new Tuple<Vector2f, Vector2f>(tRightBottom, tRightBottom - mov));
                break;

              default:
                throw new InvalidDataException("Unknown tile collision type: " + col);
            }

            foreach (var boxVec in boxVectors)
            {
              foreach (var tileLine in tileLines)
              {
                Vector2f? p = Intersections.LineSegmentLineSegment(boxVec.Item1, boxVec.Item2, tileLine.Item1, tileLine.Item2);
                if (p.HasValue)
                {
                  Vector2f dif = p.Value - boxVec.Item1;
                  result.X = BasicMath.SignedMin(result.X, dif.X);
                  result.Y = BasicMath.SignedMin(result.Y, dif.Y);
                }
              }
            }

            foreach (var tileVec in tileVectors)
            {
              foreach (var boxLine in boxLines)
              {
                Vector2f? p = Intersections.LineSegmentLineSegment(tileVec.Item1, tileVec.Item2, boxLine.Item1, boxLine.Item2);
                if (p.HasValue)
                {
                  Vector2f dif = p.Value - tileVec.Item1;
                  result.X = Math.Min(result.X, dif.X);
                  result.Y = Math.Min(result.Y, dif.Y);
                }
              }
            }

          }
        }
      }

      Vector2f e = new Vector2f(0.001f, 0.001f);
      return result - (e * VectorMath.Sign(mov));
    }

  }
}
