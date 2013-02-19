using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuEngine.Geometry;

namespace OkuEngine.Collision
{
  /// <summary>
  /// Defines a single bodie in the collision world
  /// </summary>
  /// <typeparam name="T">The type of data to store in the body.</typeparam>
  public class Body<T>
  {
    private int _groupId = 0;
    private Transformation _previousTransform = Transformation.Identity;
    private Transformation _transform = Transformation.Identity;
    private AABB _boundingBox = new AABB();
    private Vector2f[] _shape = null;
    private T _data = default(T);

    private Vector2f[] _transBox = new Vector2f[4];
    private Vector2f[] _transShape = null;

    /// <summary>
    /// Gets or sets a group id for the body that is used for coarse
    /// collision filtering. Only bodies with the same group id
    /// can collide.
    /// </summary>
    public int GroupId // Is used filter collisions event further
    { 
      get { return _groupId; }
      set { _groupId = value; }
    }

    /// <summary>
    /// Gets or sets the current transformation of the body.
    /// </summary>
    public Transformation Transform //Transforms objects space AABB and Shape to world space
    {
      get { return _transform; }
      set { _transform = value; }
    }

    /// <summary>
    /// Gets or sets the previous transformation of the body.
    /// </summary>
    public Transformation PreviousTransform //Transforms objects space AABB and Shape to world space
    {
      get { return _previousTransform; }
      set { _previousTransform = value; }
    }

    /// <summary>
    /// Gets or sets the bounding box of the body.
    /// </summary>
    public AABB BoundingBox //Mandatory
    {
      get { return _boundingBox; }
      set { _boundingBox = value; }
    }

    /// <summary>
    /// Gets or sets the optional shape of the body.
    /// </summary>
    public Vector2f[] Shape //Optional
    {
      get { return _shape; }
      set { _shape = value; }
    }

    /// <summary>
    /// Gets or sets the user data that is connected to this body.
    /// </summary>
    public T Data
    {
      get { return _data; }
      set { _data = value; }
    }

    /// <summary>
    /// Calculates the transformed AABB which is the AABB of the box after it got transformed.
    /// </summary>
    /// <returns>The AABB of the transformed AABB.</returns>
    public AABB GetTransformedBoundingBox()
    {
      BoundingBox.GetPoints(_transBox);
      Transform.AsMatrix().Transform(_transBox);
      return _transBox.GetBoundingBox();
    }

    /// <summary>
    /// Calculates the transformed shape of the body.
    /// </summary>
    /// <returns>The transformed shape of the body.</returns>
    public Vector2f[] GetTransformedShape()
    {
      if (Shape != null)
      {
        if (_transShape == null)
          _transShape = new Vector2f[Shape.Length];

        Transform.AsMatrix().Transform(Shape, _transShape);
        return _transShape;
      }
      return null;
    }

  }
}
