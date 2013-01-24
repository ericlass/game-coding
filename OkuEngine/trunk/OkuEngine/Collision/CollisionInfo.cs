using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Collision
{
  public class CollisionInfo<T>
  {
    public Body<T> BodyA { get; set; }
    public Body<T> BodyB { get; set; }
    public Vector2f MTD { get; set; } //Must be filled
    public float TimeDelta { get; set; } //Only filled by detectors that take the time into account
  }
}
