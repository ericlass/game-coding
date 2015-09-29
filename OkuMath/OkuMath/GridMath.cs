using System;
using System.Collections.Generic;

namespace OkuMath
{
  /// <summary>
  /// Defines functions for regular grids with quadratic cells.
  /// The grid is always assumed to be centered at the world origin.
  /// </summary>
  public static class GridMath
  {
    /// <summary>
    /// Calculates the cell the given point is in.
    /// </summary>
    /// <param name="p">The point.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <returns>The vertical and horizontal cell indexes the point is in.</returns>
    public static Vector2i CellOfPoint(Vector2f p, float cellSize)
    {
      return new Vector2i(
        (int)(p.X / cellSize),
        (int)(p.Y / cellSize)
      );
    }

    /// <summary>
    /// Calculates the cells the AABB defined by min and max touches.
    /// </summary>
    /// <param name="min">The minimum vector of the AABB.</param>
    /// <param name="max">The maximum vector of the AABB.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <returns>A list of all cells the AABB touches.</returns>
    public static Vector2i[] CellsOfAABB(Vector2f min, Vector2f max, float cellSize)
    {
      int left = (int)(min.X / cellSize);
      int right = (int)(max.X / cellSize);
      int top = (int)(max.Y / cellSize);
      int bottom = (int)(min.Y / cellSize);

      Vector2i[] result = new Vector2i[right - left * top - bottom];
      int i = 0;
      for (int x = left; x <= right; x++)
      {
        for (int y = bottom; y <= top; y++)
        {
          result[i] = new Vector2i(x, y);
          i++;
        }
      }

      return result;
    }

    /// <summary>
    /// Calculates which cells the infinite line defined by a and b crosses.
    /// As calculating the cells for an infinite line would take infinite time, you have to specify
    /// the maxT value. It defines how far the method calculates the cells along the line.
    /// You can image the resulting line like this:
    /// -maxT-----a-----b-----+maxT
    /// </summary>
    /// <param name="a">The first point of the line.</param>
    /// <param name="b">The second point of the line.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <param name="maxT">Defines the minimum and maximum t value of the line to check.</param>
    /// <returns>A list of all cells the line crosses.</returns>
    public static Vector2i[] CellsOfLine(Vector2f a, Vector2f b, float cellSize, float maxT)
    {
      Vector2f start = b + ((a - b) * (maxT + 1));
      Vector2f end = a + ((b - a) * (maxT + 1));
      return CellsOfLineSegment(start, end, cellSize);
    }

    /// <summary>
    /// Calculates which cells the infinite ray defined by a and b crosses.
    /// As calculating the cells for an infinite ray would take infinite time, you have to specify
    /// the maxT value. It defines how far the method calculates the cells along the ray.
    /// You can image the resulting line like this:
    /// o-----+maxT
    /// </summary>
    /// <param name="o">The first point of the line.</param>
    /// <param name="d">The second point of the line.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <param name="maxT">Defines the maximum t value of the line to check.</param>
    /// <returns>A list of all cells the line crosses.</returns>
    public static Vector2i[] CellsOfRay(Vector2f o, Vector2f d, float cellSize, float maxT)
    {
      return CellsOfLineSegment(o, d * maxT, cellSize);
    }

    /// <summary>
    /// Calculates which cells line segment defined by a and b crosses.
    /// </summary>
    /// <param name="a">The first point of the line segment.</param>
    /// <param name="b">The second point of the line segment.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <returns>A list of all cells the line crosses.</returns>
    public static Vector2i[] CellsOfLineSegment(Vector2f a, Vector2f b, float cellSize)
    {
      Vector2i startCell = CellOfPoint(a, cellSize);
      Vector2i endCell = CellOfPoint(b, cellSize);

      int x = startCell.X;
      int y = startCell.Y;

      Vector2f delta = b - a;
      int stepX = Math.Sign(delta.X);
      int stepY = Math.Sign(delta.Y);

      float tMaxX;
      if (stepX > 0)
        tMaxX = ((cellSize * (x + 1)) - a.X) / delta.X;
      else
        tMaxX = (a.X - (cellSize * (x))) / delta.X;

      float tMaxY;
      if (stepY > 0)
        tMaxY = ((cellSize * (y + 1)) - a.Y) / delta.Y;
      else
        tMaxY = (a.Y - (cellSize * (y))) / delta.Y;

      float tDeltaX = cellSize / delta.X;
      float tDeltaY = cellSize / delta.Y;

      int numCells = (endCell.X - startCell.X) * (endCell.Y - startCell.Y);
      Vector2i[] result = new Vector2i[numCells];
      int i = 0;
      while (i < numCells)
      {
        if (tMaxX < tMaxY)
        {
          tMaxX += tDeltaX;
          x += stepX;
        }
        else
        {
          tMaxY += tDeltaY;
          y += stepY;
        }
        result[i] = new Vector2i(x, y);
        i++;
      }

      return result;
    }

    /// <summary>
    /// Caculates the cells the triangle defined by a, b and c touches.
    /// </summary>
    /// <param name="a">The first point of the triangle.</param>
    /// <param name="b">The second point of the triangle.</param>
    /// <param name="c">The third point of the triangle.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <returns>A list of all cells the triangle touches.</returns>
    private static Vector2i[] CellsOfTriangle(Vector2f a, Vector2f b, Vector2f c, float cellSize)
    {
      return CellsOfPolygon(new Vector2f[] { a, b, c }, cellSize);
    }

    private static Vector2i[] CellsOfPolygon(Vector2f[] poly, float cellSize)
    {
      //Use Edge-Flag-Algorithm
      throw new NotImplementedException();
    }

    private static Vector2i[] CellsOfCapsule(Vector2f a, Vector2f b, float r, float cellSize)
    {
      //Hard. Ideas:
      // - Raster OBB and two circles
      throw new NotImplementedException();
    }

    /// <summary>
    /// Calculates the cells the circle defined the center c and the radius r touches.
    /// </summary>
    /// <param name="c">The center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <param name="cellSize">The width and height of the grid cells.</param>
    /// <returns>A list of all cells the circle touches.</returns>
    public static Vector2i[] CellsOfCircle(Vector2f c, float r, float cellSize)
    {
      int top = (int)((c.Y + r) / cellSize);
      int bottom = (int)((c.Y - r) / cellSize);

      List<Vector2i> result = new List<Vector2i>();
      float step = 1.0f / (top - bottom);
      for (float v = step * 0.5f; v <= 1.0f; v += step)
      {
        float width = CircleMath.HalfWidthOfCircle(v) * r;

        int left = (int)((c.X - width) / cellSize);
        int right = (int)((c.X + width) / cellSize);

        for (int i = left; i <= right; i++)
        {
          result.Add(new Vector2i(i, top));
          result.Add(new Vector2i(i, bottom));
        }

        top--;
        bottom++;
      }

      return result.ToArray();
    }






  }
}
