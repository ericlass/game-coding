using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using OkuMath;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class TilemapComponent : IComponent
  {
    public const byte CollisionNone = 0;
    public const byte CollisionFull = 1;
    public const byte CollisionNorthWest = 2;
    public const byte CollisionNorthEast = 3;
    public const byte CollisionSouthWest = 4;
    public const byte CollisionSouthEast = 5;

    private AssetHandle _tileSetImage = null;
    private int _width = 4;
    private int _height = 4;
    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private byte[] _collision = null;
    private List<ushort[]> _layers = new List<ushort[]>();

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

    /// <summary>
    /// List of texture coordinates for the tiles from the tile sets.
    /// The index in the list is the tile index from the tile set.
    /// Index 0 is always null as 0 measn no tile.
    /// </summary>
    internal List<Vector2f[]> TileTexCoords { get; set; }

    /// <summary>
    /// List of mesh assest for the chunks of the tile map.
    /// Each item in the list is an array of the chunks for a single tile layer.
    /// </summary>
    internal List<AssetHandle[]> ChunkMeshes { get; set; }

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return "tilemap"; }
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

    public IComponent Copy()
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

  }
}
