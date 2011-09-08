using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class LineParticleRenderer : IParticleRenderer
  {
    public void Render(List<Particle> particles)
    {
      List<Vector> points = new List<Vector>();
      List<Color> colors = new List<Color>();
      foreach (Particle p in particles)
      {
        if (!p.IsDead)
        {
          points.Add(p.OldPosition);
          points.Add(p.Position);
          colors.Add(p.Color);
          colors.Add(p.Color);
        }
      }

      OkuDrivers.Renderer.DrawLines(points.ToArray(), colors.ToArray(), 1, VertexInterpretation.LineSegments);
    }

  }
}
