using System;

namespace OkuEngine
{
  public class Particle
  {
    private Vector2f _position = Vector2f.Zero; //current position
    private Vector2f _oldPosition = Vector2f.Zero; //previous position
    private Vector2f _velocity = Vector2f.Zero; //velocitiy in world units per second

    private Color _color = Color.White; // color

    private float _scale = 1.0f; //scale

    private float _energy = 10; // life energy that is left in seconds
    private float _lifeTime = 10; // original lifetime in seconds
    private float _lifeRatio = -1.0f;

    private int _id = KeySequence.NextValue(KeySequence.ParticleSequence); // artificial key of particle

    public void Update(float dt)
    {
      _oldPosition = _position;

      if (!_velocity.IsZero())
        _position = _position + (_velocity * dt);

      _energy -= dt;
      _lifeRatio = -1.0f;
    }

    /// <summary>
    /// Gets the ratio of the lifetime. This value ranges from 0.0 (start of life) - 1.0 (end of life). 
    /// Can be used for calculating lifetime effects.
    /// </summary>
    public float LifetimeRatio
    {
      get 
      {
        if (_lifeRatio < 0)
          _lifeRatio = 1.0f - (_energy / _lifeTime);
        return _lifeRatio;
      }
    }

    /// <summary>
    /// Gets if the life of this particle has ended or not.
    /// </summary>
    public bool IsDead
    {
      get { return _energy <= 0.0f; }
    }

    public Vector2f Position
    {
      get { return _position; }
      set { _position = value; }
    }

    public Vector2f OldPosition
    {
      get { return _oldPosition; }
      set { _oldPosition = value; }
    }

    public Vector2f Velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public float Scale 
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public float Energy
    {
      get { return _energy; }
      set { _energy = value; }
    }

    public float LifeTime
    {
      get { return _lifeTime; }
      set { _lifeTime = value; }
    }

  }
}