using System;
using System.Collections.Generic;
using OkuBase.Collections;
using OkuBase.Graphics;
using OkuMath;

namespace OkuBase.Particles
{
  public class LineParticleRenderer : IParticleRenderer
  {
    private DynamicArray<Vector2f> _vertices = new DynamicArray<Vector2f>();
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

      OkuManager.Instance.Graphics.DrawLines(_vertices.InternalArray, _colors.InternalArray, index, 1, LineMode.LineSegments);
    }

  }
}
