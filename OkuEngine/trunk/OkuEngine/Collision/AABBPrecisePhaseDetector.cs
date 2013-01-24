using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  public class AABBPrecisePhaseDetector<T> : PrecisePhaseDetector<T>
  {
    public override CollisionInfo<T> GetCollisionInfo(Body<T> bodyA, Body<T> bodyB)
    {
      AABB boxA = bodyA.GetTransformedBoundingBox();
      AABB boxB = bodyB.GetTransformedBoundingBox();

      if (boxA.Intersects(boxB))
      {
        //Use simple SAT on the bounding boxes
        float min1 = boxA.Min.X;
        float max1 = boxA.Max.X;
        float min2 = boxB.Min.X;
        float max2 = boxB.Max.X;

        float xOverlap = 0;
        
        if (!(min1 > max2 || max1 < min2))
        {
          float center1 = (min1 + max1);
          float center2 = (min2 + max2);

          if (center2 > center1)
            xOverlap = max1 - min2;
          else
            xOverlap = min1 - max2;
        }

        float yOverlap = 0;

        min1 = boxA.Min.Y;
        max1 = boxA.Max.Y;
        min2 = boxB.Min.Y;
        max2 = boxB.Max.Y;

        if (!(min1 > max2 || max1 < min2))
        {
          float center1 = (min1 + max1);
          float center2 = (min2 + max2);

          if (center2 > center1)
            yOverlap = max1 - min2;
          else
            yOverlap = min1 - max2;
        }

        CollisionInfo<T> result = new CollisionInfo<T>();
        result.BodyA = bodyA;
        result.BodyB = bodyB;

        if (Math.Abs(xOverlap) > Math.Abs(yOverlap))
          result.MTD = new Vector2f(xOverlap, 0);
        else
          result.MTD = new Vector2f(0, yOverlap);

        return result;
      }
      return null;
    }
  }
}
