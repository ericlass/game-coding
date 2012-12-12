using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Collision
{
  public interface ICollidable
  {
    int Id { get; }
    AABB BoundingBox { get; }
    Vector[] Shape { get; }
    bool IsStatic { get; }
  }
}
