using System;
using System.Runtime.InteropServices;
using OkuBase.Graphics;
using OkuMath;

namespace OkuBase.Geometry
{
  /// <summary>
  /// Defines a single vertex for use with a vertex buffer.
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Pack=1)]
  public struct Vertex
  {
    /// <summary>
    /// The x component of the texture coordinates.
    /// </summary>
    public float TX;
    /// <summary>
    /// The y component of the texture coordinates.
    /// </summary>
    public float TY;
    /// <summary>
    /// The blue value of the color.
    /// </summary>
    public byte B;
    /// <summary>
    /// The green value of the color.
    /// </summary>
    public byte G;
    /// <summary>
    /// The red value of the color.
    /// </summary>
    public byte R;
    /// <summary>
    /// The alpha value of the color.
    /// </summary>
    public byte A;
    /// <summary>
    /// The x component of the position.
    /// </summary>
    public float VX;
    /// <summary>
    /// The y component of the position.
    /// </summary>
    public float VY;
    /// <summary>
    /// Reserved. Should always be zero.
    /// </summary>
    public float Reserved;

    /// <summary>
    /// Creates a new vertex with the given vertex data.
    /// </summary>
    /// <param name="vx">The x component of the position.</param>
    /// <param name="vy">The y component of the position.</param>
    /// <param name="tx">The x component of the texture coordinates</param>
    /// <param name="ty">The y component of the texture coordinates</param>
    /// <param name="r">The red value of the color</param>
    /// <param name="g">The green value of the color</param>
    /// <param name="b">The blue value of the color</param>
    /// <param name="a">The alpha value of the color</param>
    public Vertex(float vx, float vy, float tx, float ty, byte r, byte g, byte b, byte a)
    {
      VX = vx;
      VY = vy;
      TX = tx;
      TY = ty;
      R = r;
      G = g;
      B = b;
      A = a;
      Reserved = 0;
    }

    /// <summary>
    /// Creates a new vertex from the given values.
    /// </summary>
    /// <param name="pos">The positions of the vertex.</param>
    /// <param name="tex">The texture coordinates.</param>
    /// <param name="col">The color.</param>
    public Vertex(Vector2f pos, Vector2f tex, Color col)
    {
      VX = pos.X;
      VY = pos.Y;
      TX = tex.X;
      TY = tex.Y;
      R = col.R;
      G = col.G;
      B = col.B;
      A = col.A;
      Reserved = 0;
    }

  }
}
