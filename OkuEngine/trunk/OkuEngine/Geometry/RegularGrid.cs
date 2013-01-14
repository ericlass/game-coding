using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Geometry
{
  /// <summary>
  /// Defines a regular grid that can be used to partition space into quadratic cells.
  /// </summary>
  public class RegularGrid
  {
    private Vector2f _offset = Vector2f.Zero;
    private float _width = 0.0f;
    private float _height = 0.0f;
    private float _cellSize = 0.0f;
    private bool _centered = false;

    /// <summary>
    /// Creates a new regular grid with the given width, height and cell size.
    /// </summary>
    /// <param name="width">The width of the grid.</param>
    /// <param name="height">The height of the grid.</param>
    /// <param name="cellSize">The size (width and height) of the indivudual cells.</param>
    public RegularGrid(float width, float height, float cellSize)
    {
      _width = width;
      _height = height;
      _cellSize = cellSize;
    }

    /// <summary>
    /// Gets or sets the offest of the origin of the grid.
    /// </summary>
    public Vector2f Offset
    {
      get { return _offset; }
      set { _offset = value; }
    }

    /// <summary>
    /// Gets or sets the width of the grid.
    /// </summary>
    public float Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Gets or sets the height of the grid.
    /// </summary>
    public float Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Gets or sets the size of the individual grid cells.
    /// </summary>
    public float CellSize
    {
      get { return _cellSize; }
      set { _cellSize = value; }
    }

    /// <summary>
    /// Gets or sets if the origin of the grid is centered or not.
    /// </summary>
    public bool Centered
    {
      get { return _centered; }
      set { _centered = value; }
    }

    /// <summary>
    /// Gets how many cells the grid has vertically.
    /// </summary>
    public int NumVerticalCells
    {
      get { return (int)Math.Ceiling(_width / _cellSize); }
    }

    /// <summary>
    /// Gets how many cells the grid has horizontally.
    /// </summary>
    public int NumHorizontalCells
    {
      get { return (int)Math.Ceiling(_height / _cellSize); }
    }

    /// <summary>
    /// Gets the left boundary of the grid.
    /// </summary>
    public float Left
    {
      get
      {
        if (_centered)
          return _offset.X - (_width * 0.5f);
        else
          return _offset.X;
      }
    }

    /// <summary>
    /// Gets the right boundary of the grid.
    /// </summary>
    public float Right
    {
      get { return Left + _width; }
    }

    /// <summary>
    /// Gets the bottom boundary of the grid.
    /// </summary>
    public float Bottom
    {
      get
      {
        if (_centered)
          return _offset.Y - (_height * 0.5f);
        else
          return _offset.Y;
      }
    }

    /// <summary>
    /// Gets the top boundary of the grid.
    /// </summary>
    public float Top
    {
      get { return Bottom + _height; }
    }

    /// <summary>
    /// Checks if the given point is inside of the grid.
    /// </summary>
    /// <param name="point">The point to be checked.</param>
    /// <returns>True if the point is inside, else false.</returns>
    public bool IsInside(Vector2f point)
    {
      return Intersections.PointInAABB(point, Left, Bottom, Right, Top);
    }

    /// <summary>
    /// Checks if the given point is inside of the grid.
    /// </summary>
    /// <param name="x">The x coordinate of the point.</param>
    /// <param name="y">The y coordinate of the point.</param>
    /// <returns>True if the point is inside, else false.</returns>
    public bool IsInside(float x, float y)
    {
      return Intersections.PointInAABB(x, y, Left, Bottom, Right, Top);
    }

    public Vector2i GetMinCell()
    {
      int x, y;
      GetCellOf(Left, Bottom, out x, out y);
      return new Vector2i(x, y);
    }

    public Vector2i GetMaxCell()
    {
      int x, y;
      GetCellOf(Right, Top, out x, out y);
      return new Vector2i(x, y);
    }

    /// <summary>
    /// Gets the bounds of the cell with the given coordinates.
    /// </summary>
    /// <param name="x">The x index of the cell.</param>
    /// <param name="y">The y index of the cell.</param>
    /// <param name="clip">If the grid size is not a multiple of the cell size, true clips the cells to the grid size.</param>
    /// <param name="bounds">The bounds of the cell are returned here.</param>
    /// <returns>True if the given cell is inside of the grid, else false.</returns>
    public bool GetCellBounds(int x, int y, bool clip, out AABB bounds)
    {
      float left = _offset.X + (x * _cellSize);
      float right = left + _cellSize;

      float bottom = _offset.Y + (y * _cellSize);
      float top = bottom + _cellSize;

      if (clip)
      {
        right = Math.Min(right, Left + _width);
        top = Math.Min(top, Bottom + _height);
      }

      bounds = new AABB(left, bottom, right - left, top - bottom);

      //TODO: return false if x and y define a cell that is outside of the grid.
      return true;
    }

    /// <summary>
    /// Gets the cell of the given point.
    /// </summary>
    /// <param name="point">The point to get the cell for.</param>
    /// <param name="x">The x index of the cell is returned here.</param>
    /// <param name="y">The y index of the cell is returned here.</param>
    /// <returns>True if the point is within the grid, else false.</returns>
    public bool GetCellOf(Vector2f point, out int x, out int y)
    {
      x = (int)((point.X - _offset.X) / _cellSize);
      y = (int)((point.Y - _offset.Y) / _cellSize);

      return IsInside(point);
    }

    /// <summary>
    /// Gets the cell of the given point.
    /// </summary>
    /// <param name="px">The x coordinate of the point.</param>
    /// <param name="py">The y coordinate of the point.</param>
    /// <param name="x">The x index of the cell is returned here.</param>
    /// <param name="y">The y index of the cell is returned here.</param>
    /// <returns>True if the point is within the grid, else false.</returns>
    public bool GetCellOf(float px, float py, out int x, out int y)
    {
      x = (int)((px - _offset.X) / _cellSize);
      y = (int)((py - _offset.Y) / _cellSize);

      return IsInside(x, y);
    }

    /// <summary>
    /// Calucates the boundary cells the given aabb intersects.
    /// </summary>
    /// <param name="box">The aabb to check.</param>
    /// <param name="min">The minimum cell indices (left, bottom) are returned here.</param>
    /// <param name="max">The maximum cell indices (right, top) are returned here.</param>
    public void GetCellsIntersecting(AABB box, ref Vector2i min, ref Vector2i max)
    {
      int x, y;

      GetCellOf(box.Min, out x, out y);
      min.X = x;
      min.Y = y;

      GetCellOf(box.Max, out x, out y);
      max.X = x;
      max.Y = y;
    }

    /// <summary>
    /// Traverses the line given by start and end through the grid.
    /// </summary>
    /// <param name="start">The start of the line.</param>
    /// <param name="end">The end of the line.</param>
    /// <returns>A list of indices of all cell the line crosses.</returns>
    public List<Vector2i> GetCellsOnLine(Vector2f start, Vector2f end)
    {
      return GetCellsOnLine(start.X, start.Y, end.X, end.Y);
    }

    /// <summary>
    /// Traverses the line given by start and end through the grid.
    /// </summary>
    /// <param name="x1">The x coordinate of the start point of the line.</param>
    /// <param name="y1">The y coordinate of the start point of the line.</param>
    /// <param name="x2">The x coordinate of the end point of the line.</param>
    /// <param name="y2">The y coordinate of the end point of the line.</param>
    /// <returns>A list of indices of all cell the line crosses.</returns>
    public List<Vector2i> GetCellsOnLine(float x1, float y1, float x2, float y2)
    {
      int cx, cy;
      GetCellOf(x1, y1, out cx, out cy);

      AABB cellBounds;
      GetCellBounds(cx, cy, false, out cellBounds);

      float dirX = x2 - x1;
      float dirY = y2 - y1;

      int stepX = Math.Sign(dirX);
      int stepY = Math.Sign(dirY);

      float tMaxX = dirX == 0.0f ? float.PositiveInfinity : Math.Abs((stepX < 0 ? cellBounds.Min.X : cellBounds.Max.X) - x1) / dirX;
      float tMaxY = dirY == 0.0f ? float.PositiveInfinity : Math.Abs((stepY < 0 ? cellBounds.Min.Y : cellBounds.Max.Y) - y1) / dirY;

      float tDeltaX = dirX == 0.0 ? 0.0f : Math.Abs(_cellSize / dirX);
      float tDeltaY = dirY == 0.0 ? 0.0f : Math.Abs(_cellSize / dirY);

      List<Vector2i> result = new List<Vector2i>();
      while (true)
      {
        result.Add(new Vector2i(cx, cy));

        if (tMaxX < tMaxY)
        {
          tMaxX = tMaxX + tDeltaX;
          if (tMaxX > 1.0f) //Exit when end of line has been reached.
            break;
          cx = cx + stepX;
        }
        else
        {
          tMaxY = tMaxY + tDeltaY;
          if (tMaxY > 1.0f) //Exit when end of line has been reached.
            break;
          cy = cy + stepY;
        }
      }

      return result;
    }

  }
}
