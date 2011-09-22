using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class Tilemap
  {
    //Constants to determine the collision shape of tiles
    public const byte TILE_COLLISION_NONE = 0;
    public const byte TILE_COLLISION_FULL = 1;
    public const byte TILE_COLLISION_LEFT_TOP = 2;
    public const byte TILE_COLLISION_RIGHT_TOP = 3;
    public const byte TILE_COLLISION_RIGHT_BOTTOM = 4;
    public const byte TILE_COLLISION_LEFT_BOTTOM = 5;

    //List that contains a list of line segments for each collision shape that can be used to find the collision point of a line segment with a tile.
    private List<List<LineSegment>> _bounds = new List<List<LineSegment>>()
    {
      new List<LineSegment>() {  },
      new List<LineSegment>() { new LineSegment(0, 0, 1, 0), new LineSegment(1, 0, 1, 1), new LineSegment(1, 1, 0, 1), new LineSegment(0, 1, 0, 0)},
      new List<LineSegment>() { new LineSegment(0, 0, 1, 0), new LineSegment(1, 0, 0, 1), new LineSegment(0, 1, 0, 0) },
      new List<LineSegment>() { new LineSegment(0, 0, 1, 0), new LineSegment(1, 0, 1, 1), new LineSegment(1, 1, 0, 0) },
      new List<LineSegment>() { new LineSegment(0, 1, 1, 0), new LineSegment(1, 0, 1, 1), new LineSegment(1, 1, 0, 1) },
      new List<LineSegment>() { new LineSegment(0, 0, 1, 1), new LineSegment(1, 1, 0, 1), new LineSegment(0, 1, 0, 0) },
    };

    private List<Vector[]> _bounds2 = new List<Vector[]>()
    {
      new Vector[] { },
      new Vector[] { new Vector(0, 0), new Vector(1, 0), new Vector(1, 1), new Vector(0, 1) },
      new Vector[] { new Vector(0, 0), new Vector(1, 0), new Vector(0, 1) },
      new Vector[] { new Vector(0, 0), new Vector(1, 0), new Vector(1, 1) },
      new Vector[] { new Vector(0, 1), new Vector(1, 0), new Vector(1, 1) },
      new Vector[] { new Vector(0, 0), new Vector(1, 1), new Vector(0, 1) }
    };

    //The main tiles
    private Tile[,] _tiles = null;

    //The tile images
    private List<ImageContent> _tileImages = new List<ImageContent>();
    
    private int _tileSize = 32;
    private int _mapWidth = 0;
    private int _mapHeight = 0;
    private Vector _origin = new Vector();

    /// <summary>
    /// Create new tile map with the given parameters.
    /// </summary>
    /// <param name="width">The number of tiles the tile map will span horizontaly.</param>
    /// <param name="height">The number of tiles the tile map will span verticaly.</param>
    /// <param name="tileSize">The size of tiles in pixels. The tiles are always quadratic.</param>
    public Tilemap(int width, int height, int tileSize)
    {
      _tiles = new Tile[width, height];
      _tileSize = tileSize;
      _mapWidth = width * tileSize;
      _mapHeight = height * tileSize;
    }

    /// <summary>
    /// Gets or sets the origin of the tile map. This is the top left corner of the tile at (0,0).
    /// </summary>
    public Vector Origin
    {
      get { return _origin; }
      set { _origin = value; }
    }

    /// <summary>
    /// Gets or sets the tile at a specific location in the tile map.
    /// </summary>
    /// <param name="x">The x coordinate of the tile.</param>
    /// <param name="y">The y coordinate of the tile. </param>
    /// <returns>The tile at the given position.</returns>
    public Tile this[int x, int y]
    {
      get { return _tiles[x, y]; }
      set { _tiles[x, y] = value; }
    }

    /// <summary>
    /// Gets or set the images that are used to draw the tile map. The indices of the
    /// images in the list must match the Image value of the tiles.
    /// </summary>
    public List<ImageContent> TileImages
    {
      get { return _tileImages; }
      set { _tileImages = value; }
    }

    /// <summary>
    /// Calculates the first intersection of the line segment with a collision tile.
    /// </summary>
    /// <param name="p1">The start point of the line segment.</param>
    /// <param name="p2">The end point of the line segment.</param>
    /// <param name="ip">The intersection point in world space coordinates is returned in this parameter.</param>
    /// <returns>If there is an intersection, true is returned. Otherwise false.</returns>
    public bool GetIntersection(Vector p1, Vector p2, out Vector ip)
    {
      ip = Vector.Zero;

      int vx = 0;
      int vy = 0;

      //line origin in tile map pixel space
      Vector lineOrgMapPixelSpace = new Vector();

      //Tile map pixel boundaries
      float mapLeft = _origin.X;
      float mapRight = mapLeft + _mapWidth;
      float mapTop = _origin.Y;
      float mapBottom = mapTop + _mapHeight;

      if (p1.X >= mapLeft && p1.X < mapRight &&
        p1.Y >= mapTop && p1.Y < mapBottom)
      {
        //If line origin is inside tilemap
        lineOrgMapPixelSpace.X = p1.X - mapLeft;
        lineOrgMapPixelSpace.Y = p1.Y - mapTop;
      }
      else
      {
        //If line oprigin is outside of tilemap, get first intersection with tilemap
        float t = 0;
        if (Intersections.LineSegmentAABB(p1.X, p1.Y, p2.X, p2.Y, mapLeft, mapRight, mapTop, mapBottom, out t, float.MaxValue))
        {
          Vector p = OkuMath.InterpolateLinear(p1, p2, t);
          lineOrgMapPixelSpace.X = p.X - mapLeft;
          lineOrgMapPixelSpace.Y = p.Y - mapTop;
        }
        else
          return false; //Ray does not hit tilemap
      }

      //Calculate line direction
      Vector lineDir = p2 - p1;
      lineDir.Normalize();

      //Calculate tile coordinates of line origin
      vx = (int)(lineOrgMapPixelSpace.X / _tileSize);
      vy = (int)(lineOrgMapPixelSpace.Y / _tileSize);

      //Steps to do in both directions
      int stepX = Math.Sign(lineDir.X);
      int stepY = Math.Sign(lineDir.Y);

      //Calculate tile indices that are just out of the tile map
      int outX = stepX < 0.0 ? -1 : _tiles.GetLength(0);
      int outY = stepY < 0.0 ? -1 : _tiles.GetLength(1);

      float tMaxX = lineDir.X != 0.0f ? (((vx + (stepX < 0 ? 0 : 1)) * _tileSize) - lineOrgMapPixelSpace.X) / lineDir.X : float.PositiveInfinity;
      float tMaxY = lineDir.Y != 0.0f ? (((vy + (stepY < 0 ? 0 : 1)) * _tileSize) - lineOrgMapPixelSpace.Y) / lineDir.Y : float.PositiveInfinity;

      float tDeltaX = lineDir.X != 0.0f ? Math.Abs(_tileSize / lineDir.X) : 0.0f;
      float tDeltaY = lineDir.Y != 0.0f ? Math.Abs(_tileSize / lineDir.Y) : 0.0f;

      //Precalculate line position in tile map tile space
      Vector lineMapTileSpaceStart = new Vector((p1.X - mapLeft) / _tileSize, (p1.Y - mapTop) / _tileSize);
      Vector lineMapTileSpaceEnd = new Vector((p2.X - mapLeft) / _tileSize, (p2.Y - mapTop) / _tileSize);

      Vector lineTileTileSpaceStart = new Vector();
      Vector lineTileTileSpaceEnd = new Vector();

      Vector[] shape = null;
      while (true)
      {
        shape = _bounds2[_tiles[vx, vy].Collision];

        //Compute line segment in local tile tile space
        lineTileTileSpaceStart.X = lineMapTileSpaceStart.X - vx;
        lineTileTileSpaceStart.Y = lineMapTileSpaceStart.Y - vy;
        lineTileTileSpaceEnd.X = lineMapTileSpaceEnd.X - vx;
        lineTileTileSpaceEnd.Y = lineMapTileSpaceEnd.Y - vy;

        //Check if shape and line segment do intersect
        if (shape != null && shape.Length > 0)
        {
          float minT = float.MaxValue;
          bool intersects = false;
          for (int i = 0; i < shape.Length; i++)
          {
            int j = (i + 1) % shape.Length;
            float t = 0;
            if (Intersections.LineSegments(lineTileTileSpaceStart, lineTileTileSpaceEnd, shape[i], shape[j], out t, minT))
            {
              minT = t;
              intersects = true;
            }
          }

          if (intersects)
          {
            ip = OkuMath.InterpolateLinear(p1, p2, minT);
            return true;
          }
        }

        //Traverse through tile map
        if (tMaxX < tMaxY)
        {
          vx = vx + stepX;
          if (vx == outX)
            return false;
          tMaxX = tMaxX + tDeltaX;
        }
        else
        {
          vy = vy + stepY;
          if (vy == outY)
            return false;
          tMaxY = tMaxY + tDeltaY;
        }
      }
    }

    /// <summary>
    /// Draws the tilemap at the configured origin using the configured tile images.
    /// Images with collision type 0 (No collision) are not drawn! If there is no image
    /// for a tile, it is not drawn.
    /// </summary>
    public void Draw()
    {
      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          Tile tile = _tiles[x, y];
          if (tile.Collision > TILE_COLLISION_NONE && (tile.Image >= 0 && tile.Image < _tileImages.Count))
          {
            Vector position = new Vector((x * _tileSize) + _origin.X + (_tileSize / 2.0f), (y * _tileSize) + _origin.Y + (_tileSize / 2.0f));
            OkuDrivers.Renderer.DrawImage(_tileImages[tile.Image], position);
          }
        }
      }
    }

    public void SaveToFile(string filename)
    {
      StreamWriter writer = new StreamWriter(filename);
      try
      {
        writer.Write(ToString());
        writer.Flush();
      }
      finally
      {
        writer.Close();
        writer.Dispose();
      }      
    }

    public void LoadFromFile(string filename)
    {
      StreamReader reader = new StreamReader(filename);

      try
      {
        string line = reader.ReadLine();

        int width = 0;
        int height = 0;
        string[] dimensions = line.Split('x');
        if (dimensions.Length == 2)
        {
          if (!int.TryParse(dimensions[0], out width) || !int.TryParse(dimensions[1], out height))
            throw new FormatException("The tilemap size '" + line + "' is not in a valid format. Example: 16x16");
        }
        else
          throw new FormatException("File '" + filename + "' is not a valid OkuEngine tilemap file. It does not contain the size information in the first line. Example: 16x16");

        _tiles = new Tile[width, height];

        line = reader.ReadLine();
        int x = 0;
        int y = 0;
        while (line != null && line.Trim().Length > 0)
        {
          string[] tiles = line.Split(';');

          for (int i = 0; i < tiles.Length; i++)
          {
            string[] tileInfos = tiles[i].Split(':');
            if (tileInfos.Length == 2)
            {
              byte tileType = 0;
              ushort tileImage = 0;
              if (!byte.TryParse(tileInfos[0], out tileType) || !ushort.TryParse(tileInfos[1], out tileImage))
                throw new FormatException("The tilemap line '" + line + "' has a wrong format. Please check the line manualy and correct any errors.");
              _tiles[x, y] = new Tile(tileType, tileImage);
            }
            else
              throw new FormatException("File '" + filename + "' is not a valid OkuEngine tilemap file. It does not contain the size information in the first line. Example: 16x16");

            x++;
          }

          line = reader.ReadLine();
          x = 0;
          y++;
        }
      }
      finally
      {
        reader.Close();
      }
    }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();

      builder.Append(_tiles.GetLength(0));
      builder.Append('x');
      builder.Append(_tiles.GetLength(1));
      builder.Append(Environment.NewLine);

      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          Tile tile = _tiles[x, y];
          if (x > 0)
            builder.Append(';');
          builder.Append(tile.Collision);
          builder.Append(':');
          builder.Append(tile.Image);
        }
        builder.Append(Environment.NewLine);
      }

      return builder.ToString();
    }

  }
}
