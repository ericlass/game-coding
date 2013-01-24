using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  /// <summary>
  /// This is something like a regular grid or quad tree or any other spatial partitioning thing.
  /// Also, the broad phase detector is the only one who cares about the group id as this is some kind of broad filter too.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class BroadPhaseDetector<T>
  {
    public abstract void AddBody(Body<T> body); //Is called when body is added to world
    public abstract void UpdateBody(Body<T> body); //Is called when body moves somehow
    public abstract void RemoveBody(Body<T> body); //Is called wheb body is removed from world

    public abstract List<Body<T>> GetCollisionCandidates(Body<T> body);
  }
}
