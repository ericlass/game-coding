using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Events;
using Newtonsoft.Json;

namespace OkuEngine.Scenes
{
  /// <summary>
  /// A single scene node in the scene graph.
  /// Defines several virtual methods that can be overriden
  /// by special scene node. If you override one of these methods
  /// make sure to call the base method.
  /// </summary>
  public class SceneNode : IStoreable
  {
    protected SceneNodeProperties _props = null;
    protected SceneNode _parent = null;
    protected List<SceneNode> _children = new List<SceneNode>();

    /// <summary>
    /// Creates a new scene node.
    /// </summary>
    internal SceneNode()
    {
      _props = new SceneNodeProperties();
      _props.Transform.OnChange += new Transformation.OnChangeDelegate(Transform_OnChange);
    }

    /// <summary>
    /// Creates a new scene node with the given paramters.
    /// </summary>
    /// <param name="objectId">The id of the object that is connected to the scene node.</param>
    /// <param name="name">The name of the scene node.</param>
    internal SceneNode(int objectId)
    {
      _props = new SceneNodeProperties(objectId);
      _props.Transform.OnChange += new Transformation.OnChangeDelegate(Transform_OnChange);
    }

    private void Transform_OnChange(Transformation transform)
    {
      OkuManagers.EventManager.QueueEvent(EventTypes.SceneNodeMoved, this);
    }

    /// <summary>
    /// Gets the properties of the scene node.
    /// </summary>
    [JsonPropertyAttribute]
    public SceneNodeProperties Properties
    {
      get { return _props; }
    }

    /// <summary>
    /// Gets or sets the parent node of the node.
    /// Setting automatically removes the node
    /// from the previous parents child nodes
    /// and adds it to the new parents child nodes.
    /// </summary>
    public SceneNode Parent
    {
      get { return _parent; }
    }

    /// <summary>
    /// Gets or sets the list of child nodes.
    /// </summary>
    [JsonPropertyAttribute]
    public List<SceneNode> Children
    {
      get { return _children; }
      set { _children = value; }
    }

    /// <summary>
    /// Sets the parent of the node.
    /// Automatically removes the node
    /// from the previous parents child nodes
    /// and adds it to the new parents child nodes.
    /// </summary>
    /// <param name="parent">The new parent of the node.</param>
    internal void SetParent(SceneNode parent)
    {
      if (_parent != null)
      {
        _parent.RemoveChild(this);
      }
      _parent = parent;
      if (_parent != null)
      {
        _parent.AddChild(this);
      }
    }

    /// <summary>
    /// Adds the given node as a child node of this node.
    /// </summary>
    /// <param name="node">The node to be added as child node.</param>
    /// <returns>True if the node was added as a child, false if it already is a child of the node.</returns>
    public virtual bool AddChild(SceneNode node)
    {
      _children.Add(node);
      return true;
    }

    /// <summary>
    /// Removes the given child node from the node.
    /// </summary>
    /// <param name="node">The child node to be removed.</param>
    /// <returns>True if the child node was removed, false if it was not a child of the node.</returns>
    public virtual bool RemoveChild(SceneNode node)
    {
      return _children.Remove(node);
    }

    /// <summary>
    /// Updates the scene node and all child nodes recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <param name="dt">The time delta since the last frame.</param>
    /// <returns>True if the update was successful, else false.</returns>
    public virtual bool Update(Scene scene, float dt)
    {
      _props.PreviousTransform.Apply(_props.Transform);

      foreach (SceneNode child in _children)
      {
        child.Update(scene, dt);
      }
      return true;
    }

    /// <summary>
    /// Restores the scene node and all child nodes recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the restore was successful, else false.</returns>
    public virtual bool Restore(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.Restore(scene);
      }
      return true;
    }

    /// <summary>
    /// Is called just before th node is rendered so it can set up
    /// rendering parameters.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the process was successful, else false.</returns>
    public virtual bool PreRender(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.PreRender(scene);
      }
      return true;
    }

    /// <summary>
    /// Checks if the scene node is visible through the
    /// current active camera by using the bounding box.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the node is visible, else false.</returns>
    public virtual bool IsVisible(Scene scene)
    {
      if (_props.SceneObject != null)
        return scene.IsVisible(_props.SceneObject.BoundingBox);

      return false;
    }

    /// <summary>
    /// Renders the scene node.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the node was rendered successfully, else false.</returns>
    public virtual bool Render(Scene scene)
    {
      scene.ApplyAndPushTransform(_props.Transform);
      try
      {
        if (_props.SceneObject != null)
          _props.SceneObject.Render(scene);
      }
      finally
      {
        scene.PopTransform();
      }

      return true;
    }

    /// <summary>
    /// Renders all children of the scene node recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the children were rendered, else false.</returns>
    public virtual bool RenderChildren(Scene scene)
    {
      scene.ApplyAndPushTransform(_props.Transform);
      try
      {
        foreach (SceneNode child in _children)
        {
          child.Render(scene);
          child.RenderChildren(scene);
        }
      }
      finally
      {
        scene.PopTransform();
      }
      return true;
    }

    /// <summary>
    /// Is called right after the rendering of the node and it's children.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the process was successfull, else false.</returns>
    public virtual bool PostRender(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        child.PostRender(scene);
      }
      return true;
    }

    /// <summary>
    /// Adds all children of this scene node recursively to the given list.
    /// This does not include the scene node itself.
    /// </summary>
    /// <param name="allChildren">Will contain all child nodes of this node.</param>
    public void GetAllChildren(List<SceneNode> allChildren)
    {
      foreach (SceneNode child in _children)
      {
        allChildren.Add(child);
        child.GetAllChildren(allChildren);
      }
    }

    public bool AfterLoad()
    {
      _props.Body.Data = this;
      return _props.AfterLoad();
    }

  }
}
