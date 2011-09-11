using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public class PointParticleRenderer : IParticleRenderer
  {
    private float _pointSize = 2.0f;
    private ArrayList<Vector> _vertices = new ArrayList<Vector>();
    private ArrayList<Color> _colors = new ArrayList<Color>();
    
    public void Render(List<Particle> particles)
    {
      _vertices.AsureCapacity(particles.Count);
      _colors.AsureCapacity(particles.Count);

      int index = 0;
      for (int i = 0; i < particles.Count; i++)
      {
        Particle p = particles[i];
        if (!p.IsDead)
        {
          _vertices[index] = p.Position;
          _colors[index] = p.Color;
          index++;
        }
      }

      OkuDrivers.Renderer.DrawPoints(_vertices.InternalArray, _colors.InternalArray, index, _pointSize);
    }

    public float PointSize 
    {
      get { return _pointSize; }
      set { _pointSize = value; }
    }

  }
}
