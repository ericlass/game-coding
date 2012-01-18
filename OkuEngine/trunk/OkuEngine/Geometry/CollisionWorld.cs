using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class CollisionWorld
  {
    private Dictionary<int, Vector[]> _statics = new Dictionary<int, Vector[]>();
    private Dictionary<int, Vector[]> _dynamics = new Dictionary<int, Vector[]>();

    private Dictionary<int, Vector> _translations = new Dictionary<int,Vector>();

    private const int _virtualWidth = 1000000;
    private int _cellWidth = 100;
    private Dictionary<long, Dictionary<int, List<int>>> _grid = new Dictionary<long, Dictionary<int, List<int>>>();

    public CollisionWorld()
    {
    }

    private long GetKey(int x, int y)
    {
      return (y * _virtualWidth) + x;
    }

    private Dictionary<int, List<int>> GetLinesAt(int x, int y)
    {
      long key = GetKey(x, y);
      if (_grid.ContainsKey(key))
        return _grid[key];
      else
        return null;
    }

    private void AddLine(int x, int y, int poly, int lineIndex)
    {
      long key = GetKey(x, y);
      if (_grid.ContainsKey(key))
      {
        // Change grid ti contain HashSet instead of list
        //
      }
    }

    public Dictionary<int, HashSet<int>> GetLinesOnLine(Vector start, Vector end)
    {
      int vx = (int)(start.X / _cellWidth);
      int vy = (int)(start.Y / _cellWidth);

      Vector lineDir = end - start;

      int stepX = Math.Sign(lineDir.X);
      int stepY = Math.Sign(lineDir.Y);

      int outX = (int)(end.X / _cellWidth) + stepX;
      int outY = (int)(end.Y / _cellWidth) + stepY;

      float tMaxX = float.PositiveInfinity;
      if (lineDir.X != 0.0f)
        tMaxX = (((vx + stepX < 0 ? 0 : 1) * _cellWidth) - start.X) / lineDir.X;

      float tMaxY = float.PositiveInfinity;
      if (lineDir.Y != 0.0f)
        tMaxY = (((vy + stepY < 0 ? 0 : 1) * _cellWidth) - start.Y) / lineDir.Y;

      float tDeltaX = 0.0f;
      if (lineDir.X != 0.0f)
        tDeltaX = _cellWidth / lineDir.X;

      float tDeltaY = 0.0f;
      if (lineDir.Y != 0.0f)
        tDeltaY = _cellWidth / lineDir.Y;

      Dictionary<int, HashSet<int>> result = new Dictionary<int, HashSet<int>>();

      //Traverse through tile map
      while (true)
      {
        Dictionary<int, List<int>> lines = GetLinesAt(vx, vy);
        if (lines != null)
        {
          foreach (int poly in lines.Keys)
          {
            if (!result.ContainsKey(poly))
              result.Add(poly, new HashSet<int>());

            foreach (int line in lines[poly])
              result[poly].Add(line);
          }
        }

        if (tMaxX < tMaxY)
        {
          vx += stepX;
          if (vx == outX)
            break;
          tMaxX += tDeltaX;
        }
        else
        {
          vy += stepY;
          if (vy == outY)
            break;
          tMaxY += tDeltaY;
        }
      }

      return result;
    }

    public void AddLineToGrid(int poly, int lineIndex, Vector start, Vector end)
    {
      int vx = (int)(start.X / _cellWidth);
      int vy = (int)(start.Y / _cellWidth);

      Vector lineDir = end - start;

      int stepX = Math.Sign(lineDir.X);
      int stepY = Math.Sign(lineDir.Y);

      int outX = (int)(end.X / _cellWidth) + stepX;
      int outY = (int)(end.Y / _cellWidth) + stepY;

      float tMaxX = float.PositiveInfinity;
      if (lineDir.X != 0.0f)
        tMaxX = (((vx + stepX < 0 ? 0 : 1) * _cellWidth) - start.X) / lineDir.X;

      float tMaxY = float.PositiveInfinity;
      if (lineDir.Y != 0.0f)
        tMaxY = (((vy + stepY < 0 ? 0 : 1) * _cellWidth) - start.Y) / lineDir.Y;

      float tDeltaX = 0.0f;
      if (lineDir.X != 0.0f)
        tDeltaX = _cellWidth / lineDir.X;

      float tDeltaY = 0.0f;
      if (lineDir.Y != 0.0f)
        tDeltaY = _cellWidth / lineDir.Y;

      //Traverse through tile map
      while (true)
      {


        if (tMaxX < tMaxY)
        {
          vx += stepX;
          if (vx == outX)
            break;
          tMaxX += tDeltaX;
        }
        else
        {
          vy += stepY;
          if (vy == outY)
            break;
          tMaxY += tDeltaY;
        }
      }
    }

    public int AddStatic(Vector[] polygon)
    {
      int result = KeySequence.NextValue;
      _statics.Add(result, polygon);
      return result;
    }

    public bool RemoveStatic(int id)
    {
      return _statics.Remove(id);
    }

    public int AddDynamic(Vector[] polygon)
    {
      int result = KeySequence.NextValue;
      _dynamics.Add(result, polygon);
      return result;
    }

    public bool RemoveDynamic(int id)
    {
      return _dynamics.Remove(id);
    }

    public void SetTranslation(int id, Vector translation)
    {
      if (_dynamics.ContainsKey(id))
        _translations.Add(id, translation);
      else
        throw new ArgumentException("The id " + id + " is not a dynamic of this world!");
    }

    public void ApplyTranslations()
    {
      //TODO: Calculate collisions

      _translations.Clear();
    }

  }
}
