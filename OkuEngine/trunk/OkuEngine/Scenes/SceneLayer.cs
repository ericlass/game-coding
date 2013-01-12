using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes.Backdrops;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Represents one layer in a scene.
  /// </summary>
  public class SceneLayer : StoreableEntity
  {
    private SceneNode _root = new SceneNode(-1);
    private Dictionary<int, SceneNode> _objectMap = new Dictionary<int, SceneNode>();
    private Backdrop _backdrop = null;

    internal SceneLayer()
    {
    }

    /// <summary>
    /// Create a new layer with the given id and name.
    /// </summary>
    /// <param name="id">The id of the new layer.</param>
    /// <param name="name">The name of the layer.</param>
    internal SceneLayer(int id, string name)
    {
      _id = id;
      _name = name;
    }

    /// <summary>
    /// Gets the backdrop of the layer.
    /// </summary>
    public Backdrop Backdrop
    {
      get { return _backdrop; }
    }

    /// <summary>
    /// Adds the scene object with the given id to the layer below the given parent.
    /// </summary>
    /// <param name="objectId">The id of the scene object.</param>
    /// <param name="parent">The parent of the new node. Null can be given to add it below the root.</param>
    /// <returns>The scene node of the scene object that has just been added.</returns>
    public SceneNode Add(int objectId, SceneNode parent)
    {
      if (!_objectMap.ContainsKey(objectId))
      {
        SceneNode node = new SceneNode(objectId);
        node.Properties.Layer = _id;

        if (parent == null)
          node.SetParent(_root);
        else
          node.SetParent(parent);

        _objectMap.Add(objectId, node);
        return node;
      }
      throw new ArgumentException("Cannot add the same scene object to a layer twice! Scene object Id = " + objectId);
    }

    /// <summary>
    /// Remove the scene node with the given scene object id.
    /// </summary>
    /// <param name="objectId">The scene object id to remove.</param>
    /// <returns>True if the scene object was removed. False if the scene object was not part of the layer.</returns>
    public bool Remove(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
      {
        SceneNode node = _objectMap[objectId];
        node.SetParent(null);
        _objectMap.Remove(objectId);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the node for the scene object id.
    /// </summary>
    /// <param name="objectId">The scene object id to find.</param>
    /// <returns>The scene node for the given scene object id or null if the scene object is not in the layer.</returns>
    public SceneNode GetNode(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
        return _objectMap[objectId];

      return null;
    }

    /// <summary>
    /// Checks if the layer contains the scene object with the given id.
    /// </summary>
    /// <param name="objectId">The scene object id to find.</param>
    /// <returns>True if the scene object with the given id is part of this layer, else false.</returns>
    public bool ContainsObject(int objectId)
    {
      return _objectMap.ContainsKey(objectId);
    }

    /// <summary>
    /// Updates the layer and all scene objects inside it.
    /// </summary>
    /// <param name="scene">The scenen to use.</param>
    /// <param name="dt">The time passed since the last frame in secoonds.</param>
    public void Update(Scene scene, float dt)
    {
      if (_backdrop != null)
        _backdrop.Update(dt);
      _root.Update(scene, dt);
    }

    /// <summary>
    /// Renders the layer and all it's scene objects and nodes.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public void Render(Scene scene)
    {
      if (_backdrop != null)
        _backdrop.Render(scene);

      _root.PreRender(scene);
      _root.Render(scene);
      _root.RenderChildren(scene);
      _root.PostRender(scene);
    }

    /// <summary>
    /// Restores the layer and all its scene objects and nodes.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public void Restore(Scene scene)
    {
      _root.Restore(scene);
    }

    /// <summary>
    /// Moves the given scene object one number to the front in the drawing order of the layer.
    /// </summary>
    /// <param name="objectId">The scene object to move up.</param>
    /// <returns>True if the scene object was moved, else false.</returns>
    public bool MoveOneUp(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
      {
        SceneNode node = _objectMap[objectId];
        List<SceneNode> children = node.Parent.Children;
        int index = children.IndexOf(node);
        if (index < children.Count - 1)
        {
          children[index] = children[index + 1];
          children[index + 1] = node;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Moves the given scene object one number to the back in the drawing order of the layer.
    /// </summary>
    /// <param name="objectId">The scene object to move back.</param>
    /// <returns>True if the scene object was moved, else false.</returns>
    public bool MoveOneDown(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
      {
        SceneNode node = _objectMap[objectId];
        List<SceneNode> children = node.Parent.Children;
        int index = children.IndexOf(node);
        if (index > 0)
        {
          children[index] = children[index - 1];
          children[index - 1] = node;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Moves the given scene object to the front in the drawing order of the layer.
    /// This makes the scene object be drawn last and occlude all other scene objects.
    /// </summary>
    /// <param name="objectId">The scene object to move.</param>
    /// <returns>True if the scene object was moved, else false.</returns>
    public bool MoveToFront(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
      {
        SceneNode node = _objectMap[objectId];
        List<SceneNode> children = node.Parent.Children;
        children.Remove(node);
        children.Add(node);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Moves the given scene object to the back in the drawing order of the layer.
    /// This makes the scene object be drawn first and be occluded by all other scene objects.
    /// </summary>
    /// <param name="objectId">The scene object to move.</param>
    /// <returns>True if the scene object was moved, else false.</returns>
    public bool MoveToBack(int objectId)
    {
      if (_objectMap.ContainsKey(objectId))
      {
        SceneNode node = _objectMap[objectId];
        List<SceneNode> children = node.Parent.Children;
        children.Remove(node);
        children.Insert(0, node);
        return true;
      }
      return false;
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode backdropNode = node["backdrop"];
      //TODO: Load backdrop through factory

      XmlNode child = node["nodes"];
      if (child != null)
      {
        XmlNode nodeNode = child.FirstChild;
        while (nodeNode != null)
        {
          SceneNode sceneNode = new SceneNode();
          if (sceneNode.Load(nodeNode))
          {
            sceneNode.SetParent(_root);

            List<SceneNode> allNodes = new List<SceneNode>();
            allNodes.Add(sceneNode);
            sceneNode.GetAllChildren(allNodes);
            foreach (SceneNode iNode in allNodes)
            {
              sceneNode.Properties.Layer = Id;
              _objectMap.Add(iNode.Properties.ObjectId, iNode);
            }
          }
          else
          {
            OkuManagers.Logger.LogError("Could not load scene node: " + nodeNode.OuterXml);
          }

          nodeNode = nodeNode.NextSibling;
        }
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("layer");
      if (!base.Save(writer))
      {
        writer.WriteEndElement();
        return false;
      }

      //TODO: Save backdrop
      //TODO: Save child nodes

      writer.WriteEndElement();

      return true;
    }

  }
}
