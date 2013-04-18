using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Geometry;
using OkuEngine.Actors;

namespace OkuEngine.Collision.Detectors
{
  public class RegularGridBroadPhaseDetector : BroadPhaseDetector
  {
    private RegularGrid _grid = null;
    private Dictionary<Body, List<Vector2i>> _bodyCells = new Dictionary<Body, List<Vector2i>>();
    private Dictionary<Vector2i, HashSet<Body>> _cellBodies = new Dictionary<Vector2i, HashSet<Body>>();
    private List<Vector2i> _cellBuffer = new List<Vector2i>();

    public RegularGridBroadPhaseDetector(float width, float height, float cellSize)
    {
      _grid = new RegularGrid(width, height, cellSize);
      _grid.Centered = true;
    }

    public override void AddBody(Body body)
    {
      if (_bodyCells.ContainsKey(body))
        throw new OkuException("Trying to add body twice to collision world! " + body.ToString());

      BoundingCircleComponent comp = body.SceneNode.Actor.GetComponent<BoundingCircleComponent>(BoundingCircleComponent.ComponentName);
      if (comp != null)
      {
        _cellBuffer.Clear();
        _grid.GetCellsIntersecting(comp.GetBoundingCircle(), ref _cellBuffer);
        
        foreach (Vector2i cell in _cellBuffer)
        {
          HashSet<Body> bodies = null;
          if (!_cellBodies.ContainsKey(cell))
          {
            bodies = new HashSet<Body>();
            _cellBodies.Add(cell, bodies);
          }
          else
            bodies = _cellBodies[cell];

          bodies.Add(body);
        }

        if (!_bodyCells.ContainsKey(body))
          _bodyCells.Add(body, new List<Vector2i>());
        _bodyCells[body].AddRange(_cellBuffer);
      }
    }

    public override void UpdateBody(Body body)
    {
      RemoveBody(body);
      AddBody(body);
    }

    public override void RemoveBody(Body body)
    {
      if (_bodyCells.ContainsKey(body))
      {
        foreach (Vector2i cell in _bodyCells[body])
          _cellBodies[cell].Remove(body);

        _bodyCells.Remove(body);
      }
    }

    public override void Clear()
    {
      _bodyCells.Clear();
      _cellBodies.Clear();
    }

    public override void GetCollisionCandidates(Body body, ref List<Body> candidates)
    {
      if (_bodyCells.ContainsKey(body))
      {
        foreach (Vector2i cell in _bodyCells[body])
        {
          foreach (Body cand in _cellBodies[cell])
            if (cand != body)
              candidates.Add(cand);
        }
        candidates.Remove(body);
      }
    }

  }
}
