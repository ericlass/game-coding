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
    /// Normalizes the given vector. That is, all components are scaled so the magnitude of the vector is 1.0.
    /// <param name="vec">The vector to be normalized.</param>
    /// <returns>The normalized vector.</returns>
    /// </summary>
    public static Vector2f Normalize(Vector2f vec)
    {
      return vec / vec.Magnitude;
    }

    /// <summary>
    /// Normalizes the given vector. That is, all components are scaled so the magnitude of the vector is 1.0.
    /// <param name="vec">The vector to be normalized.</param>
    /// <returns>The normalized vector.</returns>
    /// </summary>
    public static Vector3f Normalize(Vector3f vec)
    {
      return vec / vec.Magnitude;
    }

    /// <summary>
    /// Normalizes the given vector. That is, all components are scaled so the magnitude of the vector is 1.0.
    /// <param name="vec">The vector to be normalized.</param>
    /// <returns>The normalized vector.</returns>
    /// </summary>
    public static Vector4f Normalize(Vector4f vec)
    {
      return vec / vec.Magnitude;
    }

    /// <summary>
    /// Calculates the dot/scalar product of the given vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The dot/scalar product of the two vectors.</returns>
    public static float DotProduct(Vector2f vec1, Vector2f vec2)
    {
      return vec1.X * vec2.X + vec1.Y * vec2.Y;
    }

    /// <summary>
    /// Calculates the dot/scalar product of the given vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The dot/scalar product of the two vectors.</returns>
    public static float DotProduct(Vector3f vec1, Vector3f vec2)
    {
      return vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z;
    }

    /// <summary>
    /// Calculates the dot/scalar product of the given vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The dot/scalar product of the two vectors.</returns>
    public static float DotProduct(Vector4f vec1, Vector4f vec2)
    {
      return vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z + vec1.W * vec2.W;
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
    /// Calculates the distance between two points given by the two vectors.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The distance between the two points.</returns>
    public static float Distance(Vector3f vec1, Vector3f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      float c = vec1.Z - vec2.Z;
      return (float)Math.Sqrt(a * a + b * b + c * c);
    }

    /// <summary>
    /// Calculates the distance between two points given by the two vectors.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The distance between the two points.</returns>
    public static float Distance(Vector4f vec1, Vector4f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      float c = vec1.Z - vec2.Z;
      float d = vec1.W - vec2.W;
      return (float)Math.Sqrt(a * a + b * b + c * c + d * d);
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
    /// Calculates the squared distance between two points given by the two vectors.
    /// The squared distance is calculated faster than the actual distance and can be used for comparisons.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The squered distance between the two points.</returns>
    public static float SquaredDistance(Vector3f vec1, Vector3f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      float c = vec1.Z - vec2.Z;
      return a * a + b * b + c * c;
    }

    /// <summary>
    /// Calculates the squared distance between two points given by the two vectors.
    /// The squared distance is calculated faster than the actual distance and can be used for comparisons.
    /// </summary>
    /// <param name="vec1">The first point.</param>
    /// <param name="vec2">The second point.</param>
    /// <returns>The squered distance between the two points.</returns>
    public static float SquaredDistance(Vector4f vec1, Vector4f vec2)
    {
      float a = vec1.X - vec2.X;
      float b = vec1.Y - vec2.Y;
      float c = vec1.Z - vec2.Z;
      float d = vec1.W - vec2.W;
      return a * a + b * b + c * c + d * d;
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
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The projected vector.</returns>
    public static Vector2f Project(Vector2f vec1, Vector2f vec2)
    {
      float dp = DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
      return vec2 * dp;
    }

    /// <summary>
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The projected vector.</returns>
    public static Vector3f Project(Vector3f vec1, Vector3f vec2)
    {
      float dp = DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
      return vec2 * dp;
    }

    /// <summary>
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The projected vector.</returns>
    public static Vector4f Project(Vector4f vec1, Vector4f vec2)
    {
      float dp = DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
      return vec2 * dp;
    }

    /// <summary>
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The 1d scalar projected value.</returns>
    public static float ProjectScalar(Vector2f vec1, Vector2f vec2)
    {
      return DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
    }

    /// <summary>
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The 1d scalar projected value.</returns>
    public static float ProjectScalar(Vector3f vec1, Vector3f vec2)
    {
      return DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
    }

    /// <summary>
    /// Project the given vec1 onto vec2.
    /// </summary>
    /// <param name="vec1">The vector to project onto.</param>
    /// <param name="vec2">The vector to be projected.</param>
    /// <returns>The 1d scalar projected value.</returns>
    public static float ProjectScalar(Vector4f vec1, Vector4f vec2)
    {
      return DotProduct(vec1, vec2) / (vec2.SquaredMagnitude);
    }

    /// <summary>
    /// Calculates the left hand normal of the vector.
    /// </summary>
    /// <returns>The normalized left hand vector of the vector.</returns>
    public static Vector2f GetNormal(Vector2f vec)
    {
      return Normalize(new Vector2f(vec.Y, -vec.X));
    }

    /// <summary>
    /// Calculates the cross product of the two given vectors.
    /// The result depends on the order of the given vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The cross product as a new vector.</returns>
    public static Vector3f CrossProduct(Vector3f vec1, Vector3f vec2)
    {
      return new Vector3f(
          vec1.Y * vec2.Z - vec2.Y * vec1.Z,
          vec1.Z * vec2.X - vec2.Z * vec1.X,
          vec1.X * vec2.Y - vec2.X * vec1.Y
        );
    }

    /// <summary>
    /// Calculates a normal as-is if a vertex's eye-space position vector points in the opposite
    /// direction of a geometric normal, otherwise return the negated version of the normal.
    /// </summary>
    /// <param name="n">Peturbed normal vector.</param>
    /// <param name="i">Incidence vector (typically a direction vector from the eye to a vertex).</param>
    /// <param name="nref">Geometric normal vector (for some facet the peturbed normal belongs).</param>
    /// <returns>
    ///   A (peturbed) normal as-is if a vertex's eye-space position vector
    ///   points in the opposite direction of a geometric normal, otherwise
    ///   return the negated version of the (peturbed) normal.
    /// </returns>
    public static Vector2f FaceForward(Vector2f n, Vector2f i, Vector2f nref)
    {
      return DotProduct(i, nref) < 0 ? n : -n;
    }

    /// <summary>
    /// Calculates a normal as-is if a vertex's eye-space position vector points in the opposite
    /// direction of a geometric normal, otherwise return the negated version of the normal.
    /// </summary>
    /// <param name="n">Peturbed normal vector.</param>
    /// <param name="i">Incidence vector (typically a direction vector from the eye to a vertex).</param>
    /// <param name="nref">Geometric normal vector (for some facet the peturbed normal belongs).</param>
    /// <returns>
    ///   A (peturbed) normal as-is if a vertex's eye-space position vector
    ///   points in the opposite direction of a geometric normal, otherwise
    ///   return the negated version of the (peturbed) normal.
    /// </returns>
    public static Vector3f FaceForward(Vector3f n, Vector3f i, Vector3f nref)
    {
      return DotProduct(i, nref) < 0 ? n : -n;
    }

    /// <summary>
    /// Calculates a normal as-is if a vertex's eye-space position vector points in the opposite
    /// direction of a geometric normal, otherwise return the negated version of the normal.
    /// </summary>
    /// <param name="n">Peturbed normal vector.</param>
    /// <param name="i">Incidence vector (typically a direction vector from the eye to a vertex).</param>
    /// <param name="nref">Geometric normal vector (for some facet the peturbed normal belongs).</param>
    /// <returns>
    ///   A (peturbed) normal as-is if a vertex's eye-space position vector
    ///   points in the opposite direction of a geometric normal, otherwise
    ///   return the negated version of the (peturbed) normal.
    /// </returns>
    public static Vector4f FaceForward(Vector4f n, Vector4f i, Vector4f nref)
    {
      return DotProduct(i, nref) < 0 ? n : -n;
    }

    /// <summary>
    /// Returns the reflection vector given an incidence vector i and a normal vector n.
    /// The resulting vector is the identical number of components as the two input vectors.
    /// The normal vector n should be normalized. If n is normalized, the output vector
    /// will have the same length as the input incidence vector i.
    /// </summary>
    /// <param name="i">Incidence vector.</param>
    /// <param name="n">Normal vector.</param>
    /// <returns>The reflection vector given an incidence vector and a normal vector.</returns>
    public static Vector2f Reflect(Vector2f i, Vector2f n)
    {
      return i - (2.0f * n * DotProduct(n, i));
    }

    /// <summary>
    /// Returns the reflection vector given an incidence vector i and a normal vector n.
    /// The resulting vector is the identical number of components as the two input vectors.
    /// The normal vector n should be normalized. If n is normalized, the output vector
    /// will have the same length as the input incidence vector i.
    /// </summary>
    /// <param name="i">Incidence vector.</param>
    /// <param name="n">Normal vector.</param>
    /// <returns>The reflection vector given an incidence vector and a normal vector.</returns>
    public static Vector3f Reflect(Vector3f i, Vector3f n)
    {
      return i - (2.0f * n * DotProduct(n, i));
    }

    /// <summary>
    /// Returns the reflection vector given an incidence vector i and a normal vector n.
    /// The resulting vector is the identical number of components as the two input vectors.
    /// The normal vector n should be normalized. If n is normalized, the output vector
    /// will have the same length as the input incidence vector i.
    /// </summary>
    /// <param name="i">The incident vector.</param>
    /// <param name="n">The surface normal vector.</param>
    /// <returns>The reflection vector given an incidence vector and a normal vector.</returns>
    public static Vector4f Reflect(Vector4f i, Vector4f n)
    {
      return i - (2.0f * n * DotProduct(n, i));
    }

    /// <summary>
    /// For the incident vector I and surface normal N, and the ratio of indices of
    /// refraction eta, return the refraction vector.
    /// The input parameters for the incident vector I and the surface normal N
    /// must already be normalized to get the desired results.
    /// </summary>
    /// <param name="i">The incident vector</param>
    /// <param name="n">The surface normal vector.</param>
    /// <param name="eta">The ratio of indices of refraction.</param>
    /// <returns>The refraction vector.</returns>
    public static Vector2f Refract(Vector2f i, Vector2f n, float eta)
    {
      float cosi = DotProduct(n, i);
      float cost2 = 1.0f - eta * eta * (1.0f - cosi * cosi);

      if (cost2 < 0)
        return Vector2f.Zero;
      else
        return eta * i - ((eta * cosi + (float)Math.Sqrt(cost2)) * n);
    }

    /// <summary>
    /// For the incident vector I and surface normal N, and the ratio of indices of
    /// refraction eta, return the refraction vector.
    /// The input parameters for the incident vector I and the surface normal N
    /// must already be normalized to get the desired results.
    /// </summary>
    /// <param name="i">The incident vector</param>
    /// <param name="n">The surface normal vector.</param>
    /// <param name="eta">The ratio of indices of refraction.</param>
    /// <returns>The refraction vector.</returns>
    public static Vector3f Refract(Vector3f i, Vector3f n, float eta)
    {
      float cosi = DotProduct(n, i);
      float cost2 = 1.0f - eta * eta * (1.0f - cosi * cosi);

      if (cost2 < 0)
        return Vector3f.Zero;
      else
        return eta * i - ((eta * cosi + (float)Math.Sqrt(cost2)) * n);
    }

    /// <summary>
    /// For the incident vector I and surface normal N, and the ratio of indices of
    /// refraction eta, return the refraction vector.
    /// The input parameters for the incident vector I and the surface normal N
    /// must already be normalized to get the desired results.
    /// </summary>
    /// <param name="i">The incident vector</param>
    /// <param name="n">The surface normal vector.</param>
    /// <param name="eta">The ratio of indices of refraction.</param>
    /// <returns>The refraction vector.</returns>
    public static Vector4f Refract(Vector4f i, Vector4f n, float eta)
    {
      float cosi = DotProduct(n, i);
      float cost2 = 1.0f - eta * eta * (1.0f - cosi * cosi);

      if (cost2 < 0)
        return Vector4f.Zero;
      else
        return eta * i - ((eta * cosi + (float)Math.Sqrt(cost2)) * n);
    }

  }
}
