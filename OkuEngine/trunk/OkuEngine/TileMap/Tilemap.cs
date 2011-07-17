using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class Tilemap
  {
    //Constants to determine the collision shape of tiles
    private const byte TILE_COLLISION_NONE = 0;
    private const byte TILE_COLLISION_FULL = 1;
    private const byte TILE_COLLISION_LEFT_TOP = 2;
    private const byte TILE_COLLISION_RIGHT_TOP = 3;
    private const byte TILE_COLLISION_RIGHT_BOTTOM = 4;
    private const byte TILE_COLLISION_LEFT_BOTTOM = 5;

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

    public Vector Origin
    {
      get { return _origin; }
      set { _origin = value; }
    }

    public Tile this[int x, int y]
    {
      get { return _tiles[x, y]; }
      set { _tiles[x, y] = value; }
    }

    public List<ImageContent> TileImages
    {
      get { return _tileImages; }
      set { _tileImages = value; }
    }

    public Vector GetIntersection(LineSegment line)
    {
      int vx = 0;
      int vy = 0;

      Vector lineOrgMapPixelSpace = new Vector();

      float mapLeft = _origin.X;
      float mapRight = mapLeft + _mapWidth;
      float mapTop = _origin.Y;
      float mapBottom = mapTop + _mapHeight;

      if (line.X1 >= mapLeft && line.X1 < mapRight &&
        line.Y1 >= mapTop && line.Y1 < mapBottom)
      {
        lineOrgMapPixelSpace.X = line.X1 - mapLeft;
        lineOrgMapPixelSpace.Y = line.Y1 - mapTop;
      }
      else
      {
        float t = 0;
        if (Intersections.LineSegmentAABB(line.X1, line.Y1, line.X2, line.Y2, mapLeft, mapRight, mapTop, mapBottom, out t, float.MaxValue))
        {
          Vector p = line.GetPointAt(t);
          lineOrgMapPixelSpace.X = p.X - mapLeft;
          lineOrgMapPixelSpace.Y = p.Y - mapTop;
        }
        else
          return null; //Ray does not hit voxelspace
      }

      Vector lineDir = new Vector(line.X2 - line.X1, line.Y2 - line.Y1);
      lineDir.Normalize();

      vx = (int)(lineOrgMapPixelSpace.X / _tileSize);
      vy = (int)(lineOrgMapPixelSpace.Y / _tileSize);

      int stepX = Math.Sign(lineDir.X);
      int stepY = Math.Sign(lineDir.Y);

      int outX = stepX < 0.0 ? -1 : _tiles.GetLength(0);
      int outY = stepY < 0.0 ? -1 : _tiles.GetLength(1);

      float tMaxX = lineDir.X != 0.0f ? (((vx + (stepX < 0 ? 0 : 1)) * _tileSize) - lineOrgMapPixelSpace.X) / lineDir.X : float.PositiveInfinity;
      float tMaxY = lineDir.Y != 0.0f ? (((vy + (stepY < 0 ? 0 : 1)) * _tileSize) - lineOrgMapPixelSpace.Y) / lineDir.Y : float.PositiveInfinity;

      float tDeltaX = lineDir.X != 0.0f ? Math.Abs(_tileSize / lineDir.X) : 0.0f;
      float tDeltaY = lineDir.Y != 0.0f ? Math.Abs(_tileSize / lineDir.Y) : 0.0f;

      //Precalculate line position in tile map tile space
      LineSegment lineMapTileSpace = new LineSegment(
        (line.X1 - mapLeft) / _tileSize,
        (line.Y1 - mapTop) / _tileSize,
        (line.X2 - mapLeft) / _tileSize,
        (line.Y2 - mapTop) / _tileSize
      );

      List<LineSegment> shape = null;
      while (true)
      {
        shape = _bounds[_tiles[vx, vy].Collision];

        //Compute line segment in local tile tile space
        LineSegment lineTileTileSpace = new LineSegment(
            lineMapTileSpace.X1 - vx,
            lineMapTileSpace.Y1 - vy,
            lineMapTileSpace.X2 - vx,
            lineMapTileSpace.Y2 - vy
          );

        if (shape != null && shape.Count > 0)
        {
          float minT = float.MaxValue;
          bool intersects = false;
          foreach (LineSegment shapeSegment in shape)
          {
            float t = 0;
            if (Intersections.LineSegments(lineTileTileSpace, shapeSegment, out t, minT))
            {
              minT = t;
              intersects = true;
            }
          }

          if (intersects)
          {
            Vector intersection = line.GetPointAt(minT);

            //This test is not needed for a tilemap. It is only needed in space partitioning grids.
            /*int ix = (int)((intersection.X - mapLeft) / _tileSize);
            int iy = (int)((intersection.Y - mapTop) / _tileSize);

            if (ix == vx && iy == vy)*/
              return intersection;
          }
        }

        if (tMaxX < tMaxY)
        {
          vx = vx + stepX;
          if (vx == outX)
            return null;
          tMaxX = tMaxX + tDeltaX;
        }
        else
        {
          vy = vy + stepY;
          if (vy == outY)
            return null;
          tMaxY = tMaxY + tDeltaY;
        }
      }
    }

    public void Draw()
    {
      for (int y = 0; y < _tiles.GetLength(1); y++)
      {
        for (int x = 0; x < _tiles.GetLength(0); x++)
        {
          Tile tile = _tiles[x, y];
          if (tile.Collision > TILE_COLLISION_NONE)
          {
            Vector position = new Vector((x * _tileSize) + _origin.X + (_tileSize / 2.0f), (y * _tileSize) + _origin.Y + (_tileSize / 2.0f));
            OkuDrivers.Renderer.DrawImage(_tileImages[tile.Image], position);
          }
        }
      }
    }

  }
}
