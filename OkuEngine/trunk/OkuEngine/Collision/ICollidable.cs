using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  public interface ICollidable
  {
    AABB BoundingBox { get; }
    Vector2f[] Shape { get; }
  }
}
