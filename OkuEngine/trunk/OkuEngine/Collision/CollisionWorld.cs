using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Collections;

namespace OkuEngine.Collision
{
  public class CollisionWorld<T>
  {
    private HashSet<Body<T>> _bodies = new HashSet<Body<T>>();
    private BroadPhaseDetector<T> _broadDetector = null;
    private PrecisePhaseDetector<T> _preciseDetector = null;
    private HashSet<Body<T>> _updatedBodies = new HashSet<Body<T>>();
    private PairList<Body<T>> _collidedPairs = new PairList<Body<T>>();

    public CollisionWorld(BroadPhaseDetector<T> broadDetector, PrecisePhaseDetector<T> preciseDetector)
    {
      _broadDetector = broadDetector;
      _preciseDetector = preciseDetector;
    }

    public void AddBody(Body<T> body)
    {
      _bodies.Add(body);
      _updatedBodies.Add(body);
      _broadDetector.AddBody(body);
    }

    public void UpdateBody(Body<T> body)
    {
      _broadDetector.UpdateBody(body);
      _updatedBodies.Add(body);
    }

    public void RemoveBody(Body<T> body)
    {
      _broadDetector.RemoveBody(body);
      _updatedBodies.Remove(body);
      _bodies.Remove(body);
    }

    public bool GetCollisions(List<CollisionInfo<T>> collisions)
    {
      collisions.Clear();
      _collidedPairs.Clear();
      foreach (Body<T> body in _updatedBodies)
      {
        List<Body<T>> candidates = _broadDetector.GetCollisionCandidates(body);
        foreach (Body<T> candidate in candidates)
        {
          if (!_collidedPairs.Contains(body, candidate))
          {
            CollisionInfo<T> info = _preciseDetector.GetCollisionInfo(body, candidate);
            if (info != null)
            {
              collisions.Add(info);
              _collidedPairs.Add(info.BodyA, info.BodyB);
            }
          }
        }
      }

      //Clear updated bodies list
      _updatedBodies.Clear();
      //Make sure that currently colliding bodies are also checked next time!
      _collidedPairs.GetDistinctValues(ref _updatedBodies);

      return collisions.Count > 0;
    }

  }
}
