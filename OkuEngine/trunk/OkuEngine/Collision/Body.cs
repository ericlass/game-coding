using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OkuBase.Geometry;
using OkuEngine.Geometry;
using OkuEngine.Scenes;
using OkuEngine.Actors;

namespace OkuEngine.Collision
{
  /// <summary>
  /// Defines a single bodie in the collision world
  /// </summary>
  public class Body
  {
    private int _groupId = 0;
    private SceneNode _sceneNode = null;

    private Vector2f[] _transBox = new Vector2f[4];
    private Vector2f[] _transShape = null;

    private Vector2f[] _testPoints = new Vector2f[] { Vector2f.Zero, new Vector2f(1.0f, 0.0f) };
    private Vector2f[] _transPoints = new Vector2f[2];

    public Body(SceneNode sceneNode)
    {
      _sceneNode = sceneNode;
    }

    public Body(SceneNode sceneNode, int groupId)
    {
      _sceneNode = sceneNode;
      _groupId = groupId;
    }

    /// <summary>
    /// Gets or sets a group id for the body that is used for coarse
    /// collision filtering. Only bodies with the same group id
    /// can collide.
    /// </summary>
    public int GroupId // Is used to filter collisions event further
    { 
      get { return _groupId; }
      set { _groupId = value; }
    }

    /// <summary>
    /// Gets or sets the current transformation of the body.
    /// </summary>
    public Matrix3 WorldTransform
    {
      get { return _sceneNode.GetWorldMatrix(); }
    }

    /// <summary>
    /// Gets or sets the bounding box of the body.
    /// </summary>
    public Circle BoundingCircle //Mandatory
    {
      get
      {
        BoundingCircleComponent comp = _sceneNode.Actor.GetComponent<BoundingCircleComponent>(BoundingCircleComponent.ComponentName);
        if (comp == null)
          return default(Circle);
        return comp.GetBoundingCircle();
      }
    }

    /// <summary>
    /// Gets or sets the optional shape of the body.
    /// </summary>
    public Vector2f[] Shape //Optional
    {
      get 
      {
        CollisionComponent comp = _sceneNode.Actor.GetComponent<CollisionComponent>(CollisionComponent.ComponentName);
        if (comp == null)
          return null;
        return comp.Shape.Vertices;
      }
    }

    /// <summary>
    /// Gets or sets the user data that is connected to this body.
    /// </summary>
    public SceneNode SceneNode
    {
      get { return _sceneNode; }
    }

    /// <summary>
    /// Calculates the transformed AABB which is the AABB of the box after it got transformed.
    /// </summary>
    /// <returns>The AABB of the transformed AABB.</returns>
    public Circle GetTransformedBoundingCircle()
    {
      WorldTransform.Transform(_testPoints, _transPoints);
      return new Circle(_transPoints[0], BoundingCircle.Radius * Vector2f.Distance(_transPoints[0], _transPoints[1]));
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

        WorldTransform.Transform(Shape, _transShape);
        return _transShape;
      }
      return null;
    }

  }
}
