using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision.Detectors
{
  /// <summary>
  /// Defines a precise phase detector that actually does not detect collisions.
  /// </summary>
  public class NoPrecisePhaseDetector : PrecisePhaseDetector
  {
    public override CollisionInfo GetCollisionInfo(Body bodyA, Body bodyB)
    {
      return null;
    }
  }
}
