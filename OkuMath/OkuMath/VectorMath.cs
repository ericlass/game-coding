using System;

namespace OkuMath
{
  /// <summary>
  /// Defines vector math functions.
  /// </summary>
  public static class VectorMath
  {
    /// <summary>
    /// Defines one degree in radians.
    /// </summary>
    public const float OneDegreeInRadians = (float)(Math.PI / 180.0);

    /// <summary>
    /// Normalizes the given vector. That is, X and Y are scaled so the magnitude of the vector is 1.0.
    /// <param name="vec">The vector to be normalized.</param>
    /// <returns>The normalized vector.</returns>
    /// </summary>
    public static Vector2f Normalize(Vector2f vec)
    {
      return vec / vec.Magnitude;
    }

    /// <summary>
    /// Calculates the dot/scalar product of the given vectors.
    /// NOTE: The vectors have to normalized!
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The dot/scalar product of the two vectors.</returns>
    public static float DotProduct(Vector2f vec1, Vector2f vec2)
    {
      return vec1.X * vec2.X + vec1.Y * vec2.Y;
    }

    /// <summary>
    /// Calculates the distance between two points given by the two vectors.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The distance between the two points.</returns>
    public static float Distance(Vector2f vec1, Vector2f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      return (float)Math.Sqrt(a * a + b * b);
    }

    /// <summary>
    /// Calculates the squared distance between two points given by the two vectors.
    /// The squared distance is calculated faster than the actual distance and can be used for comparisons.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The squered distance between the two points.</returns>
    public static float SquaredDistance(Vector2f vec1, Vector2f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      return a * a + b * b;
    }

    /// <summary>
    /// Rotates the given vector around the origin by the given angle. Positive angles
    /// mean clockwise rotation, negative values mean counter-clockwise rotation.
    /// </summary>
    /// <param name="vec">The vector to be rotated.</param>
    /// <param name="angle">The angle to rotate in degrees.</param>
    /// <returns>The vector rotated by the given angle.</returns>
    public static Vector2f Rotate(Vector2f vec, float angle)
    {
      float rad = angle * OneDegreeInRadians;

      float sin = (float)Math.Sin(rad);
      float cos = (float)Math.Cos(rad);

      float nx = vec.X * cos - vec.Y * sin;
      float ny = vec.X * sin + vec.Y * cos;

      return new Vector2f(nx, ny);
    }

    /// <summary>
    /// Project the given vec2 onto vec1.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The projected vector.</returns>
    public static Vector2f Project(Vector2f vec1, Vector2f vec2)
    {
      float dp = DotProduct(vec1, vec2) / (vec1.SquaredMagnitude);
      return new Vector2f(dp * vec1.X, dp * vec1.Y);
    }

    /// <summary>
    /// Project the given vec2 onto vec1.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The 1d scalar projected value.</returns>
    public static float ProjectScalar(Vector2f vec1, Vector2f vec2)
    {
      return DotProduct(vec1, vec2) / (vec1.SquaredMagnitude);
    }

    /// <summary>
    /// Calculates the left hand normal of the vector.
    /// </summary>
    /// <returns>The normalized left hand vector of the vector.</returns>
    public static Vector2f GetNormal(Vector2f vec)
    {
      return Normalize(new Vector2f(vec.Y, -vec.X));
    }

  }
}
