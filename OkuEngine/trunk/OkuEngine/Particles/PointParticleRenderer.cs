using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public class PointParticleRenderer : IParticleRenderer
  {
    private float _pointSize = 2.0f;
    
    public void Render(List<Particle> particles)
    {
      List<Vector> points = new List<Vector>();
      List<Color> colors = new List<Color>();
      foreach (Particle p in particles)
      {
        if (!p.IsDead)
        {
          points.Add(p.Position);
          colors.Add(p.Color);
        }
      }

      OkuDrivers.Renderer.DrawPoints(points.ToArray(), colors.ToArray(), PointSize);
    }

    public float PointSize 
    {
      get { return _pointSize; }
      set { _pointSize = value; }
    }

  }
}
