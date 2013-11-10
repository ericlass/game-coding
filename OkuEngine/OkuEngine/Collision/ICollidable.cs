using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Geometry;

namespace OkuEngine.Collision
{
  public interface ICollidable
  {
    Circle BoundingCircle { get; }
    Vector2f[] Shape { get; }
  }
}
