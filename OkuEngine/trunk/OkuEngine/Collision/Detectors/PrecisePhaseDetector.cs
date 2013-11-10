using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision.Detectors
{
  /// <summary>
  /// This is a detector that checks two specific bodies for collision like SAT or Continuous.
  /// Should check the group id just for safety.
  /// </summary>
  public abstract class PrecisePhaseDetector
  {
    public abstract CollisionInfo GetCollisionInfo(Body bodyA, Body bodyB); //Returns null if no collision
  }
}
