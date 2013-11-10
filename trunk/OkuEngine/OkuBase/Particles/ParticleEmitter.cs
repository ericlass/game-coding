using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using OkuBase.Geometry;

namespace OkuBase.Particles
{
  /// <summary>
  /// Base class for particle emitters. Do not use directly. Use a descendent of it.
  /// Override the Emit method in descendents to create different emitter behavior.
  /// </summary>
  public class ParticleEmitter
  {
    private float _angle = 0.0f;
    private float _angleVariation = 0.0f;

    private float _birthRate = 10.0f;

    private float _lifetime = 10.0f;
    private float _lifetimeVariation = 0.0f;
    private float _speed = 100.0f;
    private float _speedVariation = 0.0f;
    private float _scale = 1.0f;
    private float _scaleVariation = 0.0f;

    private Color _color = Color.White;

    protected Random _rand = new Random();
    private float _pi = (float)Math.PI;
    private float _emitTimer = 0.0f; // Used to keep track of fractional particles per frame

    /// <summary>
    /// Creates new particles and adds them to the list in the particles parameter.
    /// </summary>
    /// <param name="particles">The list to emit new particles to.</param>
    /// <param name="dt">The time that has passed since the last frame.</param>
    public virtual void Emit(List<Particle> particles, float dt)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Calculates a random angle value taking into account the current configuration.
    /// </summary>
    /// <returns>A renadom angle in radians.</returns>
    protected float GetRandomAngle()
    {
      float rads = (_angle / 180.0f) * _pi;
      return _angleVariation == 0.0f ? rads : rads + (_rand.RandomFloat() * _pi * _angleVariation);
    }

    /// <summary>
    /// Calculates a random speed value taking into account the current configuration.
    /// </summary>
    /// <returns>A random spped in pixels per second.</returns>
    protected float GetRandomSpeed()
    {
      return _speedVariation == 0.0f ? _speed : _speed + (_rand.RandomFloat() * _speed * _speedVariation);
    }

    /// <summary>
    /// Calculates a random velocity vector for a new particle taking into account the
    /// configured angle and speed and the corresponding variations.
    /// </summary>
    /// <returns>The direction vector scaled by the speed.</returns>
    protected virtual Vector2f GetRandomVelocity()
    {
      float angle = GetRandomAngle();
      float speed = GetRandomSpeed();
      return new Vector2f((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
    }

    /// <summary>
    /// Calculates a random lifetime for a new particle taking into account the configured
    /// lifetime and the corresponding variation.
    /// </summary>
    /// <returns>A random lifetime.</returns>
    protected float GetRandomLifetime()
    {
      return _lifetimeVariation == 0.0f ? _lifetime : _lifetime + (_rand.RandomFloat() * _lifetime * _lifetimeVariation);
    }

    /// <summary>
    /// Calculates a random scale for a new particle taking into account the configured scale and variation.
    /// </summary>
    /// <returns>A random scale value.</returns>
    protected float GetRandomScale()
    {
      return _scaleVariation == 0.0f ? _scale : _scale + (_rand.RandomFloat() * _scale * _scaleVariation);
    }

    /// <summary>
    /// Calculates how many particles have to be generated for the given amount of time.
    /// </summary>
    /// <param name="dt">The amount of time that has passed since the last frame.</param>
    /// <returns>The number of particles that have to be created for the given time. Maybe zero.</returns>
    protected int GetNumParticleToEmit(float dt)
    {
      _emitTimer += _birthRate * dt;
      int num = (int)_emitTimer;
      _emitTimer -= num;
      return num;
    }

    /// <summary>
    /// Creates a new particle from the configured parameters.
    /// </summary>
    /// <returns>The newly created particle.</returns>
    protected Particle AddParticle(List<Particle> particles)
    {
      Particle result = null;
      foreach (Particle p in particles)
      {
        if (p.IsDead)
        {
          result = p;
          break;
        }
      }

      if (result == null)
      {
        result = new Particle();
        particles.Add(result);
      }

      result.Color = _color;
      result.Energy = GetRandomLifetime();
      result.LifeTime = result.Energy;
      result.Scale = GetRandomScale();
      result.Velocity = GetRandomVelocity();

      return result;
    }

    /// <summary>
    /// Gets or sets the angle in which the emitter spreads particles in degrees.
    /// </summary>
    public float Angle
    {
      get { return _angle; }
      set { _angle = value; }
    }

    /// <summary>
    /// Gets or sets the variation of the emitting angle. Must be in the range 0.0 - 1.0 where 0.0 means no variation and 1.0 means 360°.
    /// </summary>
    public float AngleVariation
    {
      get { return _angleVariation; }
      set { _angleVariation = value; }
    }

    /// <summary>
    /// Gets or sets the rate at which particles are born. Can be smaller than 1.0 but not negative.
    /// </summary>
    public float BirthRate
    {
      get { return _birthRate; }
      set { _birthRate = value; }
    }

    /// <summary>
    /// Gets or sets the initial lifetime of the emitted particles in seconds.
    /// </summary>
    public float Lifetime
    {
      get { return _lifetime; }
      set { _lifetime = value; }
    }

    /// <summary>
    /// Gets or sets the variation of the lifetime of the emitted particles. Ranges from 0.0 to 1.0 where 0.0 means no variation
    /// and 1.0 means liftime is in range (lifetime +- lifetime).
    /// </summary>
    public float LifetimeVariation
    {
      get { return _lifetimeVariation; }
      set { _lifetimeVariation = value; }
    }

    /// <summary>
    /// Gets or sets the speed the pixels move at in world units per second.
    /// </summary>
    public float Speed
    {
      get { return _speed; }
      set { _speed = value; }
    }

    /// <summary>
    /// Gets or sets the variation of the speed of new particles. Ranges from 0.0 to 1.0 where 0.0 means no variation and 1.0
    /// means speed is in range (speed +- speed).
    /// </summary>
    public float SpeedVariation
    {
      get { return _speedVariation; }
      set { _speedVariation = value; }
    }

    /// <summary>
    /// Gets or sets the scale of the emitted particles. 1.0 means original size.
    /// </summary>
    public float Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    /// <summary>
    /// Gets or sets the variation of the speed of new particles. Ranges from 0.0 to 1.0 where 0.0 means no variation and
    /// 1.0 means scale is in range (scale +- scale).
    /// </summary>
    public float ScaleVariation
    {
      get { return _scaleVariation; }
      set { _scaleVariation = value; }
    }

    /// <summary>
    /// Gets or sets the color of newly created particles.
    /// </summary>
    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

  }
}
