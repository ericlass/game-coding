using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  /// <summary>
  /// This is a detector that checks two specific bodies for collision like SAT or Continuous.
  /// Should check the group id just for safety.
  /// </summary>
  public abstract class PrecisePhaseDetector<T>
  {
    public abstract CollisionInfo<T> GetCollisionInfo(Body<T> bodyA, Body<T> bodyB); //Returns null if no collision
  }
}
