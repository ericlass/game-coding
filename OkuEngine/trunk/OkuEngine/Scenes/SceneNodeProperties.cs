using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Actors;
using OkuEngine.Collision;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Stores properties of a scene node.
  /// </summary>
  public class SceneNodeProperties : IStoreable
  {
    private int _objectId = 0;
    private SceneObject _object = null;
    private Transformation _previousTransform = new Transformation();
    private Transformation _transform = new Transformation();
    private Body<SceneNode> _body = null;

    /// <summary>
    /// Creates new scene node properties.
    /// </summary>
    internal SceneNodeProperties()
    {
    }

    /// <summary>
    /// Creates properties with the given object id and name.
    /// </summary>
    /// <param name="objectId">The object id.</param>
    /// <param name="name">The name.</param>
    internal SceneNodeProperties(int objectId)
    {
      _objectId = objectId;
    }

    /// <summary>
    /// Gets the scene object for the scene node.
    /// This can be null if the scene node is only used for transformation.
    /// </summary>
    public SceneObject SceneObject
    {
      get { return _object; }
    }

    /// <summary>
    /// Gets or sets the object id associated with the scene node.
    /// </summary>
    public int ObjectId
    {
      get { return _objectId; }
      set { _objectId = value; }
    }

    /// <summary>
    /// Gets or sets the transformation of the scene node.
    /// </summary>
    public Transformation Transform
    {
      get { return _transform; }
      set 
      { 
        _transform = value;
        _body.Transform = value;
      }
    }

    /// <summary>
    /// Gets or sets the previous transformation of the scene node.
    /// </summary>
    public Transformation PreviousTransform
    {
      get { return _previousTransform; }
      set 
      { 
        _previousTransform = value;
        _body.PreviousTransform = value;
      }
    }

    /// <summary>
    /// Gets the collision body that is assigned to the scene node.
    /// </summary>
    public Body<SceneNode> Body
    {
      get { return _body; }
    }

    public bool Load(XmlNode node)
    {
      string objectValue = node.GetTagValue("object");

      // Load scene object, is allowed to be null!
      if (objectValue != null)
      {
        int test = 0;
        if (int.TryParse(objectValue, out test))
        {
          _objectId = test;
          _object = OkuData.SceneObjects[_objectId];
          if (_object == null)
          {
            OkuManagers.Logger.LogError("No scene object found with the id " + test + " while loading scene node! Is the initialization order correct?");
            return false;
          }
        }
        else
          return false;
      }

      //Load transform
      XmlNode transNode = node["transform"];
      if (transNode != null)
        _transform.Load(transNode);

      // Setup some stuff here. The rest is setup in SceneNode.Load() and SceneLayer.Load()
      //TODO: What to do if the scene object does not want any collision?
      _body = new Body<SceneNode>();
      _body.BoundingBox = _object.BoundingBox;
      _body.Transform = _transform;
      _body.PreviousTransform = _previousTransform;
      _body.Shape = _object.Shape;

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteValueTag("object", _objectId.ToString());
      _transform.Save(writer);

      return true;
    }

  }
}
