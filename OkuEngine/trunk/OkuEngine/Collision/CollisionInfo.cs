using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Geometry;

namespace OkuEngine.Collision
{
  public class CollisionInfo
  {
    public Body BodyA { get; set; }
    public Body BodyB { get; set; }
    public Vector2f MTD { get; set; } //Must be filled
    public float TimeDelta { get; set; } //Only filled by detectors that take the time into account
  }
}
