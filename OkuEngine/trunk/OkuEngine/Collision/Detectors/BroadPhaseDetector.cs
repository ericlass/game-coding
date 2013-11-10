using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision.Detectors
{
  /// <summary>
  /// This is something like a regular grid or quad tree or any other spatial partitioning thing.
  /// Also, the broad phase detector is the only one who cares about the group id as this is some kind of broad filter too.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class BroadPhaseDetector
  {
    public abstract void AddBody(Body body); //Is called when body is added to world
    public abstract void UpdateBody(Body body); //Is called when body moves somehow
    public abstract void RemoveBody(Body body); //Is called wheb body is removed from world
    public abstract void Clear();

    public abstract void GetCollisionCandidates(Body body, ref List<Body> candidates);
  }
}
