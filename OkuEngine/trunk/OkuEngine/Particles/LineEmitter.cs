using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class LineEmitter : ParticleEmitter
  {
    private Vector _start = Vector.Zero;
    private Vector _end = Vector.Zero;
    private bool _normalDirection = true;
    private Vector _normal = Vector.Zero;

    public LineEmitter()
    {
    }

    public LineEmitter(Vector start, Vector end)
    {
      _start = start;
      _end = end;
    }

    /// <summary>
    /// Gets or sets the start point of the emitters line.
    /// </summary>
    public Vector Start
    {
      get { return _start; }
      set 
      {
        _start = value;
        _normal = Vector.Zero;
      }
    }

    /// <summary>
    /// Gets or sets the end point of the emitters line.
    /// </summary>
    public Vector End
    {
      get { return _end; }
      set 
      { 
        _end = value;
        _normal = Vector.Zero;
      }
    }

    /// <summary>
    /// Gets or sets if the normal of the line is used for the initial 
    /// direction of the particles or the separate angle proeprties.
    /// </summary>
    public bool NormalDirection
    {
      get { return _normalDirection; }
      set { _normalDirection = value; }
    }

    /// <summary>
    /// Calculates a random velocity vector for a new particle taking into account the
    /// configured angle and speed and the corresponding variations.
    /// If the NormalDirection property is set to true the normal of the line is used 
    /// as direction. In this case the angle variation is not supported.
    /// </summary>
    /// <returns>The direction vector scaled by the speed.</returns>
    protected override Vector GetRandomVelocity()
    {
      Vector result = base.GetRandomVelocity();
      if (_normalDirection)
      {
        if (_normal == Vector.Zero)
          _normal = OkuMath.GetNormal(_start, _end);
        result = _normal * GetRandomSpeed();
      }
      return result;
    }

    /// <summary>
    /// Calculates a random position on the emitter line.
    /// </summary>
    /// <returns>A random point on the emitter line.</returns>
    private Vector GetRandomPosition()
    {
      float t = (float)_rand.NextDouble();
      return OkuMath.LinearInterpolate(_start, _end, t);
    }

    public override void Emit(List<Particle> particles, float dt)
    {
      int numParticles = GetNumParticleToEmit(dt);
      for (int i = 0; i < numParticles; i++)
      {
        Particle p = AddParticle(particles);
        p.Position = GetRandomPosition();
        p.OldPosition = p.Position;
      }
    }

  }
}
