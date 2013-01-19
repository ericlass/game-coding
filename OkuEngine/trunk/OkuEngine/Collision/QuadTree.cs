using System;
using System.Collections.Generic;

namespace OkuEngine.Collision
{
  /// <summary>
  /// Description of QuadTreeCell.
  /// </summary>
  public class QuadTree
  {
    private const int MaxLevels = 8;
    private const int SplitThreshold = 5;
    
    private AABB _area = new AABB();
    private QuadTree _parent = null;
    private QuadTree[] _children = null;
    private int _level = 0;
    private HashSet<ICollidable> _bodies = new HashSet<ICollidable>();
    private HashSet<ICollidable> _buffer = new HashSet<ICollidable>();
    
    public AABB Area
    {
      get { return _area; }
    }

    /// <summary>
    /// Used to construct the top level quad tree cell.
    /// </summary>
    /// <param name="area">The area of the whole quad tree.</param>
    public QuadTree(AABB area)
    {
    }

    /// <summary>
    /// Used for creating new sub cells.
    /// </summary>
    /// <param name="level">The level of the cell.</param>
    private QuadTree(int level)
    {
      _level = level;
    }

    /// <summary>
    /// Gets or sets the parent of the cell.
    /// </summary>
    public QuadTree Parent
    {
      get { return _parent; }
      set { _parent = value; }
    }

    public QuadTree Add(ICollidable body)
    {
      QuadTree result = this;
      
      if (!_area.Contains(body.BoundingBox))
        throw new ArgumentException();
        
      if (_children == null) //Cell has not been split yet
      {
        _bodies.Add(body);
        if (_level < MaxLevels && _bodies.Count >= SplitThreshold)
        {
          _buffer.Clear();
          _children = new QuadTree[4];
          AABB[] childAreas = _area.Split(2, 2);
          for (int i = 0; i < _children.Length; i++)
          {
            QuadTree child = new QuadTree(_level + 1);
            _children[i] = child;
            child._area = childAreas[i];
            child.Parent = this;
            foreach (ICollidable currentBody in _bodies)
            {
              if (child.Area.Contains(currentBody.BoundingBox))
              {
                result = child.Add(currentBody);
                _buffer.Add(currentBody);
              }
            }
          }
          foreach (ICollidable oid in _buffer)
            _bodies.Remove(oid);
        }
      }
      else //Cell is already split
      {
        bool handled = false;
        for (int i = 0; i < _children.Length; i++)
        {
          if (_children[i].Area.Contains(body.BoundingBox))
          {
            result = _children[i].Add(body);
            handled = true;
          }
        }
        if (!handled)
          _bodies.Add(body);
      }
      
      return result;
    }

    public bool Remove(ICollidable body)
    {
      if (!_bodies.Contains(body))
      {
        for (int i = 0; i < _children.Length; i++)
        {
          if (_children[i].Remove(body))
            return true;
        }
      }
      else 
      {
        _bodies.Remove(body);
        return true;
      }
      
      return false;
    }

    public void GetBodies(AABB aabb, ref List<ICollidable> result)
    {
      if (!_area.Intersects(aabb))
        throw new ArgumentException();
          
      result.AddRange(_bodies);
      for (int i = 0; i < _children.Length; i++)
      {
        if (_children[i].Area.Intersects(aabb))
          _children[i].GetBodies(aabb, ref result);
      }
    }

    public void UpdateBody(ICollidable so)
    {
      //TODO: Do it
    }
    
  }
}
