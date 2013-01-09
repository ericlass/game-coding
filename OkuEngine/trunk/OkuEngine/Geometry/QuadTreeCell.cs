using System;
using System.Collections.Generic;
using OkuEngine.Scenes;

namespace OkuEngine.Geometry
{
  /// <summary>
  /// Description of QuadTreeCell.
  /// </summary>
  public class QuadTreeCell
  {
    private const int MaxLevels = 8;
    private const int SplitThreshold = 5;
    
    private AABB _area = new AABB();
    private QuadTreeCell _parent = null;
    private QuadTreeCell[] _children = null;
    private int _level = 0;
    private Dictionary<int, SceneObject> _objects = new Dictionary<int, SceneObject>();
    private HashSet<int> _buffer = new HashSet<int>();
    
    public AABB Area
    {
      get { return _area; }
    }
    
    public QuadTreeCell(int level)
    {
      _level = level;
    }
    
    public QuadTreeCell Add(SceneObject so)
    {
      QuadTreeCell result = this;
      
      if (!_area.Contains(so.BoundingBox))
        throw new ArgumentException();
        
      if (_children == null) //Cell has not been split yet
      {
        _objects.Add(so.Id, so);
        if (_level < MaxLevels && _objects.Count >= SplitThreshold)
        {
          _buffer.Clear();
          _children = new QuadTreeCell[4];
          for (int i = 0; i < _children.Length; i++)
          {
            _children[i] = new QuadTreeCell(_level + 1);
            foreach (SceneObject currentObject in _objects.Values)
            {
              if (_children[i].Area.Contains(currentObject.BoundingBox))
              {
                result = _children[i].Add(currentObject);
                _buffer.Add(currentObject.Id);
              }
            }
          }
          foreach (int oid in _buffer)
            _objects.Remove(oid);
        }
      }
      else //Cell is already split
      {
        bool handled = false;
        for (int i = 0; i < _children.Length; i++)
        {
          if (_children[i].Area.Contains(so.BoundingBox))
          {
            result = _children[i].Add(so);
            handled = true;
          }
        }
        if (!handled)
          _objects.Add(so.Id, so);
      }
      
      return result;
    }
    
    public bool Remove(SceneObject so)
    {
      if (!_objects.ContainsKey(so.Id))
      {
        for (int i = 0; i < _children.Length; i++)
        {
          if (_children[i].Remove(so))
            return true;
        }
      }
      else 
      {
        _objects.Remove(so.Id);
        return true;
      }
      
      return false;
    }
    
    public void GetObjects(AABB aabb, ref List<SceneObject> result)
    {
      if (!_area.Intersects(aabb))
        throw new ArgumentException();
          
      result.AddRange(_objects.Values);
      for (int i = 0; i < _children.Length; i++)
      {
        if (_children[i].Area.Intersects(aabb))
          _children[i].GetObjects(aabb, ref result);
      }
    }
    
  }
}
