using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using OkuMath;

namespace OkuEngine.Assets
{
  public class TilemapAsset
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

    private int _width = 4;
    private int _height = 4;
    private int _tileWidth = 16;
    private int _tileHeight = 16;
    private byte[] _collision = null;
    private List<ushort[]> _layers = new List<ushort[]>();

    public event Action OnModify;

    /// <summary>
    /// Creates a new tilemap component with the given width, height and number of layers.
    /// </summary>
    /// <param name="width">The width of the tile map (tiles).</param>
    /// <param name="height">The height of the tile map (tiles).</param>
    /// <param name="layers">The number of graphical layers.</param>
    public TilemapAsset(int width, int height, int layers)
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
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="tileWidth">The width of a single tile.</param>
    /// <param name="tileHeight">The height of a single tile.</param>
    /// <param name="collision">The collision layer.</param>
    /// <param name="layers">The graphical layer.</param>
    private TilemapAsset(int width, int height, int tileWidth, int tileHeight, byte[] collision, List<ushort[]> layers)
    {
      _width = width;
      _height = height;
      _collision = collision;
      _layers = layers;
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
      OnModify?.Invoke();
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
      OnModify?.Invoke();
    }

    public Vector2f GetMaxMovementSAT(Vector2f min, Vector2f max)
    {
      //Calculate tile area that sweeped box touches
      Vector2i tileLeftBottom = GridMath.CellOfPoint(min, _tileWidth);
      Vector2i tileRightTop = GridMath.CellOfPoint(max, _tileWidth);

      tileLeftBottom.X = BasicMath.Clamp(tileLeftBottom.X, 0, _width - 1);
      tileLeftBottom.Y = BasicMath.Clamp(tileLeftBottom.Y, 0, _height - 1);
      tileRightTop.X = BasicMath.Clamp(tileRightTop.X, 0, _width - 1);
      tileRightTop.Y = BasicMath.Clamp(tileRightTop.Y, 0, _height - 1);

      //Calculate corner points of box
      Vector2f leftBottom = min;
      Vector2f leftTop = new Vector2f(min.X, max.Y);
      Vector2f rightTop = max;
      Vector2f rightBottom = new Vector2f(max.X, min.Y);

      //Calculate line segement of box
      var boxPoints = new Vector2f[]
      {
        leftBottom,
        leftTop,
        rightTop,
        rightBottom
      };

      var tilePoints = new List<Vector2f>(4);
      bool hasCollision = false;

      //Vector2f result = new Vector2f(float.MaxValue, float.MaxValue);
      var result = Vector2f.Zero;

      //Loop through all tiles and check for collisions
      for (int ty = tileLeftBottom.Y; ty <= tileRightTop.Y; ty++)
      {
        for (int tx = tileLeftBottom.X; tx <= tileRightTop.X; tx++)
        {
          byte col = GetCollision(tx, ty);

          if (col > CollisionNone)
          {
            tilePoints.Clear();

            //Tile boundaries
            float tileLeft = tx * _tileWidth;
            float tileRight = tileLeft + _tileWidth;
            float tileBottom = ty * _tileHeight;
            float tileTop = tileBottom + _tileHeight;

            //Tile corner points
            Vector2f tLeftBottom = new Vector2f(tileLeft, tileBottom);
            Vector2f tLeftTop = new Vector2f(tileLeft, tileTop);
            Vector2f tRightTop = new Vector2f(tileRight, tileTop);
            Vector2f tRightBottom = new Vector2f(tileRight, tileBottom);

            //Create tile lines and point vectors depending on tile type
            switch (col)
            {
              case CollisionFull:
                tilePoints.Add(tLeftBottom);
                tilePoints.Add(tLeftTop);
                tilePoints.Add(tRightTop);
                tilePoints.Add(tRightBottom);
                break;

              case CollisionNorthEast:
                tilePoints.Add(tLeftTop);
                tilePoints.Add(tRightTop);
                tilePoints.Add(tRightBottom);
                break;

              case CollisionNorthWest:
                tilePoints.Add(tLeftBottom);
                tilePoints.Add(tLeftTop);
                tilePoints.Add(tRightTop);
                break;

              case CollisionSouthEast:
                tilePoints.Add(tLeftBottom);
                tilePoints.Add(tRightTop);
                tilePoints.Add(tRightBottom);
                break;

              case CollisionSouthWest:
                tilePoints.Add(tLeftBottom);
                tilePoints.Add(tLeftTop);
                tilePoints.Add(tRightBottom);
                break;

              default:
                throw new InvalidDataException("Unknown tile collision type: " + col);
            }

            Vector2f mtd;
            if (Overlaps.PolygonPolygon(boxPoints, tilePoints.ToArray(), out mtd))
            {
              result += mtd;
              hasCollision = true;
            }

          }
        }
      }

      if (hasCollision)
        return result * 1.01f; //If there was a collision, move box a little away from tile to avoid problems
      else
        return Vector2f.Zero;
    }

    /// <summary>
    /// Loads a tile map from a Tiled TMX file. Supports loading of CSV encoded layers.
    /// The lowest layer is considered to be the collision layer. It should only contain tile ids from 0 - 5.
    /// </summary>
    /// <param name="stream">The stream containing the TMX file data.</param>
    /// <param name="imageLoader">A callback that can resolve the relative image paths in TMX files.</param>
    /// <returns>The loaded tile map.</returns>
    public static TilemapAsset LoadFromTiledXml(Stream stream, out string tileImagePath)
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
      tileImagePath = src;

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

      return new TilemapAsset(width, height, tileWidth, tileHeight, collisionData, layersData);
    }

    /// <summary>
    /// Saves the tilemap to an OkuEngine-specific, binary tilemap format that is optimized for fast loading and streaming.
    /// </summary>
    /// <param name="stream">The stream to save the tile map to.</param>
    public static TilemapAsset SaveToOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Loads tile map data from an OkuEngine-soecific file format.
    /// </summary>
    /// <param name="stream">The stream to load the data from.</param>
    public static TilemapAsset LoadFromOkuFormat(Stream stream)
    {
      throw new NotImplementedException();
    }

  }
}
