using System;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace OkuBase.Particles
{
  /// <summary>
  /// Defines a single particle with its properties.
  /// </summary>
  public class Particle
  {
    private Vector2f _position = Vector2f.Zero; //current position
    private Vector2f _oldPosition = Vector2f.Zero; //previous position
    private Vector2f _velocity = Vector2f.Zero; //velocitiy in world units per second

    private Color _color = Color.White; // color

    private float _scale = 1.0f; //scale

    private float _energy = 10; // life energy that is left in seconds
    private float _lifeTime = 10; // original lifetime in seconds

    private int _id = KeySequence.NextValue(KeySequence.ParticleSequence); // artificial key of particle

    /// <summary>
    /// Gets the ratio of the lifetime. This value ranges from 0.0 (start of life) - 1.0 (end of life). 
    /// Can be used for calculating lifetime effects.
    /// </summary>
    public float LifetimeRatio
    {
      get { return 1.0f - (_energy / _lifeTime); }
    }

    /// <summary>
    /// Gets if the life of this particle has ended or not.
    /// </summary>
    public bool IsDead
    {
      get { return _energy <= 0.0f; }
    }

    /// <summary>
    /// Gets or set the position of the particle.
    /// </summary>
    public Vector2f Position
    {
      get { return _position; }
      set { _position = value; }
    }

    /// <summary>
    /// Gets or set the position of the particle in the previous step.
    /// </summary>
    public Vector2f OldPosition
    {
      get { return _oldPosition; }
      set { _oldPosition = value; }
    }

    /// <summary>
    /// Gets or set the velocity of the particle.
    /// </summary>
    public Vector2f Velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }

    /// <summary>
    /// Gets or set the color of the particle.
    /// </summary>
    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    /// <summary>
    /// Gets or sets the scale of the particle.
    /// </summary>
    public float Scale 
    {
      get { return _scale; }
      set { _scale = value; }
    }

    /// <summary>
    /// Gets or sets the energy of the particle. This is actually the number of seconds the particle still has to live.
    /// </summary>
    public float Energy
    {
      get { return _energy; }
      set { _energy = value; }
    }

    /// <summary>
    /// Gets or set the total life time of the particle. This is how long the particle exists in seconds.
    /// </summary>
    public float LifeTime
    {
      get { return _lifeTime; }
      set { _lifeTime = value; }
    }

  }
}