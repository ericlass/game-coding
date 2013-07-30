using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase.Geometry;

namespace OkuEngine.Collision.Detectors
{
  public class BoundingCirclePrecisePhaseDetector : PrecisePhaseDetector
  {
    public override CollisionInfo GetCollisionInfo(Body bodyA, Body bodyB)
    {
      Circle circleA = bodyA.GetTransformedBoundingCircle();
      Circle circleB = bodyB.GetTransformedBoundingCircle();

      CollisionInfo result = null;
      Vector2f mtd = Vector2f.Zero;
      if (IntersectionTests.Circles(circleA.Center, circleA.Radius, circleB.Center, circleB.Radius, out mtd))
      {
        result = new CollisionInfo();
        result.BodyA = bodyA;
        result.BodyB = bodyB;
        result.MTD = mtd;
      }

      return result;
    }
  }
}
