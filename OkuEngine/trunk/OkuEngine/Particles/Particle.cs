using System;

namespace OkuEngine
{
  public struct Particle
  {
    public Vector Position;
    public Vector OldPosition;
    public Vector Velocity;
    public Color Color;
    public int Energy;
    public float Size;

    public Particle(Vector position, Vector oldPosition, Vector velocity, Color color, int energy, float size)
    {
      Position = position;
      OldPosition = oldPosition;
      Velocity = velocity;
      Color = color;
      Energy = energy;
      Size = size;
    }

  }
}