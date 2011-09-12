using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class LineParticleRenderer : IParticleRenderer
  {
    private DynamicArray<Vector> _vertices = new DynamicArray<Vector>();
    private DynamicArray<Color> _colors = new DynamicArray<Color>();

    public void Render(List<Particle> particles)
    {
      _vertices.AsureCapacity(particles.Count * 2);
      _colors.AsureCapacity(particles.Count * 2);

      int index = 0;
      for (int i = 0; i < particles.Count; i++)
      {
        Particle p = particles[i];
        if (!p.IsDead)
        {
          _vertices[index] = p.Position;
          _colors[index] = p.Color;
          index++;
          _vertices[index] = p.OldPosition;
          _colors[index] = p.Color;
          index++;
        }
      }

      OkuDrivers.Renderer.DrawLines(_vertices.InternalArray, _colors.InternalArray, index, 1, VertexInterpretation.LineSegments);


      /*List<Vector> points = new List<Vector>();
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

      OkuDrivers.Renderer.DrawLines(points.ToArray(), colors.ToArray(), points.Count, 1, VertexInterpretation.LineSegments);*/
    }

  }
}
