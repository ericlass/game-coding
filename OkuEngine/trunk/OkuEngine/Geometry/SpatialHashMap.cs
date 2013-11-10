﻿using System;
using System.Collections.Generic;

namespace OkuEngine
{
  /// <summary>
  /// Defines a spatial hash map that implementes spatial hashing
  /// in a regular grid which can be used to speed up collision
  /// calculations.
  /// </summary>
  /// <typeparam name="T">The type of entity in the map.</typeparam>
  public class SpatialHashMap<T>
  {
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;
    private float _factor = 0;
    private int _width = 0;
    
    private List<T>[] _table = null;
    private Dictionary<T, List<int>> _objects = new Dictionary<T, List<int>>();
    
    /// <summary>
    /// Creates a new spatial hash map with the given parameters.
    /// </summary>
    /// <param name="left">The left boundary of the map.</param>
    /// <param name="right">The right boundary of the map.</param>
    /// <param name="top">The top boundary of the map.</param>
    /// <param name="bottom">The bottom boundary of the map.</param>
    /// <param name="cellSize">The size of the rectangular cells of the grid.</param>
    public SpatialHashMap(int left, int right, int top, int bottom, int cellSize)
    {
      //Calculate factor to speed up further processing
      _factor = 1.0f / cellSize;
      
      int _width = OkuMath.Ceiling((right - left + 1) * _factor);
      int height = OkuMath.Ceiling((top - bottom + 1) * _factor);
      
      _left = (int)(left * _factor) * cellSize;
      _right = _left + (_width * cellSize) - 1;
      
      _bottom = (int)(bottom * _factor) * cellSize;
      _top = _bottom + (height * cellSize) - 1;
      
      //Initialize hash table
      _table = new List<T>[_width * height];
      for (int i = 0; i < _table.Length; i++)
        _table[i] = new List<T>();
    }
    
    /// <summary>
    /// Gets a hash value for the given coordinates.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <returns>The hash value for the coordinate.</returns>
    public int GetHash(int x, int y)
    {
      return OkuMath.Floor((x - _left) * _factor) + OkuMath.Floor((y - _bottom) * _factor) * _width;
    }
    
    /* LUA test code
    min = -2
    max = 6
    cellsize = 3
    factor = 1 / cellsize
    width = math.ceil((max - min + 1) / cellsize)
    print('width: ' .. width)

    realmin = math.floor(min / cellsize) * cellsize
    realmax = realmin + (width * cellsize) - 1

    print('realmin: ' .. realmin)
    print('realmax: ' .. realmax)

    for y = realmax, realmin, -1 do
      out = '';
      for x = realmin, realmax, 1 do
        hash = math.floor((x - realmin) * factor) + (math.floor((y - realmin) * factor) * width)
        out = out .. '(' .. hash .. ')'
      end
      print(out)
    end
    */
    
  }
}
