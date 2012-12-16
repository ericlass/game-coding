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
    private string _objectType = null;

    private int _layer = 0;
    private Transformation _transform = new Transformation();

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
      set { _transform = value; }
    }

    /// <summary>
    /// Gets the number of the render pass this scene node belongs to.
    /// </summary>
    public int Layer
    {
      get { return _layer; }
      set { _layer = value; }
    }

    public bool Load(XmlNode node)
    {
      string actorValue = node.GetTagValue("actor");
      string brushValue = node.GetTagValue("brush");

      //Check that actor or brush is given
      if (actorValue == null && brushValue == null)
      {
        OkuManagers.Logger.LogError("Neither actor nor brush given for scene node! " + node.OuterXml);
        return false;
      }

      //Check that not actor AND brush are given
      if (actorValue != null && brushValue != null)
      {
        OkuManagers.Logger.LogError("Both actor and brush given for scene node! This is not allowed. " + node.OuterXml);
        return false;
      }

      //TODO: Load scene objects generically
      //Load actor
      if (actorValue != null)
      {
        _objectType = "actor";
        int test = 0;
        if (int.TryParse(actorValue, out test))
        {
          _objectId = test;
          Actor actor = OkuData.SceneObjects.Get<Actor>(test);
          if (actor == null)
          {
            OkuManagers.Logger.LogError("No actor found with the id " + test + " while loading scene node! Is the initialization order correct?");
            return false;
          }
          _object = actor;
        }
        else
          return false;
      }

      //Load brush
      if (brushValue != null)
      {
        _objectType = "brush";
        int test = 0;
        if (int.TryParse(brushValue, out test))
        {
          _objectId = test;
          Brush brush = OkuData.SceneObjects.Get<Brush>(test);
          if (brush == null)
          {
            OkuManagers.Logger.LogError("No brush found with the id " + test + " while loading scene node! Is the initialization order correct?");
            return false;
          }
          _object = brush;
        }
        else
          return false;
      }

      //Load transform
      XmlNode transNode = node["transform"];
      if (transNode != null)
        _transform.Load(transNode);

      if (_objectId < 0)
      {
        OkuManagers.Logger.LogError("No object specified for scene node!");
        return false;
      }

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteValueTag(_objectType, _objectId.ToString());
      _transform.Save(writer);

      return true;
    }

  }
}
