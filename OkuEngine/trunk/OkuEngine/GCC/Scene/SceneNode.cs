using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.GCC.Scene
{
  /// <summary>
  /// A single scene node in the scene graph.
  /// Defines several virtual methods that can be overriden
  /// by special scene node. If you override one of these methods
  /// make sure to call the base method.
  /// </summary>
  public class SceneNode
  {
    protected SceneNode _parent = null;
    protected List<SceneNode> _children = new List<SceneNode>();
    protected SceneNodeProperties _props = new SceneNodeProperties();

    /// <summary>
    /// Creates a new scene node with the given paramters.
    /// </summary>
    /// <param name="actorId">The id of the actor that is connected to the scene node.</param>
    /// <param name="name">The name of the scene node.</param>
    /// <param name="transform">The transformation matrix for the scene node.</param>
    public SceneNode(int actorId, string name, Matrix3 transform)
    {
      _props.ActorId = actorId;
      _props.Name = name;
      _props.ToParent = transform;
    }

    /// <summary>
    /// Gets the properties of the scene node.
    /// </summary>
    public SceneNodeProperties Properties
    {
      get { return _props; }
    }

    /// <summary>
    /// Gets or sets the parent node of the scene node.
    /// </summary>
    public SceneNode Parent
    {
      get { return _parent; }
      set
      {
        if (_parent != null)
        {
          _parent.RemoveChild(this);
        }
        _parent = value;
        if (_parent != null)
        {
          _parent.AddChild(this);
        }
      }
    }

    /// <summary>
    /// Updates the scene node and all child nodes recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <param name="dt">The time delta since the last frame.</param>
    /// <returns>True if the update was successfull, else false.</returns>
    public virtual bool Update(Scene scene, float dt)
    {
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
    /// <returns>True if the restore was successfull, else false.</returns>
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
    /// <returns>True if the process was successfull, else false.</returns>
    public virtual bool PreRender(Scene scene)
    {
      scene.PushAndSetMatrix(_props.ToParent);
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
      return Intersections.AABBs(_props.Area, scene.Camera.Properties.Area);
    }

    /// <summary>
    /// Renders the scene node.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if the node was rendered successfully, else false.</returns>
    public virtual bool Render(Scene scene)
    {
      return true;
    }

    /// <summary>
    /// Renders the children of the scene node recursively.
    /// </summary>
    /// <param name="scene">The scene to use.</param>
    /// <returns>True if all children where renderend successfully, else false.</returns>
    public virtual bool RenderChildren(Scene scene)
    {
      foreach (SceneNode child in _children)
      {
        if (child.PreRender(scene))
        {
          if (child.IsVisible(scene))
          {
            child.Render(scene);
          }
        }
        child.RenderChildren(scene);
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
      scene.PopMatrix();
      return true;
    }

    /// <summary>
    /// Adds the given scene node as a child of the scene node and sets it's parent to this node.
    /// </summary>
    /// <param name="node">The node to add as a child.</param>
    /// <returns>True if the child was added, else false.</returns>
    public virtual bool AddChild(SceneNode node)
    {
      //Cannot restore area when removing child!
      //_props.Area = _props.Area.Add(node.Properties.Area);
      node.Parent = node;
      return true;
    }

    /// <summary>
    /// Remove the given node from the child list and sets it's parent to null.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public virtual bool RemoveChild(SceneNode node)
    {
      node.Parent = null;
      return true;
    }

    /// <summary>
    /// Remove the child with the given actor id and sets it's parent to null.
    /// </summary>
    /// <param name="actorId">The actor id.</param>
    /// <returns>True if the node was removed or false if there is no child node with the given actor id.</returns>
    public virtual bool RemoveChild(int actorId)
    {
      bool result = false;
      for (int i = _children.Count - 1; i >= 0; i--)
      {
        if (_children[i].Properties.ActorId == actorId)
        {
          _children[i].Parent = null;
          result = true;
        }
      }
      return result;
    }

    /// <summary>
    /// Calculates the matrix that transforms the scene node into world space.
    /// </summary>
    /// <returns>The matrix that transform the node into world space.</returns>
    public Matrix3 GetToWorld()
    {
      Matrix3 result = _props.ToParent;
      SceneNode p = _parent;
      while (p != null)
      {
        result = result * p.Properties.ToParent; //TODO: Check if multiplication order is correct!
        p = p.Parent;
      }
      return result;
    }

    /// <summary>
    /// Calculates the matrix that transforms something from world space into object space.
    /// </summary>
    /// <returns>The matrix that transforms something from world space into object space.</returns>
    public Matrix3 GetFromWorld()
    {
      Matrix3 result = _props.FromParent;
      SceneNode p = _parent;
      while (p != null)
      {
        result = p.Properties.FromParent * result; //TODO: Check if multiplication order is correct!
        p = p.Parent;
      }
      return result;
    }

  }
}
