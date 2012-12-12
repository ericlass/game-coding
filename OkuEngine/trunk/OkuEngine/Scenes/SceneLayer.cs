using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// Represents one layer in a scene.
  /// </summary>
  public class SceneLayer : StoreableEntity
  {
    private SceneNode _root = new SceneNode(-1);
    private Dictionary<int, SceneNode> _actorMap = new Dictionary<int, SceneNode>();

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
    /// Adds the actor with the given id to the layer below the given parent.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="parent">The parent of the new node. Null can be given to add it below the root.</param>
    /// <returns>The scene node of the actor that has just been added.</returns>
    public SceneNode Add(int actorId, SceneNode parent)
    {
      if (!_actorMap.ContainsKey(actorId))
      {
        SceneNode node = new SceneNode(actorId);
        node.Properties.Layer = _id;

        if (parent == null)
          node.SetParent(_root);
        else
          node.SetParent(parent);

        _actorMap.Add(actorId, node);
        return node;
      }
      throw new ArgumentException("Cannot add the same actor to a layer twice! Actor Id = " + actorId);
    }

    /// <summary>
    /// Remove the scene node with the given actor id.
    /// </summary>
    /// <param name="actorId">The actor id to remove.</param>
    /// <returns>True if the actor was removed. False if the actor was not part of the layer.</returns>
    public bool Remove(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
      {
        SceneNode node = _actorMap[actorId];
        node.SetParent(null);
        _actorMap.Remove(actorId);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the node for the actor id.
    /// </summary>
    /// <param name="actorId">The actor id to find.</param>
    /// <returns>The scene node for the given actor id or null if the actor is not in the layer.</returns>
    public SceneNode GetNode(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
        return _actorMap[actorId];

      return null;
    }

    /// <summary>
    /// Checks if the layer contains the actor with the given id.
    /// </summary>
    /// <param name="actorId">The actor id to find.</param>
    /// <returns>True if the actor with the given id is part of this layer, else false.</returns>
    public bool ContainsActor(int actorId)
    {
      return _actorMap.ContainsKey(actorId);
    }

    /// <summary>
    /// Updates the layer and all actors inside it.
    /// </summary>
    /// <param name="scene">The scenen to use.</param>
    /// <param name="dt">The time passed since the last frame in secoonds.</param>
    public void Update(Scene scene, float dt)
    {
      _root.Update(scene, dt);
    }

    /// <summary>
    /// Renders the layers and all it's actors and nodes.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public void Render(Scene scene)
    {
      _root.PreRender(scene);
      _root.Render(scene);
      _root.RenderChildren(scene);
      _root.PostRender(scene);
    }

    /// <summary>
    /// Restores the layer and all its actors and nodes.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    public void Restore(Scene scene)
    {
      _root.Restore(scene);
    }

    /// <summary>
    /// Moves the given actor one number to the front in the drawing order of the layer.
    /// </summary>
    /// <param name="actorId">The actor to move up.</param>
    /// <returns>True if the actor was moved, else false.</returns>
    public bool MoveOneUp(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
      {
        SceneNode node = _actorMap[actorId];
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
    /// Moves the given actor one number to the back in the drawing order of the layer.
    /// </summary>
    /// <param name="actorId">The actor to move back.</param>
    /// <returns>True if the actor was moved, else false.</returns>
    public bool MoveOneDown(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
      {
        SceneNode node = _actorMap[actorId];
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
    /// Moves the given actor to the front in the drawing order of the layer.
    /// This makes the actor be drawn last and occlude all other actors.
    /// </summary>
    /// <param name="actorId">The actor to move.</param>
    /// <returns>True if the actor was moved, else false.</returns>
    public bool MoveToFront(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
      {
        SceneNode node = _actorMap[actorId];
        List<SceneNode> children = node.Parent.Children;
        children.Remove(node);
        children.Add(node);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Moves the given actor to the back in the drawing order of the layer.
    /// This makes the actor be drawn first and be occluded by all other actors.
    /// </summary>
    /// <param name="actorId">The actor to move.</param>
    /// <returns>True if the actor was moved, else false.</returns>
    public bool MoveToBack(int actorId)
    {
      if (_actorMap.ContainsKey(actorId))
      {
        SceneNode node = _actorMap[actorId];
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
              //TODO: Adapt to new actor/brush concept
              _actorMap.Add(iNode.Properties.ObjectId, iNode);
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
      writer.WriteEndElement();

      return true;
    }

  }
}
